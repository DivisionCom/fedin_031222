using fedin_031222.AppData;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fedin_031222.Pages
{
    /// <summary>
    /// Interaction logic for PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
        }

        private void btnMaterials_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageMaterials());
        }

        private void btnAddMaterials_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageAddMaterials());
        }

        private void btnTableMaterials_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageTableMaterials());
        }
    }
}
