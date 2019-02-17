/*
 * Please leave this Copyright notice in your code if you use it
 * Written by Decebal Mihailescu [http://www.codeproject.com/script/articles/list_articles.asp?userid=634640]
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using COMTypes = System.Runtime.InteropServices.ComTypes;


namespace WinToolkitDLL.ThirdParty
{
    public sealed class ImageRepository : IFileSystemImage, IFileSystemImageResult, IDisposable
    {
        public delegate void CancelingHandler();

        internal const uint STGM_SHARE_DENY_WRITE = 0x00000020;
        private readonly UniqueListFileSystemInfo _items = new UniqueListFileSystemInfo(1);
        private bool _cancel;
        private MsftFileSystemImage _sysImage;

        #region DiscFormat2Data_Events Members

        public DiscFormat2Data_EventsHandler Update;

        #endregion

        static ImageRepository()
        {
            Debug.AutoFlush = true;
        }

        public List<FileSystemInfo> Items
        {
            get { return _items; }
            //set { _items = value; }
        }

        public long ActualSize { get; private set; }

        public MsftFileSystemImage FileSysImage
        {
            get { return _sysImage; }
            set
            {
                lock (this)
                {
                    if (value != _sysImage)
                    {
                        if (_sysImage != null)
                        {
                            Marshal.FinalReleaseComObject(_sysImage);
                        }
                        _sysImage = value;
                    }
                }
            }
        }

        public long SizeBeforeFormatting { get; private set; }

        public bool Cancel
        {
            get { return _cancel; }
            set
            {
                lock (this)
                {
                    _cancel = value;
                }
            }
        }

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        private static extern int SHCreateStreamOnFile(string pszFile, uint grfMode, out IStream ppstm);

        public static COMTypes.IStream LoadCOMStream(string file)
        {
            COMTypes.IStream newStream;
            var hres = ISOFormatter.SHCreateStreamOnFile(file, STGM_SHARE_DENY_WRITE, out newStream);
            if (hres != 0 || newStream == null)
                throw new COMException("can't open " + file + " as IStream", unchecked((int) hres));
            return newStream;
        }

        public void CancelOp()
        {
            Cancel = true;
        }

        private static long FolderSize(DirectoryInfo d)
        {
            long size = 0;
            foreach (var inf in d.GetFileSystemInfos())
            {
                var fi = inf as FileInfo;
                if (fi != null)
                    size += fi.Length;
                else
                    size += FolderSize(inf as DirectoryInfo);
            }
            return size;
        }

        //using Microsoft.VisualBasic;//requires Microsoft.VisualBasic reference
        public void CreateBootDisc(string bootFile)
        {
            // -------- Adding Boot Image Code -----
            IBootOptions bootOptions = new BootOptions();
            bootOptions.Manufacturer = "Legolash2o";

            bootOptions.Emulation = EmulationType.EmulationNone;
            bootOptions.PlatformId = PlatformId.PlatformX86;
            _sysImage.FreeMediaBlocks = -1; // Enables larger-than-CD image
            _sysImage.FileSystemsToCreate = FsiFileSystems.FsiFileSystemISO9660 |
                                            FsiFileSystems.FsiFileSystemJoliet |
                                            FsiFileSystems.FsiFileSystemUDF;
            IStream bootStream;
            if (0 == SHCreateStreamOnFile(bootFile, 0x00, out bootStream))
            {
                bootOptions.AssignBootImage(bootStream);
            }

            //object bootStream;
            //bootStream = Interaction.CreateObject("ADODB.Stream", "");
            //Interaction.CallByName(bootStream, "Open", CallType.Method, null);
            //Interaction.CallByName(bootStream, "Type", CallType.Let, new object[] { 1 });
            //Interaction.CallByName(bootStream, "LoadFromFile", CallType.Method, new object[] { bootFile });
            //IStream fsStream = bootStream as IStream;
            //bootOptions.AssignBootImage(fsStream);

            _sysImage.BootImageOptions = bootOptions;
        }

        public bool AddNewFile(string path)
        {
            if (_items.AddUniqueFile(path))
            {
                FileSysImage = null;
                return true;
            }
            return false;
        }

        public bool AddNewFolder(string path)
        {
            FileSysImage = null;
            return _items.AddUniqueFolder(path);
        }

        private void CreateFSIFolder(DirectoryInfo fsobject, IFsiDirectoryItem diritem)
        {
            if (fsobject == null || diritem == null || _cancel)
                return;
            DirectoryInfo pysicalFolder = null;
            pysicalFolder = new DirectoryInfo(UniqueListFileSystemInfo.GetPhysicalPath(fsobject.FullName.TrimEnd('\\')));
            IFsiDirectoryItem crtdiritem = null;
            if (diritem.FullPath.Length == 0)
            {
                try
                {
                    var newpath = string.Format("{0}\\{1}", diritem.FullPath, pysicalFolder.Name);
                    if (_sysImage.Exists(newpath) != FsiItemType.FsiItemDirectory)
                        diritem.AddDirectory(pysicalFolder.Name);
                }
                catch
                {
                }
                crtdiritem = diritem[pysicalFolder.Name] as IFsiDirectoryItem;
            }
            else
                crtdiritem = diritem;
            var files = pysicalFolder.GetFiles("*"); //all files
            foreach (var file in files)
            {
                if (_cancel)
                    return;
                CreateFSIFile(file, crtdiritem);
            }

            DirectoryInfo[] folders = null;
            folders = pysicalFolder.GetDirectories("*");
            if (folders != null && folders.Length > 0)
            {
                foreach (var folder in folders)
                {
                    if (_cancel)
                        return;
                    try
                    {
                        var newpath = string.Format("{0}\\{1}", crtdiritem.FullPath, folder.Name);
                        if (_sysImage.Exists(newpath) != FsiItemType.FsiItemDirectory)
                            crtdiritem.AddDirectory(folder.Name);
                    }
                    catch
                    {
                        Cancel = true;
                        throw;
                    }
                    var subdir = crtdiritem[folder.Name] as IFsiDirectoryItem;
                    CreateFSIFolder(folder, subdir);
                }
            }
        }

        private void CreateFSIFile(FileInfo file, IFsiDirectoryItem diritem)
        {
            var realpath = UniqueListFileSystemInfo.GetPhysicalPath(file.FullName);
            var index = realpath.IndexOf(":\\") + 1;
            if (_sysImage.Exists(realpath.Substring(index)) == FsiItemType.FsiItemNotFound)
            {
                var crtdiritem = diritem;
                var name = Path.GetFileName(realpath);
                if (string.Compare(diritem.FullPath, Path.GetDirectoryName(realpath).Substring(index), true) != 0)
                {
                    var fsipath = Path.GetDirectoryName(realpath).Substring(index + 1 + diritem.FullPath.Length);
                    var dirs = fsipath.Split('\\');

                    var dInfo = new DirectoryInfo(CaptureDirectory);
                    var subdirs = dInfo.FullName.Split('\\');
                    //MessageBox.Show(subdirs.Length.ToString());
                    //create the subdirs one by one
                    foreach (var dir in dirs.Skip(subdirs.Length - 1))
                    {
                        if (dir.Length == 0)
                            continue; //in the root like C:\
                        try
                        {
                            var newpath = string.Format("{0}\\{1}", crtdiritem.FullPath, dir);
                            if (_sysImage.Exists(newpath) != FsiItemType.FsiItemDirectory)
                                crtdiritem.AddDirectory(dir);
                        }
                        catch
                        {
                            Cancel = true;
                            throw;
                        }
                        crtdiritem = crtdiritem[dir] as IFsiDirectoryItem;
                    }
                }

                COMTypes.IStream newStream = null;

                try
                {
                    newStream = LoadCOMStream(realpath);
                    crtdiritem.AddFile(name, newStream);
                }
                finally
                {
                    Marshal.FinalReleaseComObject(newStream);
                }

                ActualSize += file.Length;
                if (Update != null && Update.GetInvocationList().Length > 0)
                    Update(file.FullName, file.Length);
            }
            else
                throw new ApplicationException(realpath.Substring(index) +
                                               " occurs in multiple source folders with the same name.");
        }

        public bool CalculateSizeBeforeFormatting()
        {
            SizeBeforeFormatting = 0;
            if (Update != null && Update.GetInvocationList().Length > 0)
                _items.ForEach(delegate(FileSystemInfo item)
                {
                    var fi = item as FileInfo;
                    if (fi != null)
                    {
                        SizeBeforeFormatting += fi.Length;
                    }
                    else
                    {
                        SizeBeforeFormatting += FolderSize(item as DirectoryInfo);
                    }
                });
            return (Update != null && SizeBeforeFormatting > 0);
        }

        #region IFileSystemImage Members

        IFsiDirectoryItem IFileSystemImage.Root
        {
            get { return (_sysImage == null) ? null : _sysImage.Root; }
        }

        int IFileSystemImage.SessionStartBlock
        {
            get
            {
                if (_sysImage == null)
                    throw new NullReferenceException("_sysImage is not valid");
                return _sysImage.SessionStartBlock;
            }
            set { throw new NotImplementedException(); }
        }


        int IFileSystemImage.FreeMediaBlocks
        {
            get
            {
                if (_sysImage == null)
                    throw new NullReferenceException("_sysImage is not valid");
                return _sysImage.FreeMediaBlocks;
            }
            set { throw new NotImplementedException(); }
        }

        void IFileSystemImage.SetMaxMediaBlocksFromDevice(IDiscRecorder2 discRecorder)
        {
            throw new NotImplementedException();
        }

        int IFileSystemImage.UsedBlocks
        {
            get
            {
                if (_sysImage == null)
                    throw new NullReferenceException("_sysImage is not valid");
                return _sysImage.UsedBlocks;
            }
        }

        private string _volumeName;

        string IFileSystemImage.VolumeName
        {
            get { return _volumeName; }
            set { _volumeName = value; }
        }


        string IFileSystemImage.ImportedVolumeName
        {
            get { throw new NotImplementedException(); }
        }

        IBootOptions IFileSystemImage.BootImageOptions
        {
            get { return (_sysImage == null) ? null : _sysImage.BootImageOptions; }
            set { throw new NotImplementedException(); }
        }

        int IFileSystemImage.FileCount
        {
            get { throw new NotImplementedException(); }
        }

        int IFileSystemImage.DirectoryCount
        {
            get { throw new NotImplementedException(); }
        }

        string IFileSystemImage.WorkingDirectory
        {
            get { return (_sysImage == null) ? null : _sysImage.WorkingDirectory; }
            set { throw new NotImplementedException(); }
        }

        int IFileSystemImage.ChangePoint
        {
            get { throw new NotImplementedException(); }
        }

        bool IFileSystemImage.StrictFileSystemCompliance
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        bool IFileSystemImage.UseRestrictedCharacterSet
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        private FsiFileSystems _fsifs;

        FsiFileSystems IFileSystemImage.FileSystemsToCreate
        {
            get { return _fsifs; }
            set { _fsifs = value; }
        }

        FsiFileSystems IFileSystemImage.FileSystemsSupported
        {
            get
            {
                if (_sysImage == null)
                    throw new NullReferenceException("_sysImage is not valid");
                return _sysImage.FileSystemsSupported;
            }
        }

        int IFileSystemImage.UDFRevision
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        Array IFileSystemImage.UDFRevisionsSupported
        {
            get { return (_sysImage == null) ? null : _sysImage.UDFRevisionsSupported; }
        }

        void IFileSystemImage.ChooseImageDefaults(IDiscRecorder2 discRecorder)
        {
            throw new NotImplementedException();
        }

        private IMAPI_MEDIA_PHYSICAL_TYPE _mediatype;

        void IFileSystemImage.ChooseImageDefaultsForMediaType(IMAPI_MEDIA_PHYSICAL_TYPE value)
        {
            _mediatype = value;
        }

        int IFileSystemImage.ISO9660InterchangeLevel
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        Array IFileSystemImage.ISO9660InterchangeLevelsSupported
        {
            get
            {
                if (_sysImage == null)
                    throw new NullReferenceException("_sysImage is not valid");
                return _sysImage.ISO9660InterchangeLevelsSupported;
            }
        }

        public string BootableImageFile { get; set; }

        IFileSystemImageResult IFileSystemImage.CreateResultImage()
        {
            if (_sysImage == null)

                _cancel = false;
#if DEBUG
            var tm = new Stopwatch();
            tm.Start();
#endif
            try
            {
                FileSysImage = new MsftFileSystemImage();

                _sysImage.ChooseImageDefaultsForMediaType(_mediatype);

                if (BootableImageFile != null)
                {
                    CreateBootDisc(BootableImageFile);
                }

                var root = _sysImage.Root;

                _sysImage.FileSystemsToCreate = _fsifs;

                _sysImage.VolumeName = _volumeName;

                ActualSize = 0;
                var bUpdateUI = Update != null && Update.GetInvocationList().Length > 0;
                _items.ForEach(delegate(FileSystemInfo item)
                {
                    if (!_cancel)
                    {
                        if ((item.Attributes & FileAttributes.Directory) == 0)
                            CreateFSIFile(item as FileInfo, root);
                        else
                        {
                            var dirinf = item as DirectoryInfo;
                            if (dirinf.Parent != null)
                            {
                                if (bUpdateUI)
                                    CreateFSIFolder(item as DirectoryInfo, root);
                                else
                                    root.AddTree(item.FullName, false);
                            }
                            else
                            {
                                foreach (var fsi in dirinf.GetFileSystemInfos())
                                {
                                    if (_cancel)
                                        break;
                                    if ((fsi.Attributes & FileAttributes.Directory) == 0)
                                        CreateFSIFile(fsi as FileInfo, root);
                                    else
                                    {
                                        if (bUpdateUI)
                                            CreateFSIFolder(fsi as DirectoryInfo, root);
                                        else
                                            root.AddTree(fsi.FullName, true);
                                    }
                                }
                            }
                        }
                    }
                });

                return _cancel ? null : _sysImage.CreateResultImage();
            }
            catch (ApplicationException)
            {
                FileSysImage = null;
                throw;
            }
            catch (COMException ex)
            {
                FileSysImage = null;
                throw new ApplicationException("multiple folder occurence in source folders: " + ex.Message, ex);
            }
            catch
            {
                Cancel = true;
                throw;
            }
            finally
            {
                if (_cancel)
                    FileSysImage = null;
#if DEBUG
                tm.Stop();
                Debug.WriteLine(string.Format("Preparing the image lasted {0} ms",
                    tm.Elapsed.TotalMilliseconds.ToString("#,#")));
#endif
            }
        }

        public string CaptureDirectory { get; set; }

        FsiItemType IFileSystemImage.Exists(string FullPath)
        {
            if (_sysImage == null)
                throw new NullReferenceException("_sysImage is not valid");
            return _sysImage.Exists(FullPath);
        }

        string IFileSystemImage.CalculateDiscIdentifier()
        {
            if (_sysImage == null)
                throw new NullReferenceException("_sysImage is not valid");
            return _sysImage.CalculateDiscIdentifier();
        }

        FsiFileSystems IFileSystemImage.IdentifyFileSystemsOnDisc(IDiscRecorder2 discRecorder)
        {
            throw new NotImplementedException();
        }

        FsiFileSystems IFileSystemImage.GetDefaultFileSystemForImport(FsiFileSystems fileSystems)
        {
            if (_sysImage == null)
                throw new NullReferenceException("_sysImage is not valid");
            return _sysImage.GetDefaultFileSystemForImport(fileSystems);
        }

        FsiFileSystems IFileSystemImage.ImportFileSystem()
        {
            if (_sysImage == null)
                throw new NullReferenceException("_sysImage is not valid");
            return _sysImage.ImportFileSystem();
        }

        void IFileSystemImage.ImportSpecificFileSystem(FsiFileSystems fileSystemToUse)
        {
            if (_sysImage == null)
                throw new NullReferenceException("_sysImage is not valid");
            _sysImage.ImportSpecificFileSystem(fileSystemToUse);
        }

        void IFileSystemImage.RollbackToChangePoint(int ChangePoint)
        {
            if (_sysImage == null)
                throw new NullReferenceException("_sysImage is not valid");
            _sysImage.RollbackToChangePoint(ChangePoint);
        }

        void IFileSystemImage.LockInChangePoint()
        {
            if (_sysImage == null)
                throw new NullReferenceException("_sysImage is not valid");
            _sysImage.LockInChangePoint();
        }

        IFsiDirectoryItem IFileSystemImage.CreateDirectoryItem(string Name)
        {
            if (_sysImage == null)
                throw new NullReferenceException("_sysImage is not valid");
            return _sysImage.CreateDirectoryItem(Name);
        }

        IFsiFileItem IFileSystemImage.CreateFileItem(string Name)
        {
            if (_sysImage == null)
                throw new NullReferenceException("_sysImage is not valid");
            return _sysImage.CreateFileItem(Name);
        }

        string IFileSystemImage.VolumeNameUDF
        {
            get
            {
                if (_sysImage == null)
                    throw new NullReferenceException("_sysImage is not valid");
                return _sysImage.VolumeNameUDF;
            }
        }

        string IFileSystemImage.VolumeNameJoliet
        {
            get
            {
                if (_sysImage == null)
                    throw new NullReferenceException("_sysImage is not valid");
                return _sysImage.VolumeNameJoliet;
            }
        }

        string IFileSystemImage.VolumeNameISO9660
        {
            get
            {
                if (_sysImage == null)
                    throw new NullReferenceException("_sysImage is not valid");
                return _sysImage.VolumeNameISO9660;
            }
        }

        bool IFileSystemImage.StageFiles
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        Array IFileSystemImage.MultisessionInterfaces
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        #region IFileSystemImageResult Members

        COMTypes.IStream IFileSystemImageResult.ImageStream
        {
            get { return (_sysImage == null) ? null : _sysImage.CreateResultImage().ImageStream; }
        }

        IProgressItems IFileSystemImageResult.ProgressItems
        {
            get { return (_sysImage == null) ? null : _sysImage.CreateResultImage().ProgressItems; }
        }

        int IFileSystemImageResult.TotalBlocks
        {
            get
            {
                if (_sysImage == null)
                    throw new NullReferenceException("_sysImage is not valid");
                return _sysImage.CreateResultImage().TotalBlocks;
            }
        }

        int IFileSystemImageResult.BlockSize
        {
            get
            {
                if (_sysImage == null)
                    throw new NullReferenceException("_sysImage is not valid");
                return _sysImage.CreateResultImage().BlockSize;
            }
        }

        string IFileSystemImageResult.DiscId
        {
            get { return (_sysImage == null) ? null : _sysImage.CreateResultImage().DiscId; }
        }

        #endregion

        #region IDisposable Members

        public void Reset()
        {
            lock (this)
            {
                _cancel = false;
                if (_sysImage != null)
                {
                    //CleanUp(_sysImage.Root);
                    Marshal.FinalReleaseComObject(_sysImage);
                    _sysImage = null;
                }
            }
        }

        //private bool CleanUp( IFsiDirectoryItem fsidir)
        //{
        //    if (fsidir == null)
        //        return false;
        //    IEnumerator enm = fsidir.GetEnumerator();
        //    while (enm.MoveNext())
        //    {
        //        IFsiItem it = enm.Current as IFsiItem;
        //        IFsiFileItem fit = it as IFsiFileItem;
        //        if (fit != null)
        //        {
        //            COMTypes.IStream str = fit.Data;
        //            IntPtr pointer = Marshal.GetIUnknownForObject(str);
        //            int i = Marshal.Release(pointer);
        //            i = Marshal.Release(pointer);
        //        }
        //        else
        //            return CleanUp(it as IFsiDirectoryItem);
        //    }

        //    return true;
        //}
        void IDisposable.Dispose()
        {
            Monitor.Enter(this);
            try
            {
                BootableImageFile = null;
                if (_sysImage != null)
                {
                    //CleanUp(_sysImage.Root);
                    Marshal.FinalReleaseComObject(_sysImage);
                    _sysImage = null;
                }
            }
            catch (SynchronizationLockException)
            {
            }
            finally
            {
                Monitor.Exit(this);
                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}