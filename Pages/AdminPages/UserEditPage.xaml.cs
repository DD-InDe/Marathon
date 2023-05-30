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

namespace Marathon.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {
        public UserEditPage(User _user)
        {
            InitializeComponent();
            user = _user;
            RoleComboBox.ItemsSource = DB.entities.Role.ToList();
            CountryComboBox.ItemsSource = DB.entities.Country.ToList();

            if (user.RoleId == "R")
            {
                runner = DB.entities.Runner.First(c => c.Email == user.Email);
                CountryComboBox.SelectedItem = runner.Country;
                BirthDatePicker.SelectedDate = runner.DateOfBirth;
            }
        }

        User user;
        Runner runner;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text != "" && LastNameTextBox.Text != "")
            {
                if (PasswordTextBox.Text != "")
                {
                    if (PasswordTextBox.Text == PasswordRepeatTextBox.Password)
                    {
                        if (AppMain.PasswordCheck(PasswordTextBox.Text))
                        {
                            user.Password = PasswordTextBox.Text;
                        }
                    }
                    else
                        MessageBox.Show("Пароли не совпадают", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (user.RoleId == "R")
                    {
                        if (AppMain.AgeCheck(Convert.ToDateTime(BirthDatePicker.SelectedDate)))
                        {
                            runner.Country = (Country)CountryComboBox.SelectedItem;
                            runner.DateOfBirth = BirthDatePicker.SelectedDate;
                            DB.entities.SaveChanges();
                            if (MessageBox.Show("Изменения сохранены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                                NavigationService.GoBack();
                        }
                    }
                    else
                    {
                        DB.entities.SaveChanges();
                        if (MessageBox.Show("Изменения сохранены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                            NavigationService.GoBack();
                    }
                }
            }
            else
                MessageBox.Show("Поля не могут быть пустыми!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();

        private void Page_Loaded(object sender, RoutedEventArgs e) => this.DataContext = user;

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
    }
}
