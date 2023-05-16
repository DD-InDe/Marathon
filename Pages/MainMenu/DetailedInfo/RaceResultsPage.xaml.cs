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

namespace Marathon.Pages.MainMenu.DetailedInfo
{
    /// <summary>
    /// Логика взаимодействия для RaceResultsPage.xaml
    /// </summary>
    public partial class RaceResultsPage : Page
    {
        public RaceResultsPage()
        {
            InitializeComponent();
            //загрузка в combobox
            MarathonComboBox.ItemsSource = DB.entities.Marathon.ToList();
            DistanceComboBox.ItemsSource = DB.entities.EventType.ToList();
            GenderComboBox.ItemsSource = DB.entities.Gender.ToList();

            //загрузка в datagrid
            ResultDataGrid.ItemsSource = DB.entities.RegistrationEvent.ToList();
        }

        Registration regEvent;

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MarathonComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DistanceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
