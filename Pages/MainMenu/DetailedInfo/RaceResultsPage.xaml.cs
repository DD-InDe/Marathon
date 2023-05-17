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
            CategoryComboBox.ItemsSource = DB.entities.AgeCategory.ToList();

            //загрузка в datagrid
            MarathonComboBox.SelectedIndex = 0;
            DistanceComboBox.SelectedIndex = 0;
            GenderComboBox.SelectedIndex = 0;
            CategoryComboBox.SelectedIndex = 0;

            currentMarathon = (Entities.Marathon)MarathonComboBox.SelectedItem;
            currentDistance = (EventType)DistanceComboBox.SelectedItem;
            currentGender = (Gender)GenderComboBox.SelectedItem;
            currentCategory = (AgeCategory)CategoryComboBox.SelectedItem;

            ResultDataGrid.ItemsSource = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId
                                         && c.Registration.Runner.Gender1.Gender1 == currentGender.Gender1 && c.Registration.Runner.AgeCategory.AgeCategoryId == currentCategory.AgeCategoryId).ToList();
        }

        Registration regEvent;
        Entities.Marathon currentMarathon;
        EventType currentDistance;
        Gender currentGender;
        AgeCategory currentCategory;

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ResultDataGrid.ItemsSource = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId
                                         && c.Registration.Runner.Gender1.Gender1 == currentGender.Gender1 && c.Registration.Runner.AgeCategory.AgeCategoryId == currentCategory.AgeCategoryId).ToList();
        }

        private void MarathonComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => currentMarathon = MarathonComboBox.SelectedItem as Entities.Marathon;
        private void DistanceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => currentDistance = DistanceComboBox.SelectedItem as EventType;
        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => currentGender = GenderComboBox.SelectedItem as Gender;
        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => currentCategory = CategoryComboBox.SelectedItem as AgeCategory;
    }
}
