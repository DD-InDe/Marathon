using Marathon.Entities;
using Marathon.Pages.AdminPages;
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

namespace Marathon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Page
    {
        public AdminMenu(User user)
        {
            InitializeComponent();
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new UserManagementPage());
        private void CharitysButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new ManageCharitiesPage());
        private void VolunteersButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new VolunteerPage());
        private void InventoryButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new InventoryPage());
    }
}
