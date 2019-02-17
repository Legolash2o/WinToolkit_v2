using System;
using System.Collections.Generic;
using System.ServiceProcess;

namespace Microsoft.Win32
{
    /// <summary>
    ///     Represents the configuration of a service.
    /// </summary>
    public sealed class ServiceConfig
    {
        /// <summary>
        ///     The parsed dependencies.
        /// </summary>
        private readonly string[] _dependencies;

        /// <summary>
        ///     The native struct containing the information.
        /// </summary>
        private readonly AdvApi32.QUERY_SERVICE_CONFIG _serviceConfig;

        /// <summary>
        ///     Initializes a new instance of the ServiceConfig class.
        /// </summary>
        /// <param name="serviceConfig">
        ///     A native <see cref="AdvApi32.QUERY_SERVICE_CONFIG" /> struct containing the service
        ///     configuration.
        /// </param>
        internal ServiceConfig(AdvApi32.QUERY_SERVICE_CONFIG serviceConfig)
        {
            // Store the struct
            //
            _serviceConfig = serviceConfig;

            // Parse the dependencies as a null-separated list
            //
            _dependencies = _serviceConfig.lpDependencies == null
                ? null
                : _serviceConfig.lpDependencies.Split(new[] {'\0'}, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        ///     Gets the path to the binary that hosts the service.
        /// </summary>
        public string BinaryPath
        {
            get { return _serviceConfig.lpBinaryPathName; }
        }

        /// <summary>
        ///     Gets a list of dependencies the service has, if any.
        /// </summary>
        public IEnumerable<string> Dependencies
        {
            get { return _dependencies; }
        }

        /// <summary>
        ///     Gets the display name of the service.
        /// </summary>
        public string DisplayName
        {
            get { return _serviceConfig.lpDisplayName; }
        }

        /// <summary>
        ///     Gets the severity of the error, and action taken, if this service fails to start.
        /// </summary>
        public int ErrorControl
        {
            get { return (int) _serviceConfig.dwErrorControl; }
        }

        /// <summary>
        ///     Gets the load order group of the service.
        /// </summary>
        public string LoadOrderGroup
        {
            get { return _serviceConfig.lpLoadOrderGroup; }
        }

        /// <summary>
        ///     Gets the type of the service.
        /// </summary>
        public ServiceType ServiceType
        {
            get { return (ServiceType) _serviceConfig.dwServiceType; }
        }

        /// <summary>
        ///     Gets a value indicating when the service starts.
        /// </summary>
        public ServiceStartMode StartMode
        {
            get { return (ServiceStartMode) _serviceConfig.dwStartType; }
        }

        /// <summary>
        ///     Gets the name of the user the service runs as or the driver object name which the input and output (I/O) system
        ///     uses to load the device driver.
        /// </summary>
        public string StartName
        {
            get { return _serviceConfig.lpServiceStartName; }
        }

        /// <summary>
        ///     Gets a unique tag for the service.
        /// </summary>
        public int TagId
        {
            get { return (int) _serviceConfig.dwTagID; }
        }
    }
}