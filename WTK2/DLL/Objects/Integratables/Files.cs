using System;
using System.IO;

namespace WinToolkitDLL.Objects.Integratables
{
    public sealed class Files : _Integratable
    {
        public Files(string filePath, string copyPath)
            : base(filePath)
        {
            CopyPath = copyPath;
            _image = "/Images/MainMenu/Update_16.png";
        }

        public string CopyPath { get; private set; }

        public override Status Integrate(string mountPath)
        {
            return DoWork(mountPath);
        }

        public override Status Convert(string outDirectory)
        {
            throw new NotImplementedException();
        }

        public override Status Install()
        {
            return DoWork("C:\\");
        }

        private Status DoWork(string directory)
        {
            Status = Status.Working;
            var fullCopyTo = directory + "\\" + CopyPath;

            var dir = Path.GetDirectoryName(fullCopyTo);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.Copy(Location, fullCopyTo, true);

            if (File.Exists(fullCopyTo))
            {
                return Status.Success;
            }

            return Status.Failed;
        }
    }
}