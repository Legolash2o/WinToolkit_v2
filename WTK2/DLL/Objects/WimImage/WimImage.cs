using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using Microsoft.Dism;
using WinToolkitDLL.Extensions;

namespace WinToolkitDLL.Objects.WimImage
{
    public class WimImage : _WimImage
    {
        private readonly long _size;
        protected string _displayDescription;
        protected string _displayName;
        private int _progress;

        public WimImage(XElement xml, string wimPath)
        {
            _type = Type.WIM;

            _index = int.Parse(xml.Attribute("INDEX").Value);
            _name = xml.Element("NAME").Value;
            _description = xml.Element("DESCRIPTION").Value;
            _flag = (WimImageFlag) Enum.Parse(typeof (WimImageFlag), xml.Element("FLAGS").Value, true);
            _size = long.Parse(xml.Element("TOTALBYTES").Value);
            var arch = xml.Element("WINDOWS").Element("ARCH").Value;
            if (arch.Equals("9"))
                _architecture = Architecture.X64;

            var major = xml.Element("WINDOWS").Element("VERSION").Element("MAJOR").Value;
            var minor = xml.Element("WINDOWS").Element("VERSION").Element("MINOR").Value;
            var build = xml.Element("WINDOWS").Element("VERSION").Element("BUILD").Value;
            var rev = xml.Element("WINDOWS").Element("VERSION").Element("SPLEVEL").Value;
            _build = major + "." + minor + "." + build + "." + rev;
            _sp = int.Parse(xml.Element("WINDOWS").Element("VERSION").Element("SPLEVEL").Value);

            var xDName = xml.Element("DISPLAYNAME");
            if (xDName != null) _displayName = xDName.Value;

            var xDDesc = xml.Element("DISPLAYDESCRIPTION");
            if (xDDesc != null) _displayDescription = xDDesc.Value;

            _wimPath = wimPath;
        }

        public string Size
        {
            get { return _size.toStringSize(); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public string DisplayDescription
        {
            get { return _displayDescription; }
            set { _displayDescription = value; }
        }

        public async Task<bool> MountImage(string mountPath, ProgressBar pb)
        {
            await Task.Factory.StartNew(() =>
            {
                DismApi.MountImage(_wimPath, mountPath, _index, false, DismMountImageOptions.None,
                    delegate(DismProgress progress) { pb.SetValue(progress.Current); });
            });


            return true;
        }

        public bool RebuildImage()
        {
            return true;
        }
    }
}