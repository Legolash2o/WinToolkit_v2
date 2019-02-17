using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WinToolkitDLL;

namespace WinToolkitv2
{
    /// <summary>
    ///     Interaction logic for frmOptions.xaml
    /// </summary>
    public partial class frmOptions
    {
        public frmOptions()
        {
            InitializeComponent();
            for (var i = 1; i <= Environment.ProcessorCount; i++)
            {
                cboMaxThreads.Items.Add(i);
            }
        }

        private void BtnSaveSettings_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void BtnDefault_OnClick(object sender, RoutedEventArgs e)
        {
            var result =
                MessageBox.Show(
                    Localization.GetString("FrmOptions", 14) + "\n\n" + Localization.GetString("Global", 55),
                    Localization.GetString("Global", 55), MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                AppOptions.CurrentOptions.LoadDefaults();
                Close();
            }
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0)).RowDefinitions[0].Height = new GridLength(0);
        }

        private void FrmOptions_OnLoaded(object sender, RoutedEventArgs e)
        {
            cboMaxThreads.Text = Options.MaxThreads.ToString();
        }
    }
}