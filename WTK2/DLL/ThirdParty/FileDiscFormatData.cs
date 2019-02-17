/*
 * Please leave this Copyright notice in your code if you use it
 * Written by Decebal Mihailescu [http://www.codeproject.com/script/articles/list_articles.asp?userid=634640]
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using COMTypes = System.Runtime.InteropServices.ComTypes;


namespace WinToolkitDLL.ThirdParty
{
    /// <summary>
    ///     Creates an optical disk image (aka ISO File)
    /// </summary>
    public sealed class ISOFormatter : IDiscFormat2Data, DiscFormat2Data_Events, IDisposable
    {
        internal const uint STGM_WRITE = 0x00000001;
        internal const uint STGM_CREATE = 0x00001000;
        private IFileSystemImageResult _fsres;

        public ISOFormatter(ImageRepository img)
        {
            _fsres = ((IFileSystemImage) img).CreateResultImage();
        }

        public ISOFormatter(string outputfile)
        {
            OutputFileName = outputfile;
        }

        public ISOFormatter()
        {
        }

        public bool Cancel { get; set; }
        public string OutputFileName { get; set; }

        #region DiscFormat2Data_Events Members

        public event DiscFormat2Data_EventsHandler Update;

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            Monitor.Enter(this);
            try
            {
                if (_fsres != null)
                {
                    Marshal.FinalReleaseComObject(_fsres);
                    _fsres = null;
                }
            }
            catch (SynchronizationLockException)
            {
            }
            finally
            {
                Monitor.Exit(this);
                GC.SuppressFinalize(this);
            }
        }

        #endregion

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        internal static extern uint SHCreateStreamOnFile(string pszFile, uint grfMode, out COMTypes.IStream ppstm);

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "SHCreateStreamOnFileEx"
            )]
        private static extern uint SHCreateStreamOnFileEx(string file, uint grfMode, uint dwAttributes, bool fCreate,
            IntPtr pstmTemplate, out IStream ppstm);

        internal static COMTypes.IStream CreateCOMStreamFromFile(string file)
        {
            COMTypes.IStream newStream;
            var hres = SHCreateStreamOnFile(file, STGM_CREATE | STGM_WRITE, out newStream);
            if (hres != 0 || newStream == null)
                throw new COMException("can't open " + file + " as IStream", unchecked((int) hres));
            return newStream;
        }

        public void CancelOp()
        {
            Cancel = true;
        }

        /// <summary>
        ///     Create the optical disk image.
        /// </summary>
        /// <returns></returns>
        public COMTypes.IStream CreateImageStream(IFileSystemImageResult fsres)
        {
            var ppos = IntPtr.Zero;
            COMTypes.IStream imagestream = null;
            try
            {
                _fsres = fsres;
                imagestream = fsres.ImageStream;
                ppos = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (long)));
                imagestream.Seek(0, 0, ppos);
                if (Marshal.ReadInt64(ppos) != 0)
                    throw new IOException("Can't reset the stream position");

                //IDiscFormat2Data idf = this as IDiscFormat2Data;
                //idf.Write(imagestream);
            }
            catch (Exception exc)
            {
                if (!string.IsNullOrEmpty(OutputFileName))
                    File.Delete(OutputFileName);
                Debug.WriteLine(exc.ToString());
            }
            finally
            {
                if (ppos != IntPtr.Zero)
                    Marshal.FreeHGlobal(ppos);
            }
            return imagestream;
        }

        private void CreateProgressISOFile(COMTypes.IStream imagestream)
        {
            COMTypes.STATSTG stat;

            var bloksize = _fsres.BlockSize;
            long totalblocks = _fsres.TotalBlocks;

#if DEBUG
            var tm = new Stopwatch();
            tm.Start();
#endif
            imagestream.Stat(out stat, 0x01);

            if (stat.cbSize == totalblocks*bloksize)
            {
                var buff = new byte[bloksize];
                var bw = new BinaryWriter(new FileStream(OutputFileName, FileMode.Create));
                var pcbRead = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (uint)));
                var prg = _fsres.ProgressItems;
                var enm = prg.GetEnumerator();
                enm.MoveNext();
                var crtitem = enm.Current as IProgressItem;
                try
                {
                    Marshal.WriteInt32(pcbRead, 0);
                    for (float i = 0; i < totalblocks; i++)
                    {
                        imagestream.Read(buff, bloksize, pcbRead);
                        if (Marshal.ReadInt32(pcbRead) != bloksize)
                        {
                            var err = string.Format(
                                "Failed because Marshal.ReadInt32(pcbRead) = {0} != bloksize = {1}",
                                Marshal.ReadInt32(pcbRead), bloksize);
                            Debug.WriteLine(err);
                            throw new ApplicationException(err);
                        }
                        bw.Write(buff);
                        if (crtitem.LastBlock <= i)
                        {
                            if (enm.MoveNext())
                                crtitem = enm.Current as IProgressItem;
                            if (Cancel)
                                return;
                        }
                        if (Update != null)
                            Update(crtitem, i/totalblocks);

                        if (Cancel)
                            return;
                    }

                    if (Update != null)
                        Update(crtitem, 1);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("Exception in : CreateProgressISOFile {0}", ex.Message));

                    throw;
                }
                finally
                {
                    bw.Flush();
                    bw.Close();
                    Marshal.FreeHGlobal(pcbRead);
#if DEBUG
                    tm.Stop();
                    Debug.WriteLine(string.Format("Time spent in CreateProgressISOFile: {0} ms",
                        tm.Elapsed.TotalMilliseconds.ToString("#,#")));
#endif
                }
            }
            Debug.WriteLine("failed because stat.cbSize({0}) != totalblocks({1}) * bloksize({2}) ", stat.cbSize,
                totalblocks, bloksize);
        }

        internal void CreateISOFile(COMTypes.IStream imagestream)
        {
            if (Cancel)
                return;
            COMTypes.IStream newStream;
            newStream = CreateCOMStreamFromFile(OutputFileName);

            COMTypes.STATSTG stat;
#if DEBUG
            var tm = new Stopwatch();
            tm.Start();
#endif
            imagestream.Stat(out stat, 0x0);

            var inBytes = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (ulong)));
            var outBytes = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (ulong)));

            try
            {
                imagestream.CopyTo(newStream, stat.cbSize, inBytes, outBytes);
                newStream.Commit(0);
            }
            catch (Exception r)
            {
                Debug.WriteLine(r.ToString());
                throw;
            }
            finally
            {
                if (newStream != null)
                    Marshal.FinalReleaseComObject(newStream);
                newStream = null;
                Marshal.FreeHGlobal(inBytes);
                Marshal.FreeHGlobal(outBytes);
#if DEBUG
                tm.Stop();
                Debug.WriteLine(string.Format("Time spent in CreateISOFile: {0} ms",
                    tm.Elapsed.TotalMilliseconds.ToString("#,#")));
#endif
            }
        }

        #region IDiscFormat2Data Members

        bool IDiscFormat2Data.IsRecorderSupported(IDiscRecorder2 Recorder)
        {
            throw new NotImplementedException();
        }

        bool IDiscFormat2Data.IsCurrentMediaSupported(IDiscRecorder2 Recorder)
        {
            throw new NotImplementedException();
        }

        bool IDiscFormat2Data.MediaPhysicallyBlank
        {
            get { throw new NotImplementedException(); }
        }

        bool IDiscFormat2Data.MediaHeuristicallyBlank
        {
            get { throw new NotImplementedException(); }
        }

        object[] IDiscFormat2Data.SupportedMediaTypes
        {
            get { throw new NotImplementedException(); }
        }

        IDiscRecorder2 IDiscFormat2Data.Recorder
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        bool IDiscFormat2Data.BufferUnderrunFreeDisabled
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        bool IDiscFormat2Data.PostgapAlreadyInImage
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        IMAPI_FORMAT2_DATA_MEDIA_STATE IDiscFormat2Data.CurrentMediaStatus
        {
            get { throw new NotImplementedException(); }
        }

        IMAPI_MEDIA_WRITE_PROTECT_STATE IDiscFormat2Data.WriteProtectStatus
        {
            get { throw new NotImplementedException(); }
        }

        int IDiscFormat2Data.TotalSectorsOnMedia
        {
            get { throw new NotImplementedException(); }
        }

        int IDiscFormat2Data.FreeSectorsOnMedia
        {
            get { throw new NotImplementedException(); }
        }

        int IDiscFormat2Data.NextWritableAddress
        {
            get { throw new NotImplementedException(); }
        }

        int IDiscFormat2Data.StartAddressOfPreviousSession
        {
            get { throw new NotImplementedException(); }
        }

        int IDiscFormat2Data.LastWrittenAddressOfPreviousSession
        {
            get { throw new NotImplementedException(); }
        }

        bool IDiscFormat2Data.ForceMediaToBeClosed
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        bool IDiscFormat2Data.DisableConsumerDvdCompatibilityMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        IMAPI_MEDIA_PHYSICAL_TYPE IDiscFormat2Data.CurrentPhysicalMediaType
        {
            get { return IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DISK; }
        }

        string IDiscFormat2Data.ClientName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        int IDiscFormat2Data.RequestedWriteSpeed
        {
            get { throw new NotImplementedException(); }
        }

        bool IDiscFormat2Data.RequestedRotationTypeIsPureCAV
        {
            get { throw new NotImplementedException(); }
        }

        int IDiscFormat2Data.CurrentWriteSpeed
        {
            get { throw new NotImplementedException(); }
        }

        bool IDiscFormat2Data.CurrentRotationTypeIsPureCAV
        {
            get { throw new NotImplementedException(); }
        }

        uint[] IDiscFormat2Data.SupportedWriteSpeeds
        {
            get { throw new NotImplementedException(); }
        }

        Array IDiscFormat2Data.SupportedWriteSpeedDescriptors
        {
            get { throw new NotImplementedException(); }
        }

        bool IDiscFormat2Data.ForceOverwrite
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        Array IDiscFormat2Data.MultisessionInterfaces
        {
            get { throw new NotImplementedException(); }
        }

        void IDiscFormat2Data.Write(COMTypes.IStream data)
        {
            Cancel = false;
            var hasupdate = Update != null && Update.GetInvocationList().Length > 0;
            if (hasupdate)
                CreateProgressISOFile(data);
            else
                CreateISOFile(data);
        }

        void IDiscFormat2Data.CancelWrite()
        {
            throw new NotImplementedException();
        }

        void IDiscFormat2Data.SetWriteSpeed(int RequestedSectorsPerSecond, bool RotationTypeIsPureCAV)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}