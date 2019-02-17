using System;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace Microsoft.Dism
{
    /// <summary>
    ///     Represents progress made during time-consuming operations.
    /// </summary>
    /// <remarks>
    ///     This class also acts as a wrapper to the native callback method and stores the user data given back to the
    ///     original caller.
    /// </remarks>
    public sealed class DismProgress : IDisposable
    {
        /// <summary>
        ///     The users callback method.
        /// </summary>
        private readonly DismProgressCallback _callback;

        /// <summary>
        ///     An EventWaitHandle used to cancel the operation.
        /// </summary>
        private readonly EventWaitHandle _eventHandle;

        /// <summary>
        ///     Initializes a new instance of the DismProgress class.
        /// </summary>
        /// <param name="callback">A DismProgressCallback to call when progress is made.</param>
        /// <param name="userData">A custom object to pass to the callback.</param>
        internal DismProgress(DismProgressCallback callback, object userData)
        {
            // Save the managed callback method
            _callback = callback;

            // Save the user data
            UserData = userData;

            // Create an EventWaitHandle so the operation can be canceled
            _eventHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
        }

        /// <summary>
        ///     Gets or sets a value indicating if the operation should be canceled if possible.
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        ///     Gets the current progress value.
        /// </summary>
        public int Current { get; private set; }

        /// <summary>
        ///     Gets the total progress value.
        /// </summary>
        public int Total { get; private set; }

        /// <summary>
        ///     Gets the user defined object for the callback.
        /// </summary>
        public object UserData { get; private set; }

        /// <summary>
        ///     Gets a SafeWaitHandle object used for canceling the operation.
        /// </summary>
        internal SafeWaitHandle EventHandle
        {
            get { return _eventHandle.SafeWaitHandle; }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // See if the event handle has been created
            if (_eventHandle != null)
            {
                // Clean up the event handle
                _eventHandle.Dispose();
            }
        }

        /// <summary>
        ///     Called by the native DISM API during a time-consuming operation.
        /// </summary>
        internal void DismProgressCallbackNative(uint current, uint total, IntPtr userData)
        {
            // Save the current progress
            Current = (int) current;

            // Save the total progress
            Total = (int) total;

            // See if a callback method should be called
            if (_callback != null)
            {
                // Call the managed callback and pass this object so the user
                _callback(this);
            }

            // See if the user wishes to cancel the operation
            if (Cancel)
            {
                // Signal the event
                _eventHandle.Set();
            }
        }
    }
}