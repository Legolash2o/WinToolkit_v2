using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Windows.Data;
using WinToolkitDLL.Extensions;

namespace WinToolkitDLL.Commands
{
    /// <summary>
    ///     Converts bytes to string for use with databinding and correct sorting.
    /// </summary>
    public class ByteToStringConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return FileHandling.BytesToString(System.Convert.ToDouble(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }


    /// <summary>
    ///     Take ownership of files or clear attributes.
    /// </summary>
    public static class FileHandling
    {
        /// <summary>
        ///     Determines whether or not the path specified
        ///     is a directory or a file.
        /// </summary>
        /// <param name="path">The path that needs checking.</param>
        /// <returns>True if directory. False if file.</returns>
        public static bool IsDirectory(string path)
        {
            // get the file attributes for file or directory
            var attr = File.GetAttributes(path);

            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Clear attributes of files or folder. i.e. Remove 'Read-Only' attribute.
        /// </summary>
        /// <param name="fileOrFolder">The file or folder path.</param>
        /// <returns></returns>
        public static bool ClearAttributeFile(string fileOrFolder)
        {
            try
            {
                if (Directory.Exists(fileOrFolder))
                {
                    foreach (var folders in Directory.GetDirectories(fileOrFolder, "*.*", SearchOption.AllDirectories))
                    {
                        File.SetAttributes(folders, FileAttributes.Normal);
                    }
                    foreach (var files in Directory.GetFiles(fileOrFolder, "*", SearchOption.AllDirectories))
                    {
                        File.SetAttributes(files, FileAttributes.Normal);
                    }
                    return true;
                }

                if (File.Exists(fileOrFolder))
                {
                    File.SetAttributes(fileOrFolder, FileAttributes.Normal);
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        /// <summary>
        ///     Takes ownership of a file or folder.
        /// </summary>
        /// <param name="fileOrFolder">The file/folder you wish to take ownership of</param>
        /// <returns></returns>
        public static bool TakeOwnership(string fileOrFolder)
        {
            try
            {
                var sid = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
                var account = (NTAccount) sid.Translate(typeof (NTAccount));

                if (File.Exists(fileOrFolder))
                {
                    var fInfo = new FileInfo(fileOrFolder);

                    var nAccRule = new FileSystemAccessRule(account.Value, FileSystemRights.FullControl,
                        AccessControlType.Allow);

                    var fSecurity = fInfo.GetAccessControl(AccessControlSections.Owner);

                    fSecurity.SetOwner(new NTAccount(account.Value));
                    fInfo.SetAccessControl(fSecurity);
                    fSecurity.AddAccessRule(nAccRule);
                    fInfo.SetAccessControl(fSecurity);
                    return true;
                }

                if (Directory.Exists(fileOrFolder))
                {
                    var dInfo = new DirectoryInfo(fileOrFolder);
                    var fSecurity = dInfo.GetAccessControl(AccessControlSections.All);

                    fSecurity.SetOwner(account);
                    dInfo.SetAccessControl(fSecurity);
                    fSecurity.AddAccessRule(new FileSystemAccessRule(account, FileSystemRights.FullControl,
                        InheritanceFlags.ContainerInherit |
                        InheritanceFlags.ObjectInherit,
                        PropagationFlags.None, AccessControlType.Allow));

                    dInfo.SetAccessControl(fSecurity);
                    return true;
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        /// <summary>
        ///     Delete a specified folder.
        /// </summary>
        /// <param name="directory">The folder you wish to delete.</param>
        /// <param name="reCreate">Recreate the directory again after.</param>
        /// <returns></returns>
        public static bool DeleteDirectory(string directory, bool reCreate = false)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }

            if (reCreate)
            {
                Directory.CreateDirectory(directory);
                return Directory.Exists(directory);
            }
            return !Directory.Exists(directory);
        }

        /// <summary>
        ///     Deleted the specified file.
        /// </summary>
        /// <param name="filePath">The file you want to delete.</param>
        /// <returns></returns>
        public static bool DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
                File.Delete(filePath);
            }

            return !File.Exists(filePath);
        }

        /// <summary>
        ///     Gets the size of the file or folder.
        /// </summary>
        /// <param name="fileOrFolder">The path to the file or folder.</param>
        /// <returns>Returns a long integer size value.</returns>
        public static long GetSize(string fileOrFolder)
        {
            if (Directory.Exists(fileOrFolder))
            {
                return
                    Directory.GetFiles(fileOrFolder, "*", SearchOption.AllDirectories)
                        .Select(F => new FileInfo(F))
                        .Select(fi => fi.Length)
                        .Sum();
            }

            if (File.Exists(fileOrFolder))
            {
                var fileInfo = new FileInfo(fileOrFolder);
                return fileInfo.Length;
            }
            return 0;
        }

        /// <summary>
        ///     Returns the size of the file or folder.
        /// </summary>
        /// <param name="fileOrFolder">The file or folder path.</param>
        /// <param name="appendString">Add KB, MB, GB to the end.</param>
        /// <returns>Returns the size.</returns>
        public static string GetSize(string fileOrFolder, bool appendString)
        {
            return appendString ? BytesToString(GetSize(fileOrFolder)) : GetSize(fileOrFolder).ToString();
        }

        /// <summary>
        ///     Converts a size (bytes) into a more readable size.
        /// </summary>
        /// <param name="size">The size (in bytes)</param>
        /// <returns>Example: xxxxxKB, xxxxMB, xGB, etc..</returns>
        public static string BytesToString(double size)
        {
            if (size < 1024)
            {
                return size.ToString(CultureInfo.InvariantCulture) + " bytes";
            }
            if (size >= 1024 && size < 1048576)
            {
                return (size/1024).ToString("N") + " KB";
            }
            if (size >= 1048576 && size < 1073741824)
            {
                return (size/1024/1024).ToString("N") + " MB";
            }
            if (size >= 1073741824 && size < 1099511627776)
            {
                return (size/1024/1024/1024).ToString("N") + " GB";
            }
            if (size >= 1099511627776)
            {
                return (size/1024/1024/1024/1024).ToString("N") + " TB";
            }

            return size.ToString("N") + " bytes";
        }

        /// <summary>
        ///     Checks to see if a file is in use.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>True if file is in use</returns>
        public static bool FileInUse(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    return !fs.CanWrite;
                }
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        ///     Returns the date the file was created.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>DateTime variable.</returns>
        public static DateTime GetCreationDate(string filePath)
        {
            return new FileInfo(filePath).CreationTime;
        }

        /// <summary>
        ///     Returns the date the file was modified.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>DateTime variable.</returns>
        public static DateTime GetModifiedDate(string filePath)
        {
            return new FileInfo(filePath).LastAccessTimeUtc;
        }

        /// <summary>
        ///     Checks to see if the path is network path.
        /// </summary>
        /// <param name="path">The directory you wish to check.</param>
        /// <returns>True is on network.</returns>
        public static bool IsNetworkPath(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            return directoryInfo.FullName.StartsWithIgnoreCase(string.Empty.PadLeft(2, Path.DirectorySeparatorChar));
        }

        /// <summary>
        ///     Checks to see if the specified directroy is read-only.
        /// </summary>
        /// <param name="directory">The directory that needs checking.</param>
        /// <returns>True if read-only.</returns>
        public static bool IsReadOnly(string directory)
        {
            try
            {
                using (var SW = new StreamWriter(directory + "\\test.0"))
                {
                    SW.WriteLine("test");
                }
                DeleteFile(directory + "\\test.0");
                return false;
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        ///     Determines whether or not a file can be written or
        ///     read. Useful for when other programs are using
        ///     the file.
        /// </summary>
        /// <param name="filePath">The file path which needs testing</param>
        /// <param name="readWrite">Specify if the file needs read or write access.</param>
        /// <returns>True is locked.</returns>
        public static bool IsFileLocked(string filePath, FileAccess readWrite)
        {
            var fs = FileShare.None;
            var fm = FileMode.OpenOrCreate;

            if (readWrite == FileAccess.Read)
            {
                fs = FileShare.Read;
                fm = FileMode.Open;
            }
            try
            {
                using (var fileStream = new FileStream(filePath, fm, readWrite, fs))
                {
                    if (readWrite == FileAccess.Read)
                    {
                        return !fileStream.CanRead;
                    }
                    return !fileStream.CanWrite;
                }
            }
            catch (IOException ex)
            {
                return true;
            }
        }

        /// <summary>
        ///     Checks to see if the directory contains any files.
        /// </summary>
        /// <param name="path">The directory you wish to check.</param>
        /// <returns>True if empty</returns>
        public static bool IsDirectoryEmpty(string path)
        {
            if (!Directory.Exists(path))
            {
                return true;
            }

            try
            {
                var dirInfo = new DirectoryInfo(path);

                if (dirInfo.GetFileSystemInfos().Any(f => f is FileInfo))
                {
                    return false;
                }

                if (
                    dirInfo.GetFileSystemInfos()
                        .Where(f => f is DirectoryInfo)
                        .Cast<DirectoryInfo>()
                        .Any(dir => !IsDirectoryEmpty(dir.FullName)))
                {
                    return false;
                }
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Finds the MD5 value of the file.
        /// </summary>
        /// <param name="filePath">Path of the file.</param>
        /// <param name="ignoreSetting">Gets MD5 regardless of options.</param>
        /// <returns>MD5 Value</returns>
        public static string GetMD5(string filePath, bool ignoreSetting = false)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            if (!Options.GetMD5 && !ignoreSetting)
            {
                return "N/A";
            }

            using (var objMd5 = new MD5CryptoServiceProvider())
            {
                using (Stream objReader = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var arrHash = objMd5.ComputeHash(objReader);
                    objMd5.Clear();
                    return ByteArrayToString(arrHash);
                }
            }
        }

        /// <summary>
        ///     Used for MD5CalcFile method. Converts an array of bytes into the
        ///     normal MD5 values.
        /// </summary>
        /// <param name="arrInput">The array of bytes</param>
        /// <returns>Returns readable MD5 value.</returns>
        private static string ByteArrayToString(ICollection<byte> arrInput)
        {
            if (arrInput == null)
            {
                return null;
            }
            var strOutput = new StringBuilder(arrInput.Count);
            foreach (var b in arrInput)
            {
                strOutput.Append(string.Format("{0:X2}", b));
            }
            return strOutput.ToString().ToUpperInvariant();
        }

        /// <summary>
        ///     Reads a text file (UTF-8 Encoding)
        /// </summary>
        /// <param name="filePath">The location of the file.</param>
        /// <returns>The file contents</returns>
        public static string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath, Encoding.UTF8);
        }

        /// <summary>
        ///     Writes text to a file using UTF-8 encoding.
        /// </summary>
        /// <param name="filePath">The save location.</param>
        /// <param name="textToWrite">The text to write.</param>
        /// <param name="appendFile">Add text onto end of existing file [true/default] or overwrite [false].</param>
        /// <returns>Returns true if successful</returns>
        public static bool WriteFile(string filePath, string textToWrite, bool appendFile = true)
        {
            using (var outStream = new StreamWriter(filePath, appendFile, Encoding.UTF8))
            {
                outStream.WriteLine(textToWrite.TrimEnd('\r', '\n'));
            }
            return true;
        }
    }
}