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
    /// Логика взаимодействия для ManageCharitiesPage.xaml
    /// </summary>
    public partial class ManageCharitiesPage : Page
    {
        public ManageCharitiesPage()
        {
            InitializeComponent();

            CharityDataGrid.ItemsSource = DB.entities.Charity.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Charity selectedCharity = (Charity)((Button)sender).DataContext;
            NavigationService.Navigate(new CharityEditPage(selectedCharity));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new CharityEditPage());    
    }
}
