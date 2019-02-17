using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using DWORD = System.UInt32;

// ReSharper disable RedundantNameQualifier

namespace Microsoft.Wim
{
    public static partial class WimgApi
    {
        /// <summary>
        ///     The calling convention to use when calling the WIMGAPI.
        /// </summary>
        internal const CallingConvention WimgApiCallingConvention = CallingConvention.Winapi;

        /// <summary>
        ///     The character set to use when calling the WIMGAPI.
        /// </summary>
        internal const CharSet WimgApiCharSet = CharSet.Unicode;

        /// <summary>
        ///     The name of the assembly containing the Windows® Imaging API (WIMGAPI).
        /// </summary>
        internal const string WimgApiDllName = "WimgApi.dll";

        /// <summary>
        ///     Contains declarations for external native functions.
        /// </summary>
        private static class NativeMethods
        {
            /// <summary>
            ///     Applies an image to a directory path from a Windows® image (.wim) file.
            /// </summary>
            /// <param name="hImage">A handle to a volume image returned by the WIMLoadImage or WIMCaptureImage functions.</param>
            /// <param name="pszPath">
            ///     A pointer to a null-terminated string containing the root drive or the directory path where the
            ///     image data will be applied.
            /// </param>
            /// <param name="dwApplyFlags">Specifies how the file is to be treated and what features are to be used.</param>
            /// <returns>
            ///     If the function succeeds, the return value is an open handle to the specified image file.
            ///     If the function fails, the return value is NULL. To obtain extended error information, call the GetLastError
            ///     function.
            /// </returns>
            /// <remarks>
            ///     To obtain more information during an image apply, see the WIMRegisterMessageCallback function.
            ///     To obtain the list of files in an image without actually applying the image, specify the WIM_FLAG_NO_APPLY flag and
            ///     register a callback that handles the WIM_MSG_PROCESS message. To obtain additional file information from the
            ///     WIM_MSG_FILEINFO message, specify the WIM_FLAG_FILEINFO.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMApplyImage(WimHandle hImage, string pszPath, uint dwApplyFlags);

            /// <summary>
            ///     Captures an image from a directory path and stores it in an image file.
            /// </summary>
            /// <param name="hWim">The handle to a .wim file returned by WIMCreateFile.</param>
            /// <param name="pszPath">
            ///     A pointer to a null-terminated string containing the root drive or directory path from where the
            ///     image data is captured.
            /// </param>
            /// <param name="dwCaptureFlags">Specifies the features to use during the capture.</param>
            /// <returns>
            ///     If the function succeeds, the return value is an open handle to the specified image file.
            ///     If the function fails, the return value is NULL. To obtain extended error information, call the GetLastError
            ///     function.
            /// </returns>
            /// <remarks>To obtain information during an image capture, see the WIMRegisterMessageCallback function.</remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            public static extern WimHandle WIMCaptureImage(WimHandle hWim, string pszPath, uint dwCaptureFlags);

            /// <summary>
            ///     Closes an open Windows® imaging (.wim) file or image handle.
            ///     <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/dd851955.aspx">WIMCloseHandle</a>
            /// </summary>
            /// <param name="hObject">The handle to an open, image-based object.</param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To obtain extended error information, call the GetLastError
            ///     function.
            /// </returns>
            /// <remarks>
            ///     The WIMCloseHandle function closes handles to the following objects:
            ///     A .wim file
            ///     A volume image
            ///     If there are any open volume image handles, closing a .wim file fails.
            ///     Use the WIMCloseHandle function to close handles returned by calls to the WIMCreateFile, WIMLoadImage, and
            ///     WIMCaptureImage functions.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMCloseHandle(IntPtr hObject);

            /// <summary>
            ///     Saves the changes from a mounted image back to the .wim file.
            /// </summary>
            /// <param name="hImage">
            ///     A handle to an image opened by the WIMLoadImage function. The .wim file must have been opened with
            ///     a WIM_GENERIC_MOUNT flag in call to WIMCreateFile.
            /// </param>
            /// <param name="dwCommitFlags">Specifies the features to use during the capture.</param>
            /// <param name="phNewImageHandle">
            ///     Pointer to receive the new image handle if the WIM_COMMIT_FLAG_APPEND flag is specified.
            ///     If this parameter is NULL, the new image will be closed automatically.
            /// </param>
            /// <returns>
            ///     Returns TRUE and sets the LastError to ERROR_SUCCESS on the successful completion of this function. Returns
            ///     FALSE in case of a failure and sets the LastError to the appropriate Win32® error value.
            /// </returns>
            /// <remarks>
            ///     The WIMCommitImageHandle function updates the contents of the given image in a .wim file to reflect the
            ///     contents of the specified mount directory. After the successful completion of this operation, users or applications
            ///     can still access the contents of the image mapped under the mount directory. Use the WIMUnmountImageHandle function
            ///     to unmount the image from the mount directory using an image handle.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMCommitImageHandle(WimHandle hImage, uint dwCommitFlags,
                out WimHandle phNewImageHandle);

            /// <summary>
            ///     Copies an existing file to a new file. Notifies the application of its progress through a callback function. If the
            ///     source file has verification data, the contents of the file are verified during the copy operation.
            /// </summary>
            /// <param name="pszExistingFileName">
            ///     A pointer to a null-terminated string that specifies the name of an existing .wim
            ///     file.
            /// </param>
            /// <param name="pszNewFileName">A pointer to a null-terminated string that specifies the name of the new file.</param>
            /// <param name="pProgressRoutine">
            ///     The address of a callback function of type LPPROGRESS_ROUTINE that is called each time
            ///     another portion of the file has been copied. This parameter can be NULL.
            /// </param>
            /// <param name="pvData">An argument to be passed to the callback function. This parameter can be NULL.</param>
            /// <param name="pbCancel">
            ///     If this flag is set to TRUE during the copy operation, the operation is canceled. Otherwise, the
            ///     copy operation continues to completion.
            /// </param>
            /// <param name="dwCopyFlags">A flag that specifies how the file is to be copied.</param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To obtain extended error information, call the GetLastError
            ///     function.
            ///     If pProgressRoutine returns PROGRESS_CANCEL because the user cancels the operation, the WIMCopyFile function will
            ///     return zero and set the LastError to ERROR_REQUEST_ABORTED. In this case, the partially copied destination file is
            ///     deleted.
            ///     If pProgressRoutine returns PROGRESS_STOP because the user stops the operation, WIMCopyFile will return zero and
            ///     set the LastError to ERROR_REQUEST_ABORTED. In this case, the partially copied destination file is left intact.
            ///     If the source file contains verification information, an integrity check is performed on each block as it is
            ///     copied. If the integrity check fails, the WIMCopyFile function will return zero and set the LastError to
            ///     ERROR_FILE_CORRUPT.
            /// </returns>
            /// <remarks>
            ///     This function does not preserve extended attributes, security attributes, OLE-structured storage, NTFS file system
            ///     alternate data streams, or file attributes.
            ///     The WIMCopyFile function copies only the default stream of the source file, so the StreamSize and
            ///     StreamBytesTransferred parameters to the CopyProgressRoutine function will always match TotalFileSize and
            ///     TotalBytesTransferred, respectively. The value of the dwStreamNumber parameter will always be 1 and the value of
            ///     the dwCallBackReason parameter will always be CALLBACK_CHUNK_FINISHED.
            ///     If the destination file already exists and has the FILE_ATTRIBUTE_HIDDEN or FILE_ATTRIBUTE_READONLY attribute set,
            ///     this function fails with ERROR_ACCESS_DENIED.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMCopyFile(string pszExistingFileName, string pszNewFileName,
                Kernel32.CopyProgressRoutine pProgressRoutine, IntPtr pvData,
                [MarshalAs(UnmanagedType.Bool)] ref bool pbCancel, uint dwCopyFlags);

            /// <summary>
            ///     Makes a new image file or opens an existing image file.
            /// </summary>
            /// <param name="pszWimPath">
            ///     A pointer to a null-terminated string that specifies the name of the file to create or to
            ///     open.
            /// </param>
            /// <param name="dwDesiredAccess">
            ///     Specifies the type of access to the object. An application can obtain read access, write
            ///     access, read/write access, or device query access.
            /// </param>
            /// <param name="dwCreationDisposition">
            ///     Specifies which action to take on files that exist, and which action to take when
            ///     files do not exist.
            /// </param>
            /// <param name="dwFlagsAndAttributes">Specifies special actions to be taken for the specified file.</param>
            /// <param name="dwCompressionType">
            ///     Specifies the compression mode to be used for a newly created image file. If the file
            ///     already exists, then this value is ignored.
            /// </param>
            /// <param name="pdwCreationResult">
            ///     A pointer to a variable that receives one of the following creation-result values. If
            ///     this information is not required, specify NULL.
            /// </param>
            /// <returns>
            ///     If the function succeeds, the return value is an open handle to the specified image file.
            ///     If the function fails, the return value is NULL. To obtain extended error information, call the GetLastError
            ///     function.
            /// </returns>
            /// <remarks>Use the WIMCloseHandle function to close the handle returned by the WIMCreateFile function.</remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            public static extern WimHandle WIMCreateFile(string pszWimPath, uint dwDesiredAccess,
                uint dwCreationDisposition, uint dwFlagsAndAttributes, uint dwCompressionType,
                out WimCreationResult pdwCreationResult);

            /// <summary>
            ///     Removes an image from within a .wim (Windows image) file so it cannot be accessed. However, the file resources are
            ///     still available for use by the WIMSetReferenceFile function.
            /// </summary>
            /// <param name="hWim">
            ///     The handle to a .wim file returned by the WIMCreateFile function. This handle must have
            ///     WIM_GENERIC_WRITE access to delete the image. Split .wim files are not supported and the .wim file cannot have any
            ///     open images.
            /// </param>
            /// <param name="dwImageIndex">
            ///     Specifies the one-based index of the image to delete. A .wim file might have multiple images
            ///     stored within it.
            /// </param>
            /// <returns>
            ///     If the function succeeds, then the return value is nonzero.
            ///     If the function fails, then the return value is zero. To obtain extended error information, call GetLastError.
            ///     If there is only one image in the specified .wim file, then the WIMDeleteImage function will fail and set the
            ///     LastError to ERROR_ACCESS_DENIED.
            /// </returns>
            /// <remarks>
            ///     You must call the WIMSetTemporaryPath function before calling the WIMDeleteImage function so the image
            ///     metadata for the image can be extracted and processed from the temporary location.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMDeleteImage(WimHandle hWim, uint dwImageIndex);

            /// <summary>
            ///     Removes images from all directories where they have been previously mounted.
            /// </summary>
            /// <param name="dwDeleteFlags">Specifies which types of images are to be removed.</param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To obtain extended error information, call the GetLastError
            ///     function.
            /// </returns>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMDeleteImageMounts(uint dwDeleteFlags);

            /// <summary>
            ///     Transfers the data of an image from one Windows® image (.wim) file to another.
            /// </summary>
            /// <param name="hImage">A handle to an image opened by the WIMLoadImage function.</param>
            /// <param name="hWim">
            ///     A handle to a .wim file returned by the WIMCreateFile function. This handle must have
            ///     WIM_GENERIC_WRITE access to accept the exported image. Split .wim files are not supported.
            /// </param>
            /// <param name="dwFlags">Specifies how the image will be exported to the destination .wim file.</param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To obtain extended error information, call the GetLastError
            ///     function.
            /// </returns>
            /// <remarks>
            ///     You must call the WIMSetTemporaryPath function for both the source and the destination .wim files before calling
            ///     the WIMExportImage function.
            ///     If zero is passed in for the dwFlags parameter and the image is already stored in the destination, the function
            ///     will return FALSE and set the LastError to ERROR_ALREADY_EXISTS.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMExportImage(WimHandle hImage, WimHandle hWim, uint dwFlags);

            /// <summary>
            ///     Extracts a file from within a Windows® image (.wim) file to a specified location.
            /// </summary>
            /// <param name="hImage">A handle to an image opened by the WIMLoadImage function.</param>
            /// <param name="pszImagePath">A pointer to a file path inside the image.</param>
            /// <param name="pszDestinationPath">
            ///     A pointer to the full file path of the directory where the image path is to be
            ///     extracted.
            /// </param>
            /// <param name="dwExtractFlags">Reserved. Must be zero.</param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To
            ///     obtain extended error information, call the GetLastError function.
            /// </returns>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMExtractImagePath(WimHandle hImage, string pszImagePath,
                string pszDestinationPath, uint dwExtractFlags);

            /// <summary>
            ///     Returns the number of volume images stored in an image file.
            /// </summary>
            /// <param name="hWim">The handle to a .wim file returned by WIMCreateFile.</param>
            /// <param name="pWimInfo">A pointer to a WIM_INFO structure that is returned with information about the .wim file.</param>
            /// <param name="cbWimInfo">A DWORD value indicating the size of the pWimInfo buffer in which it passes.</param>
            /// <returns>
            ///     If the function succeeds, then the return value is non-zero.
            ///     If the function fails, then the return value is zero. To obtain extended error information, call GetLastError.
            /// </returns>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMGetAttributes(WimHandle hWim, IntPtr pWimInfo, uint cbWimInfo);

            /// <summary>
            ///     Returns the number of volume images stored in a Windows® image (.wim) file.
            /// </summary>
            /// <param name="hWim">A handle to a .wim file returned by the WIMCreateFile function.</param>
            /// <returns>
            ///     The return value is the number of images in the .wim file. If this value is zero, then the image file is
            ///     invalid or does not contain any images that can be applied.
            /// </returns>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            public static extern uint WIMGetImageCount(WimHandle hWim);

            /// <summary>
            ///     Returns information about an image within the .wim (Windows image) file.
            /// </summary>
            /// <param name="hImage">A handle returned by the WIMCreateFile, WIMLoadImage, or WIMCaptureImage function.</param>
            /// <param name="ppvImageInfo">
            ///     A pointer to a buffer that receives the address of the XML information about the volume
            ///     image. When the function returns, this value contains the address of an allocated buffer, containing XML
            ///     information about the volume image.
            /// </param>
            /// <param name="pcbImageInfo">
            ///     A pointer to a variable that specifies the size, in bytes, of the buffer pointed to by the
            ///     value of the ppvImageInfo parameter.
            /// </param>
            /// <returns></returns>
            /// <remarks>
            ///     When the function succeeds, then the data describing the image is in Unicode XML format. Use the LocalFree
            ///     function to free the memory pointed to by the ppvImageInfo parameter when no longer needed.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMGetImageInformation(WimHandle hImage, out IntPtr ppvImageInfo,
                out uint pcbImageInfo);

            /// <summary>
            ///     Returns the count of callback routines currently registered by the imaging library.
            /// </summary>
            /// <param name="hWim">The handle to a .wim file returned by WIMCreateFile.</param>
            /// <returns>The return value is the number of message callback functions currently registered.</returns>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            public static extern uint WIMGetMessageCallbackCount(WimHandle hWim);

            /// <summary>
            ///     Returns a WIM handle and an image handle corresponding to a mounted image directory.
            /// </summary>
            /// <param name="pszMountPath">
            ///     A pointer to the full file path of the directory to which the .wim file has been mounted.
            ///     This parameter is required and cannot be NULL.
            /// </param>
            /// <param name="dwFlags">Specifies how the file is to be treated and what features are to be used.</param>
            /// <param name="phWimHandle">
            ///     Pointer to receive a WIM handle corresponding to the image mounted at the specified path.
            ///     This parameter is required and cannot be NULL.
            /// </param>
            /// <param name="phImageHandle">
            ///     Pointer to receive an WIM handle corresponding to the image mounted at the specified path.
            ///     This parameter is required and cannot be NULL.
            /// </param>
            /// <returns>
            ///     Returns TRUE and sets the LastError to ERROR_SUCCESS on the successful completion of this function. Returns
            ///     FALSE in case of a failure and sets the LastError to the appropriate Win32® error value.
            /// </returns>
            /// <remarks>Use the WIMUnmountImageHandle function to unmount the image from the mount directory.</remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMGetMountedImageHandle(string pszMountPath, uint dwFlags,
                out WimHandle phWimHandle, out WimHandle phImageHandle);

            /// <summary>
            ///     Returns a list of images that are currently mounted.
            /// </summary>
            /// <param name="fInfoLevelId">A class of attribute information to retrieve.</param>
            /// <param name="pdwImageCount">A pointer to a DWORD that receives the number of mounted images.</param>
            /// <param name="pMountInfo">
            ///     Pointer to a variable that receives the array of mounted image structures. The size of the
            ///     information written varies depending on the type of structured defined by the fInfoLevelId parameter.
            /// </param>
            /// <param name="cbMountInfoLength">The size of the buffer pointed to by the pMountInfo parameter, in bytes.</param>
            /// <param name="pcbReturnLength">
            ///     A pointer to a variable in which the function returns the size of the requested
            ///     information. If the function was successful, this is the size of the information written to the buffer pointed to
            ///     by the pMountInfo parameter, but if the buffer was too small; this is the minimum size of buffer needed to receive
            ///     the information successfully.
            /// </param>
            /// <returns>
            ///     If the function succeeds, then the return value is nonzero. If the function fails, then the return value is
            ///     zero. To obtain extended error information, call the GetLastError function. If the buffer specified by the
            ///     cbMountInfoLength parameter is not large enough to hold the data, the function set LastError to
            ///     ERROR_INSUFFICIENT_BUFFER and stores the required buffer size in the variable pointed to by pcbReturnLength.
            /// </returns>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMGetMountedImageInfo(WimMountedImageInfoLevels fInfoLevelId,
                out uint pdwImageCount, [Out, Optional] IntPtr pMountInfo, uint cbMountInfoLength,
                out uint pcbReturnLength);

            /// <summary>
            ///     Queries the state of a mounted image handle.
            /// </summary>
            /// <param name="hImage">A handle to an image that has been mounted</param>
            /// <param name="fInfoLevelId">A class of attribute information to retrieve.</param>
            /// <param name="pMountInfo">
            ///     Pointer to a variable that receives mounted image structures. The size of the information
            ///     written varies depending on the type of structured defined by the fInfoLevelId.
            /// </param>
            /// <param name="cbMountInfoLength">The size of the buffer pointed to by the pMountInfo parameter, in bytes</param>
            /// <param name="pcbReturnLength">
            ///     A pointer to a variable which contains the result of a function call that returns the
            ///     size of the requested information. If the function was successful, this is the size of the information written to
            ///     the buffer pointed to by the pMountInfo parameter; if the buffer was too small, then this is the minimum size of
            ///     buffer needed to receive the information successfully.
            /// </param>
            /// <returns>
            ///     If the function succeeds, then the return value is nonzero. If the function fails, then the return value is
            ///     zero. To obtain extended error information, call the GetLastError function. If the buffer specified by the
            ///     cbMountInfoLength parameter is not large enough to hold the data, the function sets the value of LastError to
            ///     ERROR_INSUFFICIENT_BUFFER and stores the required buffer size in the variable pointed to by pcbReturnLength.
            /// </returns>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMGetMountedImageInfoFromHandle(WimHandle hImage,
                WimMountedImageInfoLevels fInfoLevelId, IntPtr pMountInfo, uint cbMountInfoLength,
                out uint pcbReturnLength);

            /// <summary>
            ///     Loads a volume image from a Windows® image (.wim) file.
            /// </summary>
            /// <param name="hWim">A handle to a .wim file returned by the WIMCreateFile function.</param>
            /// <param name="dwImageIndex">Specifies the one-based index of the image to load. An image file may store multiple images.</param>
            /// <returns>
            ///     If the function succeeds, then the return value is a handle to an object representing the volume image. If the
            ///     function fails, then the return value is NULL. To obtain extended error information, call the GetLastError
            ///     function.
            /// </returns>
            /// <remarks>
            ///     You must call the WIMSetTemporaryPath function before calling the WIMLoadImage function so the image metadata can
            ///     be extracted and processed from the temporary location.
            ///     Use the WIMCloseHandle function to unload the volume image.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            public static extern WimHandle WIMLoadImage(WimHandle hWim, uint dwImageIndex);

            /// <summary>
            ///     Mounts an image in a Windows® image (.wim) file to the specified directory.
            /// </summary>
            /// <param name="pszMountPath">
            ///     A pointer to the full file path of the directory to which the .wim file has to be mounted.
            ///     This parameter is required and cannot be NULL. The specified path must not exceed MAX_PATH characters in length.
            /// </param>
            /// <param name="pszWimFileName">
            ///     A pointer to the full file name of the .wim file that has to be mounted. This parameter is
            ///     required and cannot be NULL.
            /// </param>
            /// <param name="dwImageIndex">An index of the image in the .wim file that has to be mounted.</param>
            /// <param name="pszTempPath">
            ///     A pointer to the full file path to the temporary directory in which changes to the .wim file
            ///     can be tracked. If this parameter is NULL, the image will not be mounted for edits.
            /// </param>
            /// <returns>
            ///     Returns TRUE and sets the LastError to ERROR_SUCCESS on the successful completion of this function. Returns
            ///     FALSE in case of a failure and sets the LastError to the appropriate Win32® error value.
            /// </returns>
            /// <remarks>
            ///     The WIMMountImage function maps the contents of the given image in a .wim file to the specified mount directory.
            ///     After the successful completion of this operation, users or applications can access the contents of the image
            ///     mapped under the mount directory.
            ///     Use the WIMUnmountImage function to unmount the image from the mount directory.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMMountImage(string pszMountPath, string pszWimFileName, uint dwImageIndex,
                [Optional] string pszTempPath);

            /// <summary>
            ///     Mounts an image in a Windows® image (.wim) file to the specified directory.
            /// </summary>
            /// <param name="hImage">
            ///     A handle to a volume image returned by the WIMLoadImage or WIMCaptureImage function. The WIM file
            ///     must have been opened with WIM_GENERIC_MOUNT flag in call to WIMCreateFile.
            /// </param>
            /// <param name="pszMountPath">
            ///     A pointer to the full file path of the directory to which the .wim file has been mounted.
            ///     This parameter is required and cannot be NULL. The specified path must not exceed MAX_PATH characters in length.
            /// </param>
            /// <param name="dwMountFlags">Specifies how the file is to be treated and what features are to be used.</param>
            /// <returns>
            ///     Returns TRUE and sets the LastError to ERROR_SUCCESS on the successful completion of this function. Returns
            ///     FALSE in case of a failure and sets the LastError to the appropriate Win32® error value.
            /// </returns>
            /// <remarks>
            ///     The WIMMountImageHandle function maps the contents of the given image in a .wim file to the specified mount
            ///     directory. After the successful completion of this operation, users or applications can access the contents of the
            ///     image mapped under the mount directory. The WIM file containing the image must be opened with WIM_GENERIC_MOUNT
            ///     access. Use the WIMUnmountImageHandle function to unmount the image from the mount directory.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMMountImageHandle(WimHandle hImage, string pszMountPath, uint dwMountFlags);

            /// <summary>
            ///     Registers a log file for debugging or tracing purposes into the current WIMGAPI session.
            /// </summary>
            /// <param name="pszLogFile">
            ///     A pointer to the full file path of the file to receive debug or tracing information. This
            ///     parameter is required and cannot be NULL.
            /// </param>
            /// <param name="dwFlags">Reserved. Must be zero.</param>
            /// <returns>
            ///     Returns TRUE and sets the LastError to ERROR_SUCCESS on the successful completion of this function. Returns
            ///     FALSE in case of a failure and sets the LastError to the appropriate Win32® error value.
            /// </returns>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMRegisterLogFile(string pszLogFile, uint dwFlags);

            /// <summary>
            ///     Registers a function to be called with imaging-specific data.
            /// </summary>
            /// <param name="hWim">The handle to a .wim file returned by WIMCreateFile.</param>
            /// <param name="fpMessageProc">
            ///     A pointer to an application-defined callback function. For more information, see the
            ///     WIMMessageCallback function.
            /// </param>
            /// <param name="pvUserData">A pointer that specifies an application-defined value to be passed to the callback function.</param>
            /// <returns>
            ///     If the function succeeds, then the return value is the zero-based index of the callback. If the function
            ///     fails, then the return value is INVALID_CALLBACK_VALUE (0xFFFFFFFF). To obtain extended error information, call the
            ///     GetLastError function.
            /// </returns>
            /// <remarks>
            ///     If a WIM handle is specified, the callback function receives messages for only that WIM file. If no handle is
            ///     specified, then the callback function receives messages for all image handles.
            ///     Call the WIMUnregisterMessageCallback function when the callback function is no longer required.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            public static extern uint WIMRegisterMessageCallback([Optional] WimHandle hWim,
                WimgApi.WIMMessageCallback fpMessageProc, IntPtr pvUserData);

            /// <summary>
            ///     Reactivates a mounted image that was previously mounted to the specified directory.
            /// </summary>
            /// <param name="pszMountPath">
            ///     A pointer to the full file path of the directory to which the .wim file must be remounted.
            ///     This parameter is required and cannot be NULL.
            /// </param>
            /// <param name="dwFlags">Reserved. Must be zero.</param>
            /// <returns>
            ///     Returns TRUE and sets the LastError to ERROR_SUCCESS on the successful completion of this function. Returns
            ///     FALSE in case of a failure and sets the LastError to the appropriate Win32® error value.
            /// </returns>
            /// <remarks>
            ///     The WIMRemountImage function maps the contents of the given image in a .wim file to the specified mount
            ///     directory. After the successful completion of this operation, users or applications can access the contents of the
            ///     image mapped under the mount directory. Use the WIMUnmountImage function to unmount the image from the mount
            ///     directory.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMRemountImage(string pszMountPath, uint dwFlags);

            /// <summary>
            ///     Marks the image with the given image index as bootable.
            /// </summary>
            /// <param name="hWim">A handle to a Windows® image (.wim) file returned by the WIMCreateFile function.</param>
            /// <param name="dwImageIndex">The one-based index of the image to load. An image file can store multiple images.</param>
            /// <returns>
            ///     If the function succeeds, then the return value is nonzero.
            ///     If the function fails, then the return value is zero. To obtain extended error information, call the GetLastError
            ///     function.
            /// </returns>
            /// <remarks>
            ///     If the input value for the dwImageIndex is zero, then none of the images in the .wim file are marked for boot.
            ///     At any time, only one image in a .wim file can be set to be bootable.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMSetBootImage(WimHandle hWim, uint dwImageIndex);

            /// <summary>
            ///     Stores information about an image in the Windows® image (.wim) file.
            /// </summary>
            /// <param name="hImage">A handle returned by the WIMCreateFile, WIMLoadImage, or WIMCaptureImage functions.</param>
            /// <param name="pvImageInfo">A pointer to a buffer that contains information about the volume image.</param>
            /// <param name="cbImageInfo">Specifies the size, in bytes, of the buffer pointed to by the pvImageInfo parameter.</param>
            /// <returns>
            ///     If the function succeeds, then the return value is nonzero.
            ///     If the function fails, then the return value is zero. To obtain extended error information, call the GetLastError
            ///     function.
            /// </returns>
            /// <remarks>
            ///     The data buffer being passed into the function must be the memory representation of a Unicode XML file. Calling
            ///     this function replaces any customized image data, so, to preserve existing XML information, call the
            ///     WIMGetImageInformation function and append or edit the data.
            ///     If the input handle is from the WIMCreateFile function, then the XML data must be enclosed by <WIM></WIM> tags. If
            ///     the input handle is from the WIMLoadImage or WIMCaptureImage functions, then the XML data must be enclosed by
            ///     <IMAGE></IMAGE> tags.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMSetImageInformation(WimHandle hImage, IntPtr pvImageInfo, uint cbImageInfo);

            /// <summary>
            ///     Enables the WIMApplyImage and WIMCaptureImage functions to use alternate .wim files for file resources. This can
            ///     enable optimization of storage when multiple images are captured with similar data.
            /// </summary>
            /// <param name="hWim">A handle to a .wim (Windows image) file returned by the WIMCreateFile function.</param>
            /// <param name="pszPath">
            ///     A pointer to a null-terminated string containing the path of the .wim file to be added to the
            ///     reference list.
            /// </param>
            /// <param name="dwFlags">
            ///     Specifies how the .wim file is added to the reference list. This parameter must include one of
            ///     the following two values.
            /// </param>
            /// <returns>
            ///     If the function succeeds, then the return value is nonzero.
            ///     If the function fails, then the return value is zero. To obtain extended error information, call the GetLastError
            ///     function.
            /// </returns>
            /// <remarks>
            ///     If NULL is passed in for the pszPath parameter and WIM_REFERENCE_REPLACE is passed for the dwFlags parameter,
            ///     then the reference list is completely cleared, and no file resources are extracted during the WIMApplyImage
            ///     function.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMSetReferenceFile(WimHandle hWim, string pszPath, uint dwFlags);

            /// <summary>
            ///     Sets the location where temporary imaging files are to be stored.
            /// </summary>
            /// <param name="hWim">A handle to a .wim file returned by the WIMCreateFile function.</param>
            /// <param name="pszPath">
            ///     A pointer to a null-terminated string, indicating the path where temporary image (.wim) files are
            ///     to be stored during capture or application. This is the directory where the image is captured or applied.
            /// </param>
            /// <returns>
            ///     If the function succeeds, then the return value is nonzero.
            ///     If the function fails, then the return value is zero. To obtain extended error information, call GetLastError.
            /// </returns>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMSetTemporaryPath(WimHandle hWim, string pszPath);

            /// <summary>
            ///     Enables a large Windows® image (.wim) file to be split into smaller parts for replication or storage on smaller
            ///     forms of media.
            /// </summary>
            /// <param name="hWim">A handle to a .wim file returned by WIMCreateFile.</param>
            /// <param name="pszPartPath">
            ///     A pointer to a null-terminated string containing the path of the first file piece of the
            ///     spanned set.
            /// </param>
            /// <param name="pliPartSize">
            ///     A pointer to a LARGE_INTEGER, specifying the size of the initial piece of the spanned set.
            ///     This value will also be the default size used for subsequent pieces, unless altered by a response to the
            ///     WIM_MSG_SPLIT message. If the size specified is insufficient to create the first part of the spanned .wim file, the
            ///     value is filled in with the minimum space required. If a single file is larger than the value specified, one of the
            ///     split .swm files that results will be larger than the specified value in order to accommodate the large file. See
            ///     Remarks.
            /// </param>
            /// <param name="dwFlags">Reserved. Must be zero.</param>
            /// <returns>
            ///     If the function succeeds, then the return value is nonzero.
            ///     If the function fails, then the return value is zero. To obtain extended error information, call GetLastError.
            /// </returns>
            /// <remarks>
            ///     To obtain the minimum space required for the initial .wim file, set the contents of the pliPartSize parameter to
            ///     zero and call the WIMSplitFile function. The function will return FALSE and set the LastError function to
            ///     ERROR_MORE_DATA, and the contents of the pliPartSize parameter will be set to the minimum space required.
            ///     This function creates many parts that are required to contain the resources of the original .wim file. The calling
            ///     application may alter the path and size of subsequent pieces by responding to the WIM_MSG_SPLIT message.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMSplitFile(WimHandle hWim, string pszPartPath, ref long pliPartSize,
                uint dwFlags);

            /// <summary>
            ///     Unmounts a mounted image in a Windows® image (.wim) file from the specified directory.
            /// </summary>
            /// <param name="pszMountPath">
            ///     A pointer to the full file path of the directory to which the .wim file was mounted. This
            ///     parameter is required and cannot be NULL.
            /// </param>
            /// <param name="pszWimFileName">
            ///     A pointer to the full file name of the .wim file that must be unmounted. This parameter is
            ///     required and cannot be NULL.
            /// </param>
            /// <param name="dwImageIndex">Specifies the index of the image in the .wim file that must be unmounted.</param>
            /// <param name="bCommitChanges">
            ///     A flag that indicates whether changes (if any) to the .wim file must be committed before
            ///     unmounting the .wim file. This flag has no effect if the .wim file was mounted not to enable edits.
            /// </param>
            /// <returns>
            ///     Returns TRUE and sets the LastError to ERROR_SUCCESS on the successful completion of this function. Returns
            ///     FALSE in case of a failure and sets the LastError to the appropriate Win32® error value.
            /// </returns>
            /// <remarks>
            ///     The WIMUnmountImage function unmaps the contents of the given image in the .wim file from the specified mount
            ///     directory. After the successful completion of this operation, users or applications will not be able to access the
            ///     contents of the image previously mapped under the mount directory.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMUnmountImage(string pszMountPath, string pszWimFileName, uint dwImageIndex,
                [MarshalAs(UnmanagedType.Bool)] bool bCommitChanges);

            /// <summary>
            ///     Unmounts an image from a Windows® image (.wim) that was previously mounted with the WIMMountImageHandle function.
            /// </summary>
            /// <param name="hImage">A handle to an image previously mounted with WIMMountImageHandle.</param>
            /// <param name="dwUnmountFlags">Reserved. Must be zero.</param>
            /// <returns>
            ///     Returns TRUE and sets the LastError to ERROR_SUCCESS on the successful completion of this function. Returns
            ///     FALSE in case of a failure and sets the LastError to the appropriate Win32® error value.
            /// </returns>
            /// <remarks>
            ///     The WIMUnmountImageHandle function unmaps the contents of the given image in the .wim file from the specified
            ///     mount directory. After the successful completion of this operation, users or applications will not be able to
            ///     access the contents of the image previously mapped under the mount directory.
            /// </remarks>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMUnmountImageHandle(WimHandle hImage, uint dwUnmountFlags);

            /// <summary>
            ///     Unregisters a log file for debugging or tracing purposes from the current WIMGAPI session.
            /// </summary>
            /// <param name="pszLogFile">
            ///     The path to a log file previously specified in a call to the WIMRegisterLogFile function. This
            ///     parameter is required and cannot be NULL.
            /// </param>
            /// <returns>
            ///     Returns TRUE and sets the LastError to ERROR_SUCCESS on the successful completion of this function. Returns
            ///     FALSE in case of a failure and sets the LastError to the appropriate Win32® error value.
            /// </returns>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMUnregisterLogFile(string pszLogFile);

            /// <summary>
            ///     Unregisters a function from being called with imaging-specific data.
            /// </summary>
            /// <param name="hWim">The handle to a .wim file returned by WIMCreateFile.</param>
            /// <param name="fpMessageProc">
            ///     A pointer to the application-defined callback function to unregister. Specify NULL to
            ///     unregister all callback functions.
            /// </param>
            /// <returns>
            ///     If the function succeeds, then the return value is nonzero.
            ///     If the function fails, then the return value is zero. To obtain extended error information, call the GetLastError
            ///     function.
            /// </returns>
            [DllImport(WimgApiDllName, CallingConvention = WimgApiCallingConvention, CharSet = WimgApiCharSet,
                SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMUnregisterMessageCallback([Optional] WimHandle hWim,
                WIMMessageCallback fpMessageProc);
        }
    }
}