using System;

namespace WinToolkitDLL.Objects.Integratables
{
    public sealed class Addon : _Integratable
    {
        public Addon(string filePath)
            : base(filePath)
        {
            _image = "/Images/MainMenu/Addons_16.png";
        }

        public override Status Integrate(string mountPath)
        {
            throw new NotImplementedException();
        }

        public override Status Convert(string outDirectory)
        {
            throw new NotImplementedException();
        }

        public override Status Install()
        {
            throw new NotImplementedException();
        }
    }
}