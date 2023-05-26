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
        Entities.Marathon marathon = DB.entities.Marathon.ToList().Last();

        private void ContactsButton_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow(2);
            infoWindow.ShowDialog();
        }
        private void ProfileEditButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new EditRunnerProfilePage(runner));
        private void RegButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new MatathonRegPage(runner));
        private void ResultButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new MyRaceResultsPage(runner));
        private void SponsorButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationEvent regEvent = DB.entities.RegistrationEvent.FirstOrDefault(c => c.Registration.RunnerId == runner.RunnerId && c.Event.MarathonId == marathon.MarathonId);
            Registration registration = DB.entities.Registration.Where(c => c.RunnerId == runner.RunnerId).ToList().Last();

            if (regEvent == null)
            {
                MessageBoxResult result = MessageBox.Show( "Вы не зарегистрированы на предстоящий марафон! \n Хотите зарегистрироваться?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    NavigationService.Navigate(new MatathonRegPage(runner));
            }
            else
                NavigationService.Navigate(new MySponsorshipPage(registration));
        }
    }
}
