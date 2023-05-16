using Marathon.Entities;
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

            if (runner.RunnerImage == null)
                RunnerPhoto.DataContext = File.ReadAllBytes(@"photo\None.png");
            else
                RunnerPhoto.DataContext = runner.RunnerImage;

            GenderComboBox.ItemsSource = DB.entities.Gender.ToList();
            CountryComboBox.ItemsSource = DB.entities.Country.ToList();
        }

        Runner runner;

        private void Page_Loaded(object sender, RoutedEventArgs e) => this.DataContext = runner;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            /*проверка на пустые поля*/
            if (FirstNameTextBox.Text != null && LastNameTextBox.Text != null && BirthDatePicker.SelectedDate != null)
            {
                /*проверка возраста*/
                if (AppMain.AgeCheck(Convert.ToDateTime(BirthDatePicker.SelectedDate)))
                {
                    /* проверка пароля
                     * 
                       без пароля*/
                    if (PasswordTextBox.Password == "")
                    {
                        runner.RunnerImage = runner.RunnerImage = (byte[])RunnerPhoto.DataContext;
                        DB.entities.SaveChanges();
                    }
                    /*с паролем*/
                    else
                    {
                        if (PasswordTextBox.Password == PasswordRepeatTextBox.Password)
                        {
                            if (AppMain.PasswordCheck(PasswordTextBox.Password))
                            {
                                runner.User.Password = PasswordTextBox.Password;
                                runner.RunnerImage = (byte[])RunnerPhoto.DataContext;
                                DB.entities.SaveChanges();
                                MessageBox.Show("Данные успешно сохранены!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                                NavigationService.GoBack();
                            }
                        }
                        else MessageBox.Show("Пароли не совпадают!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else MessageBox.Show("Поля не могут быть пустыми!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();

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
                ImagePathTextBox.Text = fileDialog.FileName;
            }
        }
    }
}
