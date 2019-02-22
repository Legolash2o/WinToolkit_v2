using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Windows;
using Microsoft.Win32;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitDLL.Objects;

namespace WinToolkitDLL
{
    /// <summary>
    ///     Retrieves version information for your application or this DLL file.
    /// </summary>
    public class OS
    {
        /// <summary>
        ///     Returns whether or not the current OS is 64bit.
        /// </summary>
        /// <returns></returns>
        public static Architecture Architecture
        {
            get
            {
                if (Directory.Exists(Directories.Windows + "sysWOW64"))
                {
                    return Architecture.X64;
                }
                return Architecture.X86;
            }
        }

        public static decimal Version
        {
            get
            {
                var osVersion = Reg.GetValue(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion",
                    "CurrentVersion");
                return decimal.Parse(osVersion);
            }
        }

        public static string Build
        {
            get
            {
                return Reg.GetValue(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion",
                    "BuildLabEx");
            }
        }

        public static string Name
        {
            get
            {
                return Reg.GetValue(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion",
                    "ProductName");
            }
        }

        /// <summary>
        ///     Detects whether or no the system has an anti-virus enabled.
        /// </summary>
        /// <returns>True if anti-virus found.</returns>
        public static bool DetectAntivirus()
        {
            if (AntiVirusInstalled("\\root\\SecurityCenter"))
            {
                return true;
            }
            return AntiVirusInstalled("\\root\\SecurityCenter2");
        }

        private static bool AntiVirusInstalled(string root)
        {
            var wmipathstr = @"\\" + Environment.MachineName + root;
            try
            {
                var searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
                var instances = searcher.Get();

                foreach (var item in instances.Cast<ManagementObject>())
                {
                    switch (item["productState"].ToString())
                    {
                        case "266240":
                            return true;
                        case "266256":
                            return true;
                        case "397312":
                            return true;
                        case "397328":
                            return true;
                        case "397584":
                            return true;
                    }
                }
            }
            catch (Exception)
            {
            }

            return false;
        }

        /// <summary>
        ///     Detected the largest drive on the computer.
        /// </summary>
        /// <param name="spaceRequirement">Minimum bytes of free space the drive needs.</param>
        /// <returns></returns>
        public static string DetectLargestDrive(long spaceRequirement)
        {
            return
                DriveInfo.GetDrives()
                    .Where(
                        d =>
                            d.IsReady && d.DriveFormat.EqualsIgnoreCase("NTFS") &&
                            (d.DriveType == DriveType.Fixed || d.DriveType == DriveType.Ram) &&
                            d.TotalFreeSpace >= spaceRequirement)
                    .OrderByDescending(d => d.TotalFreeSpace)
                    .First()
                    .Name;
        }

        public static string GetDefaultBrowser()
        {
            try
            {
                var sBrowserPath =
                    Reg.GetValue(Registry.CurrentUser, "Software\\Classes\\http\\shell\\open\\command", "")
                        .Replace("\"", "");

                if (!sBrowserPath.EndsWithIgnoreCase(".EXE"))
                {
                    sBrowserPath =
                        Reg.GetValue(Registry.CurrentUser,
                            "Software\\Classes\\ActivatableClasses\\Package\\DefaultBrowser_NOPUBLISHERID\\Server\\DefaultBrowserServer",
                            "ExePath").Replace("\"", "");
                }

                if (!sBrowserPath.EndsWithIgnoreCase(".EXE"))
                {
                    sBrowserPath = Reg.GetValue(Registry.ClassesRoot, "http\\shell\\open\\command", "")
                        .Replace("\"", "");
                }

                sBrowserPath = sBrowserPath.Substring(0, sBrowserPath.LastIndexOf(".exe", StringComparison.Ordinal) + 4);
                if (File.Exists(sBrowserPath))
                {
                    return sBrowserPath;
                }
            }
            catch
            {
            }

            return "explorer.exe";
        }

        public static string GetBIOSSerial()
        {
            var mbInfo = string.Empty;
            var mbs = new ManagementObjectSearcher("Select * From Win32_BIOS");
            var moc = mbs.Get();
            var itr = moc.GetEnumerator();

            itr.MoveNext();
            mbInfo = itr.Current.Properties["SerialNumber"].Value.ToString();

            var enumerator = itr.Current.Properties.GetEnumerator();

            if (string.IsNullOrWhiteSpace(mbInfo))
                mbInfo = "0";

            return mbInfo;
        }

        public static BindingList<USBDrive> GetUSBDrives()
        {
            var drives = new BindingList<USBDrive>();


            try
            {
                foreach (
                    ManagementObject drive in
                        new ManagementObjectSearcher("select * from Win32_DiskDrive where InterfaceType='USB'").Get()
                            .AsParallel())
                {
                    try
                    {
                        int Disk = Convert.ToInt16(drive.GetPropertyValue("Index"));
                        var Partition = -1;

                        var DriveLetter = "None";
                        var Label = string.Empty;
                        var FileSystem = string.Empty;
                        var Status = drive.GetPropertyValue("Status").ToString();
                        var Model = drive.GetPropertyValue("Model").ToString();

                        var driveSize = drive.GetPropertyValue("Size");

                        if (driveSize == null)
                            continue;

                        var DriveSize = long.Parse(driveSize.ToString());
                        var Bootable = false;
                        long free = 0;
                        long size = 0;
                        var record = IOCtl.SendIoCtlDiskGetDriveLayoutEx(Disk);
                        var partitionCount = 0;
                        if (Convert.ToInt32(drive.GetPropertyValue("Partitions")) > 0)
                        {
                            foreach (ManagementObject partition in drive.GetRelated("Win32_DiskPartition"))
                            {
                                partitionCount++;
                                Partition = Convert.ToInt16(partition.GetPropertyValue("Index")) + 1;
                                Bootable = Convert.ToBoolean(partition.GetPropertyValue("Bootable").ToString());

                                var LargerThan32GB = false;

                                foreach (ManagementObject logical in partition.GetRelated("Win32_LogicalDisk"))
                                {
                                    DriveLetter = logical.GetPropertyValue("Name").ToString();
                                    try
                                    {
                                        Label = logical.GetPropertyValue("VolumeName").ToString();
                                    }
                                    catch
                                    {
                                    }

                                    try
                                    {
                                        FileSystem = logical.GetPropertyValue("FileSystem").ToString();
                                        free = long.Parse(logical.GetPropertyValue("FreeSpace").ToString());
                                        size = long.Parse(logical.GetPropertyValue("Size").ToString());
                                    }
                                    catch
                                    {
                                        FileSystem = "RAW";
                                        size = long.Parse(drive.GetPropertyValue("Size").ToString());
                                    }
                                }
                            }
                        }
                        else
                        {
                            size = long.Parse(drive.GetPropertyValue("Size").ToString());
                            Label = "None";
                        }


                        if (partitionCount > 1)
                        {
                            record = BootRecord.Hybrid;
                        }
                        var newUSB = new USBDrive(Model, DriveLetter, Disk, Partition, Label, FileSystem, DriveSize,
                            size, free, Bootable, Status, record);
                        drives.Add(newUSB);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
                //cMain.UpdateToolStripLabel(lblStatus, "Error scanning for USB drives ...");
                //cMain.ErrorBox("Win Toolkit encountered an error whilst scanning for USB devices.", "USB Scan Error", Ex.Message);
                //cMain.WriteLog(this, "Error scanning for USB", Ex.Message, lblStatus.Text);
            }

            return drives;
        }

        public static class WinToolkit
        {
          

            /// <summary>
            ///     Retrieves the version of the DLL version
            /// </summary>
            /// <returns></returns>
            public static string DllVersion
            {
                get
                {
                    var iMajor = Assembly.GetExecutingAssembly().GetName().Version.Major;
                    var iMinor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
                    var iBuild = Assembly.GetExecutingAssembly().GetName().Version.Build;
                    var iRevision = Assembly.GetExecutingAssembly().GetName().Version.Revision;

                    return iMajor + "." + iMinor + "." + iBuild + "." + iRevision;
                }
            }

            /// <summary>
            ///     Retrieves the main EXE version number.
            /// </summary>
            /// <returns></returns>
            public static string WinToolkitVersion
            {
                get
                {
                    var iMajor = Assembly.GetCallingAssembly().GetName().Version.Major;
                    var iMinor = Assembly.GetCallingAssembly().GetName().Version.Minor;
                    var iBuild = Assembly.GetCallingAssembly().GetName().Version.Build;
                    var iRevision = Assembly.GetCallingAssembly().GetName().Version.Revision;

                    return iMajor + "." + iMinor + "." + iBuild + "." + iRevision;
                }

            }
        }
    }
}