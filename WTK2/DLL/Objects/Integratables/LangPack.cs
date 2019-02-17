using System;
using System.Diagnostics;
using System.IO;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitDLL.Properties;

namespace WinToolkitDLL.Objects.Integratables
{
    public sealed class LangPack : _Integratable
    {
        public LangPack(string filePath)
            : base(filePath)
        {
            _image = "/Images/MainMenu/LangPack_32.png";

            //Helps determine the architecture and language of the Language Pack.
            var originalName = FileVersionInfo.GetVersionInfo(filePath).OriginalFilename;
            if (originalName.ContainsIgnoreCase("-X64-")) _architecture = Architecture.X64;
            _language = originalName.GetLanguageName();
        }

        public override Status Integrate(string mountPath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Convert language pack exe into cab files.
        /// </summary>
        /// <param name="outDirectory">The directory where all converted files will go.</param>
        public override Status Convert(string outDirectory)
        {
            Status = Status.Working;

            var outPath = outDirectory + "\\" + Language + "-" + _architecture.ToString().ToLowerInvariant() + ".cab";
            if (!File.Exists(outPath))
            {
                Extraction.WriteResource(Resources.exe2cab, Directories.TempPath + "exe2cab.exe");
                Processes.Open("\"" + Directories.TempPath + "\\exe2cab.exe\"",
                    "\"" + Location + "\" \"" + outPath + "\"",
                    true, true,
                    ProcessWindowStyle.Hidden);
            }

            Status = File.Exists(outPath) ? Status.Success : Status.Failed;
            return Status;
        }

        public override Status Install()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Determines if the specified file is a valid
        ///     language pack.
        /// </summary>
        /// <param name="filePath">The exe file that needs testing.</param>
        /// <returns>True if language pack.</returns>
        public static bool IsValidLangPack(string filePath)
        {
            var fileDescription = FileVersionInfo.GetVersionInfo(filePath).FileDescription;

            if (fileDescription.EqualsIgnoreCase("Language Pack Installer"))
            {
                return true;
            }
            return false;
        }
    }
}