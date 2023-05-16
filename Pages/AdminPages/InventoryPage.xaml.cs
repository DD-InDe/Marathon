using Marathon.AllWindow;
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
    /// Логика взаимодействия для InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        public InventoryPage()
        {
            InitializeComponent();
            var regEvent = DB.entities.RegistrationEvent.Where(c => c.EventId == "15_5HM").ToList();
            RunnersCountTextBlock.Text = regEvent.Count.ToString();

            List<RaceKitSet> listOne = new List<RaceKitSet>();
            listOne.Add(DB.entities.RaceKitSet.ToList()[0]);
            InventoryDataGrid.ItemsSource = listOne;
            
            ObjectsDataGrid.ItemsSource = DB.entities.SetObjects.ToList();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow(4);
            infoWindow.ShowDialog();
        }

        private void SupplyButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new InventorySupplyPage());
    }
}
