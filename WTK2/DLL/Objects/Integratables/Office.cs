using System;
using System.Diagnostics;
using System.IO;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;

namespace WinToolkitDLL.Objects.Integratables
{
    public sealed class Office : _Integratable

    {
        public Office(string filePath)
            : base(filePath)
        {
            _image = "/Images/MainMenu/OfficeMSP_32.png";

            var originalDescription = FileVersionInfo.GetVersionInfo(filePath).FileDescription;
            if (originalDescription.ContainsIgnoreCase("64-BIT")) _architecture = Architecture.X64;
            if (originalDescription.ContainsIgnoreCase("-X64-")) _architecture = Architecture.X64;
        }

        public override Status Integrate(string mountPath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Convert office updates into msp files.
        /// </summary>
        /// <param name="outDirectory">The directory where all converted files will go.</param>
        public override Status Convert(string outDirectory)
        {
            Status = Status.Working;

            if (!Directory.Exists(_tempLocation))
            {
                Directory.CreateDirectory(_tempLocation);
            }


            if (FileVersionInfo.GetVersionInfo(Location).OriginalFilename.ContainsIgnoreCase("WEXTRACT"))
            {
                Processes.Open(Location, "/C /T:\"" + _tempLocation + "\" /Q");
            }
            else
            {
                Processes.Open(Location, "/extract:\"" + _tempLocation + "\" /quiet");
            }

            if (MoveFromTemp(outDirectory, "*.msp"))
            {
                return Status.Success;
            }

            return Status.Failed;
        }

        public override Status Install()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Checks to see if the file is a valid Office Update.
        /// </summary>
        /// <param name="filePath">The path of the file. *.exe</param>
        /// <returns>True is an Office update.</returns>
        public static bool ValidOfficeFile(string filePath)
        {
            //Gets the exe file description.
            var fileDescription = FileVersionInfo.GetVersionInfo(filePath).FileDescription;

            //Checks description with known Office descriptions.
            if (fileDescription.ContainsIgnoreCase("Microsoft Filter Pack"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("Word"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("Office"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("Outlook"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("Excel"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("PowerPoint"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("Access"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("OneNote"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("Publisher"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("SharePoint Workspace"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("Visio"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("InfoPath"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("Lync"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("Project"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("SkyDrive Pro"))
            {
                return true;
            }
            if (fileDescription.ContainsIgnoreCase("Microsoft OneDrive"))
            {
                return true;
            }

            //Doesn't match. It's not an Office update.
            return false;
        }
    }
}