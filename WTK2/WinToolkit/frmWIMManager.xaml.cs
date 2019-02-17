using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitDLL.Objects.WimImage;
using WinToolkitv2.Dialogs;
using MessageBox = System.Windows.MessageBox;

namespace WinToolkitv2
{
    /// <summary>
    ///     Interaction logic for frmWIMManager.xaml
    /// </summary>
    public partial class frmWIMManager
    {
        private ObservableCollection<_WimImage> images = new ObservableCollection<_WimImage>();
        private string lastImage = "";

        #region FORM_LOAD

        private ModeType _currentMode;

        public ModeType CurrentMode
        {
            get { return _currentMode; }
            set
            {
                _currentMode = value;

                btnModeAIO.Visibility = Visibility.Collapsed;
                btnModeREG.Visibility = Visibility.Collapsed;
                btnModeWIM.Visibility = Visibility.Collapsed;

                switch (_currentMode)
                {
                    case ModeType.AIO:
                        btnModeREG.Visibility = Visibility.Visible;
                        btnModeWIM.Visibility = Visibility.Visible;
                        lblTool.Content = Localization.GetString("FrmAllInOneIntegrator", 0);
                        break;
                    case ModeType.REG:
                        btnModeAIO.Visibility = Visibility.Visible;
                        btnModeWIM.Visibility = Visibility.Visible;
                        lblTool.Content = Localization.GetString("FrmWIMRegistryEditor", 0);
                        break;
                    default:
                        btnModeAIO.Visibility = Visibility.Visible;
                        btnModeREG.Visibility = Visibility.Visible;
                        lblTool.Content = Localization.GetString("FrmWIMManager", 0); ;
                        break;
                }
            }
        }

        public enum ModeType
        {
            Main,
            AIO,
            REG,
            Online
        }

        public frmWIMManager(ModeType mode)
        {
            InitializeComponent();
            CurrentMode = mode;
            btnCurrent.Visibility = Visibility.Collapsed;
            btnContinue.Visibility = Visibility.Collapsed;
            rgSelection.Visibility = Visibility.Collapsed;

            switch (mode)
            {
                case ModeType.AIO:
                    btnCurrent.Visibility = Visibility.Visible;
                    btnContinue.Visibility = Visibility.Visible;
                    rgSelection.Visibility = Visibility.Visible;
                    break;
                case ModeType.REG:
                    btnContinue.Visibility = Visibility.Visible;
                    rgSelection.Visibility = Visibility.Visible;
                    break;
            }

            if (Lists.selectedImages.Any(l => l == "Online"))
            {
                btnCurrent.Visibility = Visibility.Collapsed;
            }

            // tbTools.Visibility = Visibility.Collapsed;
            this.LoadShared();

        }

        private void DefineGroup()
        {
            var wimView =
CollectionViewSource.GetDefaultView(images);

            // Set the grouping by city proprty
            wimView.GroupDescriptions.Add(new PropertyGroupDescription("WimPath"));

            // Set the view as the DataContext for the DataGrid
            dgImages.DataContext = wimView;
        }

        #endregion

        private void BtnWIM_OnClick(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            // ofd.Filter = "WIM Image *.wim| *.wim|ESD Image *.esd| *.esd";
            ofd.Filter = "WIM Image *.wim| *.wim|ESD Image *.esd| *.esd";
            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            sbProgress.Visibility = sbTime.Visibility = Visibility.Visible;

            lastImage = ofd.FileName;
            Refresh();
            // dgImages.ItemsSource = wims;
            //dgImages.Items.Refresh();
        }

        private async Task<ObservableCollection<_WimImage>> LoadWIM(string wimPath)
        {
            ObservableCollection<_WimImage> result = new ObservableCollection<_WimImage>();
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    result = Wim.GetWIM(wimPath);
                });
                if (result.Count > 0)
                {
                    images = new ObservableCollection<_WimImage>(images.Concat(result).Distinct());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;

            //  DefineGroup();

            //  dgImages.Items.Refresh();

            sbProgress.Visibility = sbTime.Visibility = Visibility.Collapsed;
            lblStatus.UpdateText("Idle.");
        }



        private void FrmWIMManager_OnLoaded(object sender, RoutedEventArgs e)
        {


            string debugWIM1 = @"F:\DVD\Win7SP1x86\sources\install.wim";
            string debugWIM2 = @"E:\_ISO\Win7SP1x86\sources\install.wim";

            if (Debugger.IsAttached)
            {
                if (File.Exists(debugWIM1))
                    lastImage = debugWIM1;
                else if (File.Exists(debugWIM2))
                    lastImage = debugWIM2;
            }

            Refresh();
            lblStatus.UpdateText("Idle.");
        }

        private void PbProgress_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgress.Content = pbProgress.Value + "%";
        }

        private async void Refresh()
        {
            images.Clear();
            lblStatus.UpdateText("Retreiving Mounted Images");


            await Task.Factory.StartNew(() =>
            {
                try
                {
                    images = Wim.GetMounted();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

            if (!string.IsNullOrWhiteSpace(lastImage) && !images.Any(w => w.WimPath.EqualsIgnoreCase(lastImage)))
            {
                lblStatus.UpdateText("Loading previous image...");
                await LoadWIM(lastImage);
            }

            DefineGroup();
            dgImages.Items.Refresh();
            lblStatus.UpdateText("Idle.");
        }

        private async void BtnMount_OnClick(object sender, RoutedEventArgs e)
        {
            if (dgImages.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item.");
                return;
            }

            var image = (_WimImage)dgImages.SelectedItems[0];

            if (image.ImageType != _WimImage.Type.WIM)
            {
                MessageBox.Show("This cannot be mounted.");
                return;
            }

            var FBD = new FolderBrowserDialog();
            FBD.Description = "Select Mount Path";

            if (FBD.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            var selectedPath = FBD.SelectedPath;

            lblStatus.UpdateText("Mounting Image...");
            pbProgress.SetValue(0);
            sbProgress.Visibility = sbTime.Visibility = Visibility.Visible;
            rbnMain.Disable();
            dgImages.Disable();
            await ((WimImage)image).MountImage(selectedPath, pbProgress);
            Refresh();
            dgImages.Enable();
            rbnMain.Enable();
            sbProgress.Visibility = sbTime.Visibility = Visibility.Collapsed;
            lblStatus.UpdateText("Idle.");
        }

        private void BtnHelp_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.wincert.net/forum/topic/9573-wim-manager/");
        }

        private async void UnmountImage(bool save)
        {
            if (dgImages.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item.");
                return;
            }

            var image = (_WimImage)dgImages.SelectedItems[0];

            if (image.ImageType != _WimImage.Type.Mounted)
            {
                MessageBox.Show("This image is not mounted.");
                return;
            }
            pbProgress.SetValue(0);
            sbProgress.Visibility = sbTime.Visibility = Visibility.Visible;
            rbnMain.Disable();
            dgImages.Disable();

            if (save)
            {
                lblStatus.UpdateText("Saving Image...");
                await ((WimMountedImage)image).Save(pbProgress);
            }
            else
            {
                lblStatus.UpdateText("Discarding Image...");
                await ((WimMountedImage)image).Discard(pbProgress);
            }


            Refresh();
            dgImages.Enable();
            rbnMain.Enable();
            sbProgress.Visibility = sbTime.Visibility = Visibility.Collapsed;
            lblStatus.UpdateText("Idle.");
        }

        private void BtnUnmountSave_OnClick(object sender, RoutedEventArgs e)
        {
            UnmountImage(true);
        }

        private void BtnUnmountDiscard_OnClick(object sender, RoutedEventArgs e)
        {
            UnmountImage(false);
        }

        private void BtnDVD_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnContinue_OnClick(object sender, RoutedEventArgs e)
        {
            if (dgImages.SelectedItems.Count == 0)
                return;

            var image = (_WimImage)dgImages.SelectedItems[0];

            if (Lists.selectedImages.Any(l => l == image.WimPath))
            {
                MessageBox.Show("You have already selected that image.", "Choose another");
                return;
            }

            Lists.selectedImages.Add(((_WimImage)dgImages.SelectedItems[0]).WimPath);
            new FrmAllInOne(dgImages.SelectedItems).Show();
            Close();
        }

        private void BtnCurrent_OnClick(object sender, RoutedEventArgs e)
        {
            Lists.selectedImages.Add("Online");
            new FrmAllInOne().Show();
            Close();
        }

        private void DgImages_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgImages.SelectedItems.Count > 0)
            {
                var img = (_WimImage)dgImages.SelectedItems[0];

                if (img is WimMountedImage)
                {
                    btnMount.Visibility = Visibility.Collapsed;
                    btnUnMount.Visibility = Visibility.Visible;
                }
                else
                {
                    btnMount.Visibility = Visibility.Visible;
                    btnUnMount.Visibility = Visibility.Collapsed;
                }
            }
        }


        private void RbnEditImage_OnClick(object sender, RoutedEventArgs e)
        {
            if (dgImages.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item.");
                return;
            }

            var image = (_WimImage)dgImages.SelectedItems[0];
            new frmWIMEdit(image).ShowDialog();
        }

        private void RbnMain_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0)).RowDefinitions[0].Height = new GridLength(0);
        }

        private void BtnModeAIO_OnClick(object sender, RoutedEventArgs e)
        {
            CurrentMode = ModeType.AIO;
        }

        private void BtnModeREG_OnClick(object sender, RoutedEventArgs e)
        {
            CurrentMode = ModeType.REG;
        }

        private void BtnModeWIM_OnClick(object sender, RoutedEventArgs e)
        {
            CurrentMode = ModeType.Main;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F5)
            {
                Refresh();
            }
        }
    }
}