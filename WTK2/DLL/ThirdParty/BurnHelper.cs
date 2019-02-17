/*
 * Please leave this Copyright notice in your code if you use it
 * Written by Decebal Mihailescu [http://www.codeproject.com/script/articles/list_articles.asp?userid=634640]
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace WinToolkitDLL.ThirdParty
{
    public class BurnHelper
    {
        private static readonly List<IDiscRecorder2> _recorders;
        private readonly BackgroundWorker _backgroundWorker;
        private Stopwatch _tm = new Stopwatch();

        static BurnHelper()
        {
            var discMaster = new MsftDiscMaster2();
            try
            {
                _recorders = new List<IDiscRecorder2>();
                for (var i = 0; i < discMaster.Count; ++i)
                {
                    IDiscFormat2Data mi = new MsftDiscFormat2Data();
                    try
                    {
                        IDiscRecorder2 rec = new MsftDiscRecorder2();
                        rec.InitializeDiscRecorder(discMaster[i]);

                        //remove the comment for next 2 lines
                        mi.Recorder = rec;
                        if (mi.IsRecorderSupported(rec))
                        {
                            _recorders.Add(rec);
                        }
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                    finally
                    {
                        Marshal.FinalReleaseComObject(mi);
                    }
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(discMaster);
            }
        }

        public BurnHelper(BackgroundWorker backgroundWorker)
        {
            _backgroundWorker = backgroundWorker;
        }

        public static IList<KeyValuePair<IDiscRecorder2, string>> RecordersInfo
        {
            get
            {
                // Show the corresponding disc recorder for each drive

                var list = new List<KeyValuePair<IDiscRecorder2, string>>();
                _recorders.ForEach(delegate(IDiscRecorder2 rec)
                {
                    var descr = string.Format("{0}[{1}] ", rec.VolumePathNames[0], rec.ProductId);
                    list.Add(new KeyValuePair<IDiscRecorder2, string>(rec, descr));
                });
                return list.Count > 0 ? list : null;
            }
        }

        public static List<IMAPI_MEDIA_PHYSICAL_TYPE> SupportedMediaTypes(IDiscRecorder2 rec)
        {
            var mi = new MsftDiscFormat2Data();
            try
            {
                mi.Recorder = rec;
                var lst = new List<IMAPI_MEDIA_PHYSICAL_TYPE>(mi.SupportedMediaTypes.Length);

                foreach (IMAPI_MEDIA_PHYSICAL_TYPE mediaType in mi.SupportedMediaTypes)
                {
                    lst.Add(mediaType);
                }

                return lst;
            }
            finally
            {
                Marshal.FinalReleaseComObject(mi);
            }
        }

        public void FormatMedia(string activeDiscRecorder, string clientName, bool QuickFormat, bool eject)
        {
            MsftDiscFormat2Erase discFormatErase = null;
            MsftDiscRecorder2 discRecorder = null;
            try
            {
                // Create and initialize the IDiscRecorder2
                //
                discRecorder = new MsftDiscRecorder2();

                discRecorder.InitializeDiscRecorder(activeDiscRecorder);
                discRecorder.AcquireExclusiveAccess(true, clientName);
                // discRecorder.DisableMcn();


                //
                // Create the IDiscFormat2Erase and set properties
                ////
                discFormatErase = new MsftDiscFormat2Erase();
                discFormatErase.Recorder = discRecorder;
                discFormatErase.ClientName = clientName;
                discFormatErase.FullErase = !QuickFormat;

                //
                // Setup the Update progress event handler
                //
                discFormatErase.Update += DiscFormaEraseData_Update;

                //
                // Erase the media here
                //

                discFormatErase.EraseMedia();
                if (eject)
                {
                    Thread.Sleep(2000);
                    if (!_backgroundWorker.CancellationPending)
                        discRecorder.EjectMedia();
                }
            }
            finally
            {
                //
                // remove the Update event handler
                //
                if (discFormatErase != null)
                    discFormatErase.Update -= DiscFormaEraseData_Update;
                if (discFormatErase != null)
                    Marshal.FinalReleaseComObject(discFormatErase);
                if (discRecorder != null)
                {
                    //discRecorder.EnableMcn();
                    discRecorder.ReleaseExclusiveAccess();
                    Marshal.FinalReleaseComObject(discRecorder);
                }
            }
        }

        /// <summary>
        ///     Event Handler for the Erase Progress Updates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="elapsedSeconds"></param>
        /// <param name="estimatedTotalSeconds"></param>
        private void DiscFormaEraseData_Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender,
            int elapsedSeconds, int estimatedTotalSeconds)
        {
            if (_backgroundWorker.CancellationPending)
            {
                _backgroundWorker.ReportProgress(100, 0);
                try
                {
                    var discFormatErase = sender as IDiscFormat2Erase;
                    if (discFormatErase != null)
                        Marshal.FinalReleaseComObject(discFormatErase);
                }
                catch
                {
                }
                return;
            }
            //
            // Report back to the UI
            //
            _backgroundWorker.ReportProgress(elapsedSeconds, estimatedTotalSeconds);
        }

        public int WriteStream(System.Runtime.InteropServices.ComTypes.IStream stream, string initburner,
            string clientName, bool forceMediaToBeClosed, int speed, bool eject)
        {
            MsftDiscRecorder2 discRecorder = null;
            MsftDiscFormat2Data discFormat = null;
            var result = -1;
            try
            {
                discRecorder = new MsftDiscRecorder2();
                discRecorder.InitializeDiscRecorder(initburner);
                discFormat = new MsftDiscFormat2Data();
                //remove the comment for next 2 lines
                discFormat.Recorder = discRecorder;
                discRecorder.AcquireExclusiveAccess(true, clientName);
                //rec.DisableMcn();
                //
                // initialize the IDiscFormat2Data
                //

                discFormat.ClientName = clientName;
                discFormat.ForceMediaToBeClosed = forceMediaToBeClosed;

                //
                // add the Update event handler
                //
                discFormat.Update += DiscFormatData_Update;
                //this is how it worked for my burner
                //speed = 0 => minimum speed descriptor in update
                // 0 < speed < minimum speed descriptor => half of minimum speed descriptor in update
                // minimum speed descriptor <= speed < next speed descriptor => minimum speed descriptor in update
                // next speed descriptor <= speed  => next speed descriptorin update
                //discFormat.SetWriteSpeed(2000, true);//?????????????
                discFormat.SetWriteSpeed(speed, true);

                //write the stream
                discFormat.Write(stream);

                if (_backgroundWorker.CancellationPending)
                {
                    return 1;
                }
                if (eject)
                {
                    //wait to flush all the content on the media
                    var state = IMAPI_FORMAT2_DATA_MEDIA_STATE.IMAPI_FORMAT2_DATA_MEDIA_STATE_UNKNOWN;
                    while (state == IMAPI_FORMAT2_DATA_MEDIA_STATE.IMAPI_FORMAT2_DATA_MEDIA_STATE_UNKNOWN &&
                           !_backgroundWorker.CancellationPending)
                    {
                        try
                        {
                            state = discFormat.CurrentMediaStatus;
                        }
                        catch (Exception)
                        {
                            state = IMAPI_FORMAT2_DATA_MEDIA_STATE.IMAPI_FORMAT2_DATA_MEDIA_STATE_UNKNOWN;
                            Thread.Sleep(3000);
                        }
                    }
                    if (!_backgroundWorker.CancellationPending)
                        discRecorder.EjectMedia();
                }
                result = 0;
            }
            finally
            {
                if (_backgroundWorker.CancellationPending)
                    result = 1;
                if (discFormat != null)
                {
                    // remove the Update event handler
                    //
                    discFormat.Update -= DiscFormatData_Update;
                    Marshal.FinalReleaseComObject(discFormat);
                }
                if (discRecorder != null)
                {
                    //discRecorder.EnableMcn();
                    discRecorder.ReleaseExclusiveAccess();
                    Marshal.FinalReleaseComObject(discRecorder);
                }
            }
            return result;
        }

        private void DiscFormatData_Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender,
            [In, MarshalAs(UnmanagedType.IDispatch)] object prog)
        {
            //
            // Check if we've cancelled
            //

            var format2Data = sender as IDiscFormat2Data;
            if (_backgroundWorker.CancellationPending)
            {
                try
                {
                    if (format2Data != null)
                        format2Data.CancelWrite();
                }
                catch
                {
                }

                _backgroundWorker.ReportProgress(100, "User cancelling...");
                return;
            }

            var percentDone = 0;
            try
            {
                var progress = (IDiscFormat2DataEventArgs) prog;

                string strTimeStatus = null; // "Time: " + progress.ElapsedTime + " / " + progress.TotalTime;

                switch (progress.CurrentAction)
                {
                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_VALIDATING_MEDIA:
                        percentDone = 0;
                        strTimeStatus = string.Format("Validating media: {0}%, time left: {1:##}:{2:##}:{3:##}",
                            percentDone, progress.RemainingTime/3600, (progress.RemainingTime/60)%60,
                            progress.RemainingTime%60);
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FORMATTING_MEDIA:
                        percentDone = 0;
                        strTimeStatus = string.Format("Formatting media: {0}%, time left: {1:##}:{2:##}:{3:##}",
                            percentDone, progress.RemainingTime/3600, (progress.RemainingTime/60)%60,
                            progress.RemainingTime%60);

                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_INITIALIZING_HARDWARE:
                        percentDone = 0;
                        strTimeStatus = string.Format("Initializing Hardware: {0}%, time left: {1:##}:{2:##}:{3:##}",
                            percentDone, progress.RemainingTime/3600, (progress.RemainingTime/60)%60,
                            progress.RemainingTime%60);
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_CALIBRATING_POWER:

                        percentDone = 0;
                        strTimeStatus =
                            string.Format("Calibrating Power (OPC): {0}% at {1}KB/s, time left: {2:##}:{3:##}:{4:##}",
                                percentDone, format2Data.CurrentWriteSpeed, progress.RemainingTime/3600,
                                (progress.RemainingTime/60)%60, progress.RemainingTime%60);
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_WRITING_DATA:
                        percentDone = ((progress.LastWrittenLba - progress.StartLba)*100)/progress.SectorCount;
                        if (progress.SectorCount > 0)
                        {
                            strTimeStatus =
                                string.Format("Progress writting: {0}% at {1}KB/s, time left: {2:##}:{3:##}:{4:##}",
                                    percentDone, format2Data.CurrentWriteSpeed, progress.RemainingTime/3600,
                                    (progress.RemainingTime/60)%60, progress.RemainingTime%60);
                        }
                        else
                        {
                            strTimeStatus = string.Format("Progress writting: 0% at {0}KB/s",
                                format2Data.CurrentWriteSpeed);
                            percentDone = 0;
                        }
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FINALIZATION:
                        percentDone = 100;
                        strTimeStatus =
                            string.Format("Finalizing the writing: {0}% at {1}KB/s, time left: {2:##}:{3:##}:{4:##}",
                                percentDone, format2Data.CurrentWriteSpeed, progress.RemainingTime/3600,
                                (progress.RemainingTime/60)%60, progress.RemainingTime%60);
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_COMPLETED:
                        percentDone = 100;
                        strTimeStatus =
                            string.Format("Completed the burn: {0}% at {1}KB/s, time left: {2:##}:{3:##}:{4:##}",
                                percentDone, format2Data.CurrentWriteSpeed, progress.RemainingTime/3600,
                                (progress.RemainingTime/60)%60, progress.RemainingTime%60);
                        break;

                    default:

                        strTimeStatus = "Unknown action: " + progress.CurrentAction;

                        break;
                }
                ;


                //
                // Report back to the UI
                //
                _backgroundWorker.ReportProgress(Convert.ToInt32(percentDone), strTimeStatus);
            }

            catch (Exception e)
            {
                _backgroundWorker.ReportProgress(Convert.ToInt32(percentDone), e.Message);
            }
        }

        public static bool CanWriteMedia(IDiscRecorder2 rec)
        {
            var mi = new MsftDiscFormat2Data();
            try
            {
                mi.Recorder = rec;
                return mi.IsRecorderSupported(rec) && mi.IsCurrentMediaSupported(rec);
            }
            catch
            {
                return false;
            }
            finally
            {
                Marshal.FinalReleaseComObject(mi);
            }
        }

        public static bool IsMediaBlank(IDiscRecorder2 rec)
        {
            var mi = new MsftDiscFormat2Data();
            try
            {
                mi.Recorder = rec;
                return mi.MediaPhysicallyBlank || mi.MediaHeuristicallyBlank;
            }
            catch
            {
                return false;
            }
            finally
            {
                Marshal.FinalReleaseComObject(mi);
            }
        }

        public static IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType(IDiscRecorder2 rec)
        {
            var mi = new MsftDiscFormat2Data();
            try
            {
                mi.Recorder = rec;
                return mi.CurrentPhysicalMediaType;
            }
            catch
            {
                return IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_UNKNOWN;
            }
            finally
            {
                Marshal.FinalReleaseComObject(mi);
            }
        }

        public static string GetMediaStateDescription(IDiscRecorder2 rec)
        {
            StringBuilder sb = null;
            var mi = new MsftDiscFormat2Data();
            try
            {
                mi.Recorder = rec;
                // Get the media status properties for the media to for diagnostic purposes

                sb = new StringBuilder("Media type:");
                for (var i = 1; i <= (int) mi.CurrentMediaStatus; i <<= 1)
                {
                    if ((((int) mi.CurrentMediaStatus) & i) == i)
                    {
                        sb.Append(EnumHelper.GetDescription(((IMAPI_FORMAT2_DATA_MEDIA_STATE) i)));
                        sb.Append('|');
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
            catch
            {
                return "No Media or the selected drive is not a recorder.";
            }
            finally
            {
                Marshal.FinalReleaseComObject(mi);
                sb.Length = 0;
            }
        }

        public static IList<KeyValuePair<IWriteSpeedDescriptor, string>> GetSpeedDescriptors(IDiscRecorder2 rec)
        {
            List<KeyValuePair<IWriteSpeedDescriptor, string>> list = null;
            var mi = new MsftDiscFormat2Data();
            try
            {
                mi.Recorder = rec;
                //uint[] speeds = mi.SupportedWriteSpeeds;
                var spds = mi.SupportedWriteSpeedDescriptors;
                var enm = spds.GetEnumerator();
                list = new List<KeyValuePair<IWriteSpeedDescriptor, string>>(spds.GetLength(0));
                while (enm.MoveNext())
                {
                    var spd = enm.Current as IWriteSpeedDescriptor;
                    if (spd != null)
                        list.Add(new KeyValuePair<IWriteSpeedDescriptor, string>(spd, spd.WriteSpeed.ToString()));
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                Marshal.FinalReleaseComObject(mi);
            }
            return (list.Count > 0) ? list : null;
        }

        public static IList<KeyValuePair<IMAPI_MEDIA_PHYSICAL_TYPE, string>> GetMediaTypes()
        {
            var lst = EnumHelper.EnumToList<IMAPI_MEDIA_PHYSICAL_TYPE>();
            lst.RemoveAt(lst.Count - 1);
            lst.RemoveAt(0);
            return lst;
        }
    }
}