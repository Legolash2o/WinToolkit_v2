using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitDLL.Objects.Integratables;
using MessageBox = System.Windows.MessageBox;

namespace WinToolkitv2
{
    /// <summary>
    ///     Interaction logic for frmUpdateInstaller.xaml
    /// </summary>
    public partial class frmUpdateInstaller
    {
        private IList<_Integratable> _installList = new List<_Integratable>();
        private ElapsedTimer _tim;

        public frmUpdateInstaller()
        {
            InitializeComponent();
            this.LoadShared();
            pbProgress.ValueChanged += Events.PbProgress_OnValueChanged;
            dgUpdates.Update();
            dgUpdates.DataContext = _installList;
        }

        private void FrmConverter_OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void BtnHelp_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.wincert.net/forum/forum/216-guides/");
        }

        private void BtnAddFile_OnClick(object sender, RoutedEventArgs e)
        {
            var selectFile = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Windows Update *.msu *.cab|*.msu;*.cab"
            };


            if (selectFile.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            AddList(selectFile.FileNames);
        }

        private void BtnAddFolder_OnClick(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            var files = Directory.EnumerateFiles(folderBrowser.SelectedPath);
            AddList(files);
        }

        private void BtnAddSubFolder_OnClick(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            var fileList = Directory.EnumerateFiles(folderBrowser.SelectedPath, "*.*", SearchOption.AllDirectories);
            AddList(fileList);
        }

        private void AddList(IEnumerable<string> fileList)
        {
            foreach (
                var myClass in
                    fileList.Where(
                        myClass =>
                            _installList.Any(c => c.Location.EqualsIgnoreCase(myClass)) ||
                            _installList.Any(c => c.Name.EqualsIgnoreCase(Path.GetFileNameWithoutExtension(myClass)))))
            {
                fileList = fileList.Where(u => u.EqualsIgnoreCase(myClass)).ToList();
            }


            var incompatible = 0;

            Parallel.ForEach(fileList,
                new ParallelOptions {MaxDegreeOfParallelism = Options.MaxThreads},
                currentFile =>
                {
                    _Update newItem = null;
                    if (currentFile.EndsWithIgnoreCase(".MSU"))
                    {
                        newItem = new MsuUpdate(currentFile);
                    }
                    else if (currentFile.EndsWithIgnoreCase(".CAB"))
                    {
                        newItem = new CabUpdate(currentFile);
                    }

                    if (newItem == null || newItem.AppliesTo != OS.Version.ToString())
                    {
                        incompatible++;
                        //return;
                    }

                    lock (_installList)
                    {
                        _installList.Add(newItem);
                    }
                });

            if (incompatible > 0)
            {
                MessageBox.Show(string.Format("{0} item(s) are not compatible with your OS.", incompatible),
                    "Invalid Updates");
            }


            _installList = _installList.GroupBy(x => x.Name.ToLowerInvariant()).Select(x => x.First()).ToList();

            //Updates status
            dgUpdates.ItemsSource = _installList;
            lblStatus.Text = _installList.Count + " " + Localization.GetString("Global", 54);

            dgUpdates.Update();
        }

        private void BtnInstall_OnClick(object sender, RoutedEventArgs e)
        {
            if (_installList.Count == 0)
            {
                MessageBox.Show(Localization.GetString("Global", 50), Localization.GetString("Global", 51));
                return;
            }


            lblStatus.Text = Localization.GetString("Global", 48);

            pbProgress.Value = 0;
            pbProgress.Maximum = _installList.Count;
            lblProgress.Content = "0%";
            dgUpdates.Disable();
            rbnMain.IsEnabled = false;

            _tim = new ElapsedTimer(ref txtTime);
            _tim.Start();
            var amountInstalled = 0;

            Task.Factory.StartNew(delegate
            {
                foreach (var currentFile in _installList)
                {
                    currentFile.Status = currentFile.Install();
                    amountInstalled++;

                    pbProgress.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        pbProgress.Value++;

                        var progress = (pbProgress.Value/pbProgress.Maximum)*100;

                        lblStatus.Text = amountInstalled + " / " + _installList.Count + " " +
                                         Localization.GetString("Global", 62);
                        lblProgress.Content = Math.Round(progress, 1) + "%";

                        dgUpdates.Items.Refresh();
                    }));
                }
            }).ContinueWith(continuation =>
            {
                _tim.Stop();
                lblStatus.Dispatcher.BeginInvoke(new Action(() =>
                {
                    lblStatus.Text = _installList.Count(c => c.Status == Status.Success) + " " +
                                     Localization.GetString("FrmLMM", 8);

                    dgUpdates.Enable();
                    rbnMain.IsEnabled = true;
                }));
            });
        }

        private void BtnDeleteSelected_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (_Integratable item in dgUpdates.SelectedItems)
            {
                _installList.Remove(item);
            }

            dgUpdates.Update();
            lblStatus.Text = _installList.Count + " " + Localization.GetString("Global", 54);
        }

        private void BtnDeleteAll_OnClick(object sender, RoutedEventArgs e)
        {
            _installList.Clear();

            dgUpdates.Update();
            lblStatus.Text = "0 " + Localization.GetString("Global", 54);
        }

        private void RbnMain_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0)).RowDefinitions[0].Height = new GridLength(0);
        }
    }
}