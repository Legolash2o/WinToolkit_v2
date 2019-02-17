using System;
using System.Diagnostics;
using System.IO;

namespace WinToolkitDLL
{
    public static class AppOptions
    {
        private static Options _options = new Options();

        public static Options CurrentOptions
        {
            get { return _options; }
            set { _options = value; }
        }
    }

    public class Options
    {
        //DISM
        public static string CustomDismLocation = string.Empty;
        //Priorities
        public static ProcessPriorityClass WinToolkitPri = ProcessPriorityClass.Normal;
        public static ProcessPriorityClass WinToolkitExt = ProcessPriorityClass.Normal;
        public static ProcessPriorityClass WinToolkitDism = ProcessPriorityClass.Normal;

        public Options()
        {
            if (File.Exists(Directories.Application + "Options.xml"))
            {
                //LOAD FILE
            }
            else
            {
                LoadDefaults();
            }
        }

        //Preferences

        public static bool GetMD5 { get; set; }
        public static bool MainMenuAdvanced { get; set; }
        public static bool MainMenuAutoHeight { get; set; }
        public static bool MainMenuAutoWidth { get; set; }
        public static int MaxThreads { get; set; }

        public void LoadDefaults()
        {
            GetMD5 = false;
            MainMenuAdvanced = false;
            MainMenuAutoHeight = true;
            MainMenuAutoWidth = false;
            CustomDismLocation = string.Empty;

            if (Environment.ProcessorCount > 1)
            {
                MaxThreads = Environment.ProcessorCount - 1;
            }
            else
            {
                MaxThreads = 1;
            }

            WinToolkitPri = ProcessPriorityClass.Normal;
            WinToolkitExt = ProcessPriorityClass.Normal;
            WinToolkitDism = ProcessPriorityClass.Normal;
        }
    }
}