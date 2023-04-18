using Marathon.Entities;
using Marathon.Pages.MainMenu;
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
using System.Windows.Shapes;

namespace Marathon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DateTextBlock.Text = DateTime.Now.ToLongDateString();
            RefreshButtonTimer();
        }

        private void RunnerButton_Click(object sender, RoutedEventArgs e)
        {
            FirstWindow firstWindow = new FirstWindow(1);
            this.Close();
            firstWindow.ShowDialog();
        }
        private void SponsorButton_Click(object sender, RoutedEventArgs e)
        {
            FirstWindow firstWindow = new FirstWindow(2);
            this.Close();
            firstWindow.ShowDialog();
        }
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            FirstWindow firstWindow = new FirstWindow(3);
            this.Close();
            firstWindow.ShowDialog();
        }

        private async void RefreshButtonTimer()
        {
            var s = DB.entities.Event.ToList().Last();
            TimeTextBlock.Text = ((s.StartDateTime - DateTime.Now).Value.Days + " дней " + (s.StartDateTime - DateTime.Now).Value.Hours + " часов " + (s.StartDateTime - DateTime.Now).Value.Minutes + " минут").ToString();
            await Task.Delay(1000);
            RefreshButtonTimer();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            FirstWindow firstWindow = new FirstWindow(4);
            this.Close();
            firstWindow.ShowDialog();
        }
    }
}
