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
    /// Interaction logic for PageEditMaterials.xaml
    /// </summary>
    public partial class PageEditMaterials : Page
    {
        int rbLogic = 0;
        public PageEditMaterials(Materials materials)
        {
            InitializeComponent();
            cbCategory.SelectedIndex = (int)materials.materials_category - 1;
            cbCategory.SelectedValuePath = "id_category";
            cbCategory.DisplayMemberPath = "category_name";
            cbCategory.ItemsSource = ConnectOdb.conObj.Category.ToList();

            cbManufacturer.SelectedIndex = (int)materials.materials_manufacturer - 1;
            cbManufacturer.SelectedValuePath = "id_manufacturer";
            cbManufacturer.DisplayMemberPath = "manufacturer_name";
            cbManufacturer.ItemsSource = ConnectOdb.conObj.Manufacturer.ToList();

            cbProvider.SelectedIndex = (int)materials.materials_providers - 1;
            cbProvider.SelectedValuePath = "id_providers";
            cbProvider.DisplayMemberPath = "providers_name";
            cbProvider.ItemsSource = ConnectOdb.conObj.Providers.ToList();

            MaterialsObj.id_materials = materials.id_materials;

            txtName.Text = materials.materials_name;
            txtCount.Text = Convert.ToString(materials.materials_count);
            txtDescription.Text = materials.materials_description;
            txtPhoto.Text = materials.materials_photo;

            if (materials.materials_available != 0)
            {
                rbAvailable.IsChecked = true;
                rbLogic = 1;
            }
            else
            {
                rbUnAvailable.IsChecked = true;
                rbLogic = 0;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Materials> materials1 = ConnectOdb.conObj.Materials.Where(x => x.id_materials == MaterialsObj.id_materials).AsEnumerable()
                .Select(x => {
                    x.materials_name = txtName.Text;
                    x.materials_count = Convert.ToInt32(txtCount.Text);
                    x.materials_available = rbLogic;
                    if (string.IsNullOrWhiteSpace(txtDescription.Text))
                    {
                        x.materials_description = "";
                    }
                    else 
                    {
                        x.materials_description = txtDescription.Text;
                    }

                    if (string.IsNullOrWhiteSpace(txtDescription.Text))
                    {
                        x.materials_photo = "";
                    }
                    else
                    {
                        x.materials_photo = txtPhoto.Text;
                    }
                    x.materials_category = (int)cbCategory.SelectedValue;
                    x.materials_manufacturer = (int)cbManufacturer.SelectedValue;
                    x.materials_providers = (int)cbProvider.SelectedValue;
                    return x;
                });
            foreach (Materials materials2 in materials1)
            {
                ConnectOdb.conObj.Entry(materials2).State = System.Data.Entity.EntityState.Modified;
            }
                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
