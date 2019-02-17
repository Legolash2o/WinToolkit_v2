using System;
using System.Diagnostics;
using System.IO;

namespace WinToolkitDLL.Commands
{
    /// <summary>
    ///     The class responsible for extraction files.
    /// </summary>
    public static class Extraction
    {
        #region RESOURCE

        /// <summary>
        ///     Extracts a file from memory.
        /// </summary>
        /// <param name="resource">The item in memory.</param>
        /// <param name="filePath">Where to save the item.</param>
        public static void WriteResource(byte[] resource, string filePath)
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                return;
            }
            Exception mainEx = null;

            if (File.Exists(filePath))
            {
                return;
            }

            try
            {
                var outDirectory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(outDirectory))
                {
                    Directory.CreateDirectory(outDirectory);
                }

                File.WriteAllBytes(filePath, resource);
            }
            catch (Exception Ex)
            {
                //new SmallError("Missing Reserouce", Ex, Output).Upload();
            }
        }

        #endregion

        #region EXPAND

        /// <summary>
        ///     Uses the expand.exe console tool to extract a file.
        /// </summary>
        /// <param name="filePath">The file you wish to expand</param>
        /// <param name="outDirectory">Where the extracted files go.</param>
        /// <returns>True if expanded</returns>
        /// <returns></returns>
        public static bool Expand(string filePath, string outDirectory)
        {
            return Expand(filePath, "*", outDirectory);
        }

        /// <summary>
        ///     Uses the expand.exe console tool to extract a file.
        /// </summary>
        /// <param name="filePath">The file you wish to expand</param>
        /// <param name="filter">What files you want expanded. * for all</param>
        /// <param name="outDirectory">Where the extracted files go.</param>
        /// <returns>True if expanded</returns>
        public static bool Expand(string filePath, string filter, string outDirectory)
        {
            outDirectory = outDirectory.Trim().TrimEnd('\\');

            if (!File.Exists(filePath))
            {
                return false;
            }
            if (!Directory.Exists(outDirectory))
            {
                Directory.CreateDirectory(outDirectory);
            }
            Processes.Open("expand.exe", "\"" + filePath + "\" -F:" + filter + " \"" + outDirectory + "\"", true,
                ProcessWindowStyle.Hidden);
            return Directory.Exists(outDirectory);
        }

        #endregion
    }
}