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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            User user = DB.entities.User.FirstOrDefault(c => c.Email == EmailTextBox.Text && c.Password == PasswordTextBox.Text);
            if (user == null) MessageBox.Show("Неверно введены данные!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                switch (Convert.ToChar(user.RoleId))
                {
                    case 'A': /*админ*/
                        NavigationService.Navigate(new AdminMenu(user));
                        break;

                    case 'C': /*координатор*/
                        NavigationService.Navigate(new CoordinatorMenu(user));
                        break;

                    case 'R': /*бегун*/
                        Runner runner = DB.entities.Runner.First(c => c.Email == user.Email);
                        NavigationService.Navigate(new RunnerMenu(runner));
                        break;
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window g = Window.GetWindow(this);
           
            g.Hide();
            MainWindow mainWindow = new MainWindow();

            mainWindow.ShowDialog();
            g.Close();
        }
    }
}
