using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using DWORD = System.UInt32;
using HANDLE = System.IntPtr;
using LARGE_INTEGER = System.UInt64;

namespace Microsoft.Win32
{

    #region Classes

    /// <summary>
    ///     Represents a handle to a file search returned by FindFirstFile or FindFirstFileEx.
    /// </summary>
    public sealed class FindSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        ///     Creates a new instance of the FindSafeHandle class.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public FindSafeHandle()
            : base(true)
        {
        }

        /// <summary>
        ///     Releases the handle to the loaded dynamic-link library (DLL) module.
        /// </summary>
        /// <returns>
        ///     true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this
        ///     case, it generates a releaseHandleFailed MDA Managed Debugging Assistant.
        /// </returns>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        protected override bool ReleaseHandle()
        {
            if (!IsClosed)
            {
                // Call the FreeLibrary function.
                //
                return Kernel32.NativeMethods.FindClose(this);
            }

            return true;
        }
    }

    /// <summary>
    ///     Represents a handle to a module returned by LoadLibrary or LoadLibraryEx.
    /// </summary>
    public sealed class ModuleSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        ///     Creates a new instance of the ModuleSafeHandle class.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public ModuleSafeHandle()
            : base(true)
        {
        }

        /// <summary>
        ///     Releases the handle to the loaded dynamic-link library (DLL) module.
        /// </summary>
        /// <returns>
        ///     true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this
        ///     case, it generates a releaseHandleFailed MDA Managed Debugging Assistant.
        /// </returns>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        protected override bool ReleaseHandle()
        {
            if (!IsClosed)
            {
                // Call the FreeLibrary function.
                //
                return Kernel32.NativeMethods.FreeLibrary(this);
            }

            return true;
        }
    }

    #endregion Classes

    /// <summary>
    ///     Provides access to the Win32 base APIs, such as memory management, input/output operations, process and thread
    ///     creation, and synchronization functions.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        ///     Adds a directory to the process DLL search path.
        /// </summary>
        /// <param name="path">An absolute path to the directory to add to the search path.</param>
        /// <returns>
        ///     A cookie that can be passed to <see cref="RemoveDllDirectory" /> to remove the DLL from the process DLL search
        ///     path.
        /// </returns>
        /// <exception cref="Win32Exception">The native function failed.</exception>
        public static HANDLE AddDllDirectory(string path)
        {
            // Call the native function
            //
            var cookie = NativeMethods.AddDllDirectory(path);

            // See if the cookie is invalid and the function failed
            //
            if (cookie == IntPtr.Zero)
            {
                throw new Win32Exception();
            }

            return cookie;
        }

        /// <summary>
        ///     Closes an open object handle.
        /// </summary>
        /// <param name="handle">A valid handle to an open object.</param>
        public static bool CloseHandle(HANDLE handle)
        {
            if (!NativeMethods.CloseHandle(handle))
            {
                throw new Win32Exception();
            }

            return true;
        }

        /// <summary>
        ///     Copies an existing file to a new file using the specified options.
        /// </summary>
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file.</param>
        /// <param name="options">Specifies options to use when copying the file.</param>
        /// <exception cref="ArgumentNullException">sourceFileName or destFileName is null.</exception>
        /// <exception cref="FileNotFoundException">sourceFileName was not found.</exception>
        /// <exception cref="OperationCanceledException">The file copy was canceled by the user's callback method.</exception>
        public static void CopyFile(string sourceFileName, string destFileName, CopyFileOptions options)
        {
            // Call an overload
            //
            CopyFile(sourceFileName, destFileName, options, null);
        }

        /// <summary>
        ///     Copies an existing file to a new file using the specified options and gets notified of progress.
        /// </summary>
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file.</param>
        /// <param name="options">Specifies options to use when copying the file.</param>
        /// <param name="copyFileProgressCallback">
        ///     A <see cref="CopyFileProgressCallback" /> to call when progress is made during
        ///     the file copy.
        /// </param>
        /// <exception cref="ArgumentNullException">sourceFileName or destFileName is null.</exception>
        /// <exception cref="FileNotFoundException">sourceFileName was not found.</exception>
        /// <exception cref="OperationCanceledException">The file copy was canceled by the user's callback method.</exception>
        public static void CopyFile(string sourceFileName, string destFileName, CopyFileOptions options,
            CopyFileProgressCallback copyFileProgressCallback)
        {
            // Call an overload
            //
            CopyFile(sourceFileName, destFileName, options, copyFileProgressCallback, null);
        }

        /// <summary>
        ///     Copies an existing file to a new file using the specified options and gets notified of progress.
        /// </summary>
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file.</param>
        /// <param name="options">Specifies options to use when copying the file.</param>
        /// <param name="copyFileProgressCallback">
        ///     A <see cref="CopyFileProgressCallback" /> to call when progress is made during
        ///     the file copy.
        /// </param>
        /// <param name="userData">Optional user data to be passed to the callback.</param>
        /// <exception cref="ArgumentNullException">sourceFileName or destFileName is null.</exception>
        /// <exception cref="FileNotFoundException">sourceFileName was not found.</exception>
        /// <exception cref="OperationCanceledException">The file copy was canceled by the user's callback method.</exception>
        public static void CopyFile(string sourceFileName, string destFileName, CopyFileOptions options,
            CopyFileProgressCallback copyFileProgressCallback, object userData)
        {
            if (string.IsNullOrWhiteSpace(sourceFileName))
            {
                throw new ArgumentNullException("sourceFileName");
            }

            if (string.IsNullOrWhiteSpace(destFileName))
            {
                throw new ArgumentNullException("destFileName");
            }

            if (!File.Exists(sourceFileName))
            {
                throw new FileNotFoundException(string.Format(CultureInfo.CurrentCulture,
                    "Could not find part of the path '{0}'", sourceFileName));
            }

            var cancel = false;

            // Create a CopyFileProgress object to receive the native callback and route it back to the managed callback
            //
            var copyFileProgress = new CopyFileProgress(sourceFileName, destFileName, copyFileProgressCallback, userData);

            // Call the native function
            //
            if (
                !NativeMethods.CopyFileEx(sourceFileName, destFileName, copyFileProgress.CopyProgressHandler,
                    IntPtr.Zero, ref cancel, (uint) options))
            {
                // Get the last error
                //
                var win32Exception = new Win32Exception();

                // See if the last error was ERROR_REQUEST_ABORTED
                //
                if (win32Exception.NativeErrorCode == Win32Error.ERROR_REQUEST_ABORTED)
                {
                    // Throw a OperationCanceledException exception
                    //
                    throw new OperationCanceledException("The file copy was canceled by the user.", win32Exception);
                }

                throw win32Exception;
            }
        }

        /// <summary>
        ///     Creates a symbolic link.
        /// </summary>
        /// <param name="path">The symbolic link to be created.</param>
        /// <param name="target">The name of the target for the symbolic link to be created.</param>
        /// <param name="options">
        ///     A <see cref="CreateSymbolicLinkOption" /> object that indicates options to use when creating the
        ///     link target.
        /// </param>
        /// <exception cref="Win32Exception">The native function failed.</exception>
        public static void CreateSymbolicLink(string path, string target, CreateSymbolicLinkOption options)
        {
            // Call the native function and see if it failed
            //
            if (!NativeMethods.CreateSymbolicLink(path, target, (uint) options))
            {
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Searches a directory for a file or subdirectory with a name that matches a specific name (or partial name if wild
        ///     cards are used).
        /// </summary>
        /// <param name="path">
        ///     The directory or path, and the file name, which can include wild card characters, for example, an
        ///     asterisk (*) or a question mark (?).
        /// </param>
        /// <param name="findData">
        ///     An out parameter that receives a <see cref="WIN32_FIND_DATA" /> struct containing information
        ///     about the file that was found.
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The path parameter is null.</exception>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public static FindSafeHandle FindFirstFile(string path, out WIN32_FIND_DATA findData)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("path");
            }

            var handle = NativeMethods.FindFirstFile(path, out findData);

            if (handle == null || handle.IsInvalid)
            {
                var win32Exception = new Win32Exception();

                if (win32Exception.NativeErrorCode == Win32Error.ERROR_FILE_NOT_FOUND)
                {
                    throw new FileNotFoundException(
                        string.Format(CultureInfo.CurrentCulture, "No matching files were found for pattern '{0}'", path),
                        path);
                }

                throw win32Exception;
            }

            return handle;
        }

        /// <summary>
        ///     Continues a file search from a previous call to the FindFirstFile, FindFirstFileEx, or FindFirstFileTransacted
        ///     functions.
        /// </summary>
        /// <param name="findHandle">
        ///     The search handle returned by a previous call to the FindFirstFile or FindFirstFileEx
        ///     function.
        /// </param>
        /// <param name="findData">
        ///     An out parameter that receives a <see cref="WIN32_FIND_DATA" /> struct containing information
        ///     about the file that was found.
        /// </param>
        /// <returns>true if there are more files that match the search, otherwise false.</returns>
        /// <exception cref="ArgumentNullException">The findHandle parameter is null.</exception>
        /// <exception cref="Win32Exception">The native function failed.</exception>
        public static bool FindNextFile(FindSafeHandle findHandle, out WIN32_FIND_DATA findData)
        {
            if (findHandle == null)
            {
                throw new ArgumentNullException("findHandle");
            }

            // Call the native method and see if it returns false
            //
            if (!NativeMethods.FindNextFile(findHandle, out findData))
            {
                // Get the last error
                //
                var win32Exception = new Win32Exception();

                // See if the last error is ERROR_NO_MORE_FILES
                //
                if (win32Exception.NativeErrorCode == Win32Error.ERROR_NO_MORE_FILES)
                {
                    // There are no more files
                    //
                    return false;
                }

                // Throw the native error
                //
                throw win32Exception;
            }

            // There are more files
            //
            return true;
        }

        /// <summary>
        ///     Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count. When the
        ///     reference count reaches zero, the module is unloaded from the address space of the calling process and the handle
        ///     is no longer valid.
        /// </summary>
        /// <param name="handle">
        ///     A handle to the loaded library module. The LoadLibrary, LoadLibraryEx, GetModuleHandle, or
        ///     GetModuleHandleEx function returns this handle.
        /// </param>
        /// <exception cref="Win32Exception">The native function returned an error.</exception>
        public static void FreeLibrary(ModuleSafeHandle handle)
        {
            if (!NativeMethods.FreeLibrary(handle))
            {
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Retrieves the application-specific portion of the search path used to locate DLLs for the application.
        /// </summary>
        /// <returns>The application-specific portion of the search path.</returns>
        /// <exception cref="Win32Exception">The native function failed.</exception>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public static string GetDllDirectory()
        {
            // Call the native function first to get the size of the buffer needed
            //
            var bufferLength = (int) NativeMethods.GetDllDirectory(0, IntPtr.Zero);

            // See if the buffer returned is zero meaning something failed
            //
            if (bufferLength == 0)
            {
                throw new Win32Exception();
            }

            // Allocate a buffer of the correct size
            //
            var buffer = Marshal.AllocHGlobal(bufferLength);

            try
            {
                // Call the native function again with the buffer and see if the return value isn't the buffer length
                //
                if ((int) NativeMethods.GetDllDirectory((uint) bufferLength, buffer) != bufferLength - 1)
                {
                    throw new Win32Exception();
                }

                // Return the marshaled string
                //
                return Marshal.PtrToStringAuto(buffer);
            }
            finally
            {
                // Free the buffer
                //
                Marshal.FreeHGlobal(buffer);
            }
        }

        /// <summary>
        ///     Retrieves a delegate of an unmanaged function from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="module">
        ///     A handle to the loaded library module. The LoadLibrary, LoadLibraryEx, GetModuleHandle, or
        ///     GetModuleHandleEx function returns this handle.
        /// </param>
        /// <param name="procName">The name of the function to retrieve.</param>
        /// <param name="t">The type of the delegate to be returned.</param>
        /// <returns>A delegate instance that can be cast to the appropriate delegate type.</returns>
        /// <exception cref="ArgumentNullException">
        ///     The module parameter is null
        ///     -or-
        ///     The procName parameter is null
        ///     -or-
        ///     The t parameter is null.
        /// </exception>
        /// <exception cref="Win32Exception">The native function GetProcAddress returned an error.</exception>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public static Delegate GetProc(ModuleSafeHandle module, string procName, Type t)
        {
            // Verify input parameters (module and procName are verified by GetProcAddress)
            //
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }

            // Get the proc address and then return the delegate for the proc
            //
            return Marshal.GetDelegateForFunctionPointer(GetProcAddress(module, procName), t);
        }

        /// <summary>
        ///     Retrieves a delegate of an unmanaged function from the specified dynamic-link library (DLL).
        /// </summary>
        /// <typeparam name="T">The type of the delegate to be returned.</typeparam>
        /// <param name="module">
        ///     A handle to the loaded library module. The LoadLibrary, LoadLibraryEx, GetModuleHandle, or
        ///     GetModuleHandleEx function returns this handle.
        /// </param>
        /// <param name="procName">The name of the function to retrieve.</param>
        /// <returns>A delegate instance of type t.</returns>
        /// <exception cref="ArgumentNullException">
        ///     The module parameter is null.
        ///     -or-
        ///     The procName parameter is null.
        /// </exception>
        /// <exception cref="Win32Exception">The native function GetProcAddress returned an error.</exception>
        /// <exception cref="InvalidCastException">
        ///     The delegate returned by <see cref="Marshal.GetDelegateForFunctionPointer" />
        ///     can not be cast to the type t specified.
        /// </exception>
        public static T GetProc<T>(ModuleSafeHandle module, string procName)
            where T : class
        {
            // Call the non-generic overload and cast
            //
            return (T) (object) GetProc(module, procName, typeof (T));
        }

        /// <summary>
        ///     Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="module">
        ///     A handle to the loaded library module. The LoadLibrary, LoadLibraryEx, GetModuleHandle, or
        ///     GetModuleHandleEx function returns this handle.
        /// </param>
        /// <param name="procName">The name of the function to retrieve.</param>
        /// <returns>An <see cref="IntPtr" /> object that represents the address of function.</returns>
        /// <exception cref="ArgumentNullException">
        ///     The module parameter is null.
        ///     -or-
        ///     The procName parameter is null.
        /// </exception>
        /// <exception cref="Win32Exception">The native function function returned an error.</exception>
        public static IntPtr GetProcAddress(ModuleSafeHandle module, string procName)
        {
            // Verify input parameters
            //
            if (module == null)
            {
                throw new ArgumentNullException("module");
            }

            if (string.IsNullOrWhiteSpace("procName"))
            {
                throw new ArgumentNullException("procName");
            }

            // Get the proc address
            //
            var procAddress = NativeMethods.GetProcAddress(module, procName);

            // See if the proc exists
            //
            if (procAddress == IntPtr.Zero)
            {
                throw new Win32Exception();
            }

            return procAddress;
        }

        /// <summary>
        ///     Loads the specified module into the address space of the calling process. The specified module may cause other
        ///     modules to be loaded.
        /// </summary>
        /// <param name="path">
        ///     The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file).
        ///     The name specified is the file name of the module and is not related to the name stored in the library module
        ///     itself, as specified by the LIBRARY keyword in the module-definition (.def) file.
        ///     If the string specifies a full path, the method searches only that path for the module.
        ///     If the string specifies a relative path or a module name without a path, the method uses a standard search strategy
        ///     to find the module; for more information, see the Remarks.
        ///     If the method cannot find the module, the method fails. When specifying a path, be sure to use backslashes (\), not
        ///     forward slashes (/). For more information about paths, see Naming a File or Directory.
        ///     If the string specifies a module name without a path and the file name extension is omitted, the method appends the
        ///     default library extension .dll to the module name. To prevent the method from appending .dll to the module name,
        ///     include a trailing point character (.) in the module name string.
        /// </param>
        /// <returns>A <see cref="ModuleSafeHandle" /> object containing a handle to the loaded module.</returns>
        /// <exception cref="ArgumentNullException">The path parameter is null.</exception>
        /// <exception cref="FileNotFoundException">The specified path does not exist.</exception>
        /// <exception cref="Win32Exception">The native function returned an error.</exception>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public static ModuleSafeHandle LoadLibrary(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("path");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(string.Format(CultureInfo.CurrentCulture,
                    "Could not find part of the path '{0}'", path));
            }

            // Call the native function
            //
            var moduleSafeHandle = NativeMethods.LoadLibrary(path);

            // See if a valid handle was returned
            //
            if (moduleSafeHandle == null || moduleSafeHandle.IsInvalid)
            {
                throw new Win32Exception();
            }

            return moduleSafeHandle;
        }

        /// <summary>
        ///     Loads the specified module into the address space of the calling process using the specified options. The specified
        ///     module may cause other modules to be loaded.
        /// </summary>
        /// <param name="path">
        ///     The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file).
        ///     The name specified is the file name of the module and is not related to the name stored in the library module
        ///     itself, as specified by the LIBRARY keyword in the module-definition (.def) file.
        ///     If the string specifies a full path, the method searches only that path for the module.
        ///     If the string specifies a relative path or a module name without a path, the method uses a standard search strategy
        ///     to find the module; for more information, see the Remarks.
        ///     If the method cannot find the module, the method fails. When specifying a path, be sure to use backslashes (\), not
        ///     forward slashes (/). For more information about paths, see Naming a File or Directory.
        ///     If the string specifies a module name without a path and the file name extension is omitted, the method appends the
        ///     default library extension .dll to the module name. To prevent the method from appending .dll to the module name,
        ///     include a trailing point character (.) in the module name string.
        /// </param>
        /// <param name="options">
        ///     A <see cref="LoadLibraryOptions" /> object indication what options to use when loading the
        ///     module.
        /// </param>
        /// <returns>A <see cref="ModuleSafeHandle" /> object containing a handle to the loaded module.</returns>
        /// <exception cref="ArgumentNullException">The path parameter is null.</exception>
        /// <exception cref="FileNotFoundException">The specified path does not exist.</exception>
        /// <exception cref="Win32Exception">The native function returned an error.</exception>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public static ModuleSafeHandle LoadLibrary(string path, LoadLibraryOptions options)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("path");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(string.Format(CultureInfo.CurrentCulture,
                    "Could not find part of the path '{0}'", path));
            }

            // Call the native function
            //
            var moduleSafeHandle = NativeMethods.LoadLibraryEx(path, IntPtr.Zero, (uint) options);

            // See if a valid handle was returned
            //
            if (moduleSafeHandle == null || moduleSafeHandle.IsInvalid)
            {
                throw new Win32Exception();
            }

            return moduleSafeHandle;
        }

        /// <summary>
        ///     Removes a directory that was added to the process DLL search path by using AddDllDirectory.
        /// </summary>
        /// <param name="cookie">The cookie returned by AddDllDirectory when the directory was added to the search path.</param>
        /// <exception cref="ArgumentException">The cookie parameter is IntPtr.Zero.</exception>
        /// <exception cref="Win32Exception">The native function failed.</exception>
        public static void RemoveDllDirectory(IntPtr cookie)
        {
            if (cookie == IntPtr.Zero)
            {
                throw new ArgumentNullException("cookie");
            }

            // Call the native method and see if it failed
            //
            if (!NativeMethods.RemoveDllDirectory(cookie))
            {
                throw new Win32Exception();
            }
        }

        /// <summary>
        ///     Adds a directory to the search path used to locate DLLs for the application.
        /// </summary>
        /// <param name="path">
        ///     The directory to be added to the search path. If this parameter is an empty string (""), the call
        ///     removes the current directory from the default DLL search order. If this parameter is NULL, the function restores
        ///     the default search order.
        /// </param>
        /// <exception cref="ArgumentNullException">The path parameter is null.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path does not exist.</exception>
        /// <exception cref="Win32Exception">The native function failed.</exception>
        public static void SetDllDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("path");
            }

            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException(string.Format(CultureInfo.CurrentCulture,
                    "Could not find part of the path '{0}'", path));
            }

            // Call the native function and check for a failure
            //
            if (!NativeMethods.SetDllDirectory(path))
            {
                throw new Win32Exception();
            }
        }
    }

    #region Constants

    public static partial class Kernel32
    {
        internal const int CALLBACK_CHUNK_FINISHED = 0x00000000;
        internal const int CALLBACK_STREAM_SWITCH = 0x00000001;
        internal const int COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008;
        internal const int COPY_FILE_COPY_SYMLINK = 0x00000800;
        internal const int COPY_FILE_FAIL_IF_EXISTS = 0x00000001;
        internal const int COPY_FILE_NO_BUFFERING = 0x00001000;
        internal const int COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004;
        internal const int COPY_FILE_RESTARTABLE = 0x00000002;
        internal const int DONT_RESOLVE_DLL_REFERENCES = 0x00000001;
        internal const int LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010;
        internal const int LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
        internal const int LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040;
        internal const int LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020;
        internal const int LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200;
        internal const int LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000;
        internal const int LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 0x00000100;
        internal const int LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800;
        internal const int LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400;
        internal const int LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008;
        internal const int PROGRESS_CANCEL = 0x00000001;
        internal const int PROGRESS_CONTINUE = 0x00000000;
        internal const int PROGRESS_QUIET = 0x00000003;
        internal const int PROGRESS_STOP = 0x00000002;
        internal const int SYMBOLIC_LINK_FLAG_DIRECTORY = 0x00000001;
        internal const int SYMBOLIC_LINK_FLAG_FILE = 0x00000000;
    }

    #endregion Constants

    #region Delegates

    /// <summary>
    ///     Specifies a method to call during process of a file copy.
    /// </summary>
    /// <param name="progress">A <see cref="CopyFileProgress" /> containing the status of the file copy.</param>
    /// <param name="userData">User specified data that was passed to the original copy method.</param>
    /// <returns>A <see cref="CopyFileProgressAction" /> value indicating if the file copy should be canceled.</returns>
    public delegate CopyFileProgressAction CopyFileProgressCallback(CopyFileProgress progress, object userData);

    public static partial class Kernel32
    {
        /// <summary>
        ///     An application-defined callback function used with the CopyFileEx, MoveFileTransacted, and MoveFileWithProgress
        ///     functions. It is called when a portion of a copy or move operation is completed. The LPPROGRESS_ROUTINE type
        ///     defines a pointer to this callback function. CopyProgressRoutine is a placeholder for the application-defined
        ///     function name.
        /// </summary>
        /// <param name="TotalFileSize">The total size of the file, in bytes.</param>
        /// <param name="TotalBytesTransferred">
        ///     The total number of bytes transferred from the source file to the destination file
        ///     since the copy operation began.
        /// </param>
        /// <param name="StreamSize">The total size of the current file stream, in bytes.</param>
        /// <param name="StreamBytesTransferred">
        ///     The total number of bytes in the current stream that have been transferred from
        ///     the source file to the destination file since the copy operation began.
        /// </param>
        /// <param name="dwStreamNumber">
        ///     A handle to the current stream. The first time CopyProgressRoutine is called, the stream
        ///     number is 1.
        /// </param>
        /// <param name="dwCallbackReason">The reason that CopyProgressRoutine was called.</param>
        /// <param name="hSourceFile">A handle to the source file.</param>
        /// <param name="hDestinationFile">A handle to the destination file.</param>
        /// <param name="lpData">Argument passed to CopyProgressRoutine by CopyFileEx, MoveFileTransacted, or MoveFileWithProgress.</param>
        /// <returns>
        ///     The CopyProgressRoutine function should return one of the following values.
        ///     PROGRESS_CANCEL - Cancel the copy operation and delete the destination file.
        ///     PROGRESS_CONTINUE - Continue the copy operation.
        ///     PROGRESS_QUIET - Continue the copy operation, but stop invoking CopyProgressRoutine to report progress.
        ///     PROGRESS_STOP - Stop the copy operation. It can be restarted at a later time.
        /// </returns>
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa363854(v=vs.85).aspx
        public delegate CopyFileProgressAction CopyProgressRoutine(
            ulong TotalFileSize, ulong TotalBytesTransferred, ulong StreamSize, ulong StreamBytesTransferred,
            uint dwStreamNumber, uint dwCallbackReason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData);
    }

    #endregion Delegates

    #region Enums

    /// <summary>
    ///     Indicates options to use when copying a file with the
    ///     <see cref="Kernel32.CopyFile(string, string, CopyFileOptions, CopyFileProgressCallback, object)" /> method.
    /// </summary>
    public enum CopyFileOptions : uint
    {
        /// <summary>
        /// </summary>
        None = 0,

        /// <summary>
        ///     The copy operation fails immediately if the target file already exists.
        /// </summary>
        FailIfExists = Kernel32.COPY_FILE_FAIL_IF_EXISTS,

        /// <summary>
        ///     The copy operation is performed using unbuffered I/O, bypassing system I/O cache resources. Recommended for very
        ///     large file transfers.
        ///     ! This value is not supported in Windows XP and Windows Server 2003 !
        /// </summary>
        NoBuffering = Kernel32.COPY_FILE_NO_BUFFERING,

        /// <summary>
        ///     Progress of the copy is tracked in the target file in case the copy fails. The failed copy can be restarted at a
        ///     later time by specifying the same values for lpExistingFileName and lpNewFileName as those used in the call that
        ///     failed. This can significantly slow down the copy operation as the new file may be flushed multiple times during
        ///     the copy operation.
        /// </summary>
        Restartable = Kernel32.COPY_FILE_RESTARTABLE,

        /// <summary>
        ///     The file is copied and the original file is opened for write access.
        /// </summary>
        OpenSourceForWrite = Kernel32.COPY_FILE_OPEN_SOURCE_FOR_WRITE,

        /// <summary>
        ///     An attempt to copy an encrypted file will succeed even if the destination copy cannot be encrypted.
        /// </summary>
        AllowDecryptedDestination = Kernel32.COPY_FILE_ALLOW_DECRYPTED_DESTINATION,

        /// <summary>
        ///     If the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file that
        ///     the source symbolic link is pointing to.
        ///     ! This value is not supported in Windows XP and Windows Server 2003 !
        /// </summary>
        CopySymbolicLink = Kernel32.COPY_FILE_COPY_SYMLINK
    }

    /// <summary>
    ///     Indicates the action to take during copy file progress.
    /// </summary>
    public enum CopyFileProgressAction : uint
    {
        /// <summary>
        ///     Indicates that CopyFileEx should continue the copy operation.
        /// </summary>
        Continue = Kernel32.PROGRESS_CONTINUE,

        /// <summary>
        ///     Indicates that CopyFileEx should cancel the copy operation and delete the destination file.
        /// </summary>
        Cancel = Kernel32.PROGRESS_CANCEL,

        /// <summary>
        ///     Indicates that CopyFileEx should stop the copy operation. It can be restarted at a later time.
        /// </summary>
        Stop = Kernel32.PROGRESS_STOP,

        /// <summary>
        ///     Indicates that CopyFileEx should continue the copy operation, but stop invoking CopyProgressRoutine to report
        ///     progress.
        /// </summary>
        Quiet = Kernel32.PROGRESS_QUIET
    }

    /// <summary>
    ///     Represents options of the <see cref="Kernel32.CreateSymbolicLink" /> method.
    /// </summary>
    public enum CreateSymbolicLinkOption
    {
        /// <summary>
        ///     Indicates the link target is a file.
        /// </summary>
        File = Kernel32.SYMBOLIC_LINK_FLAG_FILE,

        /// <summary>
        ///     Indicates the link target is a directory.
        /// </summary>
        Directory = Kernel32.SYMBOLIC_LINK_FLAG_DIRECTORY
    }

    /// <summary>
    ///     Represents options of the <see cref="Kernel32.LoadLibrary(string, LoadLibraryOptions)" /> method.
    /// </summary>
    [Flags]
    public enum LoadLibraryOptions
    {
        /// <summary>
        ///     Indicates the system should not call DllMain for process and thread initialization and termination. Also, the
        ///     system does not load additional executable modules that are referenced by the specified module.
        ///     Note:  Do not use this value; it is provided only for backward compatibility. If you are planning to access only
        ///     data or resources in the DLL, use <see cref="LoadLibraryOptions.LoadAsDatafileExclusive" /> or
        ///     LOAD_LIBRARY_AS_IMAGE_RESOURCE or both. Otherwise, load the library as a DLL or executable module using the
        ///     LoadLibrary function.
        /// </summary>
        DoNotResolveDllReferences = Kernel32.DONT_RESOLVE_DLL_REFERENCES,

        /// <summary>
        ///     Indicates the system should not check AppLocker rules or apply Software Restriction Policies for the DLL. This
        ///     action applies only to the DLL being loaded and not to its dependencies. This value is recommended for use in setup
        ///     programs that must run extracted DLLs during installation.
        /// </summary>
        IgnoreCodeAuthorizationLevel = Kernel32.LOAD_IGNORE_CODE_AUTHZ_LEVEL,

        /// <summary>
        ///     Indicates the system should map the file into the calling process's virtual address space as if it were a data
        ///     file. Nothing is done to execute or prepare to execute the mapped file. Therefore, you cannot call functions like
        ///     GetModuleFileName, GetModuleHandle or GetProcAddress with this DLL. Using this value causes writes to read-only
        ///     memory to raise an access violation. Use this flag when you want to load a DLL only to extract messages or
        ///     resources from it.
        ///     This value can be used with <see cref="LoadLibraryOptions.LoadAsImageResource" />.
        /// </summary>
        LoadAsDatafile = Kernel32.LOAD_LIBRARY_AS_DATAFILE,

        /// <summary>
        ///     Similar to <see cref="LoadLibraryOptions.LoadAsDatafile" />, except that the DLL file is opened with exclusive
        ///     write access for the calling process. Other processes cannot open the DLL file for write access while it is in use.
        ///     However, the DLL can still be opened by other processes.
        ///     This value can be used with <see cref="LoadLibraryOptions.LoadAsImageResource" />.
        /// </summary>
        LoadAsDatafileExclusive = Kernel32.LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE,

        /// <summary>
        ///     Indicates that the system should map the file into the process's virtual address space as an image file. However,
        ///     the loader does not load the static imports or perform the other usual initialization steps. Use this flag when you
        ///     want to load a DLL only to extract messages or resources from it. If forced integrity checking is desired for the
        ///     loaded file then LOAD_LIBRARY_AS_IMAGE is recommended instead.
        ///     Unless the application depends on the image layout, this value should be used with either
        ///     <see cref="LoadLibraryOptions.LoadAsDatafileExclusive" /> or <see cref="LoadLibraryOptions.LoadAsDatafile" />.
        /// </summary>
        LoadAsImageResource = Kernel32.LOAD_LIBRARY_AS_IMAGE_RESOURCE,

        /// <summary>
        ///     Indicates the application's installation directory is searched for the DLL and its dependencies. Directories in the
        ///     standard search path are not searched. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.
        /// </summary>
        SearchApplicationDirectory = Kernel32.LOAD_LIBRARY_SEARCH_APPLICATION_DIR,

        /// <summary>
        ///     This value is a combination of LOAD_LIBRARY_SEARCH_APPLICATION_DIR, LOAD_LIBRARY_SEARCH_SYSTEM32, and
        ///     LOAD_LIBRARY_SEARCH_USER_DIRS. Directories in the standard search path are not searched. This value cannot be
        ///     combined with LOAD_WITH_ALTERED_SEARCH_PATH.
        ///     This value represents the recommended maximum number of directories an application should include in its DLL search
        ///     path.
        /// </summary>
        SearchDefaultDirectories = Kernel32.LOAD_LIBRARY_SEARCH_DEFAULT_DIRS,

        /// <summary>
        ///     Indicates that the directory that contains the DLL is temporarily added to the beginning of the list of directories
        ///     that are searched for the DLL's dependencies. Directories in the standard search path are not searched.
        ///     The lpFileName parameter must specify a fully qualified path. This value cannot be combined with
        ///     LOAD_WITH_ALTERED_SEARCH_PATH.
        ///     For example, if Lib2.dll is a dependency of C:\Dir1\Lib1.dll, loading Lib1.dll with this value causes the system to
        ///     search for Lib2.dll only in C:\Dir1. To search for Lib2.dll in C:\Dir1 and all of the directories in the DLL search
        ///     path, combine this value with LOAD_LIBRARY_DEFAULT_DIRS.
        /// </summary>
        SearchDllLoadDirectory = Kernel32.LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR,

        /// <summary>
        ///     Indicates that %windows%\system32 should be searched for the DLL and its dependencies. Directories in the standard
        ///     search path are not searched. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.
        /// </summary>
        SearchSystem32Directory = Kernel32.LOAD_LIBRARY_SEARCH_SYSTEM32,

        /// <summary>
        ///     Indicates that directories added using the AddDllDirectory or the SetDllDirectory function are searched for the DLL
        ///     and its dependencies. If more than one directory has been added, the order in which the directories are searched is
        ///     unspecified. Directories in the standard search path are not searched. This value cannot be combined with
        ///     LOAD_WITH_ALTERED_SEARCH_PATH.
        /// </summary>
        SearchUserDirectories = Kernel32.LOAD_LIBRARY_SEARCH_USER_DIRS,

        /// <summary>
        ///     Indicates that the system should use the alternate file search strategy to find associated executable modules that
        ///     the specified module causes to be loaded. If this value is used and lpFileName specifies a relative path, the
        ///     behavior is undefined.
        ///     If this value is not used, or if lpFileName does not specify a path, the system uses the standard search strategy
        ///     discussed in the Remarks section to find associated executable modules that the specified module causes to be
        ///     loaded.
        ///     This value cannot be combined with any LOAD_LIBRARY_SEARCH flag.
        /// </summary>
        UseAlternateSearchPath = Kernel32.LOAD_WITH_ALTERED_SEARCH_PATH
    }

    /// <summary>
    ///     Indicates the reason CopyProgressRoutine was called.
    /// </summary>
    internal enum CopyFileProgressCallbackReason : uint
    {
        /// <summary>
        ///     Another part of the data file was copied.
        /// </summary>
        ChunkFinished = Kernel32.CALLBACK_CHUNK_FINISHED,

        /// <summary>
        ///     Another stream was created and is about to be copied. This is the callback reason given when the callback routine
        ///     is first invoked.
        /// </summary>
        StreamSwitch = Kernel32.CALLBACK_STREAM_SWITCH
    }

    #endregion Enums

    #region Native Methods

    public static partial class Kernel32
    {
        /// <summary>
        ///     The character set to use.
        /// </summary>
        public const CharSet DllCharSet = CharSet.Unicode;

        /// <summary>
        ///     Get assembly name for the Kernel32 API.
        /// </summary>
        public const string DllName = "Kernel32";

        /// <summary>
        ///     Represents a class that contains method stubs for native calls.
        /// </summary>
        internal static class NativeMethods
        {
            /// <summary>
            ///     Adds a directory to the process DLL search path.
            /// </summary>
            /// <param name="NewDirectory">
            ///     An absolute path to the directory to add to the search path. For example, to add the
            ///     directory Dir2 to the process DLL search path, specify \Dir2.
            /// </param>
            /// <returns>
            ///     If the function succeeds, the return value is an opaque pointer that can be passed to RemoveDllDirectory to remove
            ///     the DLL from the process DLL search path.
            ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            internal static extern IntPtr AddDllDirectory(string NewDirectory);

            /// <summary>
            ///     Closes an open object handle.
            /// </summary>
            /// <param name="hObject">A valid handle to an open object.</param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
            ///     If the application is running under a debugger, the function will throw an exception if it receives either a handle
            ///     value that is not valid or a pseudo-handle value. This can happen if you close a handle twice, or if you call
            ///     CloseHandle on a handle returned by the FindFirstFile function instead of calling the FindClose function.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool CloseHandle(HANDLE hObject);

            /// <summary>
            ///     Copies an existing file to a new file, notifying the application of its progress through a callback function.
            /// </summary>
            /// <param name="lpExistingFileName">The name of an existing file.</param>
            /// <param name="lpNewFileName">The name of the new file.</param>
            /// <param name="lpProgressRoutine">
            ///     The address of a callback function of type LPPROGRESS_ROUTINE that is called each time
            ///     another portion of the file has been copied. This parameter can be NULL.
            /// </param>
            /// <param name="lpData">The argument to be passed to the callback function.</param>
            /// <param name="pbCancel">
            ///     If this flag is set to TRUE during the copy operation, the operation is canceled. Otherwise, the
            ///     copy operation will continue to completion.
            /// </param>
            /// <param name="dwCopyFlags">Flags that specify how the file is to be copied.</param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To get extended error information call GetLastError.
            ///     If lpProgressRoutine returns PROGRESS_CANCEL due to the user canceling the operation, CopyFileEx will return zero
            ///     and GetLastError will return ERROR_REQUEST_ABORTED. In this case, the partially copied destination file is deleted.
            ///     If lpProgressRoutine returns PROGRESS_STOP due to the user stopping the operation, CopyFileEx will return zero and
            ///     GetLastError will return ERROR_REQUEST_ABORTED. In this case, the partially copied destination file is left intact.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName,
                CopyProgressRoutine lpProgressRoutine, IntPtr lpData, ref bool pbCancel, uint dwCopyFlags);

            /// <summary>
            ///     Creates a symbolic link.
            /// </summary>
            /// <param name="lpSymlinkFileName">The symbolic link to be created.</param>
            /// <param name="lpTargetFileName">The name of the target for the symbolic link to be created.</param>
            /// <param name="dwFlags">Indicates whether the link target, lpTargetFileName, is a directory.</param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName,
                uint dwFlags);

            /// <summary>
            ///     Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, FindFirstFileNameW,
            ///     FindFirstFileNameTransactedW, FindFirstFileTransacted, FindFirstStreamTransactedW, or FindFirstStreamW functions.
            /// </summary>
            /// <param name="hFindFile">The file search handle.</param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool FindClose(FindSafeHandle hFindFile);

            /// <summary>
            ///     Searches a directory for a file or subdirectory with a name that matches a specific name (or partial name if wild
            ///     cards are used).
            ///     To specify additional attributes to use in a search, use the FindFirstFileEx function.
            ///     To perform this operation as a transacted operation, use the FindFirstFileTransacted function.
            /// </summary>
            /// <param name="lpFileName">
            ///     The directory or path, and the file name, which can include wild card characters, for example, an asterisk (*) or a
            ///     question mark (?).
            ///     This parameter should not be NULL, an invalid string (for example, an empty string or a string that is missing the
            ///     terminating null character), or end in a trailing backslash (\).
            ///     If the string ends with a wild card, period (.), or directory name, the user must have access permissions to the
            ///     root and all subdirectories on the path.
            ///     In the ANSI version of this function, the name is limited to MAX_PATH characters. To extend this limit to 32,767
            ///     wide characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see
            ///     Naming a File.
            /// </param>
            /// <param name="lpFindFileData">
            ///     A pointer to the WIN32_FIND_DATA structure that receives information about a found file or
            ///     directory.
            /// </param>
            /// <returns>
            ///     If the function succeeds, the return value is a search handle used in a subsequent call to FindNextFile or
            ///     FindClose, and the lpFindFileData parameter contains information about the first file or directory found.
            ///     If the function fails or fails to locate files from the search string in the lpFileName parameter, the return value
            ///     is INVALID_HANDLE_VALUE and the contents of lpFindFileData are indeterminate. To get extended error information,
            ///     call the GetLastError function.
            ///     If the function fails because no matching files can be found, the GetLastError function returns
            ///     ERROR_FILE_NOT_FOUND.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            internal static extern FindSafeHandle FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

            /// <summary>
            ///     Continues a file search from a previous call to the FindFirstFile, FindFirstFileEx, or FindFirstFileTransacted
            ///     functions.
            /// </summary>
            /// <param name="hFindFile">The search handle returned by a previous call to the FindFirstFile or FindFirstFileEx function.</param>
            /// <param name="lpFindFileData">
            ///     A pointer to the WIN32_FIND_DATA structure that receives information about the found file
            ///     or subdirectory.
            /// </param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero and the lpFindFileData parameter contains information about
            ///     the next file or directory found.
            ///     If the function fails, the return value is zero and the contents of lpFindFileData are indeterminate. To get
            ///     extended error information, call the GetLastError function.
            ///     If the function fails because no more matching files can be found, the GetLastError function returns
            ///     ERROR_NO_MORE_FILES.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool FindNextFile(FindSafeHandle hFindFile, out WIN32_FIND_DATA lpFindFileData);

            /// <summary>
            ///     Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count. When the
            ///     reference count reaches zero, the module is unloaded from the address space of the calling process and the handle
            ///     is no longer valid.
            /// </summary>
            /// <param name="handle">
            ///     A handle to the loaded library module. The LoadLibrary, LoadLibraryEx, GetModuleHandle, or
            ///     GetModuleHandleEx function returns this handle.
            /// </param>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool FreeLibrary(ModuleSafeHandle handle);

            /// <summary>
            ///     Retrieves the application-specific portion of the search path used to locate DLLs for the application.
            /// </summary>
            /// <param name="nBufferLength">The size of the output buffer, in characters.</param>
            /// <param name="lpBuffer">A pointer to a buffer that receives the application-specific portion of the search path.</param>
            /// <returns>
            ///     If the function succeeds, the return value is the length of the string copied to lpBuffer, in characters, not
            ///     including the terminating null character. If the return value is greater than nBufferLength, it specifies the size
            ///     of the buffer required for the path.
            ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            internal static extern uint GetDllDirectory(uint nBufferLength, IntPtr lpBuffer);

            /// <summary>
            ///     Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
            /// </summary>
            /// <param name="hModule">
            ///     A handle to the DLL module that contains the function or variable. The LoadLibrary, LoadLibraryEx,
            ///     LoadPackagedLibrary, or GetModuleHandle function returns this handle.
            ///     The GetProcAddress function does not retrieve addresses from modules that were loaded using the
            ///     LOAD_LIBRARY_AS_DATAFILE flag. For more information, see LoadLibraryEx.
            /// </param>
            /// <param name="lpProcName">
            ///     The function or variable name, or the function's ordinal value. If this parameter is an
            ///     ordinal value, it must be in the low-order word; the high-order word must be zero.
            /// </param>
            /// <returns>
            ///     If the function succeeds, the return value is the address of the exported function or variable.
            ///     If the function fails, the return value is NULL. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            internal static extern IntPtr GetProcAddress(ModuleSafeHandle hModule, string lpProcName);

            /// <summary>
            ///     Loads the specified module into the address space of the calling process. The specified module may cause other
            ///     modules to be loaded.
            /// </summary>
            /// <param name="lpFileName">
            ///     The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file).
            ///     The name specified is the file name of the module and is not related to the name stored in the library module
            ///     itself, as specified by the LIBRARY keyword in the module-definition (.def) file.
            ///     If the string specifies a full path, the function searches only that path for the module.
            ///     If the string specifies a relative path or a module name without a path, the function uses a standard search
            ///     strategy to find the module; for more information, see the Remarks.
            ///     If the function cannot find the module, the function fails. When specifying a path, be sure to use backslashes (\),
            ///     not forward slashes (/). For more information about paths, see Naming a File or Directory.
            ///     If the string specifies a module name without a path and the file name extension is omitted, the function appends
            ///     the default library extension .dll to the module name. To prevent the function from appending .dll to the module
            ///     name, include a trailing point character (.) in the module name string.
            /// </param>
            /// <returns>
            ///     If the function succeeds, the return value is a handle to the module.
            ///     If the function fails, the return value is NULL. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            internal static extern ModuleSafeHandle LoadLibrary(string lpFileName);

            /// <summary>
            ///     Loads the specified module into the address space of the calling process. The specified module may cause other
            ///     modules to be loaded.
            /// </summary>
            /// <param name="lpFileName">
            ///     A string that specifies the file name of the module to load. This name is not related to the name stored in a
            ///     library module itself, as specified by the LIBRARY keyword in the module-definition (.def) file.
            ///     The module can be a library module (a .dll file) or an executable module (an .exe file). If the specified module is
            ///     an executable module, static imports are not loaded; instead, the module is loaded as if
            ///     DONT_RESOLVE_DLL_REFERENCES was specified. See the dwFlags parameter for more information.
            ///     If the string specifies a module name without a path and the file name extension is omitted, the function appends
            ///     the default library extension .dll to the module name. To prevent the function from appending .dll to the module
            ///     name, include a trailing point character (.) in the module name string.
            ///     If the string specifies a fully qualified path, the function searches only that path for the module. When
            ///     specifying a path, be sure to use backslashes (\), not forward slashes (/). For more information about paths, see
            ///     Naming Files, Paths, and Namespaces.
            ///     If the string specifies a module name without a path and more than one loaded module has the same base name and
            ///     extension, the function returns a handle to the module that was loaded first.
            ///     If the string specifies a module name without a path and a module of the same name is not already loaded, or if the
            ///     string specifies a module name with a relative path, the function searches for the specified module. The function
            ///     also searches for modules if loading the specified module causes the system to load other associated modules (that
            ///     is, if the module has dependencies). The directories that are searched and the order in which they are searched
            ///     depend on the specified path and the dwFlags parameter. For more information, see Remarks.
            ///     If the function cannot find the module or one of its dependencies, the function fails.
            /// </param>
            /// <param name="hFile">This parameter is reserved for future use. It must be NULL.</param>
            /// <param name="dwFlags">
            ///     The action to be taken when loading the module. If no flags are specified, the behavior of this
            ///     function is identical to that of the LoadLibrary function.
            /// </param>
            /// <returns>
            ///     If the function succeeds, the return value is a handle to the loaded module.
            ///     If the function fails, the return value is NULL. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            internal static extern ModuleSafeHandle LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);

            /// <summary>
            ///     Removes a directory that was added to the process DLL search path by using AddDllDirectory.
            /// </summary>
            /// <param name="Cookie">The cookie returned by AddDllDirectory when the directory was added to the search path.</param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool RemoveDllDirectory(IntPtr Cookie);

            /// <summary>
            ///     Adds a directory to the search path used to locate DLLs for the application.
            /// </summary>
            /// <param name="lpPathName">
            ///     The directory to be added to the search path. If this parameter is an empty string (""), the
            ///     call removes the current directory from the default DLL search order. If this parameter is NULL, the function
            ///     restores the default search order.
            /// </param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool SetDllDirectory(string lpPathName);
        }
    }

    #endregion Native Methods
}