using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WinToolkit;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitv2.Dialogs;

namespace WinToolkitv2._Code
{
    public static class Exceptions
    {
        public static System.Windows.Application AppContext = null;

        public static void Save(this Exception ex, Priority priority)
        {
            Save(ex, "", priority);
        }

        public static void Save(this Exception ex)
        {
            Save(ex, "", Priority.Normal);
        }

        public static void Save(this Exception ex, string title)
        {
            Save(ex, title, Priority.Normal);
        }

        public static void Upload(this Exception ex, Priority priority)
        {
            Upload(ex, "", priority);
        }

        public static void Upload(this Exception ex, string title)
        {
            Upload(ex, title, Priority.Normal);
        }

        public static void Upload(this Exception ex)
        {
            Upload(ex, "", Priority.Normal);
        }

        public static void Show(this Exception ex)
        {
            Show(ex, "", Priority.Normal);
        }

        public static void Show(this Exception ex, Priority priority)
        {
            Show(ex, "", priority);
        }

        public static void Show(this Exception ex, string title)
        {
            Show(ex, title, Priority.Normal);
        }

        public static void Show(this Exception ex, string title, Priority priority)
        {
            var CE = new CustomException(priority, title, ex);
            CE.Show();
        }

        public static void Save(this Exception ex, string title, Priority priority)
        {
            var CE = new CustomException(priority, title, ex);
            CE.Save();
        }

        public static void Upload(this Exception ex, string title, Priority priority)
        {
            var CE = new CustomException(priority, title, ex);
            CE.Upload();

            //Upload Code here
        }

        public class CustomException
        {
            private const long MAX_ATTACHMENT_SIZE = 10485760; //10MB

            private static XElement XmlResult;
            private static Exception _ex;
            private Priority _priority = Priority.Normal;
            private string _title;
            private DateTime _date;

            private string _bundlePath;

            private List<Bitmap> _screenshots = new List<Bitmap>();
            private List<string> _attachments = new List<string>();
            private long _attachmentSize = 0;

            public CustomException(Priority priority, string title, Exception ex)
            {
                _ex = ex;
                _date = DateTime.Now;
                _title = title;
                _priority = priority;
                AppContext.Dispatcher.Invoke(new Action(() =>
                {
                    GetInfo();
                }));


                Save();
            }

            private async void GetInfo()
            {
                _screenshots = Misc.GetScreenshotWindows();
                await Task.Factory.StartNew(() =>
                {
                    XmlResult = new XElement("Error");
                    XmlResult.SetAttributeValue("Type", _priority);
                    XmlResult.SetAttributeValue("Date", DateTime.UtcNow.ToString("dd MMMM yyyy H:mm:ss"));
                    XmlResult.SetAttributeValue("WTK", OS.WinToolkit.WinToolkitVersion);
                    XmlResult.SetAttributeValue("DLL", OS.WinToolkit.DllVersion);

                    XmlResult.SetAttributeValue("Lang", CultureInfo.CurrentUICulture);
                    XmlResult.SetAttributeValue("Name", Environment.MachineName);


                    if (!string.IsNullOrWhiteSpace(_title))
                    {
                        var xComment = new XComment(_title);
                        XmlResult.Add(xComment);
                    }

                    XmlResult.Add(new XText(_ex.Message));

                    GetExtended();
                    GetOS();
                    GetHardwareInfo();
                    GetOptions();
                    GetStackTrace();
                    GetMessageHistory();
                    GetProcesses();

                });


            }

            public bool Save()
            {
                return Save("Error_" + DateTime.Now.ToString("yy-MM-dd_HHmmss") + ".zip");
            }

            public bool Save(string saveTo)
            {
                string bundleTemp = Directories.TempPath + Misc.RandomString() + "\\";
                FileHandling.DeleteDirectory(bundleTemp, true);

                for (int i = 0; i < Screenshots.Count; i++)
                {
                    Screenshots[i].Save(bundleTemp + "Screenshot" + i + ".png");
                }

                for (int i = 0; i < Attachments.Count; i++)
                {
                    string fileName = Path.GetFileNameWithoutExtension(Attachments[i]);
                    string fileExtension = Path.GetExtension(Attachments[i]);

                    if (File.Exists(fileName + "." + fileExtension))
                    {
                        File.Copy(Attachments[i], bundleTemp + fileName + "_" + i + "." + fileExtension, true);
                    }
                    else
                    {
                        File.Copy(Attachments[i], fileName + "." + fileExtension, true);
                    }

                }

                XML.Save(bundleTemp + "Error.xml");

                FileHandling.DeleteFile(saveTo);
                ZipFile.CreateFromDirectory(bundleTemp, saveTo, CompressionLevel.Optimal, false);

                FileHandling.DeleteDirectory(bundleTemp);

                _bundlePath = saveTo;
                return true;
            }

            public void Show()
            {
                AppContext.Dispatcher.Invoke(new Action(() =>
                {
                    new FrmError(this).ShowDialog();
                }));
               
            }

            public bool Upload()
            {
                throw new NotImplementedException();
            }

            public List<Bitmap> Screenshots
            { get { return _screenshots; } }

            public Priority Priority
            { get { return _priority; } }

            public string Title
            { get { return _title; } }

            public DateTime Date
            { get { return _date; } }

            public Exception Exception
            { get { return _ex; } }

            public string BundlePath
            { get { return _bundlePath; } }

            public XElement XML
            { get { return XmlResult; } }

            public List<string> Attachments
            { get { return _attachments; } }

            public long LimitRemaining
            { get { return MAX_ATTACHMENT_SIZE - _attachmentSize; } }

            public bool AddAttachment(string filePath, bool removeLimit)
            {
                if (!_attachments.Any(f => f.EqualsIgnoreCase(filePath)))
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (!removeLimit && _attachmentSize > MAX_ATTACHMENT_SIZE)
                    {
                        return false;
                    }

                    _attachmentSize += fi.Length;
                    _attachments.Add(filePath);
                }
                return true;
            }

            public void RemoveAttachment(string filePath)
            {
                FileInfo fi = new FileInfo(filePath);
                _attachmentSize -= fi.Length;

                _attachments.Remove(filePath);
            }

            public void AddNote(string text)
            {
                var notes = XmlResult.Element("Notes");
                if (notes == null)
                {
                    notes = new XElement("Notes");
                    XmlResult.Add(notes);
                }
                notes.SetValue(text);
            }

            #region METHODS

            /// <summary>
            ///     Get Operating System information.
            /// </summary>
            private static void GetOS()
            {
                var xOS = new XElement("Software");


                if (OS.Architecture == Architecture.X64)
                {
                    xOS.SetAttributeValue("Arc", "x64");
                }
                else
                {
                    xOS.SetAttributeValue("Arc", "x86");
                }
                xOS.SetAttributeValue("Name", OS.Name);
                xOS.SetAttributeValue("Version", OS.Version);
                xOS.SetAttributeValue("Build", OS.Build);
                xOS.SetElementValue("Directory", Environment.SystemDirectory);
                xOS.SetElementValue("Anti-Virus", OS.DetectAntivirus());
                xOS.SetElementValue("Browser", OS.GetDefaultBrowser());

                foreach (var D in DISM.All)
                {
                    var dFile = new XElement("DISM");
                    dFile.SetAttributeValue("Version", D.Version);
                    dFile.SetAttributeValue("Type", D.Type.ToString());
                    dFile.SetAttributeValue("Location", D.Location);
                    xOS.Add(dFile);
                }


                XmlResult.Add(xOS);
            }

            private static void GetExtended()
            {
                var msg = new XComment(_ex.ToString());
                XmlResult.Add(msg);
            }

            /// <summary>
            ///     Gets the hardware of the local computer.
            /// </summary>
            private static void GetHardwareInfo()
            {
                var HD = new XElement("Hardware");
                GetCPU(HD);
                GetRAM(HD);

                //Display Resolution
                GetDisplay(HD);


                GetHDDs(HD);

                XmlResult.Add(HD);
            }

            private static void GetHDDs(XElement HD)
            {
                var driveList =
                    DriveInfo.GetDrives()
                        .Where(
                            d =>
                                d.DriveType == DriveType.Fixed || d.DriveType == DriveType.Removable ||
                                d.DriveType == DriveType.CDRom)
                        .OrderBy(d => !d.IsReady)
                        .ToArray();
                foreach (var drive in driveList)
                {
                    var hdInfo = new XElement("Drive");
                    hdInfo.SetAttributeValue("Letter", drive.Name);
                    hdInfo.SetAttributeValue("Type", drive.DriveType);
                    if (drive.IsReady)
                    {
                        hdInfo.SetAttributeValue("Used", (drive.TotalSize - drive.AvailableFreeSpace).toStringSize());
                        hdInfo.SetAttributeValue("Free", drive.AvailableFreeSpace.toStringSize());
                        hdInfo.SetAttributeValue("Size", drive.TotalSize.toStringSize());
                        hdInfo.SetAttributeValue("Label", drive.VolumeLabel);

                        //cMain.BytesToString(Drive.AvailableFreeSpace, true) + "  / " + cMain.BytesToString(Drive.TotalSize, true) 
                    }
                    HD.Add(hdInfo);
                }
            }

            private static void GetDisplay(XElement HD)
            {
                foreach (var D in Screen.AllScreens)
                {
                    var dDisplay = new XElement("Display");
                    dDisplay.SetAttributeValue("Width", D.Bounds.Width);
                    dDisplay.SetAttributeValue("Height", D.Bounds.Height);
                    dDisplay.SetAttributeValue("Depth", D.BitsPerPixel);
                    HD.Add(dDisplay);
                }
            }

            private static void GetCPU(XElement HD)
            {
                //Get CPU
                var mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                foreach (ManagementObject mo in mos.Get())
                {
                    var dCPU = new XElement("CPU");
                    dCPU.SetAttributeValue("Name", mo["Name"] + "Mhz");
                    dCPU.SetAttributeValue("Speed", mo["MaxClockSpeed"] + "Mhz");
                    dCPU.SetAttributeValue("Cores", mo["NumberOfLogicalProcessors"]);
                    dCPU.SetAttributeValue("Load", mo["LoadPercentage"] + "%");
                    dCPU.SetAttributeValue("Status", mo["Status"]);
                    HD.Add(dCPU);
                }
            }

            private static void GetRAM(XElement HD)
            {
                //Get RAM
                try
                {
                    var wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                    var searcher = new ManagementObjectSearcher(wql);
                    var results = searcher.Get();

                    foreach (ManagementObject result in results)
                    {
                        var TVM = (Convert.ToInt32(result["TotalVisibleMemorySize"]));
                        var FPM = (Convert.ToInt32(result["FreePhysicalMemory"]));

                        var dRAMP = new XElement("RAM");
                        dRAMP.SetAttributeValue("Used", string.Format("{0:#,##0} MB", (TVM - FPM) / 1024));
                        dRAMP.SetAttributeValue("Free", string.Format("{0:#,##0} MB", FPM / 1024));
                        dRAMP.SetAttributeValue("Total", string.Format("{0:#,##0} MB", TVM / 1024));

                        HD.Add(dRAMP);
                        break;
                    }
                }
                catch
                {
                }
            }


            /// <summary>
            ///     Gets the current running processes.
            /// </summary>
            private static void GetProcesses()
            {
                var xProcs = new XElement("Processes");

                foreach (var p in Process.GetProcesses().OrderBy(pn => pn.ProcessName))
                {
                    try
                    {
                        var xProc = new XElement("Process");
                        xProc.SetAttributeValue("Name", p.ProcessName);

                        var desc = p.MainModule.FileVersionInfo.FileDescription;

                        if (!string.IsNullOrEmpty(desc))
                        {
                            xProc.SetAttributeValue("Desc", desc);
                        }
                        xProc.SetAttributeValue("Desc", desc);
                        xProc.SetAttributeValue("RAM", p.WorkingSet64.toStringSize());

                        xProcs.Add(xProc);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                if (xProcs.HasElements)
                    XmlResult.Add(xProcs);
            }

            /// <summary>
            ///     Gets the current WTK options.
            /// </summary>
            private static void GetOptions()
            {
                var xOptions = new XElement("Options");
                var obj = AppOptions.CurrentOptions.GetType().GetProperties();
                foreach (var p in obj)
                {
                    var name = p.Name;
                    var value = p.GetValue(obj, null);
                    xOptions.SetElementValue(name, value.ToString());
                }
                if (xOptions.HasElements)
                {
                    XmlResult.Add(xOptions);
                }
                // throw new NotImplementedException();
            }

            /// <summary>
            ///     Gets the stack stace to help find the error.
            /// </summary>
            private static void GetStackTrace()
            {
                var stackFrames = new StackTrace();
                if (stackFrames.FrameCount == 0)
                {
                    return;
                }


                var stackTrace = new XElement("StackTrace");


                foreach (var SF in stackFrames.GetFrames().Take(20))
                {
                    var msg = new XElement("Stack", SF.GetMethod().Name);
                    stackTrace.Add(msg);
                }
                XmlResult.Add(stackTrace);
            }


            private static void GetMessageHistory()
            {
                if (Lists.MessageQueue.Count == 0)
                {
                    return;
                }
                lock (Lists.MessageQueue)
                {
                    var msgHistory = new XElement("MessageHistory");
                    var i = 1;

                    foreach (var s in Lists.MessageQueue)
                    {
                        var msg = new XElement("L" + i++);
                        msg.SetAttributeValue("Value", s);
                        msgHistory.Add(msg);
                    }
                    XmlResult.Add(msgHistory);
                }
            }

            #endregion
        }
    }
}