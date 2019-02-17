using System;
using System.Windows;
using System.Windows.Threading;
using WinToolkitDLL;

namespace WinToolkitv2._Code
{
    public static class Unhandled
    {
        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var error = (e.ExceptionObject as Exception);
            if (error != null)
            {
                error.Save("Unhandled Exception", Priority.Highest);
                error.Show("Unhandled Exception", Priority.Highest);
            }
            
            Environment.Exit(ExitCodes.UNHANDLED_EXCEPTION);
        }

        public static void CurrentDomain_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var error = e.Exception;

            error.Save("Unhandled Dispatcher Exception", Priority.Highest);
            error.Show("Unhandled Dispatcher Exception", Priority.Highest);

            e.Handled = true;
            Environment.Exit(ExitCodes.UNHANDLED_DISPATCHER_EXCEPTION);
        }
    }
}