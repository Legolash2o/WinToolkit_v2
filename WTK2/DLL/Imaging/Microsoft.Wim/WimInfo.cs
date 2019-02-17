using System;
using System.Runtime.InteropServices;

namespace Microsoft.Wim
{
    /// <summary>
    ///     Represents information about a Windows® image (.wim).
    /// </summary>
    public sealed class WimInfo
    {
        /// <summary>
        ///     The native <see cref="WimgApi.WIM_INFO" /> struct that contains information about the .wim file.
        /// </summary>
        private readonly WimgApi.WIM_INFO _wimInfo;

        /// <summary>
        ///     Initializes a new instance of the WimInfo class.
        /// </summary>
        /// <param name="wimInfoPtr">A pointer to a native <see cref="WimgApi.WIM_INFO" /> struct.</param>
        internal WimInfo(IntPtr wimInfoPtr)
            : this((WimgApi.WIM_INFO) Marshal.PtrToStructure(wimInfoPtr, typeof (WimgApi.WIM_INFO)))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the WimInfo class.
        /// </summary>
        /// <param name="wimInfo">A <see cref="WimgApi.WIM_INFO" /> that contains information about the .wim file.</param>
        internal WimInfo(WimgApi.WIM_INFO wimInfo)
        {
            // Store the WIM_INFO struct
            //
            _wimInfo = wimInfo;
        }

        /// <summary>
        ///     Gets a <see cref="WimInfoAttributes" /> value that indicates how the file is treated and what features will be
        ///     used.
        /// </summary>
        public WimInfoAttributes Attributes
        {
            get { return (WimInfoAttributes) _wimInfo.WimAttributes; }
        }

        /// <summary>
        ///     Gets the index of the bootable image in the .wim file. If this value is zero, then there are no bootable images
        ///     available. To set a bootable image, call the WIMSetBootImage function.
        /// </summary>
        public int BootIndex
        {
            get { return (int) _wimInfo.BootIndex; }
        }

        /// <summary>
        ///     Gets a <see cref="WimCompressionType" /> value that indicates the method of compression used to compress resources
        ///     in the .wim file.
        /// </summary>
        public WimCompressionType CompressionType
        {
            get { return _wimInfo.CompressionType; }
        }

        /// <summary>
        ///     Gets a <see cref="WimCreateFileOptions" /> value that indicates the options used when the .wim file was created.
        /// </summary>
        public WimCreateFileOptions CreateOptions
        {
            get { return (WimCreateFileOptions) _wimInfo.WimFlagsAndAttr; }
        }

        /// <summary>
        ///     Gets the unique identifier for the Windows® image (.wim) file.
        /// </summary>
        public Guid Guid
        {
            get { return _wimInfo.Guid; }
        }

        /// <summary>
        ///     Gets the number of images contained in the .wim file.
        /// </summary>
        public int ImageCount
        {
            get { return (int) _wimInfo.ImageCount; }
        }

        /// <summary>
        ///     Gets the part number of the current .wim file in a spanned set.  This value should be one, unless the data of the
        ///     .wim file was originally split by the <see cref="WimgApi.SplitFile(WimHandle, string, long)" /> method.
        /// </summary>
        public int PartNumber
        {
            get { return _wimInfo.PartNumber; }
        }

        /// <summary>
        ///     Gets the full path to the .wim file.
        /// </summary>
        public string Path
        {
            get { return _wimInfo.WimPath; }
        }

        /// <summary>
        ///     Gets the total number of .wim file parts in a spanned set. This value must be one, unless the data of the .wim file
        ///     was originally split via the <see cref="WimgApi.SplitFile(WimHandle, string, long)" /> method.
        /// </summary>
        public int TotalParts
        {
            get { return _wimInfo.TotalParts; }
        }
    }
}