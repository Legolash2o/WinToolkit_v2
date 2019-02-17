using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Wim
{
    /// <summary>
    ///     Specifies options when applying an image.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    [Flags]
    public enum WimApplyImageOptions : uint
    {
        /// <summary>
        ///     Sends a WIM_MSG_FILEINFO message during the apply operation.
        /// </summary>
        FileInfo = WimgApi.WIM_FLAG_FILEINFO,

        /// <summary>
        ///     Specifies that the image is to be sequentially read for caching or performance purposes.
        /// </summary>
        Index = WimgApi.WIM_FLAG_INDEX,

        /// <summary>
        ///     Applies the image without physically creating directories or files. Useful for obtaining a list of files and
        ///     directories in the image.
        /// </summary>
        NoApply = WimgApi.WIM_FLAG_NO_APPLY,

        /// <summary>
        ///     No options are set.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Disables restoring security information for directories.
        /// </summary>
        DisableDirectoryAcl = WimgApi.WIM_FLAG_NO_DIRACL,

        /// <summary>
        ///     Disables restoring security information for files
        /// </summary>
        DisableFileAcl = WimgApi.WIM_FLAG_NO_FILEACL,

        /// <summary>
        ///     Disables automatic path fixups for junctions and symbolic links.
        /// </summary>
        DisableRPFix = WimgApi.WIM_FLAG_NO_RP_FIX,

        /// <summary>
        ///     Verifies that files match original data.
        /// </summary>
        Verify = WimgApi.WIM_FLAG_VERIFY
    }

    /// <summary>
    ///     Specifies options when capturing an image.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    [Flags]
    public enum WimCaptureImageOptions : uint
    {
        /// <summary>
        ///     Disables capturing security information for directories.
        /// </summary>
        DisableDirectoryAcl = WimgApi.WIM_FLAG_NO_DIRACL,

        /// <summary>
        ///     Disables capturing security information for files.
        /// </summary>
        DisableFileAcl = WimgApi.WIM_FLAG_NO_FILEACL,

        /// <summary>
        ///     Disables automatic path fix-ups for junctions and symbolic links.
        /// </summary>
        DisableRPFix = WimgApi.WIM_FLAG_NO_RP_FIX,

        /// <summary>
        ///     No options are set.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Capture verifies single-instance files byte by byte.
        /// </summary>
        Verify = WimgApi.WIM_FLAG_VERIFY
    }

    /// <summary>
    ///     Specifies options when committing an image.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    [Flags]
    public enum WimCommitImageOptions : uint
    {
        /// <summary>
        ///     Disables capturing security information for directories.
        /// </summary>
        DisableDirectoryAcl = WimgApi.WIM_FLAG_NO_DIRACL,

        /// <summary>
        ///     Disables capturing security information for files.
        /// </summary>
        DisableFileAcl = WimgApi.WIM_FLAG_NO_FILEACL,

        /// <summary>
        ///     Disables automatic path repairs for junctions and symbolic links.
        /// </summary>
        DisableRPFix = WimgApi.WIM_FLAG_NO_RP_FIX,

        /// <summary>
        ///     No options are set.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Capture verifies single-instance files byte by byte.
        /// </summary>
        Verify = WimgApi.WIM_FLAG_VERIFY
    }

    /// <summary>
    ///     Represents the compression mode to be used for a newly created image file.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum WimCompressionType : uint
    {
        /// <summary>
        ///     Capture uses LZMS file compression.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Lzms")] Lzms = 3,

        /// <summary>
        ///     Capture uses LZX file compression.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Lzx")] Lzx = 2,

        /// <summary>
        ///     Capture does not use file compression.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Capture uses XPRESS file compression.
        /// </summary>
        Xpress = 1
    }

    /// <summary>
    ///     Specifies options when copying a file from an image.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    [Flags]
    public enum WimCopyFileOptions : uint
    {
        /// <summary>
        ///     The copy operation fails immediately if the target file already exists.
        /// </summary>
        FailIfExists = 0x00000001,

        /// <summary>
        ///     No options are set.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Automatically retries copy operations in event of failures.
        /// </summary>
        Retry = WimgApi.WIM_COPY_FILE_RETRY
    }

    /// <summary>
    ///     Specifies options when creating a .wim file.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    [Flags]
    public enum WimCreateFileOptions : uint
    {
        /// <summary>
        ///     No options are set.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Opens the .wim file in a mode that enables simultaneous reading and writing.
        /// </summary>
        ShareWrite = WimgApi.WIM_FLAG_SHARE_WRITE,

        /// <summary>
        ///     Generates data integrity information for new files. Verifies and updates existing files.
        /// </summary>
        Verify = WimgApi.WIM_FLAG_VERIFY
    }

    /// <summary>
    ///     Specifies which action to take when creating .wim and the file exists, and which action to take when file does not
    ///     exist.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum WimCreationDisposition : uint
    {
        /// <summary>
        ///     Makes a new image file. If the file exists, the function overwrites the file.
        /// </summary>
        CreateAlways = WimgApi.WIM_CREATE_ALWAYS,

        /// <summary>
        ///     Makes a new image file. If the specified file already exists, the function fails.
        /// </summary>
        CreateNew = WimgApi.WIM_CREATE_NEW,

        /// <summary>
        ///     Opens the image file if it exists. If the file does not exist and the caller requests
        ///     <see cref="WimFileAccess.Write" /> access, the function makes the file.
        /// </summary>
        OpenAlways = WimgApi.WIM_OPEN_ALWAYS,

        /// <summary>
        ///     Opens the image file. If the file does not exist, the function fails.
        /// </summary>
        OpenExisting = WimgApi.WIM_OPEN_EXISTING
    }

    /// <summary>
    ///     Represents the result of creating an image.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum WimCreationResult : uint
    {
        /// <summary>
        ///     The file did not exist and was created.
        /// </summary>
        CreatedNew = 0,

        /// <summary>
        ///     The file existed and was opened for access.
        /// </summary>
        OpenedExisting = 1
    }

    /// <summary>
    ///     Specifies options when exporting an image.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    [Flags]
    public enum WimExportImageOptions : uint
    {
        /// <summary>
        ///     The image will be exported to the destination .wim file even if it is already stored in that .wim file.
        /// </summary>
        AllowDuplicates = WimgApi.WIM_EXPORT_ALLOW_DUPLICATES,

        /// <summary>
        ///     Image resources and XML information are exported to the destination .wim file and no supporting file resources are
        ///     included.
        /// </summary>
        MetadataOnly = WimgApi.WIM_EXPORT_ONLY_METADATA,

        /// <summary>
        ///     No options are set.
        /// </summary>
        None = 0,

        /// <summary>
        ///     File resources will be exported to the destination .wim file and no image resources or XML information will be
        ///     included.
        /// </summary>
        ResourcesOnly = WimgApi.WIM_EXPORT_ONLY_RESOURCES
    }

    /// <summary>
    ///     Defines constants for read, write, or mount access to a .wim file.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    [Flags]
    public enum WimFileAccess : uint
    {
        /// <summary>
        ///     Specifies mount access to the image file.
        /// </summary>
        Mount = WimgApi.WIM_GENERIC_MOUNT,

        /// <summary>
        ///     Specifies query access to the file. An application can query image information without accessing the images.
        /// </summary>
        Query = 0,

        /// <summary>
        ///     Specifies read-only access to the image file. Enables images to be applied from the file. Combine with
        ///     WimFileAccess.Write for read/write (append) access.
        /// </summary>
        Read = WimgApi.WIM_GENERIC_READ,

        /// <summary>
        ///     Specifies write access to the image file. Enables images to be captured to the file. Includes WimFileAccess.Read
        ///     access to enable apply and append operations with existing images.
        /// </summary>
        Write = WimgApi.WIM_GENERIC_WRITE
    }

    /// <summary>
    ///     Specifies how a .wim file is treated and what features will be used.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    [Flags]
    public enum WimInfoAttributes : uint
    {
        /// <summary>
        ///     The .wim file only contains image resources and XML information.
        /// </summary>
        MetadataOnly = WimgApi.WIM_ATTRIBUTE_METADATA_ONLY,

        /// <summary>
        ///     The .wim file does not have any other attributes set.
        /// </summary>
        Normal = WimgApi.WIM_ATTRIBUTE_NORMAL,

        /// <summary>
        ///     The .wim file is locked and cannot be modified.
        /// </summary>
        ReadOnly = WimgApi.WIM_ATTRIBUTE_READONLY,

        /// <summary>
        ///     The .wim file only contains file resources and no images or metadata.
        /// </summary>
        ResourceOnly = WimgApi.WIM_ATTRIBUTE_RESOURCE_ONLY,

        /// <summary>
        ///     The .wim file contains one or more images where symbolic link or junction path fix-up is enabled.
        /// </summary>
        RPFix = WimgApi.WIM_ATTRIBUTE_RP_FIX,

        /// <summary>
        ///     The .wim file has been split into multiple pieces by the <see cref="WimgApi.SplitFile(WimHandle, string, long)" />
        ///     method.
        /// </summary>
        Spanned = WimgApi.WIM_ATTRIBUTE_SPANNED,

        /// <summary>
        ///     The .wim file contains integrity data that can be used by the
        ///     <see cref="WimgApi.CopyFile(string, string, WimCopyFileOptions)" /> or <see cref="WimgApi.CreateFile" /> method.
        /// </summary>
        VerifyData = WimgApi.WIM_ATTRIBUTE_VERIFY_DATA
    }

    /// <summary>
    ///     Specifies the result of a WimMessageCallback.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum WimMessageResult : uint
    {
        /// <summary>
        ///     Cancels an image apply or image capture.
        /// </summary>
        Abort = WimgApi.WIM_MSG_ABORT_IMAGE,

        /// <summary>
        ///     Indicates success and prevents other subscribers from receiving the message.
        /// </summary>
        Done = WimgApi.WIM_MSG_DONE,

        /// <summary>
        ///     Indicates the error can be ignored and the imaging operation continues.
        /// </summary>
        SkipError = WimgApi.WIM_MSG_SKIP_ERROR,

        /// <summary>
        ///     Indicate success and to enable other subscribers to process the message
        /// </summary>
        Success = WimgApi.WIM_MSG_SUCCESS
    }

    /// <summary>
    ///     Specifies the type of message sent to the WIMMessageCallback.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum WimMessageType : uint
    {
        /// <summary>
        ///     Base message value.
        /// </summary>
        None = 0x8000 + 0x1476,

        /// <summary>
        ///     Sent to the WIMMessageCallback function in debug builds with text messages containing status and error information.
        /// </summary>
        Text = 0x9477,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to indicate an update in the progress of an image application.
        /// </summary>
        /// <remarks>
        ///     Progress estimates typically increase during the early stages of an image apply and later decrease, so the
        ///     calling process must handle this as appropriate.
        /// </remarks>
        Progress = 0x9478,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to enable the caller to prevent a file or a directory from being captured or
        ///     applied.
        /// </summary>
        Process = 0x9479,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to indicate that volume information is gathered during an image capture.
        /// </summary>
        Scanning = 0x947A,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to indicate the number of files to capture or to apply.
        /// </summary>
        SetRange = 0x947B,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to indicate the number of files that were captured or applied.
        /// </summary>
        SetPosition = 0x947C,

        /// <summary>
        ///     Sent to the WIMMessageCallback function to indicate that a file was either captured or applied.
        /// </summary>
        StepIt = 0x947D,

        /// <summary>
        ///     Sent to the WIMMessageCallback function to enable the caller to prevent a file resource from being compressed
        ///     during a capture.
        /// </summary>
        Compress = 0x947E,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to alert the caller that an error occurred while capturing or applying an
        ///     image.
        /// </summary>
        Error = 0x947F,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to enable the caller to align a file resource on a particular alignment
        ///     boundary.
        /// </summary>
        Alignment = 0x9480,

        /// <summary>
        ///     Sent to a WIMMessageCallback function when an I/O error occurs during a WIMApplyImage operation.
        /// </summary>
        Retry = 0x9481,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to enable the caller to change the size or the name of a piece of a split
        ///     Windows® image (.wim) file.
        /// </summary>
        Split = 0x9482,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to provide the caller with information about the file being applied during a
        ///     WIMApplyImage operation.
        /// </summary>
        FileInfo = 0x9483,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to alert the caller that a non-critical error occurred while capturing or
        ///     applying an image.
        /// </summary>
        Info = 0x9484,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to warn the caller that a non-critical error occurred while capturing or
        ///     applying an image.
        /// </summary>
        Warning = 0x9485,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to warn the caller that the Object ID for a particular file could not be
        ///     restored.
        /// </summary>
        WarningObjectId = 0x9487,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to tell the caller that a stale mount directory is being removed.
        /// </summary>
        StaleMountDirectory = 0x9488,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to tell the caller how many stale files were removed.
        /// </summary>
        StaleMountFile = 0x9489,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to indicate progress during an image-cleanup operation.
        /// </summary>
        MountCleanupProgress = 0x948A,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to indicate that a drive is being scanned during a cleanup operation.
        /// </summary>
        CleanupScanningDrive = 0x948B,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to indicate that an image has been mounted to multiple locations. Only one
        ///     mount location can have changes written back to the .wim file.
        /// </summary>
        ImageAlreadyMounted = 0x948C,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to indicate that an image is being unmounted as part of the cleanup process.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Unmounting")] CleanupUnmountingImage = 0x948D,

        /// <summary>
        ///     Sent to a WIMMessageCallback function to allow the caller to abort an imaging operation that is currently
        ///     processing a file resource.
        /// </summary>
        /// <remarks>
        ///     This message is provided to allow applications to abort imaging operations that would otherwise not be aborted
        ///     until the next WIM_MSG_PROCESS message.
        /// </remarks>
        QueryAbort = 0x948E
    };

    /// <summary>
    ///     Represents options when mounting an image.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    [Flags]
    public enum WimMountImageOptions : uint
    {
        /// <summary>
        ///     Mounts the image using a faster operation.
        /// </summary>
        Fast = WimgApi.WIM_FLAG_MOUNT_FAST,

        /// <summary>
        ///     Disables capturing security information for directories.
        /// </summary>
        DisableDirectoryAcl = WimgApi.WIM_FLAG_NO_DIRACL,

        /// <summary>
        ///     Disables capturing security information for files.
        /// </summary>
        DisableFileAcl = WimgApi.WIM_FLAG_NO_FILEACL,

        /// <summary>
        ///     Disables automatic path repairs for junctions and symbolic links.
        /// </summary>
        DisableRPFix = WimgApi.WIM_FLAG_NO_RP_FIX,

        /// <summary>
        ///     Mounts the image using a legacy operation.
        /// </summary>
        Legacy = WimgApi.WIM_FLAG_MOUNT_LEGACY,

        /// <summary>
        ///     No options are set.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Mounts the image without the ability to save changes, regardless of WIM access level.
        /// </summary>
        ReadOnly = WimgApi.WIM_FLAG_MOUNT_READONLY,

        /// <summary>
        ///     Verifies that files match original data.
        /// </summary>
        Verify = WimgApi.WIM_FLAG_VERIFY
    }

    /// <summary>
    ///     Represents the current state of a mount point.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    [SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames")]
    [Flags]
    public enum WimMountPointState : uint
    {
        /// <summary>
        ///     The image mount point is no longer valid.
        /// </summary>
        Invalid = WimgApi.WIM_MOUNT_FLAG_INVALID,

        /// <summary>
        ///     The image is actively mounted.
        /// </summary>
        Mounted = WimgApi.WIM_MOUNT_FLAG_MOUNTED,

        /// <summary>
        ///     The image is in the process of mounting.
        /// </summary>
        Mounting = WimgApi.WIM_MOUNT_FLAG_MOUNTING,

        /// <summary>
        ///     The image mount point has been removed or replaced.
        /// </summary>
        NoMountDir = WimgApi.WIM_MOUNT_FLAG_NO_MOUNTDIR,

        /// <summary>
        ///     The mount point has been replaced with by a different mounted image.
        /// </summary>
        MountDirReplaced = WimgApi.WIM_MOUNT_FLAG_MOUNTDIR_REPLACED,

        /// <summary>
        ///     The WIM file backing the mount point is missing or inaccessible.
        /// </summary>
        NoWim = WimgApi.WIM_MOUNT_FLAG_NO_WIM,

        /// <summary>
        ///     The image has been mounted with read-write access.
        /// </summary>
        ReadWrite = WimgApi.WIM_MOUNT_FLAG_READWRITE,

        /// <summary>
        ///     The image is not mounted, but is capable of being remounted.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Remountable")] Remountable = WimgApi.WIM_MOUNT_FLAG_REMOUNTABLE
    }

    /// <summary>
    ///     Specifies the mode to use when setting a reference file.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    [SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags")]
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum WimSetReferenceMode : uint
    {
        /// <summary>
        ///     The specified .wim file is appended to the current list.
        /// </summary>
        Append = WimgApi.WIM_REFERENCE_APPEND,

        /// <summary>
        ///     The specified .wim file becomes the only item in the list.
        /// </summary>
        Replace = WimgApi.WIM_REFERENCE_REPLACE
    }

    /// <summary>
    ///     Represents options when setting a reference file.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    [Flags]
    public enum WimSetReferenceOptions : uint
    {
        /// <summary>
        ///     No options are set.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The .wim file is opened in a mode that enables simultaneous reading and writing.
        /// </summary>
        ShareWrite = WimgApi.WIM_FLAG_SHARE_WRITE,

        /// <summary>
        ///     Data integrity information is generated for new files, verified, and updated for existing files.
        /// </summary>
        Verify = WimgApi.WIM_FLAG_VERIFY
    }

    internal enum WimMountedImageInfoLevels : uint
    {
        Level0,
        Level1,
        Invalid
    }
}