using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Dism;
using Microsoft.Wim;
using Microsoft.Win32;
using WinToolkitDLL.Commands;

namespace WinToolkitDLL.Objects.WimImage
{
    public static class Wim
    {
        public static ObservableCollection<_WimImage> GetMounted()
        {
            var images = new ObservableCollection<_WimImage>();
            var mounted = false;
            var mountReg = "SOFTWARE\\Microsoft\\WIMMount\\Mounted Images\\";
            if (Reg.KeyExist(Registry.LocalMachine, mountReg))
            {
                foreach (var d in DismApi.GetMountedImages())
                {
                    var WI = new WimMountedImage(d);
                    images.Add(WI);
                }
            }
            return images;
        }

        public static ObservableCollection<_WimImage> GetWIM(string filePath)
        {
            //Check registry first then return;


            var images = new ObservableCollection<_WimImage>();
            using (
                var handle = WimgApi.CreateFile(filePath, WimFileAccess.Read, WimCreationDisposition.OpenExisting,
                    WimCreateFileOptions.None, WimCompressionType.None))
            {
                WimgApi.SetTemporaryPath(handle, Environment.GetEnvironmentVariable("TEMP"));
                var result = WimgApi.GetImageInformation(handle);

                var xParent = (XElement) result.FirstNode;
                var xElement = xParent.Element("TOTALBYTES");
                if (xElement == null)
                    throw new Exception("Invalid WIM File.");

                foreach (var xImage in xParent.Elements().Skip(1))
                {
                    var WI = new WimImage(xImage, filePath);
                    images.Add(WI);
                }
            }
            return images;
        }
    }
}