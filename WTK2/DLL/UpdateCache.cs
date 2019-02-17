using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitDLL.Objects.Integratables;

namespace WinToolkitDLL
{
    public static class UpdateCache
    {
        public static readonly string CACHE_PATH_XML = Directories.Application + "\\updateCache.xml";
        public static readonly string CACHE_ERROR_XML = Directories.Application + "\\updateCacheErrors.xml";
        private static readonly XElement xError = new XElement("UpdatesError");
        private static readonly XElement xUpdates = new XElement("Updates");
        private static readonly List<UpdateCacheItem> _updateCache = new List<UpdateCacheItem>();

        public static int Count
        {
            get { return _updateCache.Count; }
        }

        public static int LDRCount
        {
            get { return _updateCache.Count(u => u.Type == UpdateType.LDR); }
        }

        public static int GDRCount
        {
            get { return _updateCache.Count(u => u.Type == UpdateType.GDR); }
        }

        public static int UnknownCount
        {
            get { return _updateCache.Count(u => u.Type == UpdateType.Unknown); }
        }

        public static UpdateCacheItem Find(string MD5)
        {
            return _updateCache.FirstOrDefault(u => u.MD5.EqualsIgnoreCase(MD5));
        }

        public static UpdateCacheItem Find(string fileName, long size)
        {
            if (fileName == null)
            {
                return null;
            }
            return _updateCache.FirstOrDefault(u => u.FileName.StartsWithIgnoreCase(fileName) && u.Size == size);
        }

        public static void Add(_Update update)
        {
            var searchUpdate = _updateCache.FirstOrDefault(u => u.MD5.EqualsIgnoreCase(update.MD5));

            if (searchUpdate == null)
            {
                var newCache = new UpdateCacheItem();
                newCache.FileName = Path.GetFileName(update.Location);
                newCache.Size = update.Size;
                newCache.PackageName = update.PackageName;
                newCache.PackageVersion = update.PackageVersion;
                newCache.Type = update.UpdateType;
                if (update.MD5.EqualsIgnoreCase("N/A"))
                {
                    newCache.MD5 = FileHandling.GetMD5(update.Location);
                }
                else
                {
                    newCache.MD5 = update.MD5;
                }
                newCache.Architecture = update.Architecture;
                newCache.PackageDescription = update.Description;
                newCache.Language = update.Language;
                newCache.AppliesTo = update.AppliesTo.TryParse<decimal>();
                newCache.Support = update.Support;
                newCache.CreatedDate = update.Date;
                newCache.AllowedOffline = update.AllowedOffline;

                lock (_updateCache)
                {
                    if (update.PackageName.EqualsIgnoreCase("default") || update.PackageName.EqualsIgnoreCase("1.0") ||
                        update.PackageName.Equals("000000") || update.AppliesTo.ToString() == "1.0")
                    {
                        newCache.Type = UpdateType.Unknown;
                        xError.Add(newCache.XML);
                    }
                    else
                    {
                        xUpdates.Add(newCache.XML);
                    }

                    _updateCache.Add(newCache);
                    Save();
                }
            }
        }

        public static void Load()
        {
            if (File.Exists(CACHE_PATH_XML))
            {
                var xDoc = new XmlDocument();
                xDoc.Load(CACHE_PATH_XML);

                var xParent = (XmlElement) xDoc.LastChild;

                foreach (XmlElement E in xParent.ChildNodes)
                {
                    var newCache = new UpdateCacheItem
                    {
                        FileName = E.Attributes["Filename"].InnerText,
                        Size = long.Parse(E.Attributes["Size"].InnerText),
                        PackageName = E.Attributes["Name"].InnerText,
                        PackageVersion = E.Attributes["Version"].InnerText,
                        Architecture = (Architecture) Enum.Parse(typeof (Architecture), E.Attributes["Arc"].InnerText),
                        MD5 = E.Attributes["MD5"].InnerText,
                        PackageDescription = E.Attributes["Desc"].InnerText,
                        AppliesTo = E.Attributes["AppliesTo"].InnerText.TryParse<decimal>(),
                        Support = E.Attributes["Support"].InnerText,
                        CreatedDate = DateTime.Parse(E.Attributes["CreatedDate"].InnerText)
                    };
                    if (E.HasAttribute("Offline"))
                    {
                        newCache.AllowedOffline = bool.Parse(E.Attributes["Offline"].InnerText);
                    }

                    if (E.HasAttribute("Type"))
                    {
                        newCache.Type = (UpdateType) Enum.Parse(typeof (UpdateType), E.Attributes["Type"].InnerText);
                    }
                    if (E.HasAttribute("Lang"))
                    {
                        newCache.Language = E.Attributes["Lang"].InnerText;
                    }

                    _updateCache.Add(newCache);
                }
            }
        }

        public static void Save()
        {
            var stopwatch = new Stopwatch();
            if (Debugger.IsAttached)
                stopwatch.Start();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Saving...");
            Console.ResetColor();

            xUpdates.SetAttributeValue("Count", xUpdates.Nodes().Count());
            xUpdates.SetAttributeValue("GDR", GDRCount);
            xUpdates.SetAttributeValue("LDR", LDRCount);
            xUpdates.SetAttributeValue("Date", DateTime.UtcNow.ToString("dd MMMM yyyy H:mm"));
            xError.SetAttributeValue("Count", xError.Nodes().Count());

            if (xUpdates.HasElements)
            {
                xUpdates.Save(CACHE_PATH_XML);
            }

            if (xError.HasElements)
            {
                xError.Save(CACHE_ERROR_XML);
            }


            if (Debugger.IsAttached)
            {
                stopwatch.Stop();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                Console.ResetColor();
            }
        }

        public class UpdateCacheItem
        {
            public bool AllowedOffline;
            public decimal AppliesTo;
            public Architecture Architecture;
            public DateTime CreatedDate;
            public string FileName;
            public string Language;
            public string MD5;
            public string PackageDescription;
            public string PackageName;
            public string PackageVersion;
            public long Size;
            public string Support;
            public UpdateType Type;

            public XElement XML
            {
                get
                {
                    var xUpdate = new XElement("Update");
                    xUpdate.SetAttributeValue("Name", PackageName);
                    xUpdate.SetAttributeValue("Size", Size);


                    xUpdate.SetAttributeValue("Version", PackageVersion);
                    xUpdate.SetAttributeValue("Filename", FileName);
                    xUpdate.SetAttributeValue("Arc", Architecture.ToString());
                    xUpdate.SetAttributeValue("MD5", MD5);
                    xUpdate.SetAttributeValue("Desc", PackageDescription);

                    xUpdate.SetAttributeValue("AppliesTo", AppliesTo);
                    xUpdate.SetAttributeValue("Support", Support);
                    xUpdate.SetAttributeValue("CreatedDate", CreatedDate);

                    if (AllowedOffline)
                    {
                        xUpdate.SetAttributeValue("Offline", AllowedOffline);
                    }
                    if (Type == UpdateType.LDR)
                    {
                        xUpdate.SetAttributeValue("Type", Type);
                    }
                    if (!Language.EqualsIgnoreCase("NEUTRAL"))
                    {
                        xUpdate.SetAttributeValue("Lang", Language);
                    }

                    return xUpdate;
                }
            }
        }
    }
}