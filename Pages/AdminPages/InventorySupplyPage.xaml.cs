using Marathon.Entities;
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

namespace Marathon.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для InventorySupplyPage.xaml
    /// </summary>
    public partial class InventorySupplyPage : Page
    {
        public InventorySupplyPage()
        {
            InitializeComponent();
            InventoryDataGrid.ItemsSource = DB.entities.SetObjects.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DB.entities.SaveChanges();
            DB.entities = new Marathon1Entities();
            InventoryDataGrid.ItemsSource = DB.entities.SetObjects.ToList();
        }
    }
}
