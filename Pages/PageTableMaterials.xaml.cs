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
using System.Windows.Threading;

namespace fedin_031222.Pages
{
    /// <summary>
    /// Interaction logic for PageTableMaterials.xaml
    /// </summary>
    public partial class PageTableMaterials : Page
    {
        public PageTableMaterials()
        {
            InitializeComponent();
            gridList.ItemsSource = ConnectOdb.conObj.Materials.ToList();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить материал?", "Предупреждение",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var userObj = gridList.SelectedItems.Cast<Materials>().ToList();
                try
                {
                    ConnectOdb.conObj.Materials.RemoveRange(userObj);
                    ConnectOdb.conObj.SaveChanges();
                    MessageBox.Show("Материал успешно удалён!");

                    gridList.ItemsSource = ConnectOdb.conObj.Materials.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
