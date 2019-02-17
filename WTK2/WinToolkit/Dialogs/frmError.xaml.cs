using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using WinToolkitDLL;
using WinToolkitDLL.Commands;
using WinToolkitDLL.Extensions;
using WinToolkitv2._Code;
using Brushes = System.Windows.Media.Brushes;
using Clipboard = System.Windows.Clipboard;
using Image = System.Windows.Controls.Image;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace WinToolkitv2.Dialogs
{
    /// <summary>
    /// Interaction logic for frmError.xaml
    /// </summary>
    public partial class FrmError
    {
        
        private readonly Exceptions.CustomException _exception;
        private bool _moved;

        public FrmError(Exceptions.CustomException customException)
        {
            _exception = customException;
            InitializeComponent();

          
            lblTitle.Content = _exception.Title;
            if (string.IsNullOrWhiteSpace(_exception.Title))
            {
                lblTitle.Content = "Unknown Error";
            }
           
            lblMachine.Content = Environment.MachineName;
            lblDate.Content = _exception.Date.ToString("dd MMMM yyyy HH:mm");
            lblPriority.Content = _exception.Priority;
            lblEXEversion.Content = OS.WinToolkit.WinToolkitVersion;
            lblDLLversion.Content = OS.WinToolkit.DllVersion;
            lblMessage.Content = _exception.Exception.Message;
            lblSource.Content = _exception.Exception.TargetSite.Name;
            lblAssembly.Content = _exception.Exception.Source;

            lblExtended.Text = _exception.Exception.ToString();

            foreach (Bitmap bmp in _exception.Screenshots)
            {

                var screenshot = Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromWidthAndHeight(bmp.Width, bmp.Height));

                Image img = new Image
                {
                    Margin = new Thickness(5, 5, 5, 0),
                    Source = screenshot
                };

                spMoreInfo.Children.Add(img);
            }

            UpdateLimit();
        }

        private void BtnForum_OnClick(object sender, RoutedEventArgs e)
        {
            Processes.OpenLink("http://www.wincert.net/forum/index.php?app=forums&module=post&section=post&do=new_post&f=213", false);
        }

        private void BtnSaveXMLAs_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog
            {
                Filter = "Error Log *.xml|*.xml",
                FileName = "Error_" + OS.WinToolkit.WinToolkitVersion.Replace(".", "-") + "_" +
                           _exception.Date.ToString("yy-MM-dd_HHmm")
            };


            var showDialog = ofd.ShowDialog();
            if (showDialog != null && !(bool)showDialog)
                return;

            _exception.XML.Save(ofd.FileName);
        }

        private void BtnClipboard_OnClick(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            StringBuilder builder = new StringBuilder();
            TextWriter writer = new StringWriter(builder);

            _exception.XML.Save(writer);

            Clipboard.SetText(builder.ToString());
        }

        private void BtnSaveScreenshotAs_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog
            {
                Filter = "Error Screenshot *.png|*.png",
                FileName = "Error_" + OS.WinToolkit.WinToolkitVersion.Replace(".", "-") + "_" +
                           _exception.Date.ToString("dd_MMMM_yyyy-HHmmss")
            };


            var showDialog = ofd.ShowDialog();
            if (showDialog != null && !(bool)showDialog)
                return;


            for (int i = 0; i < _exception.Screenshots.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(ofd.FileName) + "_" + i;
                string saveTo = Path.GetDirectoryName(ofd.FileName) + "\\" + fileName + ".png";
                _exception.Screenshots[i].Save(saveTo);
            }
        }

        private void BtnSaveAsBundle_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog
            {
                Filter = "Error Bundle *.zip|*.zip",
                FileName = "Error_" + OS.WinToolkit.WinToolkitVersion.Replace(".", "-") + "_" +
                           _exception.Date.ToString("dd_MMMM_yyyy-HHmm")
            };


            var showDialog = ofd.ShowDialog();
            if (showDialog != null && !(bool)showDialog)
                return;

            _exception.Save(ofd.FileName);

        }

        private void TxtNotes_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _exception.AddNote(txtNotes.Text);
        }

        private void OnExpanded(object sender, RoutedEventArgs e)
        {
            if (!_moved)
            {
                _moved = true;
                Top -= 100;
            }

            Expander current = (Expander)sender;
            switch (current.Name)
            {
                case "eExtended":
                    eAttachments.IsExpanded = false;
                    eNotes.IsExpanded = false;
                    return;
                case "eNotes":
                    eAttachments.IsExpanded = false;
                    eExtended.IsExpanded = false;
                    return;
                case "eAttachments":
                    eNotes.IsExpanded = false;
                    eExtended.IsExpanded = false;
                    return;
            }
        }

        private void UpdateAttachments()
        {
            scAttachments.Children.Clear();
            foreach (string file in _exception.Attachments)
            {
                Grid grd = new Grid();
                ColumnDefinition cd1 = new ColumnDefinition();
                ColumnDefinition cd2 = new ColumnDefinition(); 
                ColumnDefinition cd3 = new ColumnDefinition();

                grd.ColumnDefinitions.Add(cd1);
                grd.ColumnDefinitions.Add(cd2);
                grd.ColumnDefinitions.Add(cd3);

                Label fileName = new Label { Content = file };
                Label fileSize = new Label { Content = new FileInfo(file).Length.toStringSize(), HorizontalContentAlignment= HorizontalAlignment.Center};

                Button btnDelete = new Button
                {
                    Content = FindResource("imgDelete"),
                    BorderThickness = new Thickness(0),
                    Background = Brushes.Transparent
                };

                var file1 = file;
                btnDelete.Click += delegate(object sender, RoutedEventArgs args)
                {
                    _exception.RemoveAttachment(file1);
                    UpdateAttachments();

                };

                Grid.SetColumn(fileName, 2);
                Grid.SetColumn(fileSize, 1);
                Grid.SetColumn(btnDelete, 0);

                grd.Children.Add(btnDelete);
                grd.Children.Add(fileSize);
                grd.Children.Add(fileName);



                cd1.Width = new GridLength(20);
                cd2.Width = new GridLength(100);
                cd3.Width = new GridLength(200, GridUnitType.Star);
                scAttachments.Children.Add(grd);
            }
            UpdateLimit();
        }

        private void UpdateLimit()
        {
            eAttachments.Header = Localization.GetString("FrmError", 18) + " [" + _exception.Attachments.Count + " - " +
                                  _exception.LimitRemaining.toStringSize() + "]";
        }

        private void BtnAttachment_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "All Files *.*|*.*";
            OFD.Title = "Add Attachments";

            if (OFD.ShowDialog() == false)
                return;

            if (_exception.AddAttachment(OFD.FileName, false))
            {
                UpdateAttachments();
            }
        }
    }
}
