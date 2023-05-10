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
    /// Логика взаимодействия для MarathonDurationPage.xaml
    /// </summary>
    public partial class MarathonDurationPage : Page
    {
        public MarathonDurationPage()
        {
            InitializeComponent();

            SpeedList.ItemsSource = DB.entities.SpeedObjects.ToList();
            DistantionList.ItemsSource = DB.entities.DistanceObjects.ToList();
        }

        SpeedObjects speedObjects;
        DistanceObjects distanceObjects;

        private void SpeedList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            speedObjects = SpeedList.SelectedItem as SpeedObjects;
            InfoStackPanel.DataContext = speedObjects;
        }

        private void DistantionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            distanceObjects = DistantionList.SelectedItem as DistanceObjects;
            InfoStackPanel.DataContext = distanceObjects;
        }
    }
}
