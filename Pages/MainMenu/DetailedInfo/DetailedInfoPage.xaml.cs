using Marathon.Pages.MainMenu.DetailedInfo;
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
    /// Логика взаимодействия для DetailedInfoPage.xaml
    /// </summary>
    public partial class DetailedInfoPage : Page
    {
        public DetailedInfoPage()
        {
            InitializeComponent();
        }

        private void MarathonSkillsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LastResultsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BMI_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MarathonDurationButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new MarathonDurationPage());

        private void CharityListButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new CharityPage());

        private void BMR_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
