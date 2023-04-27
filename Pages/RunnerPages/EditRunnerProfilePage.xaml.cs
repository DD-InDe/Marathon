using Marathon.Entities;
using Marathon.Resources;
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
    /// Логика взаимодействия для EditRunnerProfilePage.xaml
    /// </summary>
    public partial class EditRunnerProfilePage : Page
    {
        public EditRunnerProfilePage(Runner _runner)
        {
            InitializeComponent();
            runner = _runner;
            GenderComboBox.ItemsSource = DB.entities.Gender.ToList();
            CountryComboBox.ItemsSource = DB.entities.Country.ToList();
        }

        Runner runner;
        Gender gender;
        Country country;

        private void Page_Loaded(object sender, RoutedEventArgs e) => this.DataContext = runner;

        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => gender = GenderComboBox.SelectedItem as Gender;

        private void CountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => country = CountryComboBox.SelectedItem as Country;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text != null && LastNameTextBox.Text != null)
            {
                if (PasswordTextBox.Password != null && PasswordRepeatTextBox.Password == null) MessageBox.Show("Повторите свой пароль!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    if (PasswordTextBox.Password != PasswordRepeatTextBox.Password) MessageBox.Show("Пароли не совпадают!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    DB.entities.SaveChanges();
            }
            else
                DB.entities.SaveChanges();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();


        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VisibleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VisPasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CollapsedButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExplorerButton_Click(object sender, RoutedEventArgs e)
        {
            AppMain.MD();
        }
    }
}
