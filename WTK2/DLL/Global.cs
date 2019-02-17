using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitDLL.Objects.WimImage;

namespace WinToolkitDLL
{
    /// <summary>
    ///     Global list collection. For example, a list of all the stored mounted images.
    /// </summary>
    public static class Lists
    {
        /// <summary>
        ///     A list of all the mounted images.
        /// </summary>
        public static List<WimMountedImage> MountedImages = new List<WimMountedImage>();

        public static List<string> selectedImages = new List<string>();
        public static List<string> MessageQueue = new List<string>();

        public static void AddMessage(string msg)
        {
            lock (MessageQueue)
            {
                if (MessageQueue.Count > 20)
                {
                    MessageQueue.RemoveAt(MessageQueue.Count - 1);
                }
                MessageQueue.Insert(0, msg);
            }
        }
    }

    /// <summary>
    ///     Common sizes in bytes.
    /// </summary>
    public static class Sizes
    {
        /// <summary>
        ///     The size of 4GB in bytes.
        /// </summary>
        public const long GB4 = 4294967296;

        /// <summary>
        ///     The size of 32GB in bytes.
        /// </summary>
        public const long GB32 = 34359738368;
    }

    /// <summary>
    ///     All the common reuqired directories used.
    /// </summary>
    public static class Directories
    {
        private const long TEMP_SPACE_REQUIRED = 3000000000; //3GB

        /// <summary>
        ///     The directory of the current application.
        /// </summary>
        public static readonly string Application = Path.GetDirectoryName(Exectuable).Replace("file:\\", "");

        /// <summary>
        ///     C:\Program Files directory
        /// </summary>
        public static readonly string ProgramFiles = Environment.GetEnvironmentVariable("ProgramFiles") + "\\";

        /// <summary>
        ///     C:\Windows\System32 directory.
        /// </summary>
        public static readonly string System32 = Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\";

        /// <summary>
        ///     C:\Windows directory.
        /// </summary>
        public static readonly string Windows = Environment.GetEnvironmentVariable("SystemRoot") + "\\";

        /// <summary>
        ///     C:\ directory
        /// </summary>
        public static readonly string SystemDrive = Environment.GetEnvironmentVariable("SystemDrive") + "\\";

        /// <summary>
        ///     Users desktop directory.
        /// </summary>
        public static readonly string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private static string _tempPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\WinToolkit_Temp\\";
        private static string _errorLogs = Path.GetDirectoryName(Exectuable) + "\\Logs\\";

        /// <summary>
        ///     The full path to the exe file.
        /// </summary>
        public static string Exectuable
        {
            get
            {
                var exePath = Assembly.GetCallingAssembly().GetName().CodeBase;
                exePath = exePath.Replace("file:\\", "");
                exePath = exePath.Replace("file:///", "");
                return exePath;
            }
        }

        /// <summary>
        ///     C:\Program Files (x86) directory
        /// </summary>
        public static string ProgramFilesX86
        {
            get
            {
                var directory = Environment.GetEnvironmentVariable("ProgramFiles") + " (x86)\\";
                if (Directory.Exists(directory))
                {
                    return directory;
                }

                return ProgramFiles;
            }
        }

        /// <summary>
        ///     The directory where error logs are stored.
        /// </summary>
        public static string ErrorLogs
        {
            get
            {
                Directory.CreateDirectory(_errorLogs);
                return _errorLogs;
            }
            set
            {
                var newLogPath = value;
                if (FileHandling.IsReadOnly(newLogPath))
                {
                    throw new ReadOnlyException("Selected folder is read-only.");
                }

                Directory.CreateDirectory(value);
                _errorLogs = value;
            }
        }

        /// <summary>
        ///     The default temp path.
        /// </summary>
        public static string TempPath
        {
            get
            {
                Directory.CreateDirectory(_tempPath);
                return _tempPath;
            }
            set
            {
                var newTempPath = value;

                if (string.IsNullOrWhiteSpace(newTempPath))
                {
                    throw new NullReferenceException("Nothing entered.");
                }

                if (newTempPath.ContainsForeignCharacters())
                {
                    throw new NotSupportedException("Foreign characters detected.");
                }

                if (newTempPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                {
                    throw new NotSupportedException("Invalid characters in path.");
                }

                if (!Directory.Exists(newTempPath))
                {
                    Directory.CreateDirectory(newTempPath);
                }

                if (FileHandling.IsReadOnly(newTempPath))
                {
                    throw new ReadOnlyException("Selected folder is read-only.");
                }

                if (FileHandling.IsNetworkPath(newTempPath))
                {
                    throw new NotSupportedException("Network not supported. Reduces speed too much.");
                }

                var driveInfo = new DriveInfo(newTempPath);
                if (driveInfo.AvailableFreeSpace <= TEMP_SPACE_REQUIRED)
                {
                    throw new IOException("There is not enough space on the disk. [" +
                                          FileHandling.BytesToString(TEMP_SPACE_REQUIRED) + " required.]");
                }

                Directory.CreateDirectory(newTempPath);
                _tempPath = value;
            }
        }
    }
}