using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Dism;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WinToolkit;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitv2._Code;

namespace WinToolkitv2
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FrmStartup
    {
        public FrmStartup()
        {
            Exceptions.AppContext = Application.Current;
            //Restore Settings
            RestoreSetting();

            Localization.LoadDictionary();
            InitializeComponent();
            pbProgress.ValueChanged += Events.PbProgress_OnValueChanged;
        }

        /// <summary>
        ///     Restores setting in case WinToolkit crashed.
        /// </summary>
        private static void RestoreSetting()
        {
            Reg.RestoreAutoPlay();
        }

        private void GetLicense()
        {
            Product.SetMode( ProductMode.Pro);
            //try
            //{
            //    Debugger.Log(0, "Startup", "Finding License...");

            //    string key = "000-000-001";
            //    System.Net.WebClient wc = new System.Net.WebClient();
            //    wc.Headers.Add("User-Agent", "WinToolkit-1357924680");
            //    byte[] raw = wc.DownloadData("http://www.wintoolkit.co.uk/License/Check/" + key);

            //    string webData = System.Text.Encoding.UTF8.GetString(raw);
            //    string plaintext = Encryption.Decrypt(webData);

            //    LicenseDetails license = JsonConvert.DeserializeObject<LicenseDetails>(plaintext);
            //    Product.SetMode(license.License.Edition);
            //}
            //catch (Exception ex)
            //{
            //    Exceptions.CustomException ce = new Exceptions.CustomException(Priority.Highest, "Startup: Licence Server", ex);
            //    ce.Show();

            //}
        }

        private void LoadDism()
        {
            Debugger.Log(0, "Startup", "Finding DISM...");
            DISM.Load();
            Debugger.Log(0, "Startup", "Initializing DISM...");

            DismApi.Initialize(DismLogLevel.LogErrors);


            pbProgress.Increment();
            Debugger.Log(0, "Startup", "Dism Loaded.");
        }

        private void LoadUpdateCache()
        {
            Debugger.Log(0, "Startup", "Loading Cache...");
            UpdateCache.Load();
            pbProgress.Increment();
            Debugger.Log(0, "Startup", "Cache Loaded.");
        }

        private async void FrmStartup_OnLoaded(object sender, RoutedEventArgs e)
        {

            const long MIN_WAIT = 500;
            Stopwatch SW = new Stopwatch();
            SW.Start();
            pbProgress.Maximum = 2;


            var tasks = new List<Task>();

            try
            {
                tasks.Add(Task.Factory.StartNew(LoadDism));
                tasks.Add(Task.Factory.StartNew(LoadUpdateCache));
                tasks.Add(Task.Factory.StartNew(GetLicense));
            }
            catch (Exception)
            {
            }


            await Task.WhenAll(tasks);

            SW.Stop();
            if (SW.ElapsedMilliseconds <= MIN_WAIT)
            {
                long waitRemaining = MIN_WAIT - SW.ElapsedMilliseconds;
                Thread.Sleep((int)waitRemaining);
            }

            var frmMain = new FrmMain();
            frmMain.Show();
            Close();
        }
    }
}