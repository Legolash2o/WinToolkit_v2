using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WinToolkitDLL.Objects.WimImage;

namespace WinToolkitv2.Dialogs
{
    /// <summary>
    /// Interaction logic for frmWIMEdit.xaml
    /// </summary>
    public partial class frmWIMEdit : Window
    {
        public frmWIMEdit(_WimImage image)
        {
            InitializeComponent();

            lblImageName.Content = image.Name;
            lblWIMPath.Text = image.WimPath;

            txtImageName.Text = image.Name;
            txtImageDesc.Text = image.Description;

            if (image is WimImage)
            {
                txtImageDName.Text = ((WimImage)image).DisplayName;
                txtImageName.Text = ((WimImage)image).DisplayDescription;
            }

            cboFlag.Text = image.Flag.ToString();
        }
    }
}
