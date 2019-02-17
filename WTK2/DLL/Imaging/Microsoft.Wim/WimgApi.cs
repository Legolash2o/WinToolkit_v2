using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.Win32;
using DWORD = System.UInt32;

// ReSharper disable RedundantNameQualifier

namespace Microsoft.Wim
{
    /// <summary>
    ///     Represents the Windows® Imaging API (WIMGAPI) for capturing and applying Windows® images (WIMs).
    /// </summary>
    public static partial class WimgApi
    {
        /// <summary>
        ///     Used as an object for locking.
        /// </summary>
        private static readonly object LockObject = new object();

        /// <summary>
        ///     An instance of the <see cref="WimRegisteredCallbacks" /> class for keeping track of registered callbacks.
        /// </summary>
        private static readonly WimRegisteredCallbacks RegisteredCallbacks = new WimRegisteredCallbacks();

        /// <summary>
        ///     Applies an image to a directory path from a Windows® image (.wim) file.
        /// </summary>
        /// <param name="imageHandle">
        ///     A handle to a volume image returned by the <see cref="LoadImage" /> or
        ///     <see cref="CaptureImage" /> methods.
        /// </param>
        /// <param name="path">The root drive or the directory path where the image data will be applied.</param>
        /// <param name="options">Specifies how the file is to be treated and what features are to be used.</param>
        /// <returns><c>true</c> if the image was successfully applied, otherwise <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">imageHandle is null.</exception>
        /// <exception cref="OperationCanceledException">
        ///     The operation of applying the image was aborted by a callback returning
        ///     <see cref="WimMessageResult.Abort" />.
        /// </exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void ApplyImage(WimHandle imageHandle, string path, WimApplyImageOptions options)
        {
            // See if the handle is null
            //
            if (imageHandle == null)
            {
                throw new ArgumentNullException("imageHandle");
            }

            // Call the native function
            //
            if (!NativeMethods.WIMApplyImage(imageHandle, path, (uint) options))
            {
                // Get the last error
                //
                var win32Exception = new Win32Exception();

                switch (win32Exception.NativeErrorCode)
                {
                    case Win32Error.ERROR_REQUEST_ABORTED:
                        // If the operation was aborted, throw an OperationCanceledException exception
                        //
                        throw new OperationCanceledException(win32Exception.Message, win32Exception);
                    default:
                        throw win32Exception;
                }
            }
        }

        /// <summary>
        ///     Captures an image from a directory path and stores it in an image file.
        /// </summary>
        /// <param name="wimHandle">The handle to a .wim file returned by <see cref="CreateFile" />.</param>
        /// <param name="path">The root drive or directory path from where the image data is captured.</param>
        /// <param name="options">Specifies the features to use during the capture.</param>
        /// <returns>A <see cref="WimHandle" /> of the image if the method succeeded, otherwise false.</returns>
        /// <exception cref="ArgumentNullException">
        ///     wimHandle is null.
        ///     -or-
        ///     path is null
        /// </exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path" /> does not exist.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static WimHandle CaptureImage(WimHandle wimHandle, string path, WimCaptureImageOptions options)
        {
            // See if the handle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // See if path is null
            //
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            // See if path doesn't exist
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException(string.Format("Could not find part of the path '{0}'", path));
            }

            // Call the native function
            //
            var imageHandle = NativeMethods.WIMCaptureImage(wimHandle, path, (uint) options);

            // See if the handle returned is valid
            //
            if (imageHandle == null || imageHandle.IsInvalid)
            {
                // Throw a Win32Exception which will call GetLastError
                //
                throw new Win32Exception();
            }

            // Return the handle to the image
            //
            return imageHandle;
        }

        /// <summary>
        ///     Saves the changes from a mounted image back to the.wim file.
        /// </summary>
        /// <param name="imageHandle">
        ///     A <see cref="WimHandle" /> opened by the <see cref="LoadImage" /> method. The .wim file must
        ///     have been opened with a <see cref="WimFileAccess.Mount" /> flag in call to <see cref="CreateFile" />.
        /// </param>
        /// <param name="append">
        ///     <c>true</c> to append the modified image to the .wim file.  <c>false</c> to commit the changes to
        ///     the original image.
        /// </param>
        /// <param name="options">Specifies the features to use during the capture.</param>
        /// <returns>If append is <c>true</c>, a <see cref="WimHandle" /> of the new image, otherwise a null handle.</returns>
        /// <exception cref="ArgumentNullException">imageHandle is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static WimHandle CommitImageHandle(WimHandle imageHandle, bool append, WimCommitImageOptions options)
        {
            // See if the handle is null
            //
            if (imageHandle == null)
            {
                throw new ArgumentNullException("imageHandle");
            }

            // A WimHandle is returned only if WimCommitImageOptions.Append is passed but we'll create one any way
            //
            WimHandle newImageHandle;

            // Call the native function, add the append flag if needed
            //
            if (
                !NativeMethods.WIMCommitImageHandle(imageHandle, append ? WIM_COMMIT_FLAG_APPEND : 0 | (uint) options,
                    out newImageHandle))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }

            // Return the new image handle which may or may not contain a handle
            //
            return newImageHandle;
        }

        /// <summary>
        ///     Copies an existing file to a new file.
        /// </summary>
        /// <param name="sourceFile">The name of an existing .wim file.</param>
        /// <param name="destinationFile">The name of the new file.</param>
        /// <param name="options">Specifies how the file is to be copied.</param>
        /// <exception cref="ArgumentNullException">sourceFile or destinationFile is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void CopyFile(string sourceFile, string destinationFile, WimCopyFileOptions options)
        {
            // Call an override
            //
            CopyFile(sourceFile, destinationFile, options, null, null);
        }

        /// <summary>
        ///     Copies an existing file to a new file. Notifies the application of its progress through a callback function. If the
        ///     source file has verification data, the contents of the file are verified during the copy operation.
        /// </summary>
        /// <param name="sourceFile">The name of an existing .wim file.</param>
        /// <param name="destinationFile">The name of the new file.</param>
        /// <param name="options">Specifies how the file is to be copied.</param>
        /// <param name="copyFileProgressCallback">
        ///     A <see cref="CopyFileProgressCallback" /> method to call when progress is made
        ///     copying the file and allowing the user to cancel the operation.
        /// </param>
        /// <param name="userData">An object containing data to be used by the progress callback method.</param>
        /// <exception cref="ArgumentNullException">sourceFile or destinationFile is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void CopyFile(string sourceFile, string destinationFile, WimCopyFileOptions options,
            CopyFileProgressCallback copyFileProgressCallback, object userData)
        {
            // See if sourceFile is null
            //
            if (sourceFile == null)
            {
                throw new ArgumentNullException("sourceFile");
            }

            // See if destinationFile is null
            //
            if (destinationFile == null)
            {
                throw new ArgumentNullException("destinationFile");
            }

            // Create a CopyFileProgress object
            //
            var fileInfoCopyProgress = new CopyFileProgress(sourceFile, destinationFile, copyFileProgressCallback,
                userData);

            // Cancel flag is always false
            //
            var cancel = false;

            // Call the native function
            //
            if (
                !NativeMethods.WIMCopyFile(sourceFile, destinationFile, fileInfoCopyProgress.CopyProgressHandler,
                    IntPtr.Zero, ref cancel, (uint) options))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Makes a new image file or opens an existing image file.
        /// </summary>
        /// <param name="path">The name of the file to create or to open.</param>
        /// <param name="desiredAccess">
        ///     The type of <see cref="WimFileAccess" /> to the object. An application can obtain read
        ///     access, write access, read/write access, or device query access.
        /// </param>
        /// <param name="creationDisposition">
        ///     The <see cref="WimCreationDisposition" /> to take on files that exist, and which
        ///     action to take when files do not exist.
        /// </param>
        /// <param name="options"><see cref="WimCreateFileOptions" /> to be used for the specified file.</param>
        /// <param name="compressionType">
        ///     The <see cref="WimCompressionType" /> to be used for a newly created image file.  If the
        ///     file already exists, then this value is ignored.
        /// </param>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static WimHandle CreateFile(string path, WimFileAccess desiredAccess,
            WimCreationDisposition creationDisposition, WimCreateFileOptions options, WimCompressionType compressionType)
        {
            // See if destinationFile is null
            //
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            // Stores the creation result
            //
            WimCreationResult creationResult;

            // Call the native function
            //
            var wimHandle = NativeMethods.WIMCreateFile(path, (uint) desiredAccess, (uint) creationDisposition,
                (uint) options, (uint) compressionType, out creationResult);

            // See if the handle returned is valid
            //
            if (wimHandle == null || wimHandle.IsInvalid)
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }

            // Return the handle to the wim
            //
            return wimHandle;
        }

        /// <summary>
        ///     Removes an image from within a .wim (Windows image) file so it cannot be accessed. However, the file resources are
        ///     still available for use by the <see cref="SetReferenceFile" /> method.
        /// </summary>
        /// <param name="wimHandle">
        ///     A <see cref="WimHandle" /> to a .wim file returned by the <see cref="CreateFile" /> method.
        ///     This handle must have <see cref="WimFileAccess.Write" /> access to delete the image. Split .wim files are not
        ///     supported and the .wim file cannot have any open images.
        /// </param>
        /// <param name="index">
        ///     The one-based index of the image to delete. A .wim file might have multiple images stored within
        ///     it.
        /// </param>
        /// <exception cref="ArgumentNullException">wimHandle is null.</exception>
        /// <exception cref="IndexOutOfRangeException">
        ///     <paramref name="index" /> is less than 1
        ///     -or-
        ///     <paramref name="index" /> is greater than the number of images in the Windows® imaging file.
        /// </exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        /// <remarks>
        ///     You must call the <see cref="SetTemporaryPath" /> method before calling the <see cref="DeleteImage" /> method
        ///     so the image metadata for the image can be extracted and processed from the temporary location.
        /// </remarks>
        public static void DeleteImage(WimHandle wimHandle, int index)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // See if the specified index is valid
            //
            if (index < 1 || index > GetImageCount(wimHandle))
            {
                throw new IndexOutOfRangeException(string.Format("There is no image at index {0}.", index));
            }

            // Call the native function
            //
            if (!NativeMethods.WIMDeleteImage(wimHandle, (uint) index))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Removes images from all directories where they have been previously mounted.
        /// </summary>
        /// <param name="removeAll">
        ///     <c>true</c> to removes all mounted images, whether actively mounted or not, otherwise
        ///     <c>false</c> to remove only images that are not actively mounted.
        /// </param>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void DeleteImageMounts(bool removeAll)
        {
            // Call the native function
            //
            if (!NativeMethods.WIMDeleteImageMounts(removeAll ? WIM_DELETE_MOUNTS_ALL : 0))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Transfers the data of an image from one Windows® image (.wim) file to another.
        /// </summary>
        /// <param name="imageHandle">A <see cref="WimHandle" /> opened by the <see cref="LoadImage" /> method.</param>
        /// <param name="wimHandle">
        ///     A <see cref="WimHandle" /> returned by the <see cref="CreateFile" /> method.  This handle must
        ///     have <see cref="WimFileAccess.Write" /> access to accept the exported image. Split .wim files are not supported.
        /// </param>
        /// <param name="options">Specifies how the image will be exported to the destination .wim file.</param>
        /// <exception cref="ArgumentNullException">imageHandle or wimHandle is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        /// <remarks>
        ///     You must call the <see cref="SetTemporaryPath" /> method for both the source and the destination .wim files
        ///     before calling the ExportImage method.
        /// </remarks>
        public static void ExportImage(WimHandle imageHandle, WimHandle wimHandle, WimExportImageOptions options)
        {
            // See if imageHandle is null
            //
            if (imageHandle == null)
            {
                throw new ArgumentNullException("imageHandle");
            }

            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // Call the native function
            //
            if (!NativeMethods.WIMExportImage(imageHandle, wimHandle, (uint) options))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Extracts a file from within a Windows® image (.wim) file to a specified location.
        /// </summary>
        /// <param name="imageHandle">A <see cref="WimHandle" /> opened by the <see cref="LoadImage" /> method.</param>
        /// <param name="sourceFile">The path to a file inside the image.</param>
        /// <param name="destinationFile">The full file path of the directory where the image path is to be extracted.</param>
        /// <exception cref="ArgumentNullException">imageHandle, sourceFile, or destinationFile is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void ExtractImagePath(WimHandle imageHandle, string sourceFile, string destinationFile)
        {
            // See if imageHandle is null
            //
            if (imageHandle == null)
            {
                throw new ArgumentNullException("imageHandle");
            }

            // See if sourceFile is null
            //
            if (sourceFile == null)
            {
                throw new ArgumentNullException("sourceFile");
            }

            // See if destinationFile is null
            //
            if (destinationFile == null)
            {
                throw new ArgumentNullException("destinationFile");
            }

            // Call the native function
            //
            if (!NativeMethods.WIMExtractImagePath(imageHandle, sourceFile, destinationFile, 0))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Returns the number of volume images stored in an image file.
        /// </summary>
        /// <param name="wimHandle">A <see cref="WimHandle" /> of a .wim file returned by <see cref="CreateFile" />.</param>
        /// <returns>A <see cref="WimInfo" /> object containing information about the image file.</returns>
        /// <exception cref="ArgumentNullException">wimHandle is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static WimInfo GetAttributes(WimHandle wimHandle)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // Calculate the size of the buffer needed
            //
            var wimInfoSize = (uint) Marshal.SizeOf(typeof (WimgApi.WIM_INFO));

            // Allocate a buffer to receive the native struct
            //
            var wimInfoPtr = Marshal.AllocHGlobal((int) wimInfoSize);

            try
            {
                // Call the native function
                //
                if (!NativeMethods.WIMGetAttributes(wimHandle, wimInfoPtr, wimInfoSize))
                {
                    // Throw a Win32Exception based on the last error code
                    //
                    throw new Win32Exception();
                }

                // Return a new instance of a WimInfo class which will marshal the struct
                //
                return new WimInfo(wimInfoPtr);
            }
            finally
            {
                // Free memory
                //
                Marshal.FreeHGlobal(wimInfoPtr);
            }
        }

        /// <summary>
        ///     Returns the number of volume images stored in a Windows® image (.wim) file.
        /// </summary>
        /// <param name="wimHandle">A <see cref="WimHandle" /> of a .wim file returned by the <see cref="CreateFile" /> method.</param>
        /// <returns>
        ///     The number of images in the .wim file. If this value is zero, then the image file is invalid or does not
        ///     contain any images that can be applied.
        /// </returns>
        public static int GetImageCount(WimHandle wimHandle)
        {
            // Return the value from the native function
            //
            return (int) NativeMethods.WIMGetImageCount(wimHandle);
        }

        /// <summary>
        ///     Gets an <see cref="XmlDocument" /> that contains information about an image within the .wim (Windows image) file.
        /// </summary>
        /// <param name="wimHandle">
        ///     Either a <see cref="WimHandle" /> returned from <see cref="CreateFile" />,
        ///     <see cref="LoadImage" />, or <see cref="CaptureImage" />.
        /// </param>
        /// <returns>An <see cref="IXPathNavigable" /> object containing XML information about the volume image.</returns>
        /// <exception cref="ArgumentNullException">wimHandle is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static XDocument GetImageInformation(WimHandle wimHandle)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // Stores the native pointer to the Unicode Xml
            //
            var imageInfoPtr = IntPtr.Zero;

            try
            {
                // Receives the buffer size
                //
                uint imageInfoSize;

                // Call the native function
                //
                if (!NativeMethods.WIMGetImageInformation(wimHandle, out imageInfoPtr, out imageInfoSize))
                {
                    // Throw a Win32Exception based on the last error code
                    //
                    throw new Win32Exception();
                }

                // Marshal the buffer as a Unicode string, remove the Unicode file marker, and load it into a StringReader
                //
                var str = Marshal.PtrToStringUni(imageInfoPtr);

                if (str != null)
                {
                    return XDocument.Parse(str.Substring(1));
                }

                return null;
            }
            finally
            {
                // Free the native pointer
                //
                Marshal.FreeHGlobal(imageInfoPtr);
            }
        }

        /// <summary>
        ///     Gets the count of callback routines currently registered by the imaging library.
        /// </summary>
        /// <returns>The number of message callback functions currently registered.</returns>
        /// <exception cref="ArgumentNullException">wimHandle is null.</exception>
        public static int GetMessageCallbackCount()
        {
            return GetMessageCallbackCount(WimHandle.Null);
        }

        /// <summary>
        ///     Gets the count of callback routines currently registered by the imaging library.
        /// </summary>
        /// <param name="wimHandle">A <see cref="WimHandle" /> of a .wim file returned by <see cref="CreateFile" />.</param>
        /// <returns>The number of message callback functions currently registered.</returns>
        /// <exception cref="ArgumentNullException">wimHandle is null.</exception>
        public static int GetMessageCallbackCount(WimHandle wimHandle)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // Return the value from the native function
            //
            return (int) NativeMethods.WIMGetMessageCallbackCount(wimHandle);
        }

        /// <summary>
        ///     Gets a <see cref="WimHandle" /> for the .wim file and a <see cref="WimHandle" /> for the image corresponding to a
        ///     mounted image directory.
        /// </summary>
        /// <param name="mountPath">The full file path of the directory to which the .wim file has been mounted.</param>
        /// <param name="readOnly">
        ///     <c>true</c> to get a handle that cannot commit changes, regardless of the access level requested
        ///     at mount time, otherwise <c>false</c>.
        /// </param>
        /// <param name="imageHandle">A <see cref="WimHandle" />corresponding to the image mounted at the specified path.</param>
        /// <returns>A <see cref="WimHandle" />corresponding to the .wim file mounted at the specified path.</returns>
        /// <exception cref="ArgumentNullException">mountPath is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#")]
        public static WimHandle GetMountedImageHandle(string mountPath, bool readOnly, out WimHandle imageHandle)
        {
            // See if mountPath is null
            //
            if (mountPath == null)
            {
                throw new ArgumentNullException("mountPath");
            }

            WimHandle wimHandle;

            // Call the native function
            //
            if (
                !NativeMethods.WIMGetMountedImageHandle(mountPath, readOnly ? WIM_FLAG_MOUNT_READONLY : 0, out wimHandle,
                    out imageHandle))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }

            // Return the WIM handle
            //
            return wimHandle;
        }

        /// <summary>
        ///     Gets a <see cref="WimMountInfoCollection" /> containing <see cref="WimMountInfo" /> objects that represent a list
        ///     of images that are currently mounted.
        /// </summary>
        /// <returns>A <see cref="WimMountInfoCollection" /> containing <see cref="WimMountInfo" /> objects.</returns>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public static WimMountInfoCollection GetMountedImageInfo()
        {
            // Receives the image count
            //
            uint imageCount;

            // Receives the size of the buffer needed to store the array of structs
            //
            uint returnLength;

            // Call the native function first to get the necessary buffer size
            //
            NativeMethods.WIMGetMountedImageInfo(WimMountInfo.MountInfoLevel, out imageCount, IntPtr.Zero, 0,
                out returnLength);

            switch (Marshal.GetLastWin32Error())
            {
                case 0:

                    // Return an empty list because there are no images
                    //
                    return new WimMountInfoCollection(new List<WimMountInfo>());
                case Win32Error.ERROR_INSUFFICIENT_BUFFER:

                    // Continue on because we now know how much memory is needed
                    //
                    break;

                default:

                    // Throw a Win32Exception based on the last error code
                    //
                    throw new Win32Exception();
            }

            // Create a collection of WimMountInfo objects
            //
            var wimMountInfos = new List<WimMountInfo>();

            // Allocate enough memory for the return array
            //
            var mountInfoPtr = Marshal.AllocHGlobal((int) returnLength);

            try
            {
                // Call the native function a second time so it can fill the array of pointers
                //
                if (
                    !NativeMethods.WIMGetMountedImageInfo(WimMountInfo.MountInfoLevel, out imageCount, mountInfoPtr,
                        returnLength, out returnLength))
                {
                    // Throw a Win32Exception based on the last error code
                    //
                    throw new Win32Exception();
                }

                // Loop through each image
                //
                for (var i = 0; i < imageCount; i++)
                {
                    // Get the current pointer based on the index
                    //
                    var currentImageInfoPtr = new IntPtr(mountInfoPtr.ToInt64() + (i*(returnLength/imageCount)));

                    // Read a pointer and add a new WimMountInfo object to the collection
                    //
                    wimMountInfos.Add(new WimMountInfo(currentImageInfoPtr));
                }
            }
            finally
            {
                // Free the native array
                //
                Marshal.FreeHGlobal(mountInfoPtr);
            }

            // Return the WimMountInfo list as a read-only collection
            //
            return new WimMountInfoCollection(wimMountInfos);
        }

        /// <summary>
        ///     Gets information about a mounted image of the specified mounted image handle.
        /// </summary>
        /// <param name="imageHandle">A <see cref="WimHandle" /> of an image that has been mounted.</param>
        /// <returns>A <see cref="WimMountInfo" /> object containing information about the mounted image.</returns>
        /// <exception cref="ArgumentNullException">imageHandle is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static WimMountInfo GetMountedImageInfoFromHandle(WimHandle imageHandle)
        {
            // See if imageHandle is null
            //
            if (imageHandle == null)
            {
                throw new ArgumentNullException("imageHandle");
            }


            // Calculate the size of the buffer needed
            //
            var mountInfoSize = Marshal.SizeOf(typeof (WimgApi.WIM_MOUNT_INFO_LEVEL1));

            // Allocate a buffer for the native function
            //
            var mountInfoPtr = Marshal.AllocHGlobal(mountInfoSize);

            try
            {
                // Receives the size of buffer needed if we pass a buffer that is too small
                //
                uint returnLength;

                // Call the native function (the buffer may be too small)
                //
                if (
                    !NativeMethods.WIMGetMountedImageInfoFromHandle(imageHandle, WimMountInfo.MountInfoLevel,
                        mountInfoPtr, (uint) mountInfoSize, out returnLength))
                {
                    // See if the return value isn't ERROR_INSUFFICIENT_BUFFER
                    //
                    if (Marshal.GetLastWin32Error() != 122)
                    {
                        throw new Win32Exception();
                    }

                    // Re-allocate the buffer to the correct size
                    //
                    Marshal.ReAllocHGlobal(mountInfoPtr, (IntPtr) returnLength);

                    // Call the native function a second time so it can fill buffer with a struct
                    //
                    if (
                        !NativeMethods.WIMGetMountedImageInfoFromHandle(imageHandle, WimMountInfo.MountInfoLevel,
                            mountInfoPtr, returnLength, out returnLength))
                    {
                        // Throw a Win32Exception based on the last error code
                        //
                        throw new Win32Exception();
                    }
                }

                // Return a WimMountInfo object which will marshal the pointer to a struct
                //
                return new WimMountInfo(mountInfoPtr);
            }
            finally
            {
                // Free the native memory
                //
                Marshal.FreeHGlobal(mountInfoPtr);
            }
        }

        /// <summary>
        ///     Loads a volume image from a Windows® image (.wim) file.
        /// </summary>
        /// <param name="wimHandle">A <see cref="WimHandle" /> of a .wim file returned by the <see cref="CreateFile" /> method.</param>
        /// <param name="index">The one-based index of the image to load. An image file may store multiple images.</param>
        /// <returns>A <see cref="WimHandle" /> representing the volume image.</returns>
        /// <exception cref="ArgumentNullException">wimHandle is null.</exception>
        /// <exception cref="IndexOutOfRangeException">
        ///     index is less than 1
        ///     -or-
        ///     index is greater than the number of images in the Windows® imaging file.
        /// </exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        /// <remarks>
        ///     You must call the <see cref="SetTemporaryPath" /> method before calling the <see cref="LoadImage" /> method so
        ///     the image metadata can be extracted and processed from the temporary location.
        /// </remarks>
        public static WimHandle LoadImage(WimHandle wimHandle, int index)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // See if the specified index is valid
            //
            if (index < 1 || index > GetImageCount(wimHandle))
            {
                throw new IndexOutOfRangeException(string.Format("There is no image at index {0}.", index));
            }

            // Call the native function
            //
            var imageHandle = NativeMethods.WIMLoadImage(wimHandle, (uint) index);

            if (imageHandle == null || imageHandle.IsInvalid)
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }

            // Return the image handle
            //
            return imageHandle;
        }

        /// <summary>
        ///     Mounts an image in a Windows® image (.wim) file to the specified directory and does not allow for edits.
        /// </summary>
        /// <param name="mountPath">The full file path of the directory to which the .wim file has to be mounted.</param>
        /// <param name="imagePath">The full file name of the .wim file that has to be mounted.</param>
        /// <param name="imageIndex">An index of the image in the .wim file that has to be mounted.</param>
        /// <exception cref="ArgumentNullException">mountPath or imagePath is null.</exception>
        /// <exception cref="DirectoryNotFoundException">mountPath does not exist.</exception>
        /// <exception cref="FileNotFoundException">imagePath does not exist.</exception>
        /// <exception cref="IndexOutOfRangeException">index is less than 1.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void MountImage(string mountPath, string imagePath, int imageIndex)
        {
            // Call an overload
            //
            MountImage(mountPath, imagePath, imageIndex, null);
        }

        /// <summary>
        ///     Mounts an image in a Windows® image (.wim) file to the specified directory.
        /// </summary>
        /// <param name="mountPath">The full file path of the directory to which the .wim file has to be mounted.</param>
        /// <param name="imagePath">The full file name of the .wim file that has to be mounted.</param>
        /// <param name="imageIndex">The one-based index of the image in the .wim file that is to be mounted.</param>
        /// <param name="tempPath">
        ///     The full file path to the temporary directory in which changes to the .wim file can be tracked.
        ///     If this parameter is <c>null</c>, the image will not be mounted for edits.
        /// </param>
        /// <exception cref="ArgumentNullException">mountPath or imagePath is null.</exception>
        /// <exception cref="DirectoryNotFoundException">mountPath does not exist.</exception>
        /// <exception cref="FileNotFoundException">imagePath does not exist.</exception>
        /// <exception cref="IndexOutOfRangeException">index is less than 1.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void MountImage(string mountPath, string imagePath, int imageIndex, string tempPath)
        {
            // See if mountPath is null
            //
            if (mountPath == null)
            {
                throw new ArgumentNullException("mountPath");
            }

            // See if imagePath is null
            //
            if (imagePath == null)
            {
                throw new ArgumentNullException("imagePath");
            }

            // See if the specified index is valid
            //
            if (imageIndex < 1)
            {
                throw new IndexOutOfRangeException(string.Format("There is no image at index {0}.", imageIndex));
            }

            // See if mount path does not exist
            //
            if (!Directory.Exists(mountPath))
            {
                throw new DirectoryNotFoundException(string.Format("Could not find a part of the path '{0}'", mountPath));
            }

            // See if the image does not exist
            //
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException(string.Format("Could not find a part of the path '{0}'", imagePath));
            }

            // Call the native function
            //
            if (!NativeMethods.WIMMountImage(mountPath, imagePath, (uint) imageIndex, tempPath))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Mounts an image in a Windows® image (.wim) file to the specified directory.
        /// </summary>
        /// <param name="imageHandle">
        ///     A <see cref="WimHandle" /> of a a volume image returned by the <see cref="LoadImage" /> or
        ///     <see cref="CaptureImage" /> method. The WIM file must have been opened with <see cref="WimFileAccess.Mount" /> flag
        ///     in call to <see cref="CreateFile" />.
        /// </param>
        /// <param name="mountPath">The full file path of the directory to which the .wim file has to be mounted.</param>
        /// <param name="options">Specifies how the file is to be treated and what features are to be used.</param>
        /// <exception cref="ArgumentNullException">imageHandle or mountPath is null.</exception>
        /// <exception cref="DirectoryNotFoundException">mountPath does not exist.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        /// <remarks>
        ///     This method maps the contents of the given image in a .wim file to the specified mount directory. After the
        ///     successful completion of this operation, users or applications can access the contents of the image mapped under
        ///     the mount directory. The WIM file containing the image must be opened with <see cref="WimFileAccess.Mount" />
        ///     access. Use the <see cref="UnmountImage(WimHandle)" /> method to unmount the image from the mount directory.
        /// </remarks>
        public static void MountImage(WimHandle imageHandle, string mountPath, WimMountImageOptions options)
        {
            // See if imageHandle is null
            //
            if (imageHandle == null)
            {
                throw new ArgumentNullException("imageHandle");
            }

            // See if mountPath is null
            //
            if (mountPath == null)
            {
                throw new ArgumentNullException("mountPath");
            }

            // See if mount path does not exist
            //
            if (!Directory.Exists(mountPath))
            {
                throw new DirectoryNotFoundException(string.Format("Could not find a part of the path '{0}'", mountPath));
            }

            // Call the native function
            //
            if (!NativeMethods.WIMMountImageHandle(imageHandle, mountPath, (uint) options))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Registers a log file for debugging or tracing purposes from the current WIMGAPI session.
        /// </summary>
        /// <param name="logFile">The full file path of the file to receive debug or tracing information.</param>
        /// <exception cref="ArgumentNullException">logFile is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void RegisterLogFile(string logFile)
        {
            // See if logFile is null
            //
            if (logFile == null)
            {
                throw new ArgumentNullException("logFile");
            }

            // Call the native function
            //
            if (!NativeMethods.WIMRegisterLogFile(logFile, 0))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Registers a function to be called with imaging-specific data for all image handles.
        /// </summary>
        /// <param name="messageCallback">An application-defined callback function.</param>
        /// <returns>The zero-based index of the callback.</returns>
        /// <exception cref="ArgumentNullException">messageCallback is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static int RegisterMessageCallback(WimMessageCallback messageCallback)
        {
            // Call an overload
            //
            return RegisterMessageCallback(messageCallback, null);
        }

        /// <summary>
        ///     Registers a function to be called with imaging-specific data for all image handles.
        /// </summary>
        /// <param name="messageCallback">An application-defined callback method.</param>
        /// <param name="userData">A pointer that specifies an application-defined value to be passed to the callback function.</param>
        /// <returns>-1 if the callback is already registered, otherwise the zero-based index of the callback.</returns>
        /// <exception cref="ArgumentNullException">messageCallback is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static int RegisterMessageCallback(WimMessageCallback messageCallback, object userData)
        {
            // Call an overload
            //
            return RegisterMessageCallback(WimHandle.Null, messageCallback, userData);
        }

        /// <summary>
        ///     Registers a function to be called with imaging-specific data for only the specified WIM file.
        /// </summary>
        /// <param name="wimHandle">An optional <see cref="WimHandle" /> of a .wim file returned by <see cref="CreateFile" />.</param>
        /// <param name="messageCallback">An application-defined callback function.</param>
        /// <returns>The zero-based index of the callback.</returns>
        /// <exception cref="ArgumentNullException">messageCallback is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static int RegisterMessageCallback(WimHandle wimHandle, WimMessageCallback messageCallback)
        {
            // Call an overload
            //
            return RegisterMessageCallback(wimHandle, messageCallback, null);
        }

        /// <summary>
        ///     Registers a function to be called with imaging-specific data for only the specified WIM file.
        /// </summary>
        /// <param name="wimHandle">An optional <see cref="WimHandle" /> of a .wim file returned by <see cref="CreateFile" />.</param>
        /// <param name="messageCallback">An application-defined callback method.</param>
        /// <param name="userData">A pointer that specifies an application-defined value to be passed to the callback function.</param>
        /// <returns>-1 if the callback is already registered, otherwise the zero-based index of the callback.</returns>
        /// <exception cref="ArgumentNullException">messageCallback is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static int RegisterMessageCallback(WimHandle wimHandle, WimMessageCallback messageCallback,
            object userData)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // See if messageCallback is null
            //
            if (messageCallback == null)
            {
                // Throw an ArgumentNullException
                //
                throw new ArgumentNullException("messageCallback");
            }

            // Establish a lock
            //
            lock (LockObject)
            {
                // See if the user wants to register the handler in the global space for all WIMs
                //
                if (wimHandle == WimHandle.Null)
                {
                    // See if the callback is already registered
                    //
                    if (RegisteredCallbacks.IsCallbackRegistered(messageCallback))
                    {
                        // Just exit, the callback is already registered
                        //
                        return -1;
                    }

                    // Add the callback to the globally registered callbacks
                    //
                    if (!RegisteredCallbacks.RegisterCallback(messageCallback, userData))
                    {
                        return -1;
                    }
                }
                else
                {
                    // See if the message callback is already registered
                    //
                    if (RegisteredCallbacks.IsCallbackRegistered(wimHandle, messageCallback))
                    {
                        // Just exit, the callback is already registered
                        //
                        return -1;
                    }

                    // Add the callback to the registered callbacks by handle
                    //
                    RegisteredCallbacks.RegisterCallback(wimHandle, messageCallback, userData);
                }

                // Call the native function
                //
                var hr = NativeMethods.WIMRegisterMessageCallback(wimHandle,
                    wimHandle == WimHandle.Null
                        ? RegisteredCallbacks.GetNativeCallback(messageCallback)
                        : RegisteredCallbacks.GetNativeCallback(wimHandle, messageCallback), IntPtr.Zero);

                // See if the function returned INVALID_CALLBACK_VALUE
                //
                if (hr == INVALID_CALLBACK_VALUE)
                {
                    // Throw a Win32Exception based on the last error code
                    //
                    throw new Win32Exception();
                }

                // Return the zero-based index of the callback
                //
                return (int) hr;
            }
        }

        /// <summary>
        ///     Reactivates a mounted image that was previously mounted to the specified directory.
        /// </summary>
        /// <param name="mountPath">The full file path of the directory to which the .wim file must be remounted.</param>
        /// <exception cref="ArgumentNullException">mountPath is null.</exception>
        /// <exception cref="DirectoryNotFoundException">mountPath does not exist.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void RemountImage(string mountPath)
        {
            // See if mountPath is null
            //
            if (mountPath == null)
            {
                throw new ArgumentNullException("mountPath");
            }

            // See if mount path does not exist
            //
            if (!Directory.Exists(mountPath))
            {
                throw new DirectoryNotFoundException(string.Format("Could not find a part of the path '{0}'", mountPath));
            }

            // Call the native function
            //
            if (!NativeMethods.WIMRemountImage(mountPath, 0))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Marks the image with the given image index as bootable.
        /// </summary>
        /// <param name="wimHandle">
        ///     A <see cref="WimHandle" /> of a Windows® image (.wim) file returned by the
        ///     <see cref="CreateFile" /> method.
        /// </param>
        /// <param name="imageIndex">The one-based index of the image to load. An image file can store multiple images.</param>
        /// <exception cref="ArgumentNullException">wimHandle is null.</exception>
        /// <exception cref="IndexOutOfRangeException">
        ///     index is less than 1 or greater than the number of images in the Windows®
        ///     image file.
        /// </exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        /// <remarks>
        ///     If imageIndex is zero, then none of the images in the .wim file are marked for boot. At any time, only one
        ///     image in a .wim file can be set to be bootable.
        /// </remarks>
        public static void SetBootImage(WimHandle wimHandle, int imageIndex)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // See if the specified index is valid
            //
            if (imageIndex < 1 || imageIndex > GetImageCount(wimHandle))
            {
                throw new IndexOutOfRangeException(string.Format("There is no image at index {0}.", imageIndex));
            }

            // Call the native function
            //
            if (!NativeMethods.WIMSetBootImage(wimHandle, (uint) imageIndex))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Stores information about an image in the Windows® image (.wim) file.
        /// </summary>
        /// <param name="wimHandle">
        ///     A <see cref="WimHandle" /> of an image returned by the <see cref="CreateFile" />,
        ///     <see cref="LoadImage" />, or <see cref="CaptureImage" /> methods.
        /// </param>
        /// <param name="imageInfoXml">An <see cref="IXPathNavigable" /> object that contains information about the volume image.</param>
        /// <exception cref="ArgumentNullException">wimHandle or imageInfoXml is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        /// <remarks>
        ///     If the wimHandle parameter is from the <see cref="CreateFile" /> method, then the XML data must be enclosed by
        ///     &lt;WIM&gt;&lt;/WIM&gt; tags. If the input handle is from the <see cref="LoadImage" /> or
        ///     <see cref="CaptureImage" /> methods, then the XML data must be enclosed by &lt;IMAGE&gt;&lt;/IMAGE&gt; tags.
        /// </remarks>
        public static void SetImageInformation(WimHandle wimHandle, IXPathNavigable imageInfoXml)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // See if imageInfoXml is null
            //
            if (imageInfoXml == null)
            {
                throw new ArgumentNullException("imageInfoXml");
            }

            // Append a unicode file marker to the xml as a string
            //
            var imageInfo = string.Format("\uFEFF{0}", imageInfoXml.CreateNavigator().OuterXml);

            // Allocate enough memory for the info
            //
            var imageInfoPtr = Marshal.StringToHGlobalUni(imageInfo);

            try
            {
                // Call the native function
                //
                if (!NativeMethods.WIMSetImageInformation(wimHandle, imageInfoPtr, (uint) (imageInfo.Length + 1)*2))
                {
                    // Throw a Win32Exception based on the last error code
                    //
                    throw new Win32Exception();
                }
            }
            finally
            {
                // Free the string buffer
                //
                Marshal.FreeHGlobal(imageInfoPtr);
            }
        }

        /// <summary>
        ///     Enables the <see cref="ApplyImage" /> and <see cref="CaptureImage" /> methods to use alternate .wim files for file
        ///     resources. This can enable optimization of storage when multiple images are captured with similar data.
        /// </summary>
        /// <param name="wimHandle">
        ///     A <see cref="WimHandle" /> of a .wim (Windows image) file returned by the
        ///     <see cref="CreateFile" /> method.
        /// </param>
        /// <param name="path">The path of the .wim file to be added to the reference list.</param>
        /// <param name="mode">Specifies whether the .wim file is added to the reference list or replaces other entries.</param>
        /// <param name="options">Specifies options when adding the .wim file to the reference list.</param>
        /// <exception cref="ArgumentNullException">
        ///     wimHandle is null
        ///     -or-
        ///     mode is not WimSetReferenceMode.Replace and path is null.
        /// </exception>
        /// <exception cref="FileNotFoundException">path does not exist.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        /// <remarks>
        ///     If <c>null</c> is passed in for the path parameter and <see cref="WimSetReferenceMode.Replace" /> is passed
        ///     for the mode parameter, then the reference list is completely cleared, and no file resources are extracted during
        ///     the <see cref="ApplyImage" /> method.
        /// </remarks>
        public static void SetReferenceFile(WimHandle wimHandle, string path, WimSetReferenceMode mode,
            WimSetReferenceOptions options)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // See if not replacing and path is null
            //
            if (mode != WimSetReferenceMode.Replace && path == null)
            {
                throw new ArgumentNullException("path");
            }

            // See if path does not exist
            //
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(string.Format("Could not find part of the path '{0}'", path));
            }

            // Call the native function
            //
            if (!NativeMethods.WIMSetReferenceFile(wimHandle, path, (uint) mode | (uint) options))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Sets the location where temporary imaging files are to be stored.
        /// </summary>
        /// <param name="wimHandle">A <see cref="WimHandle" /> of a .wim file returned by the <see cref="CreateFile" /> method.</param>
        /// <param name="path">
        ///     The path where temporary image (.wim) files are to be stored during capture or application. This is
        ///     the directory where the image is captured or applied.
        /// </param>
        /// <exception cref="ArgumentNullException">wimHandle or path is null.</exception>
        /// <exception cref="DirectoryNotFoundException">path does not exist.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void SetTemporaryPath(WimHandle wimHandle, string path)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // See if path is null
            //
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            // See if path does not exist
            //
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException(string.Format("Could not find part of the path '{0}'", path));
            }

            // Call the native function
            //
            if (!NativeMethods.WIMSetTemporaryPath(wimHandle, path))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Enables a large Windows® image (.wim) file to be split into smaller parts for replication or storage on smaller
        ///     forms of media.
        /// </summary>
        /// <param name="wimHandle">A <see cref="WimHandle" /> of a .wim file returned by <see cref="CreateFile" />.</param>
        /// <param name="partPath">The path of the first file piece of the spanned set.</param>
        /// <param name="partSize">
        ///     The size of the initial piece of the spanned set. This value will also be the default size used
        ///     for subsequent pieces.
        /// </param>
        /// <exception cref="ArgumentNullException">wimHandle or partPath is null.</exception>
        /// <exception cref="DirectoryNotFoundException">Directory of partPath does not exist.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void SplitFile(WimHandle wimHandle, string partPath, long partSize)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // See if partPath is null
            //
            if (partPath == null)
            {
                throw new ArgumentNullException("partPath");
            }

            // See if the directory of partPath does not exist
            //
            // ReSharper disable once AssignNullToNotNullAttribute
            if (!Directory.Exists(Path.GetDirectoryName(partPath)))
            {
                throw new DirectoryNotFoundException(string.Format("Could not find part of the path '{0}'",
                    Path.GetDirectoryName(partPath)));
            }

            // Create a copy of part size so it can be safely passed by reference
            //
            var partSizeCopy = partSize;

            // Call the native function
            //
            if (!NativeMethods.WIMSplitFile(wimHandle, partPath, ref partSizeCopy, 0))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Gets the minimum size needed to to create a split WIM.
        /// </summary>
        /// <param name="wimHandle">A <see cref="WimHandle" /> of a .wim file returned by <see cref="CreateFile" />.</param>
        /// <param name="partPath">The path of the first file piece of the spanned set.</param>
        /// <returns>The minimum space required to split the WIM.</returns>
        /// <exception cref="ArgumentNullException">wimHandle or partPath is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static long SplitFile(WimHandle wimHandle, string partPath)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // See if partPath is null
            //
            if (partPath == null)
            {
                throw new ArgumentNullException("partPath");
            }

            // Declare a part size as zero
            //
            long partSize = 0;

            // Call the WIMSplitFile function which should return false and set partSize to the minimum size needed
            //
            if (!NativeMethods.WIMSplitFile(wimHandle, partPath, ref partSize, 0))
            {
                // See if the return code was not ERROR_MORE_DATA
                //
                if (Marshal.GetLastWin32Error() != Win32Error.ERROR_MORE_DATA)
                {
                    // Throw a Win32Exception based on the last error code
                    //
                    throw new Win32Exception();
                }
            }

            return partSize;
        }

        /// <summary>
        ///     Unmounts a mounted image in a Windows® image (.wim) file from the specified directory.
        /// </summary>
        /// <param name="mountPath">The full file path of the directory to which the .wim file was mounted.</param>
        /// <param name="imagePath">The full file name of the .wim file that must be unmounted.</param>
        /// <param name="imageIndex">Specifies the index of the image in the .wim file that must be unmounted.</param>
        /// <param name="commitChanges">
        ///     <c>true</c> to commit changes made to the .wim file if any, otherwise <c>false</c> to
        ///     discard changes.  This parameter has no effect if the .wim file was mounted not to enable edits.
        /// </param>
        /// <exception cref="ArgumentNullException">mountPath or imagePath is null.</exception>
        /// <exception cref="DirectoryNotFoundException">mountPath does not exist.</exception>
        /// <exception cref="FileNotFoundException">imagePath does not exist.</exception>
        /// <exception cref="IndexOutOfRangeException">index is less than 1.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        /// <remarks>
        ///     This method unmaps the contents of the given image in the .wim file from the specified mount directory. After
        ///     the successful completion of this operation, users or applications will not be able to access the contents of the
        ///     image previously mapped under the mount directory.
        /// </remarks>
        public static void UnmountImage(string mountPath, string imagePath, int imageIndex, bool commitChanges)
        {
            // See if mountPath is null
            //
            if (mountPath == null)
            {
                throw new ArgumentNullException("mountPath");
            }

            // See if imagePath is null
            //
            if (imagePath == null)
            {
                throw new ArgumentNullException("imagePath");
            }

            // See if the specified index is valid
            //
            if (imageIndex < 1)
            {
                throw new IndexOutOfRangeException(string.Format("There is no image at index {0}.", imageIndex));
            }

            // See if mount path does not exist
            //
            if (!Directory.Exists(mountPath))
            {
                throw new DirectoryNotFoundException(string.Format("Could not find a part of the path '{0}'", mountPath));
            }

            // See if the image does not exist
            //
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException(string.Format("Could not find a part of the path '{0}'", imagePath));
            }

            // Call the native function
            //
            if (!NativeMethods.WIMUnmountImage(mountPath, imagePath, (uint) imageIndex, commitChanges))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Unmounts a mounted image in a Windows® image (.wim) file from the specified directory.
        /// </summary>
        /// <param name="imageHandle">
        ///     A <see cref="WimHandle" /> of an image previously mounted with
        ///     <see cref="MountImage(WimHandle, string, WimMountImageOptions)" />.
        /// </param>
        /// <exception cref="ArgumentNullException">imageHandle is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Unmount")]
        public static void UnmountImage(WimHandle imageHandle)
        {
            // See if imageHandle is null
            //
            if (imageHandle == null)
            {
                throw new ArgumentNullException("imageHandle");
            }

            // Call the native function
            //
            if (!NativeMethods.WIMUnmountImageHandle(imageHandle, 0))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }

            // Close the image handle
            //
            imageHandle.Close();
        }

        /// <summary>
        ///     Unregisters a log file for debugging or tracing purposes from the current WIMGAPI session.
        /// </summary>
        /// <param name="logFile">
        ///     The path to a log file previously specified in a call to the <see cref="RegisterLogFile" />
        ///     method.
        /// </param>
        /// <exception cref="ArgumentNullException">logFile is null.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void UnregisterLogFile(string logFile)
        {
            // See if logFile is null
            //
            if (logFile == null)
            {
                throw new ArgumentNullException("logFile");
            }

            // Call the native function
            //
            if (!NativeMethods.WIMUnregisterLogFile(logFile))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Unregisters a method from being called with imaging-specific data for all image handles.
        /// </summary>
        /// <param name="messageCallback">An application-defined callback method.</param>
        /// <exception cref="ArgumentOutOfRangeException">messageCallback is not registered.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void UnregisterMessageCallback(WimMessageCallback messageCallback)
        {
            UnregisterMessageCallback(WimHandle.Null, messageCallback);
        }

        /// <summary>
        ///     Unregisters a method from being called with imaging-specific data for only the specified WIM file.
        /// </summary>
        /// <param name="wimHandle">A <see cref="WimHandle" /> of a .wim file returned by <see cref="CreateFile" />.</param>
        /// <param name="messageCallback">An application-defined callback method.</param>
        /// <exception cref="ArgumentOutOfRangeException">messageCallback is not registered.</exception>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        public static void UnregisterMessageCallback(WimHandle wimHandle, WimMessageCallback messageCallback)
        {
            // See if wimHandle is null
            //
            if (wimHandle == null)
            {
                throw new ArgumentNullException("wimHandle");
            }

            // Establish a lock
            //
            lock (LockObject)
            {
                // See if wimHandle was not specified but the message callback was
                //
                if (wimHandle == WimHandle.Null && messageCallback != null)
                {
                    // See if the message callback is registered
                    //
                    if (!RegisteredCallbacks.IsCallbackRegistered(messageCallback))
                    {
                        // Throw an ArgumentOutOfRangeException
                        //
                        throw new ArgumentOutOfRangeException("messageCallback", "Message callback is not registered.");
                    }
                }

                // See if the wimHandle and callback were specified
                //
                if (wimHandle != WimHandle.Null && messageCallback != null)
                {
                    // See if the callback is registered
                    //
                    if (!RegisteredCallbacks.IsCallbackRegistered(wimHandle, messageCallback))
                    {
                        // Throw an ArgumentOutOfRangeException
                        //
                        throw new ArgumentOutOfRangeException("messageCallback",
                            "Message callback is not registered under this handle.");
                    }
                }

                // See if the message callback is null, meaning the user wants to unregister all callbacks
                //
                var success = messageCallback == null
                    ?
                    // Call the native function and pass null for the callback
                    //
                    NativeMethods.WIMUnregisterMessageCallback(wimHandle, null)
                    : NativeMethods.WIMUnregisterMessageCallback(wimHandle,
                        wimHandle == WimHandle.Null
                            ? RegisteredCallbacks.GetNativeCallback(messageCallback)
                            :
                            // Call the native function and pass the appropriate callback
                            //
                            RegisteredCallbacks.GetNativeCallback(wimHandle, messageCallback));

                // See if the native call succeeded
                //
                if (!success)
                {
                    // Throw a Win32Exception based on the last error code
                    //
                    throw new Win32Exception();
                }

                // See if a single globally registered callback should be removed
                //
                if (wimHandle == WimHandle.Null && messageCallback != null)
                {
                    // Unregister the globally registered callback
                    //
                    RegisteredCallbacks.UnregisterCallback(messageCallback);
                }

                // See if a single registered callback by handle should be removed
                //
                if (wimHandle != WimHandle.Null && messageCallback != null)
                {
                    // Unregister the callback for the handle
                    //
                    RegisteredCallbacks.UnregisterCallback(wimHandle, messageCallback);
                }

                // See if all registered callbacks for this handle should be removed
                //
                if (wimHandle != WimHandle.Null && messageCallback == null)
                {
                    // Unregister all callbacks for this handle
                    //
                    RegisteredCallbacks.UnregisterCallbacks(wimHandle);
                }

                // See if all registered callbacks by handle and all globally registered callbacks should be removed
                //
                if (wimHandle == WimHandle.Null && messageCallback == null)
                {
                    // Unregister all callbacks
                    //
                    RegisteredCallbacks.UnregisterCallbacks();
                }
            } // Release lock
        }

        /// <summary>
        ///     Closes an open Windows® imaging (.wim) file or image handle.
        /// </summary>
        /// <param name="handle">A <see cref="WimHandle" /> to an open, image-based object.</param>
        /// <returns><c>true</c> if the handle was successfully closed, otherwise <c>false</c>.</returns>
        /// <exception cref="Win32Exception">The Windows® Imaging API reported a failure.</exception>
        internal static bool CloseHandle(IntPtr handle)
        {
            // Call the native function
            //
            if (!NativeMethods.WIMCloseHandle(handle))
            {
                // Throw a Win32Exception based on the last error code
                //
                throw new Win32Exception();
            }

            return true;
        }
    }
}