using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using Microsoft.Dism;
using WinToolkit;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;

namespace WinToolkitDLL.Objects.Integratables
{
    public sealed class CabUpdate : _Update
    {
        /// <summary>
        ///     Create a new CAB Update object with
        ///     only basic information.
        /// </summary>
        /// <param name="filePath">CAB file path.</param>
        public CabUpdate(string filePath)
            : base(filePath)
        {
            if (!File.Exists(Location))
            {
                throw new FileNotFoundException();
            }
            if (!Location.EndsWithIgnoreCase(".CAB"))
            {
                throw new InvalidOperationException("This is not a cab file.");
            }

            switch (_updateType)
            {
                case UpdateType.LDR:
                    _image = "/Images/_Global/CabUpdateLDR_32.png";
                    break;
                case UpdateType.GDR:
                    _image = "/Images/_Global/CabUpdateGDR_32.png";
                    break;
                default:
                    _image = "/Images/_Global/CabUpdate_32.png";
                    break;
            }

            if (!string.IsNullOrWhiteSpace(_packageName)) return;

            GetDetails();


            if (PackageName.StartsWithIgnoreCase("WUClient-SelfUpdate-"))
            {
                _packageDescription = PackageName;
            }
        }

        /// <summary>
        ///     Get package name and version.
        /// </summary>
        private void GetDetails()
        {
            Extraction.Expand(Location, "update.mum", _tempLocation);

            if (Directory.Exists(_tempLocation))
            {
                var msuInfo =
                    Directory.GetFiles(_tempLocation, "update.mum", SearchOption.TopDirectoryOnly).FirstOrDefault();

                if (msuInfo != null)
                {
                    var doc = new XmlDocument();
                    doc.Load(msuInfo);

                    var p = (XmlElement) doc.LastChild;
                    _packageDescription = p.Attributes["description"].InnerText;
                    _support = p.Attributes["supportInformation"].InnerText;
                    if (p.HasAttribute("creationTimeStamp"))
                        _createdDate = DateTime.Parse(p.Attributes["creationTimeStamp"].InnerText);
                    else
                        _createdDate = FileHandling.GetModifiedDate(msuInfo);


                    var p2 = (XmlElement) p.ChildNodes[0];
                    _packageName = p2.Attributes["name"].InnerText;

                    _packageVersion = p2.Attributes["version"].InnerText;

                    var applies = _packageVersion.Split('.')[0] + "." + _packageVersion.Split('.')[1];
                    _appliesTo = applies;

                    _language = p2.Attributes["language"].InnerText;

                    var arc = p2.Attributes["processorArchitecture"].InnerText;
                    if (arc.EqualsIgnoreCase("amd64"))
                        _architecture = Architecture.X64;
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
            throw new NotImplementedException();
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

            //Windows 8 or later doesn't have LDR-QFE.
            var LDR = !(OS.Version > 6.1m);
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

            // if (CheckIntegration(mountPath, LDR)) { return Status.Success; }

            if (task == Task.Install)
            {
                using (var session = DismApi.OpenOnlineSession())
                {
                    DismApi.AddPackage(session, Location, true, false,
                        delegate(DismProgress progress) { _progressBar.Value = progress.Current; });
                }
                // Processes.Run("pkgmgr.exe", "/ip /m:\"" + Location + "\" /quiet /norestart");
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
                Extraction.Expand(Location, _tempLocation);

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