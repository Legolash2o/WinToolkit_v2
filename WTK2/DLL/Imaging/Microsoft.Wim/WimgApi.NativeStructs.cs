using System;
using System.Runtime.InteropServices;
using DWORD = System.UInt32;
using USHORT = System.UInt16;

// ReSharper disable RedundantNameQualifier
// ReSharper disable InconsistentNaming

namespace Microsoft.Wim
{
    public static partial class WimgApi
    {
        /// <summary>
        ///     Contains information retrieved by the WIMGetAttributes function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = WimgApiCharSet)]
        internal struct WIM_INFO
        {
            /// <summary>
            ///     Specifies the full path to the .wim file.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string WimPath;

            /// <summary>
            ///     Specifies a GUID structure containing the unique identifier for the Windows® image (.wim) file.
            /// </summary>
            public Guid Guid;

            /// <summary>
            ///     Specifies the number of images contained in the .wim file. This value is also returned by the WIMGetImageCount
            ///     function.
            /// </summary>
            public uint ImageCount;

            /// <summary>
            ///     Specifies the method of compression used to compress resources in the .wim file. See the WIMCreateFile function for
            ///     the initial compression types.
            /// </summary>
            public WimCompressionType CompressionType;

            /// <summary>
            ///     Specifies the part number of the current .wim file in a spanned set. This value should be one, unless the data of
            ///     the .wim file was originally split by the WIMSplitFile function.
            /// </summary>
            public ushort PartNumber;

            /// <summary>
            ///     Specifies the total number of .wim file parts in a spanned set. This value must be one, unless the data of the .wim
            ///     file was originally split via the WIMSplitFile function.
            /// </summary>
            public ushort TotalParts;

            /// <summary>
            ///     Specifies the index of the bootable image in the .wim file. If this value is zero, then there are no bootable
            ///     images available. To set a bootable image, call the WIMSetBootImage function.
            /// </summary>
            public uint BootIndex;

            /// <summary>
            ///     Specifies how the file is treated and what features will be used.
            /// </summary>
            public uint WimAttributes;

            /// <summary>
            ///     Specifies the flags used during a WIMCreateFile function.
            /// </summary>
            public uint WimFlagsAndAttr;
        }

        /// <summary>
        ///     Contains information retrieved by the WIMGetMountedImageInfo function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = WimgApiCharSet)]
        internal struct WIM_MOUNT_INFO_LEVEL0
        {
            /// <summary>
            ///     Specifies the full path to the .wim file.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string WimPath;

            /// <summary>
            ///     Specifies the full path to the directory where the image is mounted.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string MountPath;

            /// <summary>
            ///     Specifies the image index within the .wim file specified in WimPath.
            /// </summary>
            public uint ImageIndex;

            /// <summary>
            ///     Specifies if the image was mounted with support for saving changes.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)] public bool MountedForRW;
        }

        /// <summary>
        ///     Contains information retrieved by the WIMGetMountedImageList function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = WimgApiCharSet, Pack = 4)]
        internal struct WIM_MOUNT_INFO_LEVEL1
        {
            /// <summary>
            ///     Specifies the full path to the .wim file.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string WimPath;

            /// <summary>
            ///     Specifies the full path to the directory where the image is mounted.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string MountPath;

            /// <summary>
            ///     Specifies the image index within the .wim file specified in WimPath.
            /// </summary>
            public uint ImageIndex;

            /// <summary>
            ///     Specifies the current state of the mount point.
            /// </summary>
            public WimMountPointState MountFlags;
        }

        /// <summary>
        ///     Contains information retrieved by the WIMGetMountedImages function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = WimgApiCharSet, Pack = 4)]
        internal struct WIM_MOUNT_LIST
        {
            /// <summary>
            ///     Specifies the full path to the .wim file.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string WimPath;

            /// <summary>
            ///     Specifies the full path to the directory where the image is mounted.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string MountPath;

            /// <summary>
            ///     Specifies the image index within the .wim file specified in WimPath.
            /// </summary>
            public uint ImageIndex;

            /// <summary>
            ///     Specifies if the image was mounted with support for saving changes.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)] public bool MountedForRW;
        }
    }
}