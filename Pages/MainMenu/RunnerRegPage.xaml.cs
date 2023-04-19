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

namespace Marathon.Pages.MainMenu
{
    /// <summary>
    /// Логика взаимодействия для RunnerRegPage.xaml
    /// </summary>
    public partial class RunnerRegPage : Page
    {
        public RunnerRegPage()
        {
            InitializeComponent();
            GenderComboBox.ItemsSource = DB.entities.Gender;
            CountryComboBox.ItemsSource = DB.entities.Country;
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text != null && PasswordTextBox.Text != null && PasswordRepeatTextBox.Text != null && FirstNameTextBox.Text != null
                && LastNameTextBox.Text != null && GenderComboBox.SelectedItem != null && CountryComboBox.SelectedItem != null)
            {

            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
