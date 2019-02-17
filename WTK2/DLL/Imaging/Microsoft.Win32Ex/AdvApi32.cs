using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using BOOL = System.Boolean;
using DWORD = System.UInt32;

namespace Microsoft.Win32
{
    /// <summary>
    ///     Provide access to functionality additional to the kernel. Included are things like the Windows registry,
    ///     shutdown/restart the system (or abort), start/stop/create a Windows service, manage user accounts.
    /// </summary>
    public static partial class AdvApi32
    {
        /// <summary>
        ///     Gets the current configuration of a service.
        /// </summary>
        /// <param name="serviceHandle">A handle to the service.</param>
        /// <returns>A <see cref="ServiceConfig" /> object containing information about the service.</returns>
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public static ServiceConfig GetServiceConfig(SafeHandle serviceHandle)
        {
            // Stores the buffer size
            //
            uint bufferSize;

            // Call the native method once to attempt to get the needed buffer size
            //
            NativeMethods.QueryServiceConfig(serviceHandle, IntPtr.Zero, 0, out bufferSize);

            // Verify the last error was ERROR_INSUFFICIENT_BUFFER, if not, throw an exception
            //
            if (Marshal.GetLastWin32Error() != Win32Error.ERROR_INSUFFICIENT_BUFFER)
            {
                throw new Win32Exception();
            }

            // Allocate a buffer that is the necessary size
            //
            var serviceConfigPtr = Marshal.AllocHGlobal((int) bufferSize);

            try
            {
                // Call the native method again which should fill the buffer with the struct and throw an exception if that fails
                //
                if (!NativeMethods.QueryServiceConfig(serviceHandle, serviceConfigPtr, bufferSize, out bufferSize))
                {
                    throw new Win32Exception();
                }

                // Marshal the pointer to a struct and return a new ServiceConfig object
                //
                return
                    new ServiceConfig(
                        (QUERY_SERVICE_CONFIG) Marshal.PtrToStructure(serviceConfigPtr, typeof (QUERY_SERVICE_CONFIG)));
            }
            finally
            {
                // Free the buffer
                //
                Marshal.FreeHGlobal(serviceConfigPtr);
            }
        }

        /// <summary>
        ///     Sets the start mode of a service.
        /// </summary>
        /// <param name="serviceHandle">A handle to the service.</param>
        /// <param name="startMode">The new start mode of the service.</param>
        public static void SetServiceStartMode(SafeHandle serviceHandle, ServiceStartMode startMode)
        {
            ChangeServiceConfig(
                serviceHandle,
                SERVICE_NO_CHANGE, // serviceType
                (uint) startMode,
                SERVICE_NO_CHANGE, // errorControl
                null, // binaryPath
                null, // loadOrderGroup
                null, // dependencies
                null, // serviceStartName
                null, // password
                null // displayName
                );
        }

        /// <summary>
        ///     Changes the configuration parameters of a service.
        /// </summary>
        /// <param name="serviceHandle">A handle to the service.</param>
        /// <param name="serviceType">
        ///     The type of service. Specify <see cref="AdvApi32.SERVICE_NO_CHANGE" /> if you are not
        ///     changing the existing service type.
        /// </param>
        /// <param name="startMode">
        ///     The service start options.  Specify <see cref="AdvApi32.SERVICE_NO_CHANGE" /> if you are not
        ///     changing the existing start options.
        /// </param>
        /// <param name="errorControl">
        ///     The severity of the error, and action taken, if this service fails to start. Specify
        ///     <see cref="AdvApi32.SERVICE_NO_CHANGE" /> if you are not changing the existing error control.
        /// </param>
        /// <param name="binaryPath">
        ///     The fully qualified path to the service binary file. Specify NULL if you are not changing the
        ///     existing path. If the path contains a space, it must be quoted so that it is correctly interpreted.
        /// </param>
        /// <param name="loadOrderGroup">
        ///     The name of the load ordering group of which this service is a member. Specify NULL if you
        ///     are not changing the existing group. Specify an empty string if the service does not belong to a group.
        /// </param>
        /// <param name="dependencies">
        ///     A pointer to a double null-terminated array of null-separated names of services or load
        ///     ordering groups that the system must start before this service can be started. (Dependency on a group means that
        ///     this service can run if at least one member of the group is running after an attempt to start all members of the
        ///     group.) Specify NULL if you are not changing the existing dependencies. Specify an empty string if the service has
        ///     no dependencies.
        /// </param>
        /// <param name="serviceStartName">
        ///     The name of the account under which the service should run. Specify NULL if you are not
        ///     changing the existing account name.
        /// </param>
        /// <param name="password">
        ///     The password to the account name specified by the lpServiceStartName parameter. Specify NULL if
        ///     you are not changing the existing password. Specify an empty string if the account has no password or if the
        ///     service runs in the LocalService, NetworkService, or LocalSystem account.
        /// </param>
        /// <param name="displayName">
        ///     The display name to be used by applications to identify the service for its users. Specify
        ///     NULL if you are not changing the existing display name.
        /// </param>
        private static void ChangeServiceConfig(SafeHandle serviceHandle, uint serviceType, uint startMode,
            uint errorControl, string binaryPath, string loadOrderGroup, string dependencies, string serviceStartName,
            string password, string displayName)
        {
            if (
                !NativeMethods.ChangeServiceConfig(serviceHandle, serviceType, startMode, errorControl, binaryPath,
                    loadOrderGroup, 0, dependencies, serviceStartName, password, displayName))
            {
                throw new Win32Exception();
            }
        }
    }

    #region Constants

    public static partial class AdvApi32
    {
        /// <summary>
        ///     Indicates that no change has occurred for a service property.
        /// </summary>
        public const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;
    }

    #endregion Constants

    #region Structs

    public static partial class AdvApi32
    {
        /// <summary>
        ///     Contains configuration information for an installed service.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct QUERY_SERVICE_CONFIG
        {
            /// <summary>
            ///     The type of service.
            /// </summary>
            public uint dwServiceType;

            /// <summary>
            ///     When to start the service.
            /// </summary>
            public uint dwStartType;

            /// <summary>
            ///     The severity of the error, and action taken, if this service fails to start.
            /// </summary>
            public uint dwErrorControl;

            /// <summary>
            ///     The fully qualified path to the service binary file.
            ///     The path can also include arguments for an auto-start service. These arguments are passed to the service entry
            ///     point (typically the main function).
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)] public string lpBinaryPathName;

            /// <summary>
            ///     The name of the load ordering group to which this service belongs. If the member is NULL or an empty string, the
            ///     service does not belong to a load ordering group.
            ///     The startup program uses load ordering groups to load groups of services in a specified order with respect to the
            ///     other groups. The list of load ordering groups is contained in the following registry value:
            ///     HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\ServiceGroupOrder
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)] public string lpLoadOrderGroup;

            /// <summary>
            ///     A unique tag value for this service in the group specified by the lpLoadOrderGroup parameter. A value of zero
            ///     indicates that the service has not been assigned a tag. You can use a tag for ordering service startup within a
            ///     load order group by specifying a tag order vector in the registry located at:
            ///     HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\GroupOrderList
            ///     Tags are only evaluated for SERVICE_KERNEL_DRIVER and SERVICE_FILE_SYSTEM_DRIVER type services that have
            ///     SERVICE_BOOT_START or SERVICE_SYSTEM_START start types.
            /// </summary>
            public uint dwTagID;

            /// <summary>
            ///     An array of null-separated names of services or load ordering groups that must start before this service. The array
            ///     is doubly null-terminated. If the pointer is NULL or if it points to an empty string, the service has no
            ///     dependencies. If a group name is specified, it must be prefixed by the SC_GROUP_IDENTIFIER (defined in WinSvc.h)
            ///     character to differentiate it from a service name, because services and service groups share the same name space.
            ///     Dependency on a service means that this service can only run if the service it depends on is running. Dependency on
            ///     a group means that this service can run if at least one member of the group is running after an attempt to start
            ///     all members of the group.
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)] public string lpDependencies;

            /// <summary>
            ///     If the service type is SERVICE_WIN32_OWN_PROCESS or SERVICE_WIN32_SHARE_PROCESS, this member is the name of the
            ///     account that the service process will be logged on as when it runs. This name can be of the form Domain\UserName.
            ///     If the account belongs to the built-in domain, the name can be of the form .\UserName. The name can also be
            ///     "LocalSystem" if the process is running under the LocalSystem account.
            ///     If the service type is SERVICE_KERNEL_DRIVER or SERVICE_FILE_SYSTEM_DRIVER, this member is the driver object name
            ///     (that is, \FileSystem\Rdr or \Driver\Xns) which the input and output (I/O) system uses to load the device driver.
            ///     If this member is NULL, the driver is to be run with a default object name created by the I/O system, based on the
            ///     service name.
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)] public string lpServiceStartName;

            /// <summary>
            ///     The display name to be used by service control programs to identify the service. This string has a maximum length
            ///     of 256 characters. The name is case-preserved in the service control manager. Display name comparisons are always
            ///     case-insensitive.
            ///     This parameter can specify a localized string using the following format:
            ///     @[Path\]DLLName,-StrID
            ///     The string with identifier StrID is loaded from DLLName; the Path is optional. For more information, see
            ///     RegLoadMUIString.
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)] public string lpDisplayName;
        };
    }

    #endregion Structs

    #region Native Methods

    public static partial class AdvApi32
    {
        /// <summary>
        ///     The character set used by AdvApi32.dll.
        /// </summary>
        public const CharSet DllCharSet = CharSet.Auto;

        /// <summary>
        ///     The name of the assembly that exposes AdvApi32.
        /// </summary>
        public const string DllName = "AdvApi32";

        /// <summary>
        ///     Provides access to the native functions.
        /// </summary>
        internal static class NativeMethods
        {
            /// <summary>
            ///     Changes the configuration parameters of a service.
            /// </summary>
            /// <param name="hService">A handle to the service.</param>
            /// <param name="dwServiceType">
            ///     The type of service. Specify SERVICE_NO_CHANGE if you are not changing the existing service
            ///     type.
            /// </param>
            /// <param name="dwStartType">
            ///     The service start options. Specify SERVICE_NO_CHANGE if you are not changing the existing
            ///     start type.
            /// </param>
            /// <param name="dwErrorControl">
            ///     The severity of the error, and action taken, if this service fails to start. Specify
            ///     SERVICE_NO_CHANGE if you are not changing the existing error control.
            /// </param>
            /// <param name="lpBinaryPathName">
            ///     The fully qualified path to the service binary file. Specify NULL if you are not
            ///     changing the existing path. If the path contains a space, it must be quoted so that it is correctly interpreted.
            /// </param>
            /// <param name="lpLoadOrderGroup">
            ///     The name of the load ordering group of which this service is a member. Specify NULL if
            ///     you are not changing the existing group. Specify an empty string if the service does not belong to a group.
            /// </param>
            /// <param name="lpdwTagId">
            ///     A pointer to a variable that receives a tag value that is unique in the group specified in the
            ///     lpLoadOrderGroup parameter. Specify NULL if you are not changing the existing tag.
            /// </param>
            /// <param name="lpDependencies">
            ///     A pointer to a double null-terminated array of null-separated names of services or load
            ///     ordering groups that the system must start before this service can be started. (Dependency on a group means that
            ///     this service can run if at least one member of the group is running after an attempt to start all members of the
            ///     group.) Specify NULL if you are not changing the existing dependencies. Specify an empty string if the service has
            ///     no dependencies.
            /// </param>
            /// <param name="lpServiceStartName">
            ///     The name of the account under which the service should run. Specify NULL if you are
            ///     not changing the existing account name. If the service type is SERVICE_WIN32_OWN_PROCESS, use an account name in
            ///     the form DomainName\UserName. The service process will be logged on as this user. If the account belongs to the
            ///     built-in domain, you can specify .\UserName (note that the corresponding C/C++ string is ".\\UserName").
            /// </param>
            /// <param name="lpPassWord">
            ///     The password to the account name specified by the lpServiceStartName parameter. Specify NULL
            ///     if you are not changing the existing password. Specify an empty string if the account has no password or if the
            ///     service runs in the LocalService, NetworkService, or LocalSystem account.
            /// </param>
            /// <param name="lpDisplayName">
            ///     he display name to be used by applications to identify the service for its users. Specify NULL if you are not
            ///     changing the existing display name; otherwise, this string has a maximum length of 256 characters. The name is
            ///     case-preserved in the service control manager. Display name comparisons are always case-insensitive.
            ///     This parameter can specify a localized string using the following format:
            ///     @[path\]dllname,-strID
            ///     The string with identifier strID is loaded from dllname; the path is optional.
            /// </param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool ChangeServiceConfig(
                SafeHandle hService,
                uint dwServiceType,
                uint dwStartType,
                uint dwErrorControl,
                [In, MarshalAs(UnmanagedType.LPWStr)] string lpBinaryPathName,
                [In, MarshalAs(UnmanagedType.LPWStr)] string lpLoadOrderGroup, int lpdwTagId,
                [In, MarshalAs(UnmanagedType.LPWStr)] string lpDependencies,
                [In, MarshalAs(UnmanagedType.LPWStr)] string lpServiceStartName,
                [In, MarshalAs(UnmanagedType.LPWStr)] string lpPassWord,
                [In, MarshalAs(UnmanagedType.LPWStr)] string lpDisplayName);

            /// <summary>
            ///     Retrieves the configuration parameters of the specified service.
            /// </summary>
            /// <param name="hService">A handle to the service.</param>
            /// <param name="lpServiceConfig">
            ///     A pointer to a buffer that receives the service configuration information. The format of
            ///     the data is a QUERY_SERVICE_CONFIG structure.
            /// </param>
            /// <param name="cbBufSize">The size of the buffer pointed to by the lpServiceConfig parameter, in bytes.</param>
            /// <param name="pcbBytesNeeded">
            ///     A pointer to a variable that receives the number of bytes needed to store all the
            ///     configuration information, if the function fails with ERROR_INSUFFICIENT_BUFFER.
            /// </param>
            /// <returns>
            ///     If the function succeeds, the return value is nonzero.
            ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport(DllName, CharSet = DllCharSet, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool QueryServiceConfig(SafeHandle hService, IntPtr lpServiceConfig, uint cbBufSize,
                out uint pcbBytesNeeded);
        }
    }

    #endregion Native Methods
}