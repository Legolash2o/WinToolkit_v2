using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Microsoft.Wim
{
    /// <summary>
    ///     Represents information about a mounted .wim file.
    /// </summary>
    public sealed class WimMountInfo
    {
        /// <summary>
        ///     Represents the current WimMountedImageInfoLevels in use for marshaling.
        /// </summary>
        internal const WimMountedImageInfoLevels MountInfoLevel = WimMountedImageInfoLevels.Level1;

        /// <summary>
        ///     The native <see cref="WimgApi.WIM_MOUNT_INFO_LEVEL1" /> struct that contains information about the mounted .wim
        ///     file.
        /// </summary>
        private readonly WimgApi.WIM_MOUNT_INFO_LEVEL1 _wimMountInfo;

        /// <summary>
        ///     Initializes a new instance of the WimMountInfo class.
        /// </summary>
        /// <param name="wimMountInfoPtr">A pointer to a native <see cref="WimgApi.WIM_MOUNT_INFO_LEVEL1" /> struct.</param>
        internal WimMountInfo(IntPtr wimMountInfoPtr)
            : this(
                (WimgApi.WIM_MOUNT_INFO_LEVEL1)
                    Marshal.PtrToStructure(wimMountInfoPtr, typeof (WimgApi.WIM_MOUNT_INFO_LEVEL1)))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the WimMountInfo class.
        /// </summary>
        /// <param name="wimMountInfo">
        ///     A <see cref="WimgApi.WIM_MOUNT_INFO_LEVEL1" /> that contains information about the mounted
        ///     .wim file.
        /// </param>
        internal WimMountInfo(WimgApi.WIM_MOUNT_INFO_LEVEL1 wimMountInfo)
        {
            // Store the WIM_MOUNT_INFO_LEVEL1 struct
            //
            _wimMountInfo = wimMountInfo;
        }

        /// <summary>
        ///     Gets the image index within the .wim file specified in <see cref="Path" />.
        /// </summary>
        public int ImageIndex
        {
            get { return (int) _wimMountInfo.ImageIndex; }
        }

        /// <summary>
        ///     Gets the full path to the directory where the image is mounted.
        /// </summary>
        public string MountPath
        {
            get { return _wimMountInfo.MountPath; }
        }

        /// <summary>
        ///     Gets the full path to the .wim file.
        /// </summary>
        public string Path
        {
            get { return _wimMountInfo.WimPath; }
        }

        /// <summary>
        ///     Gets a boolean value indicating if the image was mounted with support for saving changes.
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                // See if WimMountPointState.ReadWrite is part of the State
                //
                return (State & WimMountPointState.ReadWrite) != WimMountPointState.ReadWrite;
            }
        }

        /// <summary>
        ///     Gets the current state of the mount point.
        /// </summary>
        public WimMountPointState State
        {
            get { return _wimMountInfo.MountFlags; }
        }

        /// <summary>
        ///     Gets information about a mounted image.
        /// </summary>
        /// <param name="mountPath">The full file path of the directory to which the .wim file has been mounted.</param>
        /// <returns>A <see cref="WimMountInfo" /> object containing information about the mounted image.</returns>
        public static WimMountInfo GetMountInfo(string mountPath)
        {
            // Stores the handle to the image
            //
            WimHandle imageHandle = null;

            try
            {
                // Get a mounted image handle
                //
                // ReSharper disable once UnusedVariable
                using (var wimHandle = WimgApi.GetMountedImageHandle(mountPath, true, out imageHandle))
                {
                    // Return the mounted image info from the handle
                    //
                    return WimgApi.GetMountedImageInfoFromHandle(imageHandle);
                }
            }
            finally
            {
                // Clean up
                //
                if (imageHandle != null)
                {
                    imageHandle.Dispose();
                }
            }
        }
    }

    /// <summary>
    ///     Represents a collection of <see cref="WimMountInfo" /> objects.
    /// </summary>
    public sealed class WimMountInfoCollection : ReadOnlyCollection<WimMountInfo>
    {
        /// <summary>
        ///     Initializes a new instance of the WimMountInfoCollection class.
        /// </summary>
        /// <param name="list">A list of <see cref="WimMountInfo" /> objects to wrap as a collection.</param>
        internal WimMountInfoCollection(IList<WimMountInfo> list)
            : base(list)
        {
        }
    }
}