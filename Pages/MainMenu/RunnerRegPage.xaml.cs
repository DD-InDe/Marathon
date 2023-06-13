using Marathon.Entities;
using Marathon.Pages.RunnerPages;
using Marathon.Resources;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
            RunnerPhoto.DataContext = File.ReadAllBytes(@"C:\Users\deer\source\repos\Marathon\Resources\None.png");
        }

        Gender gender;
        Country country;

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text != null && PasswordTextBox.Text != null && PasswordRepeatTextBox.Text != null && FirstNameTextBox.Text != null
            && LastNameTextBox.Text != null && GenderComboBox.SelectedItem != null && CountryComboBox.SelectedItem != null && BirthDatePicker.SelectedDate != null)
            {
                if (AppMain.EmailCheck(EmailTextBox.Text) && AppMain.AgeCheck(Convert.ToDateTime(BirthDatePicker.SelectedDate)) && AppMain.PasswordCheck(PasswordTextBox.Text, PasswordRepeatTextBox.Password))
                {
                    User user = new User();
                    Runner runner = new Runner();

                    user.Email = EmailTextBox.Text;
                    user.Password = PasswordTextBox.Text;
                    user.FirstName = FirstNameTextBox.Text;
                    user.LastName = LastNameTextBox.Text;
                    user.RoleId = "R";
                    DB.entities.User.Add(user);

                    runner.Email = EmailTextBox.Text;
                    runner.User = user;
                    runner.Gender1 = gender;
                    runner.DateOfBirth = BirthDatePicker.SelectedDate;
                    runner.CountryCode = country.CountryCode;
                    runner.RunnerImage = (byte[])RunnerPhoto.DataContext;
                    runner.AgeCategory = AppMain.AgeCategoryCheck((DateTime)BirthDatePicker.SelectedDate);
                    DB.entities.Runner.Add(runner);

                    DB.entities.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались в системе!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new MatathonRegPage(runner));
                }
            }
            else
                MessageBox.Show("Поля не могут быть пустыми!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();


        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => gender = GenderComboBox.SelectedItem as Gender;
        private void CountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => country = CountryComboBox.SelectedItem as Country;

        private bool EmailCheck()
        {
            try { var addr = new System.Net.Mail.MailAddress(EmailTextBox.Text); }
            catch { return false; }
            return true;
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

        private void ExplorerButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Image | *.jpg; *.png"
            };

            if (fileDialog.ShowDialog() == true)
            {
                RunnerPhoto.DataContext = File.ReadAllBytes(fileDialog.FileName);
            }
        }
        private void WatermarkTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                FileInfo fileInfo = new FileInfo(ImagePathTextBox.Text.Trim('"'));
                if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png")
                    RunnerPhoto.DataContext = File.ReadAllBytes(ImagePathTextBox.Text.Trim('"'));
                else
                    MessageBox.Show("Файл не соответсвует расширению!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
