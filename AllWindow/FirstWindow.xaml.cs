using Marathon.Entities;
using Marathon.Pages;
using Marathon.Pages.MainMenu;
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
using System.Windows.Shapes;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        public FirstWindow(int page)
        {
            InitializeComponent();

            switch (page)
            {
                case 1:
                    //mainFrame.Navigate(new RunnerCheckPage());
                    mainFrame.Navigate(new MatathonRegPage(null));
                    break;
                case 2:
                    mainFrame.Navigate(new SponsorPage());
                    break;
                case 3:
                    mainFrame.Navigate(new DetailedInfoPage());
                    break;
                case 4:
                    mainFrame.Navigate(new LoginPage());
                    break;
            }

            RefreshTimer();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.CanGoBack)
            {
                mainFrame.GoBack();
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.ShowDialog();
            }
        }

        private async void RefreshTimer()
        {
            var b = DB.entities.Event.ToList().Last();
            var c = b.StartDateTime - DateTime.Now;

            TimeTextBlock.Text = c.Value.Days + " дней " + c.Value.Hours + " часов " + c.Value.Minutes + " минут";
            await Task.Delay(1000);
            RefreshTimer();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
