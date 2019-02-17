namespace WinToolkitDLL
{
    public static class ExitCodes
    {
        /// <summary>
        /// No errors.
        /// </summary>
        public const int SUCCESS = 0;

        /// <summary>
        /// WTK DLL is missing.
        /// </summary>
        public const int MISSING_DLL = -1;

        /// <summary>
        /// An error occurred outside of a Try-Catch statement.
        /// </summary>
        public const int UNHANDLED_EXCEPTION = -2;

        /// <summary>
        /// An error occurred outside of a Try-Catch statement inside a dispatcher.
        /// </summary>
        public const int UNHANDLED_DISPATCHER_EXCEPTION = -3;

        /// <summary>
        /// Trial period has expired.
        /// </summary>
        public const int EXPIRED = -4;

    }
}
