using System;
using System.ComponentModel;
using System.IO;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitDLL.ThirdParty;

namespace WinToolkitDLL.Objects.Integratables
{
    /// <summary>
    ///     Office updates which can be converted.
    /// </summary>
    public abstract class _Integratable
    {
        private readonly string _location;
        private readonly string _md5 = "N/A";
        private readonly string _name;
        private readonly string _random = Misc.RandomString();
        private readonly long _size;
        protected Architecture _architecture = Architecture.X86;
        protected DateTime _createdDate;
        protected string _image = "/Images/_Global/Blank_16.png";
        protected string _language = "N/A";
        private Status _status = Status.None;
        protected string _tooltip;

        protected _Integratable(string filePath)
        {
            _name = Path.GetFileNameWithoutExtension(filePath);
            _location = filePath;
            _size = FileHandling.GetSize(filePath);
            _createdDate = FileHandling.GetCreationDate(filePath);
            _tooltip = filePath;
            if (this is MsuUpdate || this is CabUpdate)
            {
                var cacheItem = UpdateCache.Find(Path.GetFileName(Location), Size);
                if (cacheItem != null)
                {
                    _md5 = cacheItem.MD5;
                }
            }

            if (Options.GetMD5 && _md5.EqualsIgnoreCase("N/A"))
            {
                _md5 = FileHandling.GetMD5(filePath);
            }
        }

        protected string _tempLocation
        {
            get { return Directories.TempPath + GetType().Name + "_" + (Name + Location + _random).CreateMD5(); }
        }

        protected string _scratchLocation
        {
            get { return Directories.TempPath + GetType().Name + "-S_" + (Name + Location + _random).CreateMD5(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public int CompareTo(_Integratable b)
        {
            return SafeNativeMethods.StrCmpLogicalW(Name, b.Name);
        }

        /// <summary>
        ///     Integrates the current item into the selected image.
        /// </summary>
        /// <param name="mountPath">The directory the wim image is mounted to.</param>
        /// <returns>True if integrated.</returns>
        public abstract Status Integrate(string mountPath);

        public abstract Status Convert(string outDirectory);

        /// <summary>
        ///     Installs the selected update into the current live OS.
        /// </summary>
        /// <returns>True if installed.</returns>
        public abstract Status Install();

        #region SHAREDCODE

        protected bool MoveFromTemp(string outDirectory, string filter)
        {
            var successful = false;
            foreach (var file in Directory.GetFiles(_tempLocation, filter))
            {
                var filename = Path.GetFileName(file);
                var newPath = outDirectory + "\\" + filename;
                if (!File.Exists(newPath))
                {
                    File.Move(file, newPath);
                }

                successful = true;
            }

            FileHandling.DeleteDirectory(_tempLocation);
            return successful;
        }

        #endregion

        #region ACCESSORS

        public Architecture Architecture
        {
            get { return _architecture; }
        }

        public DateTime Date
        {
            get { return _createdDate; }
        }

        public string Image
        {
            get { return _image; }
        }

        public string ToolTip
        {
            get { return _tooltip; }
        }

        /// <summary>
        ///     Returns the location of the file.
        /// </summary>
        public string Location
        {
            get { return _location; }
        }

        public string MD5
        {
            get { return _md5; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Language
        {
            get { return _language.Replace("\"", ""); }
        }

        public long Size
        {
            get { return _size; }
        }


        public Status Status
        {
            get { return _status; }
            set
            {
                _status = value;
                switch (_status)
                {
                    case Status.Incompatible:
                        _image = "/Images/_Global/Incompatible_16.png";
                        break;
                    case Status.Failed:
                        _image = "/Images/_Global/Delete_16.png";
                        break;
                    case Status.Success:
                        _image = "/Images/_Global/OK_16.png";
                        break;
                    case Status.Working:
                        _image = "/Images/_Global/Start_16.png";
                        break;
                }
            }
        }

        #endregion
    }
}