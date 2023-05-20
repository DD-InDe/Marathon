using Marathon.Entities;
using System;
using System.Collections;
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

            MarathonComboBox.SelectedIndex = 0;
            DistanceComboBox.SelectedIndex = 0;

            //загрузка в datagrid
            currentDataList = DB.entities.RegistrationEvent.Where(c=>c.RaceTime != 0 && c.RaceTime != null && c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId).ToList();
            currentDataList = currentDataList.OrderBy(c => c.RaceTime).ToList();
            ResultDataGrid.ItemsSource = currentDataList;

            //загрузка инфы в textblock
            int time = 0;
            foreach (var item in currentDataList)
                time += Convert.ToInt32(item.RaceTime);
            var k = TimeSpan.FromSeconds(time/currentDataList.Count);

            RunnerCount.Text = Convert.ToString(DB.entities.RegistrationEvent.Where(c=> c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId).ToList().Count);
            FinishCount.Text = Convert.ToString(currentDataList.Count);
            Time.Text = $"{k.Hours}h {k.Minutes}m {k.Seconds}s";
        }

        List<RegistrationEvent> currentDataList = new List<RegistrationEvent>();
        Entities.Marathon currentMarathon;
        EventType currentDistance;
        Gender currentGender;
        AgeCategory currentCategory;

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentGender == null && currentCategory == null)
            {
                currentDataList = DB.entities.RegistrationEvent.Where(c => c.RaceTime != 0 && c.RaceTime != null && c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId).ToList();
                RunnerCount.Text = Convert.ToString(DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId).ToList().Count);
            }
            if (currentGender != null && currentCategory == null)
            {
                currentDataList = DB.entities.RegistrationEvent.Where(c => c.RaceTime != 0 && c.RaceTime != null && c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId && c.Registration.Runner.Gender == currentGender.Gender1).ToList();
                RunnerCount.Text = Convert.ToString(DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId && c.Registration.Runner.Gender == currentGender.Gender1).ToList().Count);
            }
            if (currentGender == null && currentCategory != null)
            {
                currentDataList = DB.entities.RegistrationEvent.Where(c => c.RaceTime != 0 && c.RaceTime != null && c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId && c.Registration.Runner.AgeId == currentCategory.AgeCategoryId).ToList();
                RunnerCount.Text = Convert.ToString(DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId && c.Registration.Runner.AgeId == currentCategory.AgeCategoryId).ToList().Count);
            }
            if (currentGender != null && currentCategory != null)
            {
                currentDataList = DB.entities.RegistrationEvent.Where(c => c.RaceTime != 0 && c.RaceTime != null && c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId && c.Registration.Runner.Gender == currentGender.Gender1 && c.Registration.Runner.AgeId == currentCategory.AgeCategoryId).ToList();
                RunnerCount.Text = Convert.ToString(DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == currentMarathon.MarathonId && c.Event.EventTypeId == currentDistance.EventTypeId && c.Registration.Runner.Gender == currentGender.Gender1 && c.Registration.Runner.AgeId == currentCategory.AgeCategoryId).ToList().Count);
            }

            int time = 0;
            foreach (var item in currentDataList)
                time += Convert.ToInt32(item.RaceTime);
            var k = TimeSpan.FromSeconds(time / currentDataList.Count);

            FinishCount.Text = Convert.ToString(currentDataList.Count);
            Time.Text = $"{k.Hours}h {k.Minutes}m {k.Seconds}s";

            currentDataList = currentDataList.OrderBy(c => c.RaceTime).ToList();
            ResultDataGrid.ItemsSource = currentDataList;
        }

        private void MarathonComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => currentMarathon = MarathonComboBox.SelectedItem as Entities.Marathon;
        private void DistanceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => currentDistance = DistanceComboBox.SelectedItem as EventType;
        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => currentGender = GenderComboBox.SelectedItem as Gender;
        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => currentCategory = CategoryComboBox.SelectedItem as AgeCategory;

        private void ResultDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var f = ResultDataGrid.SelectedItem;
        }

        private void ResultDataGrid_LoadingRow(object sender, DataGridRowEventArgs e) => e.Row.Header = Convert.ToString(e.Row.GetIndex() + 1);
    }
}
