using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using WinToolkit;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;

namespace WinToolkitDLL.Objects.Integratables
{
    public sealed class MsuUpdate : _Update
    {
        /// <summary>
        ///     Create a new MSU Update object with
        ///     only basic information.
        /// </summary>
        /// <param name="filePath">MSU file path.</param>
        public MsuUpdate(string filePath)
            : base(filePath)
        {
            if (!File.Exists(Location))
            {
                throw new FileNotFoundException();
            }
            if (!Location.EndsWithIgnoreCase(".MSU"))
            {
                throw new InvalidOperationException("This is not a msu file.");
            }

            switch (_updateType)
            {
                case UpdateType.LDR:
                    _image = "/Images/_Global/MSUUpdateLDR_32.png";
                    break;
                case UpdateType.GDR:
                    _image = "/Images/_Global/MSUUpdateGDR_32.png";
                    break;
                default:
                    _image = "/Images/_Global/MSUUpdate_32.png";
                    break;
            }

            if (!string.IsNullOrWhiteSpace(_packageName)) return;

            Extraction.Expand(Location, "*.msu", _tempLocation);

            GetBasicDetails();
            GetExtendedDetails();

            if (_packageName == null)
            {
                Extraction.Expand(Location, "*.cab", _tempLocation);
                var cabFile = Directory.GetFiles(_tempLocation, "*.cab", SearchOption.TopDirectoryOnly).FirstOrDefault();

                if (cabFile != null)
                {
                    var cab = new CabUpdate(cabFile);
                    _packageName = cab.PackageName;
                    _updateType = cab.UpdateType;
                    _packageVersion = cab.PackageVersion;
                    _packageDescription = cab.Description;
                    _appliesTo = cab.AppliesTo;
                    _architecture = cab.Architecture;
                    _createdDate = cab.Date;
                    _language = cab.Language;
                    _support = cab.Support;
                    return;
                }
            }


            if (_packageName == null)
            {
                throw new InvalidDataException("Invalid Update");
            }
        }

        /// <summary>
        ///     Get package name and version.
        /// </summary>
        private void GetExtendedDetails()
        {
            Extraction.Expand(Location, "*.xml", _tempLocation);

            if (Directory.Exists(_tempLocation))
            {
                var msuInfo = Directory.GetFiles(_tempLocation, "*.xml", SearchOption.TopDirectoryOnly).FirstOrDefault();

                try
                {
                    if (msuInfo != null)
                    {
                        var xDoc = new XmlDocument();
                        xDoc.PreserveWhitespace = false;
                        xDoc.Load(msuInfo);

                        var xParent = xDoc.LastChild.LastChild.LastChild.FirstChild;

                        _packageName = xParent.Attributes["name"].InnerText;
                        _language = xParent.Attributes["language"].InnerText;

                        var arc = xParent.Attributes["processorArchitecture"].InnerText;
                        if (arc.EqualsIgnoreCase("amd64"))
                            _architecture = Architecture.X64;

                        _packageVersion = xParent.Attributes["version"].InnerText;
                        var appliesTo = _packageVersion.Split('.')[0] + "." + _packageVersion.Split('.')[1];
                        _appliesTo = appliesTo;
                    }
                }
                catch (Exception Ex)
                {
                    FileHandling.WriteFile("Errors.txt", Ex.Message + "\r\n", true);
                }
                FileHandling.DeleteDirectory(_tempLocation);
            }
        }

        /// <summary>
        ///     Get support link, architecture, description, language, and date.
        /// </summary>
        private void GetBasicDetails()
        {
            Extraction.Expand(Location, "*Windows*pkgProperties.txt", _tempLocation);

            if (Directory.Exists(_tempLocation))
            {
                var msuInfo = Directory.GetFiles(_tempLocation, "*.txt", SearchOption.TopDirectoryOnly).FirstOrDefault();

                if (msuInfo != null)
                {
                    var msuText = FileHandling.ReadFile(msuInfo);


                    foreach (var lines in msuText.Split(Environment.NewLine.ToCharArray()))
                    {
                        var line = lines.Trim();
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        if (line.StartsWithIgnoreCase("Applies to="))
                        {
                            var applyTo = line.Replace("\"", "");
                            //if (applyTo.EndsWithIgnoreCase("Windows Blue"))
                            //{
                            //    _appliesTo = 6.3m;
                            //}
                            //else
                            //{
                            //    _appliesTo = decimal.Parse(applyTo.Substring(applyTo.Length - 3));
                            //}
                        }
                        if (line.StartsWithIgnoreCase("Build Date="))
                        {
                            _createdDate = DateTime.Parse(line.Split('=').Last().Replace("\"", ""));
                        }
                        if (line.StartsWithIgnoreCase("Language="))
                        {
                            _language = line.Split('=').Last().Replace("\"", "");
                        }
                        if (line.StartsWithIgnoreCase("Package Type="))
                        {
                            _packageDescription = line.Split('=').Last().Replace("\"", "");
                        }
                        if (line.StartsWithIgnoreCase("Support Link="))
                        {
                            _support = line.Substring(13).Replace("\"", "");
                        }

                        if (line.StartsWithIgnoreCase("Processor Architecture="))
                        {
                            if (line.Split('=').Last().ContainsIgnoreCase("amd64"))
                            {
                                _architecture = Architecture.X64;
                            }
                        }
                    }
                }

                FileHandling.DeleteDirectory(_tempLocation);
            }
        }

        /// <summary>
        ///     Integrates the update into the selected image.
        /// </summary>
        /// <param name="mountPath">The directory where the image is mounted.</param>
        /// <returns>True if integrated.</returns>
        public override Status Integrate(string mountPath)
        {
            return DoWork(Task.Integrate, mountPath, false);
        }

        public override Status Convert(string outDirectory)
        {
            Status = Status.Working;

            var extracted = Extraction.Expand(Location, "*.cab", _tempLocation);

            if (extracted)
            {
                if (MoveFromTemp(outDirectory, "*Windows*.cab"))
                {
                    return Status.Success;
                }
            }
            return Status.Failed;
        }

        /// <summary>
        ///     Integrates the update into the selected image. QFE-LDR Mode.
        /// </summary>
        /// <param name="mountPath">The directory where the image is mounted.</param>
        /// <returns>True if integrated.</returns>
        public Status IntegrateLDR(string mountPath)
        {
            return DoWork(Task.Integrate, mountPath, true);
        }

        /// <summary>
        ///     Installs the update to the live OS.
        /// </summary>
        /// <returns></returns>
        public override Status Install()
        {
            //if (AppliesTo > 0 && AppliesTo != OS.Version)
            //{
            //    return Status.Incompatible;
            //}

            return DoWork(Task.Install, "C:\\", false);
        }

        /// <summary>
        ///     Installs the update to the live OS. QFE-LDR.
        /// </summary>
        /// <returns></returns>
        public Status InstallLDR()
        {
            //if (AppliesTo > 0 && AppliesTo != OS.Version)
            //{
            //    return Status.Incompatible;
            //}

            var LDR = !(OS.Version > 6.1m);

            //Windows 8 or later doesn't have LDR-QFE.
            return DoWork(Task.Install, "C:\\", LDR);
        }

        /// <summary>
        ///     Either installs or integrate the update to the live OS or image.
        /// </summary>
        /// <param name="LDR">Install LDR or GDR.</param>
        /// <returns></returns>
        private Status DoWork(Task task, string mountPath, bool LDR)
        {
            if (_progressBar == null)
                _progressBar = new ProgressBar();

            _progressBar.Value = 0;

            Status = Status.Working;

            if (CheckIntegration(mountPath, LDR))
            {
                return Status.Success;
            }

            if (task == Task.Install)
            {
                Processes.Run("wusa.exe", "\"" + Location + "\" /quiet /norestart");
            }
            else
            {
                Processes.Run(DISM.Default.Location,
                    "/Image:\"" + mountPath + "\" /Add-Package /Packagepath:\"" + Location + "\"");
            }

            if (LDR && (_updateType == UpdateType.Unknown || _updateType == UpdateType.LDR))
            {
                if (CheckIntegration(mountPath))
                {
                    return Status.Failed;
                }
                Extraction.Expand(Location, "*.cab", _tempLocation);

                var cabFile = Directory.GetFiles(_tempLocation, "*.cab", SearchOption.TopDirectoryOnly).First();
                Extraction.Expand(cabFile, _tempLocation);

                _updateType = UpdateType.GDR;
                if (File.Exists(_tempLocation + "\\update-bf.mum"))
                {
                    _updateType = UpdateType.LDR;

                    if (task == Task.Install)
                    {
                        Processes.Run("pkgmgr.exe",
                            "/ip /m:\"" + _tempLocation + "\\update-bf.mum" + "\" /quiet /norestart");
                    }
                    else
                    {
                        var s = Processes.Run("DISM",
                            "/Image:\"" + mountPath + "\" /Add-Package /Packagepath:\"" + _tempLocation +
                            "\\update-bf.mum" + "\"");
                        MessageBox.Show(s);
                    }
                }

                FileHandling.DeleteDirectory(_tempLocation);
            }

            UpdateCache.Add(this);

            if (_updateType != UpdateType.LDR)
            {
                LDR = false;
            }

            if (CheckIntegration(mountPath, LDR))
            {
                return Status.Success;
            }
            return Status.Failed;
        }

        private enum Task
        {
            Install,
            Integrate
        }
    }
}