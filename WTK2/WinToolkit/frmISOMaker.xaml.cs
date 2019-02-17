using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.ThirdParty;
using MessageBox = System.Windows.MessageBox;

namespace WinToolkitv2
{
    /// <summary>
    ///     Interaction logic for frmISOMaker.xaml
    /// </summary>
    public partial class frmISOMaker
    {
        private bool cancel;
        private ISO iso;

        public frmISOMaker()
        {
            InitializeComponent();
        }

        private void FrmISOMaker_OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void BtnHelp_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.wincert.net/forum/topic/9570-iso-maker/");
        }

        private void BtnCreateISO_OnClick(object sender, RoutedEventArgs e)
        {
            if (btnCreateISO.Label == Localization.GetString("FrmISOMaker", 6))
            {
                if (lblDirectory.Content.ToString().Equals(Localization.GetString("FrmISOMaker", 10)))
                {
                    MessageBox.Show(Localization.GetString("FrmISOMaker", 10), "");
                    return;
                }

                if (lblISO.Content.ToString().Equals(Localization.GetString("FrmISOMaker", 9)))
                {
                    MessageBox.Show(Localization.GetString("FrmISOMaker", 9), "");
                    return;
                }

                var directory = new DirectoryInfo(lblDirectory.Content.ToString());
                var files = directory.GetFiles("*", SearchOption.AllDirectories);

                var filtered = files.Select(f => f)
                    .Where(f => (f.Attributes & FileAttributes.Directory) != FileAttributes.Directory);

                if (!filtered.Any())
                {
                    MessageBox.Show(Localization.GetString("FrmISOMaker", 21), Localization.GetString("Global", 68));
                    return;
                }

                var timer = new ElapsedTimer(ref txtTime);

                timer.Start();
                Enable(false);
                cancel = false;
                lblStatus.Text = Localization.GetString("FrmISOMaker", 18) + "...";

                btnCreateISO.Label = Localization.GetString("Global", 66);
                var folder = lblDirectory.Content.ToString();
                var isoPath = lblISO.Content.ToString();
                iso = new ISO(folder, isoPath, txtLabel.Text);
                iso.ProgressChanged += iso_ProgressChanged;
                try
                {
                    iso.CreateISO();

                    if (cancel)
                    {
                        pbProgress.Foreground = Brushes.Gold;
                        DeleteISO();
                        lblStatus.Text = Localization.GetString("FrmISOMaker", 20);
                    }
                    else
                    {
                        lblStatus.Text = Localization.GetString("FrmISOMaker", 19);
                    }
                }
                catch (Exception Ex)
                {
                    DeleteISO();
                    lblStatus.Text = Localization.GetString("Global", 67) + ": " + Ex.Message;
                    pbProgress.Foreground = Brushes.Red;
                }
                timer.Stop();

                Enable(true);
                btnCreateISO.Label = Localization.GetString("FrmISOMaker", 6);
                btnCreateISO.IsEnabled = true;
            }
            else
            {
                cancel = true;
                pbProgress.Foreground = Brushes.Gold;
                btnCreateISO.IsEnabled = false;
                iso.Cancel();
            }
        }

        private void DeleteISO()
        {
            lblStatus.Text = Localization.GetString("FrmISOMaker", 17);
            FileHandling.DeleteFile(lblISO.Content.ToString());
        }

        private void Enable(bool enabled)
        {
            btnSelectFolder.IsEnabled = enabled;
            btnISOOutput.IsEnabled = enabled;
            txtLabel.IsEnabled = enabled;
        }

        private void iso_ProgressChanged(object sender, PropertyChangedEventArgs e)
        {
            var prog = int.Parse(e.PropertyName.Split('|')[0]);
            var file = e.PropertyName.Split('|')[1];
            lblStatus.Text = file;
            pbProgress.Value = prog;
        }

        private void PbProgress_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgress.Content = e.NewValue + "%";
            var brush = new SolidColorBrush(Color.FromArgb(0xFF, 0x06, (byte) (pbProgress.Value*-1.5f), 0x25));
            pbProgress.Foreground = brush;
        }

        private void BtnSelectFolder_OnClick(object sender, RoutedEventArgs e)
        {
            var fdb = new FolderBrowserDialog();
            fdb.Description = Localization.GetString("FrmISOMaker", 16);
            if (fdb.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            if (string.IsNullOrEmpty(txtLabel.Text))
            {
                lblDirectory.Content = fdb.SelectedPath;
                txtLabel.Text = new DirectoryInfo(fdb.SelectedPath).Name;
            }
        }

        private void BtnISOOutput_OnClick(object sender, RoutedEventArgs e)
        {
            var ofd = new SaveFileDialog();
            ofd.Title = Localization.GetString("FrmISOMaker", 15);
            ofd.Filter = "ISO File *.iso|*.iso";

            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            lblISOSize.Content = "N/A";
            lblISO.Content = ofd.FileName;
        }

        private void RbnMain_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0)).RowDefinitions[0].Height = new GridLength(0);
        }
    }
}