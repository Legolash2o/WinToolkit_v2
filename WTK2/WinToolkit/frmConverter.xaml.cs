using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
    ///     Interaction logic for frmConverter.xaml
    /// </summary>
    public partial class frmConverter
    {
        public enum ModeType
        {
            MSUtoCAB,
            EXEtoMSP,
            LangPack
        }

        private readonly ModeType _mode = ModeType.MSUtoCAB;
        private IList<_Integratable> _conversionList = new List<_Integratable>();
        private ElapsedTimer _tim;

        public frmConverter(ModeType modeType)
        {
            InitializeComponent();
            this.LoadShared();
            pbProgress.ValueChanged += Events.PbProgress_OnValueChanged;
            dgUpdates.Update();
            _mode = modeType;
            switch (modeType)
            {
                case ModeType.MSUtoCAB:
                    Title = Localization.GetString("FrmMSUtoCAB", 0);
                    break;
                case ModeType.EXEtoMSP:
                    Title = Localization.GetString("FrmMSPExtractor", 0);
                    break;
                case ModeType.LangPack:
                    Title = Localization.GetString("FrmLangPackConverter", 0);
                    break;
            }

            dgUpdates.DataContext = _conversionList;
        }

        private void FrmConverter_OnLoaded(object sender, RoutedEventArgs e)
        {
            lblOutput.Content += " (" + Localization.GetString("Global", 2) + ")";
        }

        private void BtnHelp_OnClick(object sender, RoutedEventArgs e)
        {
            switch (_mode)
            {
                case ModeType.LangPack:
                    Processes.OpenLink("http://www.wincert.net/forum/topic/8818-language-pack-converter/");
                    break;
                case ModeType.EXEtoMSP:
                    Processes.OpenLink("http://www.wincert.net/forum/topic/8819-msp-extractor-ms-office/");
                    break;
                case ModeType.MSUtoCAB:
                    Processes.OpenLink("http://www.wincert.net/forum/topic/8820-msu-to-cab-converter/");
                    break;
            }
        }

        private void BtnAddFile_OnClick(object sender, RoutedEventArgs e)
        {
            var selectFile = new OpenFileDialog
            {
                Multiselect = true,
                Filter =
                    "Windows Update *.msu|*.msu|Office Update *.exe|*.exe|Windows Language Pack *.exe|*.exe|All *.msu *.exe|*.msu;*.exe"
            };

            switch (_mode)
            {
                case ModeType.MSUtoCAB:
                    selectFile.FilterIndex = 1;
                    break;
                case ModeType.EXEtoMSP:
                    selectFile.FilterIndex = 2;
                    break;
                case ModeType.LangPack:
                    selectFile.FilterIndex = 3;
                    break;
            }

            if (selectFile.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            AddList(selectFile.FileNames.Where(file => Regex.IsMatch(file, @"^.+\.(msu|exe)$")));
        }

        private void BtnAddFolder_OnClick(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            AddList(
                Directory.EnumerateFiles(folderBrowser.SelectedPath)
                    .Where(file => Regex.IsMatch(file, @"^.+\.(msu|exe)$")));
        }

        private void BtnAddSubFolder_OnClick(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            var fileList = Directory.EnumerateFiles(folderBrowser.SelectedPath, "*.*", SearchOption.AllDirectories);
            AddList(fileList.Where(file => Regex.IsMatch(file, @"^.+\.(msu|exe)$")));
        }

        private void AddList(IEnumerable<string> fileList)
        {
            foreach (
                var myClass in
                    fileList.Where(
                        myClass =>
                            _conversionList.Any(c => c.Location.EqualsIgnoreCase(myClass)) ||
                            _conversionList.Any(c => c.Name.EqualsIgnoreCase(Path.GetFileNameWithoutExtension(myClass))))
                )
            {
                fileList = fileList.Where(u => u.EqualsIgnoreCase(myClass)).ToList();
            }


            var getMD5 = chkGetMD5.IsChecked == true;

            Parallel.ForEach(fileList,
                new ParallelOptions {MaxDegreeOfParallelism = Options.MaxThreads},
                currentFile =>
                {
                    if (currentFile.EndsWithIgnoreCase(".MSU"))
                    {
                        var newItem = new MsuUpdate(currentFile);
                        lock (_conversionList)
                        {
                            _conversionList.Add(newItem);
                        }
                        return;
                    }

                    if (Office.ValidOfficeFile(currentFile))
                    {
                        var newItem = new Office(currentFile);
                        lock (_conversionList)
                        {
                            _conversionList.Add(newItem);
                        }
                        return;
                    }

                    if (LangPack.IsValidLangPack(currentFile))
                    {
                        var newItem = new LangPack(currentFile);
                        lock (_conversionList)
                        {
                            _conversionList.Add(newItem);
                        }
                    }
                });


            _conversionList = _conversionList.GroupBy(x => x.Name.ToLowerInvariant()).Select(x => x.First()).ToList();

            //Updates status
            dgUpdates.ItemsSource = _conversionList;
            lblStatus.Text = _conversionList.Count + " " + Localization.GetString("Global", 54);

            dgUpdates.Update();
        }

        private void BtnConvert_OnClick(object sender, RoutedEventArgs e)
        {
            if (_conversionList.Count == 0)
            {
                MessageBox.Show(Localization.GetString("Global", 50), Localization.GetString("Global", 51));
                return;
            }
            var output = lblOutput.Content.ToString();

            if (!lblOutput.Content.ToString().ContainsIgnoreCase(":\\"))
            {
                MessageBox.Show(Localization.GetString("Global", 52), Localization.GetString("Global", 53));
                return;
            }

            lblStatus.Text = Localization.GetString("Global", 48);

            pbProgress.Value = 0;
            pbProgress.Maximum = _conversionList.Count;
            lblProgress.Content = "0%";
            dgUpdates.Disable();
            rbnMain.IsEnabled = false;

            _tim = new ElapsedTimer(ref txtTime);
            _tim.Start();
            var amountConverted = 0;

            Task.Factory.StartNew(delegate
            {
                Parallel.ForEach(_conversionList,
                    new ParallelOptions {MaxDegreeOfParallelism = Options.MaxThreads},
                    currentFile =>
                    {
                        currentFile.Status = currentFile.Convert(output);
                        amountConverted++;

                        pbProgress.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            pbProgress.Value++;

                            var progress = (pbProgress.Value/pbProgress.Maximum)*100;

                            lblStatus.Text = amountConverted + " / " + _conversionList.Count + " " +
                                             Localization.GetString("Global", 49);
                            lblProgress.Content = Math.Round(progress, 1) + "%";

                            dgUpdates.Items.Refresh();
                        }));
                    });
            }).ContinueWith(continuation =>
            {
                IEnumerable<string> fileList =
                    Directory.GetFiles(output, "*.xml", SearchOption.TopDirectoryOnly).ToArray();
                if (!fileList.Any()) return;

                fileList = Directory.GetFiles(output, "*.msp", SearchOption.TopDirectoryOnly).ToArray();
                if (!fileList.Any()) return;


                lblStatus.Dispatcher.BeginInvoke(
                    new Action(() => { lblStatus.Text = Localization.GetString("Global", 47); }));
                Parallel.ForEach(fileList,
                    new ParallelOptions {MaxDegreeOfParallelism = Options.MaxThreads},
                    xmlFile =>
                    {
                        xmlFile = Path.GetDirectoryName(xmlFile) + "\\" +
                                  Path.GetFileNameWithoutExtension(xmlFile) + ".xml";
                        FileHandling.DeleteFile(xmlFile);
                    });
            }).ContinueWith(continuation =>
            {
                _tim.Stop();
                lblStatus.Dispatcher.BeginInvoke(new Action(() =>
                {
                    lblStatus.Text = _conversionList.Count(c => c.Status == Status.Success) + " " +
                                     Localization.GetString("FrmLMM", 8);

                    dgUpdates.Enable();
                    rbnMain.IsEnabled = true;

                    if (chkOpenExplorer.IsChecked == true)
                    {
                        Processes.OpenExplorer(output);
                    }
                }));
            });
        }

        private void BtnSelectFolder_OnClick(object sender, RoutedEventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            lblOutput.Content = folderDialog.SelectedPath;
        }

        private void BtnDeleteOriginal_OnChecked(object sender, RoutedEventArgs e)
        {
            if (BtnDeleteOriginal.IsChecked != true) return;
            var result =
                MessageBox.Show(
                    Localization.GetString("FrmLMM", 6) + "\n\n" + Localization.GetString("Global", 55) +
                    "\n[Not Implemented]", Localization.GetString("Global", 55), MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
            {
                BtnDeleteOriginal.IsChecked = false;
            }
        }

        private void BtnDeleteSelected_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (_Integratable item in dgUpdates.SelectedItems)
            {
                _conversionList.Remove(item);
            }

            dgUpdates.Update();
            lblStatus.Text = _conversionList.Count + " " + Localization.GetString("Global", 54);
        }

        private void BtnDeleteAll_OnClick(object sender, RoutedEventArgs e)
        {
            _conversionList.Clear();

            dgUpdates.Update();
            lblStatus.Text = "0 " + Localization.GetString("Global", 54);
        }

        private void RbnMain_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0)).RowDefinitions[0].Height = new GridLength(0);
        }
    }
}