using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinToolkitDLL;
using WinToolkitDLL.Commands;

namespace UnitTesting
{
    [TestClass]
    public class Testing
    {
        private static readonly string _temp = Directories.Windows + "WinToolkit_Test\\";

        public Testing()
        {
            UpdateCache.Load();
            Options.GetMD5 = true;
            Directories.TempPath = _temp;
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            FileHandling.DeleteDirectory(_temp);
        }
    }


    internal static class _Global
    {
        /// <summary>
        ///     Returns the directory where all the test files are located.
        /// </summary>
        public static string TestDirectory
        {
            get { return Path.GetDirectoryName(Environment.CurrentDirectory) + "\\Test_Files\\"; }
        }
    }
}