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

            CountryComboBox.Visibility = Visibility.Collapsed;
            BirthDatePicker.Visibility = Visibility.Collapsed;
            CountryTextBlock.Visibility = Visibility.Collapsed;
            BirthTextBlock.Visibility = Visibility.Collapsed;
        }

        Role role;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Text == PasswordRepeatTextBox.Password && AppMain.PasswordCheck(PasswordTextBox.Text) && EmailCheck() && FirstNameTextBox.Text != string.Empty && LastNameTextBox.Text != string.Empty)
            {
                try
                {
                    switch (((Role)RoleComboBox.SelectedItem).RoleName)
                    {
                        case "Runner":
                            if (AppMain.AgeCheck(Convert.ToDateTime(BirthDatePicker.SelectedDate)))
                            {
                                UserAdd();
                                Runner runner = new Runner();

                                runner.Email = EmailTextBox.Text;
                                runner.DateOfBirth = BirthDatePicker.SelectedDate;
                                runner.Country = (Country)CountryComboBox.SelectedItem;
                                DB.entities.Runner.Add(runner);

                                DB.entities.SaveChanges();
                                MessageBox.Show("Вы успешно зарегистрировали пользователя!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                                NavigationService.GoBack();
                            }
                            break;

                        case "Coordinator":
                            UserAdd();

                            DB.entities.SaveChanges();
                            MessageBox.Show("Вы успешно зарегистрировали пользователя!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.GoBack();
                            break;

                        case "Administrator":
                            UserAdd();

                            DB.entities.SaveChanges();
                            MessageBox.Show("Вы успешно зарегистрировали пользователя!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.GoBack();
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Введены неккоректные данные!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void UserAdd()
        {
            User user;
            try
            {
                user = new User();

                user.Email = EmailTextBox.Text;
                user.Password = PasswordTextBox.Text;
                user.FirstName = FirstNameTextBox.Text;
                user.LastName = LastNameTextBox.Text;
                user.RoleId = ((Role)RoleComboBox.SelectedItem).RoleId;
                DB.entities.User.Add(user);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Role)RoleComboBox.SelectedItem).RoleName == "Runner")
            {
                CountryComboBox.Visibility = Visibility.Visible;
                BirthDatePicker.Visibility = Visibility.Visible;
                CountryTextBlock.Visibility = Visibility.Visible;
                BirthTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                CountryComboBox.Visibility = Visibility.Collapsed;
                BirthDatePicker.Visibility = Visibility.Collapsed;
                CountryTextBlock.Visibility = Visibility.Collapsed;
                BirthTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private bool EmailCheck()
        {
            try { var addr = new System.Net.Mail.MailAddress(EmailTextBox.Text); }
            catch
            {
                MessageBox.Show("Некорректный адрес электронный почты!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
