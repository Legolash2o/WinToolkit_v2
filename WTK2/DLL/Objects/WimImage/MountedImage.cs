using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Dism;
using Microsoft.Win32;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;

namespace WinToolkitDLL.Objects.WimImage
{
    public class WimMountedImage : _WimImage
    {
        private readonly DismMountStatus _stat;
        protected WimImageStatus _status;

        public WimMountedImage(DismMountedImageInfo info)
        {
            SYSTEM = new SYSTEM(_mountPath);
            SOFTWARE = new SOFTWARE(_mountPath);
            USER = new USER(_mountPath);
            ADMIN = new ADMIN(_mountPath);

            _type = Type.Mounted;
            _index = info.ImageIndex;
            _wimPath = info.ImageFilePath;
            _mountPath = _description = info.MountPath;

            _stat = info.MountStatus;

            GetState();

            if (info.MountStatus == DismMountStatus.NeedsRemount)
            {
                DismApi.RemountImage(_mountPath);
            }
        }

        public WimMountedImage(string mountPath, string wimPath)
        {
            _mountPath = mountPath;
            _wimPath = wimPath;
        }

        public USER USER { get; private set; }
        public ADMIN ADMIN { get; private set; }
        public SOFTWARE SOFTWARE { get; private set; }
        public SYSTEM SYSTEM { get; private set; }

        public WimImageStatus Status
        {
            get { return _status; }
        }

        public string MountPath
        {
            get { return _mountPath; }
        }

        /// <summary>
        ///     Gets the status of the current image.
        /// </summary>
        private void GetState()
        {
            var isImagexRunning = Processes.IsRunning("Imagex");

            var mountReg = "SOFTWARE\\Microsoft\\WIMMount\\Mounted Images\\";
            var status = 0;
            foreach (var RK in Reg.GetAllKeys(Registry.LocalMachine, mountReg))
            {
                if (Reg.GetValue(Registry.LocalMachine, mountReg + RK, "WIM Path").EqualsIgnoreCase(_wimPath))
                {
                    status = int.Parse(Reg.GetValue(Registry.LocalMachine, mountReg + RK, "Status"));
                }
            }

            if (status == 0)
            {
                _status = _stat == DismMountStatus.NeedsRemount ? WimImageStatus.NeedsRemount : WimImageStatus.Ok;
                return;
            }

            if (!isImagexRunning)
            {
                _status = WimImageStatus.Corrupt;
                return;
            }

            switch (status)
            {
                case 1: //Mounting
                    _status = WimImageStatus.Mounting;
                    break;
                case 3: //Unmounting
                    _status = WimImageStatus.Unmounting;
                    break;
                default:
                    _status = WimImageStatus.Ok;
                    break;
            }
        }

        public Task<bool> Discard(ProgressBar pb)
        {
            return Unmount(UnmountChoice.Discard, pb);
        }

        public Task<bool> Save(ProgressBar pb)
        {
            if (_status == WimImageStatus.Ok)
            {
                return Unmount(UnmountChoice.Save, pb);
            }
            return Unmount(UnmountChoice.Discard, pb);
        }

        private async Task<bool> Unmount(UnmountChoice option, ProgressBar pb)
        {
            var save = option == UnmountChoice.Save;
            await
                Task.Factory.StartNew(
                    () =>
                    {
                        DismApi.UnmountImage(_mountPath, save,
                            delegate(DismProgress progress) { pb.SetValue(progress.Current); });
                    });
            if (!Directory.Exists(_mountPath))
                return true;


            //DO STUFF
            return false;
        }

        private enum UnmountChoice
        {
            Discard,
            Save
        }
    }
}