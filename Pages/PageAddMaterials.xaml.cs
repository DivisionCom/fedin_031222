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
    /// Interaction logic for PageAddMaterials.xaml
    /// </summary>
    public partial class PageAddMaterials : Page
    {
        int rbLogic = 0;
        public PageAddMaterials()
        {
            InitializeComponent();
            cbCategory.SelectedValuePath = "id_category";
            cbCategory.DisplayMemberPath = "category_name";
            cbCategory.ItemsSource = ConnectOdb.conObj.Category.ToList();

            cbManufacturer.SelectedValuePath = "id_manufacturer";
            cbManufacturer.DisplayMemberPath = "manufacturer_name";
            cbManufacturer.ItemsSource = ConnectOdb.conObj.Manufacturer.ToList();

            cbProvider.SelectedValuePath = "id_providers";
            cbProvider.DisplayMemberPath = "providers_name";
            cbProvider.ItemsSource = ConnectOdb.conObj.Providers.ToList();

            if(rbAvailable.IsChecked != false)
            {
                rbLogic = 1;
            }
            else
            {
                rbLogic = 0;
            }

            if(rbUnAvailable.IsChecked != false)
            {
                rbLogic = 0;
            }
            else
            {
                rbLogic = 1;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Materials materials = new Materials()
                {
                    materials_name = txtName.Text,
                    materials_count = Convert.ToInt32(txtCount.Text),
                    materials_available = rbLogic,
                    materials_description = txtDescription.Text,
                    materials_photo = txtPhoto.Text,
                    materials_category = (int)cbCategory.SelectedValue,
                    materials_manufacturer = (int)cbManufacturer.SelectedValue,
                    materials_providers = (int)cbProvider.SelectedValue
                };

                ConnectOdb.conObj.Materials.Add(materials);
                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString());
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
