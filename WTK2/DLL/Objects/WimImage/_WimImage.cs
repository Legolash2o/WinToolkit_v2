namespace WinToolkitDLL.Objects.WimImage
{
    /// <summary>
    ///     Parent abstract class of WIM images. Can't be used.
    /// </summary>
    public abstract class _WimImage
    {
        public enum Type
        {
            Mounted,
            WIM,
            None
        }

        protected Architecture _architecture;
        protected string _build;
        protected string _description;
        protected WimImageFlag _flag;
        protected string _image = "/Images/_Global/Blank_16.png";
        protected int _index;
        protected string _mountPath;
        protected string _name;
        protected int _sp;
        protected Type _type = Type.None;
        protected string _wimPath;

        public string WimPath
        {
            get { return _wimPath; }
        }

        public string Build
        {
            get { return _build; }
        }

        public string Description
        {
            get { return _description; }
        }

        public int ServicePack
        {
            get { return _sp; }
        }

        public Architecture Architecture
        {
            get { return _architecture; }
        }

        public WimImageFlag Flag
        {
            get { return _flag; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Image
        {
            get { return _image; }
        }

        public Type ImageType
        {
            get { return _type; }
        }
    }
}