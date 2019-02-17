using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WinToolkitv2
{
    /// <summary>
    ///     Interaction logic for _frmTemplate.xaml
    /// </summary>
    public partial class _frmTemplate : Window
    {
        public _frmTemplate()
        {
            InitializeComponent();
        }

        private void PbProgress_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var progress = (pbProgress.Value / pbProgress.Maximum) * 100;
            lblProgress.Content = Math.Round(progress, 1) + "%";
        }

        private void RbnMain_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0)).RowDefinitions[0].Height = new GridLength(0);
        }
    }
}