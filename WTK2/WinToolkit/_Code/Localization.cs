using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using WinToolkitDLL;
using WinToolkitDLL.Extensions;

namespace WinToolkitv2
{
    internal class Localization
    {
        /// <summary>
        ///     Used for when a foreign dictionary is detected. Not initialized until needed.
        /// </summary>
        private static ResourceDictionary _defaultDictionary;

        public static string currentCulture = "en-US";
        public static string currentCultureName = "English (United States)";

        /// <summary>
        ///     Gets the foreign version of the string.
        /// </summary>
        /// <param name="currentWindow">Name of the current WPF Windows or Global</param>
        /// <param name="resourceName">Resource Number</param>
        /// <returns></returns>
        public static string GetString(string currentWindow, int resourceName)
        {
            Lists.AddMessage(currentWindow + "-" + resourceName);
            var stringToFind = currentWindow.Replace("frm", "Frm") + "-" + resourceName.ToString("D8");
            var stringGlobalToFind = "Global-" + resourceName.ToString("D8");

            if (Application.Current.TryFindResource(stringToFind) != null)
            {
                return (string) Application.Current.FindResource(stringToFind);
            }

            if (Application.Current.TryFindResource(stringGlobalToFind) != null)
            {
                return (string) Application.Current.FindResource(stringGlobalToFind);
            }

            //If a translation cannot be found, the default dictionary will be scanned.
            if (_defaultDictionary == null) return "(null)";

            if (_defaultDictionary.Contains(stringToFind))
            {
                return _defaultDictionary[stringToFind].ToString();
            }

            if (_defaultDictionary.Contains(stringGlobalToFind))
            {
                return _defaultDictionary[stringGlobalToFind].ToString();
            }

            //No translation was found.
            return "(null)";
        }

        /// <summary>
        ///     Checks to see if a foreign translation is available, if so the GUI will then change.
        /// </summary>
        public static void LoadDictionary()
        {
            var culture = Thread.CurrentThread.CurrentCulture.Name;

            if (culture.EqualsIgnoreCase("EN-US"))
            {
                return;
            }

            var filePath = string.Format(Directories.Application + "\\Lang\\{0}.xaml", culture);
            if (!File.Exists(filePath))
            {
                return;
            }

            try
            {
                currentCulture = Thread.CurrentThread.CurrentCulture.Name;
                currentCultureName = Thread.CurrentThread.CurrentCulture.DisplayName;
                Application.Current.Resources.Source = new Uri(filePath, UriKind.Absolute);
                LoadDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "New Dictionary Error");
            }
        }

        /// <summary>
        ///     When a foreign dictionary is loaded, the default one is kept just incase
        ///     a translation is missing.
        /// </summary>
        private static void LoadDefault()
        {
            var defaultPath = string.Format(Directories.Application + "\\Lang\\en-US.xaml",
                Thread.CurrentThread.CurrentCulture);

            if (!File.Exists(defaultPath)) return;
            try
            {
                _defaultDictionary = new ResourceDictionary();
                using (var fs = new FileStream(defaultPath, FileMode.Open))
                {
                    _defaultDictionary = (ResourceDictionary) XamlReader.Load(fs);
                    Application.Current.Resources.MergedDictionaries.Add(_defaultDictionary);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Default Dictionary Error");
            }
        }
    }
}