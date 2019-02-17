using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using WinToolkitDLL;
using WinToolkitDLL.Extensions;
using WinToolkitDLL.Objects.Integratables;
using WinToolkitDLL.Objects.WimImage;

namespace WinToolkitv2
{
    /// <summary>
    ///     Interaction logic for _frmTemplate.xaml
    /// </summary>
    public partial class FrmAllInOne : Window
    {
        private ElapsedTimer _tim;
        private readonly string _imagePath;

        #region LISTS
        private readonly IList<_WimImage> _images;

        private ConcurrentBag<_Update> _updates = new ConcurrentBag<_Update>();
        private ConcurrentBag<_Update> _drivers = new ConcurrentBag<_Update>();
        #endregion

        //Codes and methods responsible for loading of this specific AIO tool.
        #region Loading

        /// <summary>
        ///     Loads the AIO Integrator to work with offline images.
        /// </summary>
        /// <param name="images">A list of selected images.</param>
        public FrmAllInOne(IList images)
        {
            _images = images.Cast<_WimImage>().ToList();
            _imagePath = _images[0].WimPath;

            LoadBoth();
            pbProgress.ValueChanged += Events.PbProgress_OnValueChanged;

            lblImage.Content = "[" + _images.Count + "] " + _images[0].WimPath;
            lblImage.ToolTip = "Selected Images:" + _images.Aggregate("\r\n", (current, t) => current + t.Name);

            LoadOnline();
            this.LoadShared();
        }

        /// <summary>
        ///     Loads the AIO Integrator to work with the current OS.
        /// </summary>
        public FrmAllInOne()
        {
            LoadBoth();

            _imagePath = "Online";
            lblImage.Content = "[Online]";
            LoadOffline();
        }

        private void LoadBoth()
        {
            InitializeComponent();
            pbProgress.ValueChanged += Events.PbProgress_OnValueChanged;
        }

        /// <summary>
        ///     Load the GUI preferences for when working with the current OS
        /// </summary>
        private void LoadOnline()
        {
        }

        /// <summary>
        ///     Load the GUI preferences for when working with an offline image.
        /// </summary>
        private void LoadOffline()
        {
        }
        private void FrmAllInOne_OnClosing(object sender, CancelEventArgs e)
        {

        }

        private void FrmAllInOne_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void FrmAllInOne_OnClosed(object sender, EventArgs e)
        {
            Lists.selectedImages.Remove(_imagePath);
        }

        #endregion


        #region Add_Updates

        private async void addUpdate(IEnumerable<string> files)
        {
            dgUpdates.Disable();
            pbProgress.Value = 0;
            lblProgress.Content = "0%";

            var source = files.ToArray();
            pbProgress.Maximum = source.Count();

            _tim = new ElapsedTimer(ref txtTime);
            _tim.Start();

            await Task.Factory.StartNew(delegate
            {
                Parallel.ForEach(source, new ParallelOptions { MaxDegreeOfParallelism = Options.MaxThreads }, currentFile =>
               {

                   _Update newUpdate = null;
                   if (currentFile.EndsWithIgnoreCase(".cab"))
                   {
                       newUpdate = new CabUpdate(currentFile);
                   }
                   else if (currentFile.EndsWithIgnoreCase(".msu"))
                   {
                       newUpdate = new MsuUpdate(currentFile);
                   }

                   pbProgress.Increment(lblProgress);

                   if (newUpdate == null)
                       return;
                   _updates.Add(newUpdate);
               });

            });

            _tim.Stop();
            dgUpdates.ItemsSource = _updates;
            dgUpdates.Update();
        }

        private void BtnAddUpdateFile_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Updates";
            ofd.Multiselect = true;
            ofd.Filter = "Updates *.msu, *.cab|*.msu;*.msu";

            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            IEnumerable<string> files = ofd.FileNames.Where(s => (s.EndsWithIgnoreCase(".msu") || s.EndsWithIgnoreCase(".cab")) && !_updates.Any(u => u.Location.EqualsIgnoreCase(s)));
            addUpdate(files);
        }


        private void BtnAddUpdateFolder_OnClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select Updates";

            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            IEnumerable<string> files = Directory.GetFileSystemEntries(fbd.SelectedPath, "*.*", SearchOption.TopDirectoryOnly).Where(s => (s.EndsWithIgnoreCase(".msu") || s.EndsWithIgnoreCase(".cab")) && !_updates.Any(u => u.Location.EqualsIgnoreCase(s)));
            addUpdate(files);
        }

        private void BtnAddUpdateFolderRecurse_OnClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select Updates";

            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            IEnumerable<string> files = Directory.GetFileSystemEntries(fbd.SelectedPath, "*.*", SearchOption.AllDirectories).Where(s => (s.EndsWithIgnoreCase(".msu") || s.EndsWithIgnoreCase(".cab")) && !_updates.Any(u => u.Location.EqualsIgnoreCase(s)));
            addUpdate(files);
        }

        #endregion

        private void RbnMain_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((Grid)VisualTreeHelper.GetChild((DependencyObject)sender, 0)).RowDefinitions[0].Height = new GridLength(0);
        }
    }
}