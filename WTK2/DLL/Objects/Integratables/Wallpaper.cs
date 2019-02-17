using System;
using System.IO;

namespace WinToolkitDLL.Objects.Integratables
{
    public sealed class Wallpaper : _Integratable
    {
        public Wallpaper(string filePath)
            : base(filePath)
        {
            _image = "/Images/MainMenu/Wallpapers_16.png";
        }

        public override Status Integrate(string mountPath)
        {
            Status = Status.Working;

            var newLocation = mountPath + "\\Windows\\Web\\Wallpaper\\" + Path.GetFileName(Location);
            File.Copy(Location, newLocation, true);

            if (File.Exists(newLocation))
            {
                return Status.Success;
            }

            return Status.Failed;
        }

        public override Status Convert(string outDirectory)
        {
            throw new NotImplementedException();
        }

        public override Status Install()
        {
            Status = Status.Working;

            var newLocation = Directories.Windows + "Web\\Wallpaper\\" + Path.GetFileName(Location);
            File.Copy(Location, newLocation, true);

            if (File.Exists(newLocation))
            {
                return Status.Success;
            }

            return Status.Failed;
        }
    }
}