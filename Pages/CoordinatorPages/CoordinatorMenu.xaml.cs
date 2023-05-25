using Marathon.Entities;
using Marathon.Pages.CoordinatorPages;
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
    /// Логика взаимодействия для CoordinatorMenu.xaml
    /// </summary>
    public partial class CoordinatorMenu : Page
    {
        public CoordinatorMenu(User _user)
        {
            InitializeComponent();
            user = _user;
        }

        User user;

        private void RunnersButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new RunnerManagementPage(user));
        private void SponsorsButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new SponsorshipOverviewPage());
    }
}
