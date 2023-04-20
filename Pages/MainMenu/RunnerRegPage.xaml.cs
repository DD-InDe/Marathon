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

            GenderComboBox.ItemsSource = DB.entities.Gender.ToList();
            CountryComboBox.ItemsSource = DB.entities.Country.ToList();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text != null && PasswordTextBox.Text != null && PasswordRepeatTextBox.Text != null && FirstNameTextBox.Text != null
            && LastNameTextBox.Text != null && GenderComboBox.SelectedItem != null && CountryComboBox.SelectedItem != null && DateTextBox.Text != null)
            {
                if (EmailCheck(EmailTextBox.Text))
                {
                    if (DB.entities.User.FirstOrDefault(c => c.Email == EmailTextBox.Text) == null)
                    {
                        if (PasswordTextBox.Text.Length > 6 && PasswordCharCheck(PasswordTextBox.Text) && PasswordNumCheck(PasswordTextBox.Text) && PasswordSymCheck(PasswordTextBox.Text))
                        {
                            User user = new User();
                            Runner runner = new Runner();

                            user.Email = EmailTextBox.Text;
                            user.Password = PasswordTextBox.Text;
                            user.FirstName = FirstNameTextBox.Text;
                            user.LastName = LastNameTextBox.Text;
                            user.RoleId = "R";

                            runner.Email = user.Email;
                            runner.Gender1 = gender;
                            runner.DateOfBirth = Convert.ToDateTime(DateTextBox.Text);
                            runner.CountryCode = country.CountryCode;

                            DB.entities.SaveChanges();
                        }
                    }
                }
            }
        }

        Gender gender;
        Country country;

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => gender = GenderComboBox.SelectedItem as Gender;

        private void CountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => country = CountryComboBox.SelectedItem as Country;

        private bool EmailCheck(string email)
        {
            try { var addr = new System.Net.Mail.MailAddress(EmailTextBox.Text); }
            catch { return false; }
            return true;
        }
        private bool PasswordCharCheck(string password)
        {
            for (int i = 0; i < password.Length; i++)
                if (char.IsUpper(password[i])) return true;
            return false;
        }
        private bool PasswordNumCheck(string password)
        {
            for (int i = 0; i < password.Length; i++)
                if (char.IsDigit(password[i])) return true;
            return false;
        }
        private bool PasswordSymCheck(string password)
        {
            if (password.Contains("!") || password.Contains("@") || password.Contains("#") ||
                password.Contains("$") || password.Contains("%") || password.Contains("^"))
                return true;
            return false;
        }

        private void VisibleButton_Click(object sender, RoutedEventArgs e)
        {
            VisibleStackPanel.Visibility = Visibility.Collapsed;
            HiddenStackPanel.Visibility = Visibility.Visible;
        }

        private void CollapsedButton_Click(object sender, RoutedEventArgs e)
        {
            VisibleStackPanel.Visibility = Visibility.Visible;
            HiddenStackPanel.Visibility = Visibility.Collapsed;
        }

        private void VisPasswordTextBox_TextChanged(object sender, TextChangedEventArgs e) => PasswordTextBox.Password = VisPasswordTextBox.Text;
        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e) => VisPasswordTextBox.Text = PasswordTextBox.Password;
    }
}
