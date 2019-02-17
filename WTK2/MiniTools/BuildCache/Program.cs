using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitDLL.Objects.Integratables;

namespace BuildCache
{
    internal class Program
    {
        private static void WriteText(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void Cleanup()
        {
            WriteText("Cleaning...");
            FileHandling.DeleteDirectory(Directories.Application + "\\Temp\\");
        }

        private static void Main(string[] args)
        {
            Cleanup();

            try
            {
                Console.WindowHeight = 50;
            }
            catch
            {
            }

            if (args.Length == 0)
            {
                WriteText("No directory specified", ConsoleColor.Red);
                return;
            }

            var files = new List<string>();
            var foundDir = new List<UpdateDirectory>();

            WriteText("Deleting [" + UpdateCache.CACHE_PATH_XML + "]...", ConsoleColor.Yellow);
            FileHandling.DeleteFile(UpdateCache.CACHE_PATH_XML);

            WriteText("Deleting [" + UpdateCache.CACHE_ERROR_XML + "]...", ConsoleColor.Yellow);
            FileHandling.DeleteFile(UpdateCache.CACHE_ERROR_XML);
            Console.WriteLine();

            foreach (var directory in args.AsParallel())
            {
                try
                {
                    if (!Directory.Exists(directory))
                    {
                        WriteText("Invalid directory [" + directory + "]", ConsoleColor.Red);
                        return;
                    }
                    WriteText("Searching [" + directory + "]...", ConsoleColor.Yellow);

                    var foundFiles = Directory.GetFileSystemEntries(directory, "*.*", SearchOption.AllDirectories)
                        .Where(
                            f =>
                                Path.GetExtension(f)
                                    .EndsWithIgnoreCase(".MSU", StringComparison.InvariantCultureIgnoreCase) ||
                                Path.GetExtension(f)
                                    .EndsWithIgnoreCase(".CAB", StringComparison.InvariantCultureIgnoreCase))
                        .ToArray();

                    lock (files)
                    {
                        var updDirectory = new UpdateDirectory
                        {
                            Path = directory,
                            FileCount = foundFiles.Length
                        };

                        foundDir.Add(updDirectory);
                        files.AddRange(foundFiles);
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                    Console.ReadKey();
                }
            }


            Console.Title = "Building Update Cache";
            Options.GetMD5 = true;
            WriteText("Found " + files.Count + " files.");

            WriteText("Loading Cache...");
            UpdateCache.Load();

            var i = 1;
            var Cache = UpdateCache.Count;
            var total = files.Count;
            foreach (var update in files)
            {
                Console.Clear();
                var progress = ((float) i/total);
                WriteText("Building Cache " + i + " of " + total + " [" + progress.ToString("0.00%") + "]",
                    ConsoleColor.Cyan);
                Console.WriteLine();
                foreach (var updDirectory in foundDir)
                {
                    WriteText(" [" + updDirectory.Path + "] :: " + updDirectory.FileCount);
                }

                Console.WriteLine();
                WriteText("Cache: " + Cache);
                WriteText("Total: " + UpdateCache.Count + " | New: " +
                          (UpdateCache.Count - Cache - UpdateCache.UnknownCount));
                Console.WriteLine();

                WriteText("GDR: " + UpdateCache.GDRCount);
                WriteText("LDR: " + UpdateCache.LDRCount);
                WriteText("Unknown: " + UpdateCache.UnknownCount);
                Console.WriteLine();
                WriteText("----------------------------------------");
                Console.WriteLine();
                string cabFile;
                var temp = Directories.Application + "\\Temp\\" + i;

                MsuUpdate msuItem = null;
                WriteText("Name: " + Path.GetFileName(update));
                WriteText("Size: " + FileHandling.GetSize(update, true));
                Console.WriteLine();
                if (update.EndsWithIgnoreCase("MSU", StringComparison.InvariantCultureIgnoreCase))
                {
                    WriteText("Checking MSU [" + update + "]");
                    if (UpdateCache.Find(Path.GetFileName(update), FileHandling.GetSize(update)) != null)
                    {
                        i++;
                        continue;
                    }

                    WriteText("Preparing MSU [" + update + "]");
                    msuItem = new MsuUpdate(update);

                    WriteText("Extracting CAB [" + update + "]");
                    Extraction.Expand(update, "*.cab", temp);

                    cabFile = Directory.GetFiles(temp, "*.cab", SearchOption.TopDirectoryOnly).FirstOrDefault();

                    if (cabFile == null)
                    {
                        msuItem.UpdateType = UpdateType.GDR;
                        UpdateCache.Add(msuItem);
                    }
                }
                else
                {
                    cabFile = update;
                }

                if (!string.IsNullOrWhiteSpace(cabFile))
                {
                    if (msuItem != null)
                    {
                        Console.WriteLine();
                    }

                    WriteText("Checking CAB [" + update + "]");
                    if (UpdateCache.Find(Path.GetFileName(cabFile), FileHandling.GetSize(cabFile)) == null)
                    {
                        WriteText("Preparing CAB [" + cabFile + "]");
                        var cabItem = new CabUpdate(cabFile);

                        WriteText("Extracting CAB Files [" + cabFile + "]");
                        Extraction.Expand(cabFile, "update-bf.mum", temp);

                        cabItem.UpdateType = UpdateType.GDR;

                        if (File.Exists(temp + "\\update-bf.mum"))
                        {
                            cabItem.UpdateType = UpdateType.LDR;
                        }
                        Console.WriteLine();
                        WriteText("Update is " + cabItem.UpdateType, ConsoleColor.Green);
                        UpdateCache.Add(cabItem);
                        if (msuItem != null)
                        {
                            msuItem.UpdateType = cabItem.UpdateType;
                            UpdateCache.Add(msuItem);
                        }
                    }
                }

                FileHandling.DeleteDirectory(temp);
                i++;
            }
            Cleanup();

            Console.WriteLine();
            WriteText("Build complete. Press any key to close.", ConsoleColor.Green);
            Console.ReadKey();
        }

        private class UpdateDirectory
        {
            public int FileCount;
            public string Path;
        }
    }
}