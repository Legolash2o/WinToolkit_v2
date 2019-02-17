using System;
using System.ComponentModel;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Commands.FileHandlingTasks;
using WinToolkitDLL.Extensions;
using WinToolkitDLL.Objects;
using WinToolkitDLL.ThirdParty;
using MessageBox = System.Windows.MessageBox;

namespace WinToolkitv2
{
    /// <summary>
    ///     Interaction logic for USBPrep.xaml
    /// </summary>
    public partial class frmUSBPrep
    {
        private readonly EventWatcher watcher = new EventWatcher();

        public frmUSBPrep()
        {
            InitializeComponent();
            RibbonWindowService.FixMaximizedWindowTitle(this);
        }

        private void FrmUSBPrep_OnLoaded(object sender, RoutedEventArgs e)
        {
            Reg.DisableAutoPlay();
        }

        private void FrmUSBPrep_OnContentRendered(object sender, EventArgs e)
        {
            try
            {
                watcher.Query =
                    new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3");
                watcher.EventArrived += watcher_EventArrived;
                watcher.Start();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                //LargeError LE = new LargeError("EventWatcher", "Unable to start EventWatcher.", lblStatus.Text, Ex);
                //LE.Upload();
            }
            Scan();
        }

        private void FrmUSBPrep_OnClosing(object sender, CancelEventArgs e)
        {
            Reg.RestoreAutoPlay();
            watcher.Stop();
        }

        public void Enable(bool enabled = true)
        {
            rbnMain.IsEnabled = enabled;
            if (enabled)
            {
                dgUSB.Enable();
            }
            else
            {
                dgUSB.Disable();
            }
        }

        private async void Scan()
        {
            Enable(false);
            watcher.Stop();

            lblStatus.UpdateText(Localization.GetString("FrmUSBPrep", 8) + "...");

            await
                Task.Factory.StartNew(() => { Dispatcher.Invoke(() => { dgUSB.ItemsSource = OS.GetUSBDrives(); }); })
                    .ContinueWith(delegate
                    {
                        lblStatus.UpdateText(Localization.GetString("Global", 10));
                        dgUSB.Update();
                        Dispatcher.Invoke(() => { Enable(); });
                    });
            watcher.Start();
        }

        private void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            try
            {
                watcher.Stop();
                Thread.Sleep(250);
                Dispatcher.Invoke(Scan, DispatcherPriority.Send);
                watcher.Start();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }

            // watcher.ExpiryDate();
        }

        private void BtnRefresh_OnClick(object sender, RoutedEventArgs e)
        {
            Enable(false);
            Scan();
        }

        private void CbUEFI_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (rbUEFI == null)
                return;

            if (rbUEFI.IsChecked == true)
            {
                rbFAT32.IsChecked = true;
                rbNTFS.IsEnabled = false;
            }
            else
            {
                rbNTFS.IsEnabled = true;
            }
        }

        private async void BtnPrepare_OnClick(object sender, RoutedEventArgs e)
        {
            if (dgUSB.SelectedItems.Count != 1)
            {
                MessageBox.Show(Localization.GetString("Global", 69), Localization.GetString("Global", 68));
                return;
            }

            var usb = (USBDrive) dgUSB.SelectedItems[0];

            if (usb.LargerThan32Gb)
            {
                MessageBox.Show(Localization.GetString("FrmUSBPrep", 23), Localization.GetString("FrmUSBPrep", 24));
                return;
            }

            var MBR = MessageBoxResult.None;
            if (usb.BootRecord == BootRecord.MBR && rbUEFI.IsChecked == true)
            {
                MBR =
                    MessageBox.Show(
                        Localization.GetString("FrmUSBPrep", 35) + " " + Localization.GetString("Global", 55) + "\n\n[" +
                        Localization.GetString("FrmUSBPrep", 34) + "]",
                        Localization.GetString("FrmUSBPrep", 25), MessageBoxButton.YesNo);
            }
            if (usb.BootRecord == BootRecord.GPT && rbBIOS.IsChecked == true)
            {
                MBR =
                    MessageBox.Show(
                        Localization.GetString("FrmUSBPrep", 36) + " " + Localization.GetString("Global", 55) + "\n\n[" +
                        Localization.GetString("FrmUSBPrep", 34) + "]",
                        Localization.GetString("FrmUSBPrep", 25), MessageBoxButton.YesNo);
            }

            if (MBR != MessageBoxResult.None && MBR != MessageBoxResult.Yes)
            {
                return;
            }


            Enable(false);
            watcher.Stop();

            var elapsedTimer = new ElapsedTimer(ref txtTime);
            elapsedTimer.Start();
            pbProgress.Value = 0;
            lblStatus.Text = Localization.GetString("FrmISOMaker", 18);
            var quickFormat = cbQuickFormat.IsChecked == true;
            var UEFI = rbUEFI.IsChecked == true;

            var newFormat = DriveFormat.FAT32;
            if (rbNTFS.IsChecked == true)
            {
                newFormat = DriveFormat.NTFS;
            }

            var result = string.Empty;

            usb.PropertyChanged +=
                delegate(object o, PropertyChangedEventArgs args) { lblStatus.UpdateText(args.PropertyName); };

            watcher.Stop();
            await Task.Factory.StartNew(() =>
            {
                if (UEFI)
                {
                    result = usb.PrepareUSB_GPT(quickFormat, pbProgress);
                }
                else
                {
                    result = usb.PrepareUSB_MBR(quickFormat, newFormat, pbProgress);
                }
            }).ContinueWith(delegate
            {
                elapsedTimer.Stop();
                pbProgress.Value = 100;
                lblStatus.Text = "Done";
            }, TaskScheduler.FromCurrentSynchronizationContext());

            Scan();
        }

        private void PbProgress_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgress.UpdateText(pbProgress.Value + "%");
        }

        private async void BtnCopyFolder_OnClick(object sender, RoutedEventArgs e)
        {
            if (dgUSB.SelectedItems.Count != 1)
            {
                MessageBox.Show(Localization.GetString("FrmUSBPrep", 37), Localization.GetString("Global", 68));
                return;
            }

            var usb = (USBDrive) dgUSB.SelectedItems[0];

            if (usb.Status != Status.Success)
            {
                MessageBox.Show(Localization.GetString("FrmUSBPrep", 38), Localization.GetString("Global", 68));
                return;
            }

            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            Enable(false);
            await new TaskFactory().StartNew(() =>
            {
                var copyDirectory = new CopyDirectory(folderBrowserDialog.SelectedPath, usb.Letter);
                copyDirectory.Status += CopyDirectoryOnStatus;
                copyDirectory.Run();
            }).ContinueWith(delegate
            {
                lblStatus.UpdateText("Done");
                Dispatcher.Invoke(() => { Enable(); });
            });
        }

        private void CopyDirectoryOnStatus(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            pbProgress.Dispatcher.Invoke(() =>
            {
                var progress = (int) double.Parse(propertyChangedEventArgs.PropertyName.Split('|')[0]);
                var file = propertyChangedEventArgs.PropertyName.Split('|')[1];
                pbProgress.Value = progress;
                lblStatus.Text = "Copying: " + file;
            });
        }

        public class EventWatcher : ManagementEventWatcher
        {
            private bool _active;

            public new void Start()
            {
                lock (this)
                {
                    if (_active) return;
                    _active = true;
                    base.Start();
                }
            }

            public new void Stop()
            {
                lock (this)
                {
                    if (!_active) return;
                    _active = false;
                    base.Stop();
                }
            }
        }

        private void RbnMain_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0)).RowDefinitions[0].Height = new GridLength(0);
        }
    }
}