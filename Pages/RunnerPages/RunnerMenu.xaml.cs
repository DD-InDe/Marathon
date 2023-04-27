using Marathon.AllWindow;
using Marathon.Entities;
using Marathon.Pages.MainMenu;
using Marathon.Pages.RunnerPages;
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
    /// Логика взаимодействия для RunnerMenu.xaml
    /// </summary>
    public partial class RunnerMenu : Page
    {
        public RunnerMenu(Runner _runner)
        {
            InitializeComponent();
            runner = _runner;
        }

        Runner runner;

        private void ContactsButton_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow(2);
            infoWindow.ShowDialog();
        }
        private void ProfileEditButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new EditRunnerProfilePage(runner));
        private void RegButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new MatathonRegPage(runner));
    }
}
