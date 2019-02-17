using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Microsoft.Wim
{
    /// <summary>
    ///     Represents a base class for messages sent by the WIMGAPI.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "L")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W")]
    [SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix", MessageId = "T",
        Justification = "W and L correspond to the w and l in the native space")]
    public abstract class WimMessage<W, L>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessage class.
        /// </summary>
        /// <param name="wParam">An IntPtr object from the native callback function.</param>
        /// <param name="lParam">An IntPtr object from the native callback function.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "l")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Param")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w")]
        protected WimMessage(IntPtr wParam, IntPtr lParam)
        {
            // Store the wParam
            //
            this.wParam = wParam;

            // Store the lParam
            //
            this.lParam = lParam;
        }

        /// <summary>
        ///     The lParam object from the native callback function.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "l")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Param")]
        protected IntPtr lParam { get; private set; }

        /// <summary>
        ///     The marshaled value of wParam.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Param")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "param")]
        protected W Param1 { get; set; }

        /// <summary>
        ///     The marshaled value of lParam.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Param")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "param")]
        protected L Param2 { get; set; }

        /// <summary>
        ///     The wParam object from the native callback function.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "w")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Param")]
        protected IntPtr wParam { get; private set; }
    }

    /// <summary>
    ///     Represents a message that enables the caller to align a file resource on a particular alignment boundary.
    /// </summary>
    public sealed class WimMessageAlignment : WimMessage<string, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageAlignment class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageAlignment(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the path
            //
            Param1 = Marshal.PtrToStringUni(wParam);

            // Default align to false
            //
            Param2 = 0;
        }

        /// <summary>
        ///     Gets or sets a value indicating the alignment boundary to be used when storing the file resource.
        /// </summary>
        public int AlignmentBoundary
        {
            get { return Param2; }
            set
            {
                Param2 = value;

                // Write the alignment boundary to the pointer
                //
                Marshal.WriteInt32(lParam, value);
            }
        }

        /// <summary>
        ///     Gets the full path of the file that failed to be captured or applied.
        /// </summary>
        public string Path
        {
            get { return Param1; }
        }
    }

    /// <summary>
    ///     Represents a message that indicates a drive is being scanned during a cleanup operation.
    /// </summary>
    public sealed class WimMessageCleanupScanningDrive : WimMessage<char, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageCleanupScanningDrive class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageCleanupScanningDrive(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the drive letter
            //
            Param1 = (char) wParam;

            // This not used and is always zero
            //
            Param2 = 0;
        }

        /// <summary>
        ///     Gets the driver letter being scanned during a cleanup operation.
        /// </summary>
        public char DriveLetter
        {
            get { return Param1; }
        }
    }

    /// <summary>
    ///     Represents a message that indicates an image is being unmounted as part of the cleanup process.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Unmounting")]
    public sealed class WimMessageCleanupUnmountingImage : WimMessage<string, bool>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageCleanupUnmountingImage class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageCleanupUnmountingImage(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the mount path
            //
            Param1 = Marshal.PtrToStringUni(wParam);

            // This not used and is always zero
            //
            Param2 = (int) lParam != 0;
        }

        /// <summary>
        ///     Gets a boolean value that indicates whether the operation has completed.
        /// </summary>
        public bool IsComplete
        {
            get { return Param2; }
        }

        /// <summary>
        ///     Gets the path of the image being unmounted.
        /// </summary>
        public string MountPath
        {
            get { return Param1; }
        }
    }

    /// <summary>
    ///     Represents a message that enables the caller to prevent a file resource from being compressed during a capture.
    /// </summary>
    public sealed class WimMessageCompress : WimMessage<string, bool>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageCompress class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageCompress(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the path
            //
            Param1 = Marshal.PtrToStringUni(wParam);

            // Default to true
            //
            Param2 = true;
        }

        /// <summary>
        ///     Gets or sets a boolean indicating whether the file should be compressed.
        /// </summary>
        public bool Compress
        {
            get { return Param2; }
            set
            {
                Param2 = value;

                // Write a non-zero integer if the value is true
                //
                Marshal.WriteInt32(lParam, value ? 1 : 0);
            }
        }

        /// <summary>
        ///     Gets the full path of the file to be compressed.
        /// </summary>
        public string Path
        {
            get { return Param1; }
        }
    }

    /// <summary>
    ///     Represents a message to alert the caller that an error occurred while capturing or applying an image.
    /// </summary>
    public sealed class WimMessageError : WimMessage<string, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageError class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageError(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the path
            //
            Param1 = Marshal.PtrToStringUni(wParam);

            // Default to true
            //
            Param2 = (int) lParam;
        }

        /// <summary>
        ///     Gets the full file path of the file that failed to be captured or applied.
        /// </summary>
        public string Path
        {
            get { return Param1; }
        }

        /// <summary>
        ///     Gets the Win32® error code indicating the cause of the failure.
        /// </summary>
        public int Win32ErrorCode
        {
            get { return Param2; }
        }
    }

    /// <summary>
    ///     Represents a message to provide the caller with information about the file being applied during an apply operation.
    /// </summary>
    public sealed class WimMessageFileInfo : WimMessage<string, WimFileInfo>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageFileInfo class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageFileInfo(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the path
            //
            Param1 = Marshal.PtrToStringUni(wParam);

            // See if the last character is the path separator
            //
            if (Param1 != null && Param1[Param1.Length - 1] == System.IO.Path.DirectorySeparatorChar)
            {
                // Remove the last character
                //
                Param1 = Param1.Remove(Param1.Length - 1);
            }

            // Marshal the struct and cast it as a WimFileInfo object
            //
            Param2 = new WimFileInfo(Param1, lParam);
        }

        /// <summary>
        ///     Gets a <see cref="WimFileInfo" /> object containing information about the file being applied.
        /// </summary>
        public WimFileInfo FileInfo
        {
            get { return Param2; }
        }

        /// <summary>
        ///     Gets the full file path of the file or directory to be potentially captured or applied.
        /// </summary>
        public string Path
        {
            get { return Param1; }
        }
    }

    /// <summary>
    ///     Represents a message that indicates an image has been mounted to multiple locations. Only one mount location can
    ///     have changes written back to the .wim file.
    /// </summary>
    public sealed class WimMessageImageAlreadyMounted : WimMessage<string, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageImageAlreadyMounted class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageImageAlreadyMounted(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the path
            //
            Param1 = Marshal.PtrToStringUni(wParam);
        }

        /// <summary>
        ///     Gets the full file path of the existing mounted image.
        /// </summary>
        public string Path
        {
            get { return Param1; }
        }
    }

    /// <summary>
    ///     Represents a message to alert the caller that an error occurred while capturing or applying an image.
    /// </summary>
    public sealed class WimMessageInformation : WimMessage<string, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageInformation class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageInformation(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the path
            //
            Param1 = Marshal.PtrToStringUni(wParam);

            // Default to true
            //
            Param2 = (int) lParam;
        }

        /// <summary>
        ///     Gets the full file path of the file with the failure during the image capture or apply operation.
        /// </summary>
        public string Path
        {
            get { return Param1; }
        }

        /// <summary>
        ///     Gets the Win32® error code indicating the cause of the error.
        /// </summary>
        public int Win32ErrorCode
        {
            get { return Param2; }
        }
    }

    /// <summary>
    ///     Represents a message that indicates progress during an image-cleanup operation.
    /// </summary>
    public sealed class WimMessageMountCleanupProgress : WimMessage<int, TimeSpan>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageMountCleanupProgress class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageMountCleanupProgress(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the percent complete
            //
            Param1 = (int) wParam;

            // Marshal the estimated number of milliseconds until the cleanup operation is complete
            //
            Param2 = TimeSpan.FromMilliseconds((uint) lParam);
        }

        /// <summary>
        ///     Gets a <see cref="TimeSpan" /> containing the estimated amount of time until the cleanup operation is complete.
        /// </summary>
        public TimeSpan EstimatedTimeRemaining
        {
            get { return Param2; }
        }

        /// <summary>
        ///     Gets the percentage of the cleanup that has been completed.
        /// </summary>
        public int PercentComplete
        {
            get { return Param1; }
        }
    }

    /// <summary>
    ///     Represents a message that enables the caller to prevent a file or a directory from being captured or applied.
    /// </summary>
    public sealed class WimMessageProcess : WimMessage<string, bool>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageProcess class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageProcess(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the path
            //
            Param1 = Marshal.PtrToStringUni(wParam);

            // Default to true
            //
            Param2 = true;
        }

        /// <summary>
        ///     Gets the full file path of the file or the directory to be captured or applied.
        /// </summary>
        public string Path
        {
            get { return Param1; }
        }

        /// <summary>
        ///     Gets or sets a boolean indicating whether the file or the directory must be captured or applied.
        /// </summary>
        public bool Process
        {
            get { return Param2; }
            set
            {
                Param2 = value;

                // Write a non-zero integer if the value is true
                //
                Marshal.WriteInt32(lParam, value ? 1 : 0);
            }
        }
    }

    /// <summary>
    ///     Represents a message that indicates an update in the progress of an image application.
    /// </summary>
    public sealed class WimMessageProgress : WimMessage<int, TimeSpan>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageProgress class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageProgress(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the percent complete
            //
            Param1 = (int) wParam;

            // Marshal the ETA
            //
            Param2 = TimeSpan.FromMilliseconds((int) lParam);
        }

        /// <summary>
        ///     Gets a <see cref="TimeSpan" /> object that contains an estimated amount of time until the image application is
        ///     complete.
        /// </summary>
        public TimeSpan EstimatedTimeRemaining
        {
            get { return Param2; }
        }

        /// <summary>
        ///     Gets the percentage of the image that was already applied.
        /// </summary>
        public int PercentComplete
        {
            get { return Param1; }
        }
    }

    /// <summary>
    ///     Represents a message when an I/O error occurs during a <see cref="WimgApi.ApplyImage" /> operation.
    /// </summary>
    public sealed class WimMessageRetry : WimMessage<string, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageRetry class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageRetry(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the path
            //
            Param1 = Marshal.PtrToStringUni(wParam);

            // Marshal the error code
            //
            Param2 = (int) lParam;
        }

        /// <summary>
        ///     Gets the full file path to the file that had the failure during the apply operation.
        /// </summary>
        public string Path
        {
            get { return Param1; }
        }

        /// <summary>
        ///     Gets the Win32® error code indicating the cause of the error.
        /// </summary>
        public int Win32ErrorCode
        {
            get { return Param2; }
        }
    }

    /// <summary>
    ///     Represents a message that indicates volume information is gathered during an image capture.
    /// </summary>
    public sealed class WimMessageScanning : WimMessage<int, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageScanning class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageScanning(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the directory count
            //
            Param1 = (int) wParam;

            // Marshal to file count
            //
            Param2 = (int) lParam;
        }

        /// <summary>
        ///     Gets the number of directories that were scanned.
        /// </summary>
        public int DirectoryCount
        {
            get { return Param1; }
        }

        /// <summary>
        ///     Gets the number of files that were scanned.
        /// </summary>
        public int FileCount
        {
            get { return Param2; }
        }
    }


    /// <summary>
    ///     Represents a message that indicates the number of files that were captured or applied.
    /// </summary>
    public sealed class WimMessageSetPosition : WimMessage<int, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageScanning class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageSetPosition(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Not used, always zero
            //
            Param1 = 0;

            // Marshal to file count
            //
            Param2 = (int) lParam;
        }

        /// <summary>
        ///     Gets the number of files that were captured or applied.
        /// </summary>
        public int FileCount
        {
            get { return Param2; }
        }
    }

    /// <summary>
    ///     Represents a message that indicates the number of files to capture or to apply.
    /// </summary>
    public sealed class WimMessageSetRange : WimMessage<int, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageScanning class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageSetRange(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Not used, always zero
            //
            Param1 = 0;

            // Marshal to file count
            //
            Param2 = (int) lParam;
        }

        /// <summary>
        ///     Gets the number of files to capture or to apply.
        /// </summary>
        public int FileCount
        {
            get { return Param2; }
        }
    }

    /// <summary>
    ///     Represents a message that enables the caller to change the size or the name of a piece of a split Windows® image
    ///     (.wim) file.
    /// </summary>
    public sealed class WimMessageSplit : WimMessage<string, long>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageSplit class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageSplit(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the part path (A pointer to a pointer to a string)
            //
            Param1 = Marshal.PtrToStringUni(Marshal.ReadIntPtr(wParam));

            // Marshal to file count
            //
            Param2 = Marshal.ReadInt64(lParam);
        }

        /// <summary>
        ///     Gets or sets the full file path of the .wim part that is about to be created.
        /// </summary>
        public string PartPath
        {
            get { return Param1; }
            set
            {
                Param1 = value;

                // Free the original buffer
                //
                Marshal.FreeHGlobal(Marshal.ReadIntPtr(wParam));

                // Write the string back to a pointer for the native API
                //
                Marshal.WriteIntPtr(wParam, Marshal.StringToHGlobalUni(value));
            }
        }

        /// <summary>
        ///     Gets or sets a value that specifies the maximum size for the .wim part about to be created.
        /// </summary>
        public long PartSize
        {
            get { return Param2; }
            set
            {
                Param2 = value;

                // Write the value to the pointer
                //
                Marshal.WriteInt64(lParam, value);
            }
        }
    }

    /// <summary>
    ///     Represents a message that indicates to the caller that a stale mount directory is being removed.
    /// </summary>
    public sealed class WimMessageStaleMountDirectory : WimMessage<string, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageStaleMountDirectory class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageStaleMountDirectory(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the path
            //
            Param1 = Marshal.PtrToStringUni(wParam);
        }

        /// <summary>
        ///     Gets the full file path of the stale mount directory.
        /// </summary>
        public string Path
        {
            get { return Param1; }
        }
    }

    /// <summary>
    ///     Represents a message that indicates to the caller how many stale files were removed.
    /// </summary>
    public sealed class WimMessageStaleMountFile : WimMessage<long, char>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageStaleMountFile class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageStaleMountFile(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the files deleted
            //
            Param1 = (long) wParam;

            // Marshal the drive letter
            //
            Param2 = (char) lParam;
        }

        /// <summary>
        ///     Gets a value indicating which drive letter was scanned.
        /// </summary>
        public char DriveLetter
        {
            get { return Param2; }
        }

        /// <summary>
        ///     Gets a value indicating how many stale files were deleted.
        /// </summary>
        public long FilesDeleted
        {
            get { return Param1; }
        }
    }

    /// <summary>
    ///     Represents a message in debug builds with text messages containing status and error information.
    /// </summary>
    /// <remarks>This message is only sent when using the debug version of wimgapi.dll.</remarks>
    public sealed class WimMessageText : WimMessage<int, string>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageText class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageText(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Not used, always zero.
            //
            Param1 = 0;

            // Marshal the text
            //
            Param2 = Marshal.PtrToStringUni(lParam);
        }

        /// <summary>
        ///     Gets the message text.
        /// </summary>
        public string Text
        {
            get { return Param2; }
        }
    }

    /// <summary>
    ///     Represents a message to warn the caller that a non-critical error occurred while capturing or applying an image.
    /// </summary>
    public sealed class WimMessageWarning : WimMessage<string, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageWarning class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageWarning(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the path
            //
            Param1 = Marshal.PtrToStringUni(wParam);

            // Marshal the error code
            //
            Param2 = (int) lParam;
        }

        /// <summary>
        ///     Gets the full file path of the file with the failure during the image capture or apply operation.
        /// </summary>
        public string Path
        {
            get { return Param1; }
        }

        /// <summary>
        ///     Gets the Win32® error code indicating the cause of the error.
        /// </summary>
        public int Win32ErrorCode
        {
            get { return Param2; }
        }
    }

    /// <summary>
    ///     Represents a message to warn the caller that the Object ID for a particular file could not be restored.
    /// </summary>
    public sealed class WimMessageWarningObjectId : WimMessage<string, int>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMessageWarningObjectId class.
        /// </summary>
        /// <param name="wParam">The wParam object from the native callback function.</param>
        /// <param name="lParam">The lParam object from the native callback function.</param>
        internal WimMessageWarningObjectId(IntPtr wParam, IntPtr lParam)
            : base(wParam, lParam)
        {
            // Marshal the path
            //
            Param1 = Marshal.PtrToStringUni(wParam);

            // Marshal the error code
            //
            Param2 = (int) lParam;
        }

        /// <summary>
        ///     Gets the full file path of the file with the failure during the image capture or apply operation.
        /// </summary>
        public string Path
        {
            get { return Param1; }
        }

        /// <summary>
        ///     Gets the Win32® error code indicating the cause of the error.
        /// </summary>
        public int Win32ErrorCode
        {
            get { return Param2; }
        }
    }
}