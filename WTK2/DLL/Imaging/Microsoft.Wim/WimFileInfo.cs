using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Microsoft.Wim
{
    /// <summary>
    ///     Provides properties of files contained in a Windows® image (.wim). This class cannot be inherited.
    /// </summary>
    public sealed class WimFileInfo
    {
        /// <summary>
        ///     Initializes a new instance of the WimFileInfo class.
        /// </summary>
        /// <param name="fullPath">The full path to the file or directory.</param>
        /// <param name="findData">A <see cref="WIN32_FIND_DATA" /> containing information about the file or directory.</param>
        internal WimFileInfo(string fullPath, WIN32_FIND_DATA findData)
        {
            // Save the full name
            //
            FullName = fullPath;

            // Determine the name
            //
            Name = Path.GetFileName(FullName);

            // Copy other data from the WIN32_FIND_DATA struct
            //
            Attributes = findData.dwFileAttributes;
            CreationTimeUtc = findData.ftCreationTime.ToDateTime();
            LastAccessTimeUtc = findData.ftLastAccessTime.ToDateTime();
            LastWriteTimeUtc = findData.ftLastWriteTime.ToDateTime();

            // Determine the file size
            //
            Length = ((long) findData.nFileSizeHigh << 32) | findData.nFileSizeLow;
        }

        /// <summary>
        ///     Initializes a new instance of the WimFileInfo class.
        /// </summary>
        /// <param name="fullPath">The full path to the file or directory.</param>
        /// <param name="findDataPtr">
        ///     A pointer to a <see cref="WIN32_FIND_DATA" /> containing information about the file or
        ///     directory.
        /// </param>
        internal WimFileInfo(string fullPath, IntPtr findDataPtr)
            : this(fullPath, (WIN32_FIND_DATA) Marshal.PtrToStructure(findDataPtr, typeof (WIN32_FIND_DATA)))
        {
        }

        /// <summary>
        ///     Gets the attributes for the current file or directory.
        /// </summary>
        public FileAttributes Attributes { get; private set; }

        /// <summary>
        ///     Gets the creation time of the current file or directory.
        /// </summary>
        public DateTime CreationTime
        {
            get { return CreationTimeUtc.ToLocalTime(); }
        }

        /// <summary>
        ///     Gets the creation time, in coordinated universal time (UTC), of the current file or directory.
        /// </summary>
        public DateTime CreationTimeUtc { get; private set; }

        /// <summary>
        ///     Gets a string representing the directory's full path.
        /// </summary>
        public string DirectoryName
        {
            get { return Path.GetDirectoryName(FullName); }
        }

        /// <summary>
        ///     Gets the string representing the extension part of the file.
        /// </summary>
        public string Extension
        {
            get { return Path.GetExtension(Name); }
        }

        /// <summary>
        ///     Gets the full path of the directory or file.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        ///     Gets the time the current file or directory was last accessed.
        /// </summary>
        public DateTime LastAccessTime
        {
            get { return LastAccessTimeUtc.ToLocalTime(); }
        }

        /// <summary>
        ///     Gets the time, in coordinated universal time (UTC), that the current file or directory was last accessed.
        /// </summary>
        public DateTime LastAccessTimeUtc { get; private set; }

        /// <summary>
        ///     Gets the time the current file or directory was last written to.
        /// </summary>
        public DateTime LastWriteTime
        {
            get { return LastWriteTimeUtc.ToLocalTime(); }
        }

        /// <summary>
        ///     Gets the time, in coordinated universal time (UTC), that the current file or directory was last written to.
        /// </summary>
        public DateTime LastWriteTimeUtc { get; private set; }

        /// <summary>
        ///     Gets the size, in bytes, of the current file.
        /// </summary>
        public long Length { get; private set; }

        /// <summary>
        ///     Gets the name of the file.
        /// </summary>
        public string Name { get; private set; }
    }
}