using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;

namespace WinToolkit
{
    public static class DISM
    {
        /// <summary>
        ///     Determines if the DISM type is the system default or a custom location.
        /// </summary>
        public enum DismType
        {
            /// <summary>
            ///     DISM from the system32 folder.
            /// </summary>
            Standard,

            /// <summary>
            ///     DISM automatically detected via common paths
            /// </summary>
            System,

            /// <summary>
            ///     A DISM file the user has manually specified.
            /// </summary>
            Custom
        }

        private static readonly Version Win8_0DISM = new Version("6.2");
        private static readonly Version Win8_1DISM = new Version("6.3");
        private static readonly List<DismFile> available = new List<DismFile>();

        /// <summary>
        ///     Lists all DISM paths.
        /// </summary>
        public static List<DismFile> All
        {
            get { return available; }
        }

        /// <summary>
        ///     Returns the latest version found in the list.
        /// </summary>
        public static DismFile Latest
        {
            get { return available.OrderByDescending(v => v.Version).First(); }
        }

        /// <summary>
        ///     Return system, if that is not installed. The
        ///     latest is returned.
        /// </summary>
        public static DismFile Default
        {
            get
            {
                var system = available.FirstOrDefault(d => d.Type == DismType.System);
                if (system != null)
                {
                    return system;
                }
                return Latest;
            }
        }

        /// <summary>
        ///     Searches the computer for all available versions of DISM.
        /// </summary>
        /// <returns>The amount found.</returns>
        public static int Load()
        {
            new DismFile(Directories.System32 + "\\Dism.exe", DismType.System);

            if (!string.IsNullOrWhiteSpace(Options.CustomDismLocation))
            {
                foreach (var dism in Options.CustomDismLocation.Split('|'))
                {
                    new DismFile(dism, DismType.Custom);
                }
            }

            if (OS.Architecture == Architecture.X64)
            {
                new DismFile(Directories.ProgramFiles +
                             "Windows Kits\\8.1\\Assessment and Deployment Kit\\Deployment Tools\\amd64\\DISM\\dism.exe");
                new DismFile(Directories.ProgramFiles +
                             "Windows Kits\\8.0\\Assessment and Deployment Kit\\Deployment Tools\\amd64\\DISM\\dism.exe");
                new DismFile(Directories.ProgramFilesX86 +
                             "Windows Kits\\8.1\\Assessment and Deployment Kit\\Deployment Tools\\amd64\\DISM\\dism.exe");
                new DismFile(Directories.ProgramFilesX86 +
                             "Windows Kits\\8.0\\Assessment and Deployment Kit\\Deployment Tools\\amd64\\DISM\\dism.exe");
                new DismFile(Directories.ProgramFilesX86 +
                         "Windows Kits\\10\\Assessment and Deployment Kit\\Deployment Tools\\amd64\\DISM\\dism.exe");

                new DismFile(Directories.ProgramFiles + "Windows AIK\\Tools\\amd64\\Servicing\\Dism.exe");
            }
            else
            {
                new DismFile(Directories.ProgramFiles +
                             "Windows Kits\\8.1\\Assessment and Deployment Kit\\Deployment Tools\\x86\\DISM\\dism.exe");
                new DismFile(Directories.ProgramFiles +
                             "Windows Kits\\8.0\\Assessment and Deployment Kit\\Deployment Tools\\x86\\DISM\\dism.exe");
                new DismFile(Directories.ProgramFiles +
                          "Windows Kits\\10\\Assessment and Deployment Kit\\Deployment Tools\\x86\\DISM\\dism.exe");

                new DismFile(Directories.ProgramFiles + "Windows AIK\\Tools\\Servicing\\Dism.exe");
                new DismFile(Directories.ProgramFiles + "Windows AIK\\Tools\\x86\\Servicing\\Dism.exe");
                new DismFile(Directories.ProgramFiles + "Win8Dism\\Dism.exe");
            }

            if (available.Count > 0)
            {
                available.Sort((v1, v2) => v1.Version.CompareTo(v2.Version));
                available.Reverse();

                var paths = available.Select(t => Path.GetDirectoryName(t.Location)).ToList();
                Misc.AddEnvironmentPaths(paths);
            }

            return available.Count;
        }

        /// <summary>
        ///     Adds a new DISM location to the main list.
        /// </summary>
        /// <param name="DISMPath">The DISM.exe file path.</param>
        public static void Add(string DISMPath)
        {
            new DismFile(DISMPath, DismType.Custom);
            available.Sort((v1, v2) => v1.Version.CompareTo(v2.Version));
            available.Reverse();
        }

        /// <summary>
        ///     Deletes a DISM location from the main list.
        /// </summary>
        /// <param name="DISMPath">The DISM.exe file path.</param>
        public static void Delete(string DISMPath)
        {
            var f = available.First(d => d.Location.EqualsIgnoreCase(DISMPath));
            if (f == null)
                return;
            available.Remove(f);
        }

        /// <summary>
        ///     A class to hold DISM location information.
        /// </summary>
        public class DismFile
        {
            /// <summary>
            ///     New DISM location information.
            /// </summary>
            /// <param name="location">The file path.</param>
            /// <param name="type">What type of DISM is it.</param>
            public DismFile(string location, DismType type = DismType.Standard)
            {
                if (string.IsNullOrWhiteSpace(location)) return;
                if (!File.Exists(location)) return;
                if (available.Count > 0 && available.Count(d => d.Location.EqualsIgnoreCase(location)) > 0) return;

                Location = location;
                Version = new Version(FileVersionInfo.GetVersionInfo(location).ProductVersion);
                Type = type;

                if (type == DismType.System)
                {
                    available.Insert(0, this);
                }
                else
                {
                    available.Add(this);
                }
            }

            /// <summary>
            ///     The DISM.exe file path.
            /// </summary>
            public string Location { get; private set; }

            /// <summary>
            ///     The DISM file version.
            /// </summary>
            public Version Version { get; private set; }

            /// <summary>
            ///     The type of DISM location.
            /// </summary>
            public DismType Type { get; private set; }
        }
    }
}