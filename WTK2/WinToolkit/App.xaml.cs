using System;
using System.Reflection;
using System.Windows;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitv2._Code;

namespace WinToolkitv2
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public bool DLL;

        public App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += MyResolveHandler;

            try
            {
                TestDLL();
                SetUnhandled();
            }
            catch (Exception)
            {
                MessageBox.Show("WinToolkit DLL is not available. WTK will now exit.", "Missing DLL");
                Environment.Exit(-1);
            }
        }

        /// <summary>
        ///     This will test whether or not the DLL is available.
        /// </summary>
        private void TestDLL()
        {
            DLL = Misc.DLLActive;
        }

        /// <summary>
        ///     Sets what happens when an unhandled exception occurs.
        /// </summary>
        private static void SetUnhandled()
        {
            Current.DispatcherUnhandledException += Unhandled.CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.UnhandledException +=
                Unhandled.CurrentDomain_UnhandledException;
        }

        private Assembly MyResolveHandler(object sender, ResolveEventArgs args)
        {
            return null;
            // WinToolkit v1.x
            //string rName = args.Name;
            //while (rName.Contains(","))
            //{
            //    rName = rName.Substring(0, rName.Length - 1);
            //}

            //switch (rName) 
            //{
            //    case "Interop.SHDocVw":
            //        return System.Reflection.Assembly.Load(Properties.Resources.Interop_SHDocVw);
            //    case "Vista Api":
            //        return System.Reflection.Assembly.Load(Properties.Resources.Vista_Api);
            //}

            //return null;
        }
    }
}