using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Dism;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitv2.Dialogs;
using WinToolkitv2._Code;

namespace WinToolkitv2
{
    /// <summary>
    ///     Interaction logic for frmMain.xaml
    /// </summary>
    public partial class FrmMain
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region TESTS
        private void BtnTestException_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new Exception("Best file compression around: \"DEL *.* \" = 100% compression");
            }
            catch (Exception ex)
            {
                ex.Show();
            }

        }

        private void BtnTestUnhandledException_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception("According to my calculations the problem doesn't exist.");
        }
        #endregion

        public void Load_Settings()
        {
            SizeToContent = SizeToContent.Manual;
            Height = MinHeight;
            Width = MinWidth;
            if (Options.MainMenuAutoHeight && Options.MainMenuAutoWidth)
            {
                SizeToContent = SizeToContent.WidthAndHeight;
                Left = Left - ((Width - MinWidth) / 2);
                Top = Top - ((Height - MinHeight) / 2);
            }
            else if (Options.MainMenuAutoHeight)
            {
                SizeToContent = SizeToContent.Height;
                Top = Top - ((Height - MinHeight) / 2);
            }
            else if (Options.MainMenuAutoWidth)
            {
                SizeToContent = SizeToContent.Width;
                Left = Left - ((Width - MinWidth) / 2);
            }

            lblVersion.Content = OS.WinToolkit.WinToolkitVersion;
            lblDLLVersion.Content = OS.WinToolkit.DllVersion;
            chkShowAdvanced.IsChecked = Options.MainMenuAdvanced;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Settings();
            //  lblLang.Content = Localization.currentCulture;
            // lblLang.ToolTip = Localization.currentCultureName;
        }


        private void chkShowAdvanced_OnChecked(object sender, RoutedEventArgs e)
        {
            TabAdvanced.Visibility = Visibility.Visible;
        }

        private void ChkShowAdvanced_OnUnchecked(object sender, RoutedEventArgs e)
        {
            TabAdvanced.Visibility = Visibility.Collapsed;
            if (TabAdvanced.IsSelected)
            {
                TCMain.SelectedIndex = 1;
            }
        }

        private void ChkShowWelcome_OnChecked(object sender, RoutedEventArgs e)
        {
            if (TabWelcome == null)
            {
                return;
            }
            TabWelcome.Visibility = Visibility.Visible;
        }

        private void ChkShowWelcome_OnUnchecked(object sender, RoutedEventArgs e)
        {
            TabWelcome.Visibility = Visibility.Collapsed;
            if (TabWelcome.IsSelected)
            {
                TCMain.SelectedIndex = 1;
            }
        }

        private void BtnHelp_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.wincert.net/forum/topic/8822-tools-manager/");
        }
      

        private void BtnReportBug_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink(
                "http://www.wincert.net/forum/index.php?app=forums&module=post&section=post&do=new_post&f=209");
        }

        private void BtnVisitForum_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.wincert.net/forum/forum/179-win-toolkit/");
        }

        private void BtnVisitGuides_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.wincert.net/forum/forum/192-win-toolkit-guides/");
        }


        private void BtnISOMaker_OnClick(object sender, RoutedEventArgs e)
        {
            new frmISOMaker().ShowDialog();
        }

        private void BtnMSUtoCAB_OnClick(object sender, RoutedEventArgs e)
        {
            new frmConverter(frmConverter.ModeType.MSUtoCAB).ShowDialog();
        }

        private void BtnOptions_OnClick(object sender, RoutedEventArgs e)
        {
            new frmOptions().ShowDialog();
            Load_Settings();
        }

        private void BtnEXEtoMSP_OnClick(object sender, RoutedEventArgs e)
        {
            new frmConverter(frmConverter.ModeType.EXEtoMSP).ShowDialog();
        }

        private void BtnLangPackConverter_OnClick(object sender, RoutedEventArgs e)
        {
            new frmConverter(frmConverter.ModeType.LangPack).ShowDialog();
        }


        private void BtnUpdateInstaller_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckOnlineRunning())
                return;

            Lists.selectedImages.Add("Online");
            new frmUpdateInstaller().ShowDialog();
            Lists.selectedImages.Remove("Online");
        }

        private void BtnDriverInstaller_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckOnlineRunning())
                return;

            Lists.selectedImages.Add("Online");
            new frmDriverInstaller().ShowDialog();
            Lists.selectedImages.Remove("Online");
        }

        private bool CheckOnlineRunning()
        {
            if (Lists.selectedImages.Any(l => l == "Online"))
            {
                MessageBox.Show("You are already working with the current OS.", "Aborting");
                return true;
            }
            return false;
        }

        private void BtnWIMManager_OnClick(object sender, RoutedEventArgs e)
        {
            new frmWIMManager(frmWIMManager.ModeType.Main).ShowDialog();
        }

        private void BtnAllInOneIntegrator_OnClick(object sender, RoutedEventArgs e)
        {
            new frmWIMManager(frmWIMManager.ModeType.AIO).ShowDialog();
        }

        private void BtnWIMRegistryEditor_OnClick(object sender, RoutedEventArgs e)
        {
            new frmWIMManager(frmWIMManager.ModeType.REG).ShowDialog();
        }

        private void BtnUSBPrep_OnClick(object sender, RoutedEventArgs e)
        {
            new frmUSBPrep().ShowDialog();
        }

        private void BtnLocalizion_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://lang.wintoolkit.co.uk");
        }



        private void BtnBuyWin10_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnWin10ISO_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://windows.microsoft.com/en-us/windows/preview-iso");
        }

        //Buttons which open links

        #region LINKS

        private void BtnDownloadAddon_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.wincert.net/forum/index.php?/forum/180-windows-7-toolkit-addons/");
        }

        private void BtnDownloadDriver_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://driverpacks.net/driverpacks/latest");
        }

        private void BtnDownloadGadgets_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://gallery-live.com/sidebar-gadgets/");
        }

        private void BtnDownloadInstallers_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.wincert.net/forum/index.php?/forum/129-switchless-installers/");
        }

        private void BtnDownloadThemes_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://windows.microsoft.com/en-US/windows/downloads/personalize/themes");
        }

        private void BtnDownloadWallpapers1_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink(
                "http://windows.microsoft.com/en-US/windows/downloads/personalize/wallpaper-desktop-background");
        }

        private void BtnDownloadWallpapers2_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.superbwallpapers.com/");
        }

        private void BtnDownloadWallpapers3_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://wallpaperswide.com/");
        }

        private void BtnDownloadVirtualPC_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.microsoft.com/en-us/download/details.aspx?id=3702");
        }

        private void BtnDownloadVirtualBox_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("https://www.virtualbox.org/wiki/Downloads");
        }

        private void BtnDownloadVirtualPlayer_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("https://my.vmware.com/web/vmware/free#desktop_end_user_computing/vmware_player/");
        }

        private void BtnDownloadXPMode_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://windows.microsoft.com/en-GB/windows7/products/features/windows-xp-mode");
        }

        private void BtnDownloadGoogleChrome_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://support.google.com/installer/bin/answer.py?hl=en&answer=126299");
        }

        private void BtnDownloadIE_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://windows.microsoft.com/en-us/internet-explorer/ie-11-worldwide-languages");
        }

        private void BtnDownloadFirefox_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.mozilla.org/en-US/firefox/new/?from=getfirefox");
        }

        private void BtnDownloadOpera_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.opera.com/download/");
        }

        private void BtnDownloadSafari_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://support.apple.com/en_US/downloads/#safari");
        }

        private void BtnDownloadOffice2013_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink(
                "http://heidoc.net/joomla/technology-science/microsoft/73-office-2013-direct-download-links");
        }

        private void BtnDownloadOffice2010_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink(
                "http://heidoc.net/joomla/technology-science/microsoft/18-office-2010-direct-download-links");
        }

        private void BtnDownloadOffice2007_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink(
                "http://heidoc.net/joomla/technology-science/microsoft/51-office-2007-direct-download-links");
        }
        


        private void BtnISOServer2012_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://technet.microsoft.com/en-US/evalcenter/dn205286.aspx");
        }

        private void BtnISOWin7_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.microsoft.com/en-us/software-recovery");
        }


        private void BtnISOWin8_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://windows.microsoft.com/en-gb/windows-8/create-reset-refresh-media");
        }

        private void BtnISOServer2012E_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://technet.microsoft.com/evalcenter/dn205288.aspx");
        }

        private void BtnChangeLog_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.wincert.net/forum/topic/12507-download-latest-build/");
        }

        #endregion

        private void BtnWindowsHotfixDownloader_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://forums.mydigitallife.info/threads/44645");
        }


        private void BtnLanguagePacks_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink(
                "http://winaero.com/blog/download-official-mui-language-packs-for-windows-8-1-windows-8-and-windows-7/");
        }

        private void RbnMain_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0)).RowDefinitions[0].Height = new GridLength(0);
        }


        private void BtnTestExport_OnClick(object sender, RoutedEventArgs e)
        {
            string source = @"E:\_ISO\Win7SP1x86\sources\install.wim";
            string dest = @"E:\Test.wim";
           DismApi.ExportImage(source,1,dest,0, DismApi.DismCompressType.Compress_LZX, Progress, null );
        }

        private void Progress(DismProgress progress)
        {
            throw new NotImplementedException();
        }
    }
}