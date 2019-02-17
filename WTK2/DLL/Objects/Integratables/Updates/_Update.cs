using System.IO;
using System.Windows.Controls;
using WinToolkitDLL.Extensions;

namespace WinToolkitDLL.Objects.Integratables
{
    public abstract class _Update : _Integratable
    {
        protected string _appliesTo;
        protected bool _offlineAllowed = true;
        protected string _packageDescription;
        protected string _packageName;
        protected string _packageVersion;
        protected ProgressBar _progressBar = null;
        protected string _support;
        protected UpdateType _updateType = UpdateType.Unknown;

        protected _Update(string filePath)
            : base(filePath)
        {
            _language = "Neutral";
            if (Path.GetFileNameWithoutExtension(Location).EndsWithIgnoreCase("-X64")) _architecture = Architecture.X64;

            var cacheItem = UpdateCache.Find(Path.GetFileName(Location), Size);

            if (cacheItem == null && !MD5.Equals("N/A"))
                cacheItem = UpdateCache.Find(MD5);

            if (cacheItem != null)
            {
                _packageName = cacheItem.PackageName;
                _packageVersion = cacheItem.PackageVersion;
                _updateType = cacheItem.Type;
                _packageDescription = cacheItem.PackageDescription;
                _language = cacheItem.Language;
                _appliesTo = cacheItem.AppliesTo.ToString();
                _support = cacheItem.Support;
                _createdDate = cacheItem.CreatedDate;
                _offlineAllowed = cacheItem.AllowedOffline;
            }

            _tooltip = _packageName + "\n" + _packageVersion + " [" + _updateType + "]\n" + Location;
        }

        public string PackageName
        {
            get { return _packageName; }
        }

        public string Description
        {
            get { return _packageDescription; }
        }

        public string PackageVersion
        {
            get { return _packageVersion; }
        }

        public UpdateType UpdateType
        {
            get { return _updateType; }
            set { _updateType = value; }
        }

        public bool AllowedOffline
        {
            get { return _offlineAllowed; }
        }

        public string Support
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_support))
                {
                    return "N/A";
                }
                return _support;
            }
        }

        public ProgressBar Progress
        {
            get { return _progressBar; }
        }

        public string AppliesTo
        {
            get { return _appliesTo; }
        }

        protected bool CheckIntegration(string mountPath, bool checkLDR = false)
        {
            if (!Directory.Exists(mountPath + "\\Windows\\servicing\\Packages"))
            {
                return false;
            }

            var packageName = PackageName;
            var packageVersion = PackageVersion;
            foreach (var f in Directory.GetFiles(mountPath + "\\Windows\\servicing\\Packages"))
            {
                if (f.ContainsIgnoreCase(packageName) && f.ContainsIgnoreCase(packageVersion))
                {
                    if (Language.EqualsIgnoreCase("ALL") || Language.EqualsIgnoreCase("NEUTRAL") ||
                        f.ContainsIgnoreCase(Language))
                    {
                        if (!checkLDR)
                        {
                            return true;
                        }
                        if (f.ContainsIgnoreCase("_BF"))
                        {
                            return true;
                        }
                    }
                }

                if (f.ContainsIgnoreCase(Name))
                {
                    return true;
                }
                if (Description.StartsWithIgnoreCase("KB") && f.ContainsIgnoreCase(Description))
                {
                    return true;
                }
            }
            return false;
        }

        protected string GetValue(string input, string value)
        {
            var _valueName = input;
            while (!_valueName.StartsWithIgnoreCase(value))
            {
                _valueName = _valueName.Substring(1);
            }
            _valueName = _valueName.Substring(value.Length + 2);
            _valueName = _valueName.Substring(0, _valueName.IndexOf('\"'));
            return _valueName;
        }
    }
}