using System;

namespace WinToolkitDLL.Objects.Integratables
{
    public sealed class Gadget : _Integratable
    {
        public Gadget(string filePath)
            : base(filePath)
        {
            _image = "/Images/MainMenu/Gadget_16.png";
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