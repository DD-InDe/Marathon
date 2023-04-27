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

namespace Marathon.Pages.RunnerPages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationConfirmationPage.xaml
    /// </summary>
    public partial class RegistrationConfirmationPage : Page
    {
        public RegistrationConfirmationPage(Runner _runner)
        {
            InitializeComponent();
            runner = _runner;
        }

        Runner runner;

        private void OkButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new RunnerMenu(runner));
    }
}
