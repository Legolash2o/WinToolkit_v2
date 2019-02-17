using System;

namespace WinToolkitDLL.Objects.Integratables
{
    public sealed class RegFile : _Integratable
    {
        public RegFile(string filePath)
            : base(filePath)
        {
            _image = "/Images/MainMenu/RegistryEditor_16.png";
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