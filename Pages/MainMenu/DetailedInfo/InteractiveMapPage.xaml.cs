using Marathon.Entities;
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

namespace Marathon.Pages.MainMenu.DetailedInfo
{
    /// <summary>
    /// Логика взаимодействия для InteractiveMapPage.xaml
    /// </summary>
    public partial class InteractiveMapPage : Page
    {
        public InteractiveMapPage()
        {
            InitializeComponent();
            CheckPointStackPanel.Visibility = Visibility.Hidden;
            StartStackPanel.Visibility = Visibility.Hidden;
        }

        private void CheckPoint_Click(object sender, RoutedEventArgs e)
        {
            Button checkPointButton = (Button)sender;

            CheckPointStackPanel.Visibility = Visibility.Visible;
            StartStackPanel.Visibility = Visibility.Hidden;

            int numberButton = (int)Char.GetNumericValue(checkPointButton.Name[checkPointButton.Name.Length - 1]);
            CheckPointStackPanel.DataContext = DB.entities.CheckPointService.FirstOrDefault(c => c.CheckPointId == numberButton);
            ServiceListView.ItemsSource = DB.entities.CheckPointService.Where(c => c.CheckPointId == numberButton).ToList();

        }

        private void Start_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StartStackPanel.Visibility = Visibility.Visible;
            CheckPointStackPanel.Visibility = Visibility.Hidden;

            PointNameTextBlock.Text = "Линия старта";
            PointDescriptionTextBlock.Text = "Начало 42-км марафона / Конец всех марафонов";
        }
        private void Half_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StartStackPanel.Visibility = Visibility.Visible;
            CheckPointStackPanel.Visibility = Visibility.Hidden;

            PointNameTextBlock.Text = "Линия старта";
            PointDescriptionTextBlock.Text = "Начало 21-км марафона / Середина 42-км марафона";
        }
        private void End_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StartStackPanel.Visibility = Visibility.Visible;
            CheckPointStackPanel.Visibility = Visibility.Hidden;

            PointNameTextBlock.Text = "Линия старта";
            PointDescriptionTextBlock.Text = "Начало 5-км марафона";
        }
    }
}
