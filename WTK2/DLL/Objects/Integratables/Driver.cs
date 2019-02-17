using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Dism;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;

namespace WinToolkitDLL.Objects.Integratables
{
    public sealed class Driver : _Integratable
    {
        public Driver(string filePath)
            : base(filePath)
        {
            _image = "/Images/MainMenu/Driver_16.png";

            var sRead = FileHandling.ReadFile(filePath);

            var is32Bit = Is32Bit(ref sRead);
            var is64Bit = Is64Bit(ref sRead);

            if (is32Bit && is64Bit)
            {
                _architecture = Architecture.Mix;
            }
            else if (is64Bit)
            {
                _architecture = Architecture.X64;
            }

            GetInfo(ref sRead);
            _tooltip = filePath;
        }

        public string Class { get; private set; }
        public string Version { get; private set; }

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
            return DoInstall("-i -a \"" + Location + "\"");
        }

        public Status Add()
        {
            return DoInstall("-a \"" + Location + "\"");
        }

        private Status DoInstall(string argument)
        {
            Status = Status.Working;
            //var result = Processes.Open("pnputil.exe", argument);

            ////http://www.hiteksoftware.com/knowledge/articles/049.htm

            using (var session = DismApi.OpenOnlineSession())
            {
                try
                {
                    DismApi.AddDriver(session, Location, false);
                    return Status.Success;
                }
                catch (Exception Ex)
                {
                    _tooltip = Ex.Message;
                    return Status.Failed;
                }


                //if (!string.IsNullOrWhiteSpace(err))
                //{
                //    MessageBox.Show(err, "Error");
                //    //}
                //    return Status.Failed;
                //}
            }

            //if (result == 0)
            //{
            return Status.Success;
            //}
            /// return Status.Failed;
        }

        private bool Is32Bit(ref string input)
        {
            return input.ContainsIgnoreCase(".X86") ||
                   input.ContainsIgnoreCase("NTX86") ||
                   input.ContainsIgnoreCase("32-BIT") ||
                   input.ContainsIgnoreCase(".NT.") ||
                   input.ContainsIgnoreCase("[INTEL_HDC]") ||
                   input.ContainsIgnoreCase("[INTEL_SYS]") ||
                   input.ContainsIgnoreCase(";32X86") ||
                   input.ContainsIgnoreCase("[MARVELL]") ||
                   input.ContainsIgnoreCase(".X86]");
        }

        private bool Is64Bit(ref string input)
        {
            return input.ContainsIgnoreCase(".AMD64") ||
                   input.ContainsIgnoreCase("NTAMD64") ||
                   input.ContainsIgnoreCase("64-BIT") ||
                   input.ContainsIgnoreCase("NTX64") ||
                   input.ContainsIgnoreCase(".IA64");
        }

        private void GetInfo(ref string input)
        {
            foreach (
                var line in
                    input.Split(Environment.NewLine.ToCharArray())
                        .Where(l => !string.IsNullOrWhiteSpace(l) && !l.StartsWithIgnoreCase(";")))
            {
                var nLine = Regex.Replace(line, @"\s+", "");
                if (nLine.ContainsIgnoreCase("Class="))
                {
                    Class = nLine.Split('=')[1];
                    continue;
                }

                if (nLine.ContainsIgnoreCase("DriverVer="))
                {
                    var date = nLine.Split('=')[1].Split(',')[0];
                    var month = int.Parse(date.Split('/')[0]);
                    var day = int.Parse(date.Split('/')[1]);
                    var year = int.Parse(date.Split('/')[2]);
                    _createdDate = new DateTime(year, month, day);
                    if (nLine.ContainsIgnoreCase(","))
                    {
                        Version = nLine.Split('=')[1].Split(',')[1];
                    }
                    return;
                }
            }
        }
    }
}