using Marathon.Entities;
using Marathon.Pages.RunnerPages;
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

namespace Marathon.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для UserAddPage.xaml
    /// </summary>
    public partial class UserAddPage : Page
    {
        public UserAddPage()
        {
            InitializeComponent();

            RoleComboBox.ItemsSource = DB.entities.Role.ToList();
            CountryComboBox.ItemsSource = DB.entities.Country.ToList();
            GenderComboBox.ItemsSource = DB.entities.Gender.ToList();
        }

        User user;
        Role role;
        Runner runner;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text != string.Empty && LastNameTextBox.Text != string.Empty && PasswordTextBox.Text != string.Empty)
            {
                UserAdd();

                if (role.RoleName == "Runner")
                {
                    if (CountryComboBox.SelectedItem != null && GenderComboBox.SelectedItem != null && BirthDatePicker.Text != string.Empty)
                    {
                        if (AppMain.AgeCheck((DateTime)BirthDatePicker.SelectedDate))
                        {
                            runner = new Runner();
                            runner.Email = EmailTextBox.Text;
                            runner.User = user;
                            runner.Country = CountryComboBox.SelectedItem as Country;
                            runner.Gender1 = GenderComboBox.SelectedItem as Gender;
                            runner.DateOfBirth = BirthDatePicker.SelectedDate;
                            runner.AgeCategory = AppMain.AgeCategoryCheck((DateTime)BirthDatePicker.SelectedDate);
                            runner.AgeId = runner.AgeCategory.AgeCategoryId;
                            DB.entities.Runner.Add(runner);
                        }
                    }
                    else
                        MessageBox.Show("Поля не могут быть пустыми!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                DB.entities.SaveChanges();
                MessageBox.Show("Пользователь создан!");
            }
            else
                MessageBox.Show("Поля не могут быть пустыми!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();

        private void UserAdd()
        {
            try
            {
                if (AppMain.EmailCheck(EmailTextBox.Text) && AppMain.PasswordCheck(PasswordTextBox.Text, PasswordRepeatTextBox.Password))
                {
                    user = new User();
                    user.Email = EmailTextBox.Text;
                    user.FirstName = FirstNameTextBox.Text;
                    user.LastName = LastNameTextBox.Text;
                    user.Password = PasswordTextBox.Text;
                    user.Role = RoleComboBox.SelectedItem as Role;

                    DB.entities.User.Add(user);
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так..", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            role = (Role)RoleComboBox.SelectedItem;
            if (role != null && role.RoleName == "Runner")
            {
                RunnersEditStackPanel.Visibility = Visibility.Visible;
                RunnersStackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                RunnersEditStackPanel.Visibility = Visibility.Collapsed;
                RunnersStackPanel.Visibility = Visibility.Collapsed;
            }
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = "0123456789.!@#$%&*()_-,`/'".IndexOf(e.Text) > 0;
    }
}