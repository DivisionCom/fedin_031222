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
    /// Interaction logic for PageMaterials.xaml
    /// </summary>
    public partial class PageMaterials : Page
    {
        Materials[] FindMaterials()
        {
            List<Materials> materials = ConnectOdb.conObj.Materials.ToList();
            var materialsAll = materials;

            materials = materials.Where(x => x.materials_name.ToLower().Contains(TxtSearch.Text.ToLower()) || x.materials_description.StartsWith(TxtSearch.Text)).ToList().ToList();

            if (cb_self.SelectedIndex > 0)
            {
                materials = materials.Where(x => x.Manufacturer.manufacturer_name == cb_self.SelectedItem.ToString()).ToList();
            }

            return materials.ToArray();
        }
        public PageMaterials()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            if (cb_self.SelectedIndex != 0)
            {
                timer.Stop();
            }
            else
            {
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += UpdateData;
                timer.Start();
            }
            cb_self.Items.Add("Производитель");
            foreach (var manufacturer in ConnectOdb.conObj.Manufacturer)
            {
                cb_self.Items.Add(manufacturer.manufacturer_name);
            }
            cb_self.SelectedIndex = 0;

        }

        public void UpdateData(object sender, object e)
        {
            var historyMaterials = ConnectOdb.conObj.Materials.ToList();
            listMaterials.ItemsSource = historyMaterials;
            historyMaterials = ConnectOdb.conObj.Materials
                .Where(x => x.materials_name.StartsWith(TxtSearch.Text) || x.materials_description.StartsWith(TxtSearch.Text)).ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageEditMaterials((sender as Button).DataContext as Materials));
        }

        private void cb_self_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listMaterials.ItemsSource = FindMaterials();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageTableMaterials());
            MessageBox.Show("Выберите еще раз, что вы хотите удалить");
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            listMaterials.ItemsSource = FindMaterials();
        }
    }
}
