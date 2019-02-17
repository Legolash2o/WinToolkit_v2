using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Properties;
using COMTypes = System.Runtime.InteropServices.ComTypes;

namespace WinToolkitDLL.ThirdParty
{
    public class ISO
    {
        private readonly string _label;
        private readonly string _output;
        private readonly string _path;
        private readonly ImageRepository _repository = new ImageRepository();
        private ISOFormatter formatter;

        public ISO(string path, string output, string label)
        {
            _path = path;
            _output = output;
            _label = label;
        }

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        internal static extern uint SHCreateStreamOnFile
            (string pszFile, uint grfMode, out IStream ppstm);

        //http://www.codeproject.com/Articles/23653/How-to-Create-Optical-File-Images-using-IMAPIv


        public void OnPropertyChanged(string name)
        {
            var handler = ProgressChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler ProgressChanged;

        private void FormattingEvent(object o1, object o2)
        {
            var it = o1 as IProgressItem;
            var i = (int) (Convert.ToSingle(o2)*100);
            OnPropertyChanged(i + "|" + it.Description);
            // this._progBar.Value = 100 + i;
            if (it != null)
                //  this._lblUpdate.Text = string.Format("Formatting {0}", it.Description);
                //if (!_ckWorker.Checked)
                Application.DoEvents();
        }

        public void Cancel()
        {
            _repository.CancelOp();
            formatter.CancelOp();
        }

        private void RepositoryUpdate(object o1, object o2)
        {
            var file = o1 as string;
            var i = Convert.ToInt64(o2);

            var pos = (int) ((double) _repository.ActualSize/_repository.SizeBeforeFormatting*100);
            OnPropertyChanged(pos + "| " + file);
            //_progBar.Value = pos;
            //_lblUpdate.Text = string.Format("Adding {0} size = {1}", file, i);
            //if (!_ckWorker.Checked)
            //    Application.DoEvents();
        }

        public void CreateISO()
        {
            Extraction.WriteResource(Resources.BIOS, Directories.TempPath + "Files\\BIOS.com");
            _repository.BootableImageFile = Directories.TempPath + "Files\\BIOS.com";
            Application.DoEvents();
            OnPropertyChanged("0|Enumerating files...");
            var directory = new DirectoryInfo(_path);
            var files = directory.GetFiles("*", SearchOption.AllDirectories);

            var filtered = files.Select(f => f)
                .Where(f => (f.Attributes & FileAttributes.Directory) != FileAttributes.Directory);

            foreach (var file in filtered)
            {
                _repository.AddNewFile(file.FullName);
            }

            IFileSystemImageResult imageResult = null;

            COMTypes.IStream imagestream = null;
            try
            {
                var ifsi = InitRepository();
                Application.DoEvents();
                ifsi.CaptureDirectory = _path;
                imageResult = ifsi.CreateResultImage();

                if (imageResult == null)
                {
                }

                formatter = new ISOFormatter(_output);


                DiscFormat2Data_Events ev = formatter;
                // if (_ckUseUIReport.Checked)
                ev.Update += FormattingEvent;

                imagestream = formatter.CreateImageStream(imageResult);
                IDiscFormat2Data idf = formatter;

                try
                {
                    idf.Write(imagestream);
                }
                catch (ApplicationException)
                {
                    throw;
                }
                catch (IOException)
                {
                    //WaitForSelection(_output);
                    //if (_backgroundISOWorker.CancellationPending)
                    //    throw;
                    idf.Write(imagestream);
                }
                catch (COMException ex)
                {
                    if (ex.ErrorCode == -2147024864)
                    {
                        //WaitForSelection(_output);
                        //if (_backgroundISOWorker.CancellationPending)
                        //    throw;
                        idf.Write(imagestream);
                    }
                    else
                        throw;
                }
            }
            catch (COMException ex)
            {
                //Console.Beep();
                //if (ex.ErrorCode == -1062555360)
                //{
                //    _lblUpdate.Text = "On UI Thread: Media size could be too small for the amount of data";
                //}
                //else
                //    _lblUpdate.Text = "On UI Thread: " + ex.Message;
                if (ex.ErrorCode != -2147024864 && File.Exists(_output))
                    File.Delete(_output);
            }
            catch (Exception ex)
            {
                //if (!this.IsDisposed)
                //{
                //    if (_repository.Cancel)
                //        _lblUpdate.Text = "Canceled on UI thread";
                //    else
                //    {
                //        Console.Beep();
                //        _lblUpdate.Text = "Failed on UI thread: " + ex.Message;
                //    }
                //}
                if (!(ex is IOException) && File.Exists(_output))
                    File.Delete(_output);
            }
            finally
            {
                if (imagestream != null)
                {
                    Marshal.FinalReleaseComObject(imagestream);
                    imagestream = null;
                }
                if (_repository.Cancel && !string.IsNullOrEmpty(_output))
                    File.Delete(_output);
                //else if (!_ckWorker.Checked)
                //    _lblFileImage.Text = _output;
                //if (!_ckWorker.Checked)
                //    RestoreUI(formatter);
                FileHandling.DeleteFile(Directories.TempPath + "Files\\BIOS.com");
            }
        }

        private IFileSystemImage InitRepository()
        {
            Application.DoEvents();
            IFileSystemImage ifsi = _repository;
            var fstype = FsiFileSystems.FsiFileSystemNone;
            fstype |= FsiFileSystems.FsiFileSystemISO9660;
            fstype |= FsiFileSystems.FsiFileSystemJoliet;
            fstype |= FsiFileSystems.FsiFileSystemUDF;
            ifsi.FileSystemsToCreate = fstype;
            //_repository.BootableImageFile = _bootableImageFile;
            ifsi.ChooseImageDefaultsForMediaType(IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DISK);
            ifsi.VolumeName = _label;

            //this.Stop += _repository.CancelOp;
            try
            {
                //if (_ckUseUIReport.Checked)
                //{
                //if (_ckWorker.Checked)
                //    _repository.Update += new DiscFormat2Data_EventsHandler(AsyncRepositoryUpdate);
                //else
                _repository.Update += RepositoryUpdate;
                //_lblUpdate.Text = string.Format("Calculating size for {0}...", _lblDest.Text);
                //Application.DoEvents();

                try
                {
                    //if (_ckWorker.Checked)
                    //    _progBar.Style = ProgressBarStyle.Marquee;
                    OnPropertyChanged("50|Calculating size...");
                    _repository.CalculateSizeBeforeFormatting();
                }
                finally
                {
                    //if (_ckWorker.Checked)
                    //    _progBar.Style = ProgressBarStyle.Continuous;
                }

                //}
                //else
                //{
                //    if (_ckWorker.Checked)
                //        _progBar.Style = ProgressBarStyle.Marquee;
                //    _lblUpdate.Text = string.Format("Creating {0}...", _lblDest.Text);
                //}
            }
            finally
            {
            }

            return ifsi;
        }
    }
}