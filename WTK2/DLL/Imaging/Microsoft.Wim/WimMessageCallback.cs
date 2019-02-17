using System;

// ReSharper disable InconsistentNaming

namespace Microsoft.Wim
{
    /// <summary>
    ///     An application defined method to be called when messages are set from the Windows® imaging API.
    /// </summary>
    /// <param name="messageType">The <see cref="WimMessageType" /> of the message.</param>
    /// <param name="message">
    ///     An object containing information about the message.  The object's type depends on the messageType
    ///     parameter.
    /// </param>
    /// <param name="userData">A user-defined object passed when the callback was registered.</param>
    /// <returns>
    ///     To indicate success and to enable other subscribers to process the message return
    ///     <see cref="WimMessageResult.Success" />. To prevent other subscribers from receiving the message, return
    ///     <see cref="WimMessageResult.Done" />. To cancel an image apply or image capture, return
    ///     <see cref="WimMessageResult.Abort" /> when handling the <see cref="WimMessageProcess" /> message.
    /// </returns>
    public delegate WimMessageResult WimMessageCallback(WimMessageType messageType, object message, object userData);

    public static partial class WimgApi
    {
        /// <summary>
        ///     An application-defined function used with the WIMRegisterMessageCallback or WIMUnregisterMessageCallback functions.
        /// </summary>
        /// <param name="MessageId">Specifies the type of message.</param>
        /// <param name="wParam">
        ///     Specifies additional message information. The contents of this parameter depend on the value of
        ///     the dwMessageId parameter.
        /// </param>
        /// <param name="lParam">
        ///     Specifies additional message information. The contents of this parameter depend on the value of
        ///     the dwMessageId parameter.
        /// </param>
        /// <param name="UserData">
        ///     A handle that specifies the user-defined value passed to the WIMRegisterMessageCallback
        ///     function.
        /// </param>
        /// <returns>
        ///     To indicate success and to enable other subscribers to process the message return WIM_MSG_SUCCESS. To prevent
        ///     other subscribers from receiving the message, return WIM_MSG_DONE. To cancel an image apply or image capture,
        ///     return WIM_MSG_ABORT_IMAGE when handling the WIM_MSG_PROCESS message.
        /// </returns>
        /// <remarks>
        ///     Call the WIMUnregisterMessageCallback function with the result index when the WIMMessageCallback function is no
        ///     longer required.
        ///     Do not use WIM_MSG_ABORT_IMAGE to cancel the process as a shortcut method of extracting a single file. Windows®
        ///     Imaging API is multi-threaded and aborting a process will cancel all background threads, which may include the
        ///     single file you want to extract. If you want to extract a single file, use the WIMExtractImagePath function.
        /// </remarks>
        internal delegate WimMessageResult WIMMessageCallback(
            WimMessageType MessageId, IntPtr wParam, IntPtr lParam, IntPtr UserData);
    }

    /// <summary>
    ///     Represents a wrapper class for the native callback functionality.  This class exposes a native callback and then
    ///     calls the managed callback with marshaled values.
    /// </summary>
    internal sealed class WimMessageCallbackWrapper
    {
        /// <summary>
        ///     The user's callback method.
        /// </summary>
        private readonly WimMessageCallback _callback;

        /// <summary>
        ///     The user's custom data to pass around
        /// </summary>
        private readonly object _userData;

        /// <summary>
        ///     Initializes a new instance of the WimMessageCallbackWrapper class
        /// </summary>
        /// <param name="callback">
        ///     A <see cref="WimMessageCallback" /> delegate to call when a message is received from the
        ///     Windows® Imaging API.
        /// </param>
        /// <param name="userData">An object containing data to be used by the method.</param>
        public WimMessageCallbackWrapper(WimMessageCallback callback, object userData)
        {
            // Store the values
            //
            _callback = callback;
            _userData = userData;

            // Store a reference to the native callback to avoid garbage collection
            //
            NativeCallback = WimMessageCallback;
        }

        /// <summary>
        ///     Gets the native callback delegate to be executed.
        /// </summary>
        public WimgApi.WIMMessageCallback NativeCallback { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="MessageId">Specifies the sent message.</param>
        /// <param name="wParam">
        ///     Specifies additional message information. The contents of this parameter depend on the value of
        ///     the MessageId parameter.
        /// </param>
        /// <param name="lParam">
        ///     Specifies additional message information. The contents of this parameter depend on the value of
        ///     the MessageId parameter.
        /// </param>
        /// <param name="UserData">
        ///     A handle that specifies the user-defined value passed to the WIMRegisterMessageCallback
        ///     function.  This is currently not used.
        /// </param>
        /// <returns></returns>
        private WimMessageResult WimMessageCallback(WimMessageType MessageId, IntPtr wParam, IntPtr lParam,
            IntPtr UserData)
        {
            // Create a default message object as null
            //
            object message = null;

            // Create a message object depending on the message type
            //
            switch (MessageId)
            {
                case WimMessageType.Alignment:
                    message = new WimMessageAlignment(wParam, lParam);
                    break;

                case WimMessageType.CleanupScanningDrive:
                    message = new WimMessageCleanupScanningDrive(wParam, lParam);
                    break;

                case WimMessageType.CleanupUnmountingImage:
                    message = new WimMessageCleanupUnmountingImage(wParam, lParam);
                    break;

                case WimMessageType.Compress:
                    message = new WimMessageCompress(wParam, lParam);
                    break;

                case WimMessageType.Error:
                    message = new WimMessageError(wParam, lParam);
                    break;

                case WimMessageType.FileInfo:
                    message = new WimMessageFileInfo(wParam, lParam);
                    break;

                case WimMessageType.ImageAlreadyMounted:
                    message = new WimMessageImageAlreadyMounted(wParam, lParam);
                    break;

                case WimMessageType.Info:
                    message = new WimMessageInformation(wParam, lParam);
                    break;

                case WimMessageType.MountCleanupProgress:
                    message = new WimMessageMountCleanupProgress(wParam, lParam);
                    break;

                case WimMessageType.Process:
                    message = new WimMessageProcess(wParam, lParam);
                    break;

                case WimMessageType.Progress:
                    message = new WimMessageProgress(wParam, lParam);
                    break;

                case WimMessageType.QueryAbort:
                    break;

                case WimMessageType.Retry:
                    message = new WimMessageRetry(wParam, lParam);
                    break;

                case WimMessageType.Scanning:
                    message = new WimMessageScanning(wParam, lParam);
                    break;

                case WimMessageType.SetPosition:
                    message = new WimMessageSetPosition(wParam, lParam);
                    break;

                case WimMessageType.SetRange:
                    message = new WimMessageSetRange(wParam, lParam);
                    break;

                case WimMessageType.Split:
                    message = new WimMessageSplit(wParam, lParam);
                    break;

                case WimMessageType.StaleMountDirectory:
                    message = new WimMessageStaleMountDirectory(wParam, lParam);
                    break;

                case WimMessageType.StaleMountFile:
                    message = new WimMessageStaleMountFile(wParam, lParam);
                    break;

                case WimMessageType.StepIt:
                    break;

                case WimMessageType.Text:
                    message = new WimMessageText(wParam, lParam);
                    break;

                case WimMessageType.Warning:
                    message = new WimMessageWarning(wParam, lParam);
                    break;

                case WimMessageType.WarningObjectId:
                    message = new WimMessageWarningObjectId(wParam, lParam);
                    break;

                default:
                    // Some messages are sent that aren't documented, so they are discarded and not sent to the user at this time
                    // When the messages are documented, they can be added to this wrapper
                    //
                    return WimMessageResult.Done;
            }

            // Call the users callback, pass the message type, message, and user data.  Return the users result value.
            //
            return _callback(MessageId, message, _userData);
        }
    }
}