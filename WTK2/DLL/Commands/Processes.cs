using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using WinToolkitDLL.Extensions;
using WinToolkitDLL.ThirdParty;

namespace WinToolkitDLL.Commands
{
    /// <summary>
    ///     Methods which allow you to to run external programs.
    /// </summary>
    public static class Processes
    {
        /// <summary>
        ///     Opens the specified program normally.
        /// </summary>
        /// <param name="fileName">The file you wish to run</param>
        /// <param name="argument">The argument/switch you wish to run with it</param>
        /// <param name="autoClose">Autoclose any message boxes.</param>
        /// <param name="wait">Wait until the program closes.</param>
        /// <param name="windowStyle">How the window opens.</param>
        /// <returns>Exit Code</returns>
        public static int Open(string fileName, string argument, bool autoClose, bool wait,
            ProcessWindowStyle windowStyle)
        {
            if (!File.Exists(fileName) && File.Exists(Directories.System32 + fileName))
            {
                fileName = Directories.System32 + fileName;
            }

            if (!fileName.EndsWithIgnoreCase("\""))
            {
                fileName += "\"";
            }
            if (!fileName.StartsWithIgnoreCase("\""))
            {
                fileName = "\"" + fileName;
            }

            try
            {
                using (var newProcess = new Process())
                {
                    if (!string.IsNullOrWhiteSpace(argument))
                    {
                        newProcess.StartInfo.Arguments = argument;
                    }

                    newProcess.StartInfo.WindowStyle = windowStyle;
                    newProcess.StartInfo.FileName = fileName;
                    newProcess.Start();

                    if (newProcess.HasExited)
                        return newProcess.ExitCode;

                    try
                    {                       
                            newProcess.PriorityClass = fileName.ContainsIgnoreCase("DISM") ? Options.WinToolkitDism : Options.WinToolkitExt;                       
                    }
                    catch { }
                 

                    if (autoClose)
                    {
                        while (!newProcess.HasExited && fileName.ContainsIgnoreCase("EXE2CAB"))
                        {
                            Thread.Sleep(50);
                            var handle = NativeMethods.FindWindow("#32770", "EXE2CAB");

                            if (!handle.ToString().Equals("0"))
                            {
                                NativeMethods.SendMessage(new HandleRef(null, handle), 0x10, IntPtr.Zero, IntPtr.Zero);
                                newProcess.Kill();
                                return newProcess.ExitCode;
                            }
                        }
                    }

                 

                    try
                    {
                        if (wait)
                        {
                            newProcess.WaitForExit();
                        }                     
                    }
                    catch {

                    }
                    return newProcess.ExitCode;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
                //LargeError LE = new LargeError("Open Program", "An error occurred whilst trying to run: " + fileName, Ex);
                //LE.Upload(); LE.ShowDialog();
            }
            return -999;
        }

        /// <summary>
        ///     Run the specified program via console and get the result via string.
        /// </summary>
        /// <param name="fileName">The program you wish to run.</param>
        /// <param name="argument">The argument/switch you want to run.</param>
        /// <returns>Entire console text.</returns>
        public static string Run(string fileName, string argument)
        {
            try
            {
                using (var newProcess = new Process())
                {
                    newProcess.StartInfo.FileName = "cmd.exe";
                    newProcess.StartInfo.Arguments = string.Empty;
                    newProcess.StartInfo.RedirectStandardInput = true;
                    newProcess.StartInfo.RedirectStandardError = true;
                    newProcess.StartInfo.RedirectStandardOutput = true;
                    newProcess.StartInfo.UseShellExecute = false;
                    newProcess.StartInfo.CreateNoWindow = true;
                    newProcess.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                    newProcess.Start();

                    try
                    {
                        newProcess.PriorityClass = fileName.ContainsIgnoreCase("DISM")
                            ? Options.WinToolkitDism
                            : Options.WinToolkitExt;
                    }
                    catch
                    {
                    }

                    if (!fileName.StartsWithIgnoreCase("\""))
                    {
                        fileName = "\"" + fileName;
                    }
                    if (!fileName.EndsWithIgnoreCase("\""))
                    {
                        fileName = fileName + "\"";
                    }

                    using (var streamW = new StreamWriter(newProcess.StandardInput.BaseStream, Encoding.UTF8))
                    {
                        streamW.WriteLine("chcp 65001");
                        streamW.WriteLine("Set SEE_MASK_NOZONECHECKS=1");
                        if (string.IsNullOrWhiteSpace(argument))
                        {
                            streamW.WriteLine(fileName);
                        }
                        else
                        {
                            streamW.WriteLine(fileName + " " + argument);
                        }
                        streamW.WriteLine("exit");
                    }

                    using (var streamR = new StreamReader(newProcess.StandardOutput.BaseStream, Encoding.UTF8))
                    {
                        return streamR.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
            }

            return "";
        }

        /// <summary>
        ///     Kill the specified process.
        /// </summary>
        /// <param name="name">Name of the process.</param>
        public static void KillProcess(string name)
        {
            //var ps = Process.GetProcesses();
            foreach (
                var process in
                    Process.GetProcesses()
                        .Where(
                            p =>
                                string.Equals(p.ProcessName, name, StringComparison.CurrentCultureIgnoreCase) &&
                                !p.HasExited))
            {
                process.Kill();
            }
        }

        /// <summary>
        ///     Checks if the application is already running
        /// </summary>
        /// <param name="name">Name of the application</param>
        /// <param name="count">How many times you know it's already running</param>
        /// <returns>True if process is already running.</returns>
        public static bool IsRunning(string name, int count = 0)
        {
            return Process.GetProcessesByName(name).Count() > count;
        }

        /// <summary>
        ///     Opens the specified folder in Windows Explorer.
        /// </summary>
        /// <param name="folder">The required folder.</param>
        public static void OpenExplorer(string folder)
        {
            var proc = new Process
            {
                EnableRaisingEvents = false,
                StartInfo =
                {
                    FileName = "explorer.exe",
                    Arguments = "\"" + folder + "\"",
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };
            proc.Start();
        }

        /// <summary>
        ///     Opens a website using the default web browser.
        /// </summary>
        /// <param name="webSite">The website URL.</param>
        /// <param name="showAdFly">Should adverts be shown.</param>
        public static void OpenLink(string webSite, bool showAdFly = true)
        {
            if (!webSite.ContainsIgnoreCase("ADF.LY") && showAdFly && !OS.WinToolkit.ValidKey)
            {
                webSite = "http://adf.ly/1964538/" + webSite;
            }

            webSite = webSite.Replace(" ", "%20");

            try
            {
                var P = new Process
                {
                    StartInfo =
                    {
                        FileName = OS.GetDefaultBrowser(),
                        Arguments = "\"" + webSite + "\"",
                        WindowStyle = ProcessWindowStyle.Normal
                    }
                };

                P.Start();
            }
            catch
            {
                OpenWithExplorer(ref webSite);
            }
        }

        /// <summary>
        ///     Opens a website using Windows Explorer.
        ///     Only used when default browser can't be found.
        /// </summary>
        /// <param name="webSite">The website URL.</param>
        private static void OpenWithExplorer(ref string webSite)
        {
            try
            {
                var IE = Directories.ProgramFiles + "\\Internet Explorer\\iexplore.exe";
                if (File.Exists(IE))
                {
                    Open("\"" + IE + "\"", "\"" + webSite + "\"", false, ProcessWindowStyle.Normal);
                }
                else
                {
                    throw new FileNotFoundException("There seems to be an issue detecting a default browser.");
                }
            }
            catch
            {
            }
        }

        #region OVERLOADS

        /// <summary>
        ///     Opens the specified program normally.
        /// </summary>
        /// <param name="fileName">The file you wish to run</param>
        /// <returns>Exit Code</returns>
        public static int Open(string fileName)
        {
            return Open(fileName, "", false, true, ProcessWindowStyle.Hidden);
        }

        /// <summary>
        ///     Opens the specified program normally.
        /// </summary>
        /// <param name="fileName">The file you wish to run</param>
        /// <param name="argument">The argument/switch you wish to run with it</param>
        /// <returns>Exit Code</returns>
        public static int Open(string fileName, string argument)
        {
            return Open(fileName, argument, false, true, ProcessWindowStyle.Hidden);
        }

        /// <summary>
        ///     Opens the specified program normally.
        /// </summary>
        /// <param name="fileName">The file you wish to run</param>
        /// <param name="wait">Wait until the program closes.</param>
        /// <returns>Exit Code</returns>
        public static int Open(string fileName, bool wait)
        {
            return Open(fileName, "", false, wait, ProcessWindowStyle.Hidden);
        }

        /// <summary>
        ///     Opens the specified program normally.
        /// </summary>
        /// <param name="fileName">The file you wish to run</param>
        /// <param name="argument">The argument/switch you wish to run with it</param>
        /// <param name="windowStyle">How the window opens.</param>
        /// <returns>Exit Code</returns>
        public static int Open(string fileName, string argument, ProcessWindowStyle windowStyle)
        {
            return Open(fileName, argument, false, true, windowStyle);
        }

        /// <summary>
        ///     Opens the specified program normally.
        /// </summary>
        /// <param name="fileName">The file you wish to run</param>
        /// <param name="argument">The argument/switch you wish to run with it</param>
        /// <param name="wait">Wait until the program closes.</param>
        /// <param name="windowStyle">How the window opens.</param>
        /// <returns>Exit Code</returns>
        public static int Open(string fileName, string argument, bool wait, ProcessWindowStyle windowStyle)
        {
            return Open(fileName, argument, false, wait, windowStyle);
        }

        /// <summary>
        ///     Opens the specified program normally.
        /// </summary>
        /// <param name="fileName">The file you wish to run</param>
        /// <param name="argument">The argument/switch you wish to run with it</param>
        /// <param name="wait">Wait until the program closes.</param>
        /// <returns>Exit Code</returns>
        public static int Open(string fileName, string argument, bool wait)
        {
            return Open(fileName, argument, false, wait, ProcessWindowStyle.Hidden);
        }

        /// <summary>
        ///     Opens the specified program normally.
        /// </summary>
        /// <param name="fileName">The file you wish to run</param>
        /// <param name="argument">The argument/switch you wish to run with it</param>
        /// <param name="autoClose">Autoclose any message boxes.</param>
        /// <returns>Exit Code</returns>
        public static int Open(string fileName, string argument, string autoClose)
        {
            return Open(fileName, argument, false, true, ProcessWindowStyle.Hidden);
        }

        #endregion
    }
}