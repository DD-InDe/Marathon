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
            password = user.Password;

            RoleComboBox.ItemsSource = DB.entities.Role.ToList();
            CountryComboBox.ItemsSource = DB.entities.Country.ToList();
            GenderComboBox.ItemsSource = DB.entities.Gender.ToList();

            runner = DB.entities.Runner.FirstOrDefault(c => c.Email == user.Email);
        }

        User user;
        Runner runner;
        string password;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text != string.Empty && LastNameTextBox.Text != string.Empty)
            {
                if (user.Role.RoleName == "Runner")
                {
                    if (AppMain.AgeCheck((DateTime)BirthDatePicker.SelectedDate))
                    {
                        if (runner == null)
                        {
                            runner = new Runner();
                            DB.entities.Runner.Add(runner);
                        }
                        runner.AgeCategory = AppMain.AgeCategoryCheck((DateTime)BirthDatePicker.SelectedDate);
                    }
                    else
                        return;
                }
                DB.entities.SaveChanges();
                if (MessageBox.Show("Изменения успешно сохранены! \n Перейти назад?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    NavigationService.GoBack();
            }
            else
                MessageBox.Show("Поля не могут быть пустыми!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void SavePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (AppMain.PasswordCheck(PasswordTextBox.Text) && AppMain.PasswordSameCheck(PasswordTextBox.Text, PasswordRepeatTextBox.Password))
            {
                user.Password = PasswordTextBox.Text;
                DB.entities.SaveChanges();
                if (MessageBox.Show("Пароль успешно сохранен! \n Перейти назад?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    NavigationService.GoBack();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserEditStackPanel.DataContext = user;
            RunnerEditStackPanel.DataContext = runner;
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Role)RoleComboBox.SelectedItem).RoleName == "Runner")
            {
                RunnerStackPanel.Visibility = Visibility.Visible;
                RunnerEditStackPanel.Visibility = Visibility.Visible;

            }
            else
            {
                RunnerStackPanel.Visibility = Visibility.Visible;
                RunnerEditStackPanel.Visibility = Visibility.Visible;
            }
        }

    }
}
