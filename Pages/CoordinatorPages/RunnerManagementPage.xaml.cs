using Marathon.AllWindow;
using Marathon.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Marathon.Pages.CoordinatorPages
{
    /// <summary>
    /// Логика взаимодействия для RunnerManagementPage.xaml
    /// </summary>
    public partial class RunnerManagementPage : Page
    {
        DataGrid dg = new DataGrid();
        public RunnerManagementPage(User user)
        {
            InitializeComponent();

            List<RegistrationStatus> registrationStatusList = new List<RegistrationStatus>();
            regStatus = new RegistrationStatus() { RegistrationStatus1 = "Все" };
            registrationStatusList.Add(regStatus);
            registrationStatusList.AddRange(DB.entities.RegistrationStatus);
            StatusComboBox.ItemsSource = registrationStatusList;
            StatusComboBox.SelectedIndex = 0;

            List<EventType> eventTypeList = new List<EventType>();
            distance = new EventType { EventTypeName = "Все" };
            eventTypeList.Add(distance);
            eventTypeList.AddRange(DB.entities.EventType);
            DistanceComboBox.ItemsSource = eventTypeList;
            DistanceComboBox.SelectedIndex = 0;

            List<string> sortList = new List<string>() { "Имени", "Фамилии", "Почте", "Статусу" };
            SortComboBox.ItemsSource = sortList;
            SortComboBox.SelectedIndex = 0;

            RunnerDataGrid.ItemsSource = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId).ToList();

        }

        RegistrationStatus regStatus;
        EventType distance;
        string selectedSort;
        Entities.Marathon marathon = DB.entities.Marathon.ToList().Last();

        private void StatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => regStatus = (RegistrationStatus)StatusComboBox.SelectedItem;
        private void DistanceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => distance = (EventType)DistanceComboBox.SelectedItem;
        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => selectedSort = SortComboBox.SelectedItem.ToString();

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            List<RegistrationEvent> list = new List<RegistrationEvent>();
            if (regStatus.RegistrationStatus1 != "Все" && distance.EventTypeName != "Все")
            {
                switch (selectedSort)
                {
                    case "Имени":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1 && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.FirstName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Фамилии":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1 && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.LastName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Почте":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1 && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.Email).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Статусу":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1 && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.RegistrationStatus).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                }
            }
            else if (regStatus.RegistrationStatus1 != "Все" && distance.EventTypeName == "Все")
            {
                switch (selectedSort)
                {
                    case "Имени":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.FirstName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Фамилии":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.LastName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Почте":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.Email).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Статусу":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1).ToList();
                        list = list.OrderBy(c => c.Registration.RegistrationStatus).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                }
            }
            else if (regStatus.RegistrationStatus1 == "Все" && distance.EventTypeName != "Все")
            {
                switch (selectedSort)
                {
                    case "Имени":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.FirstName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Фамилии":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.LastName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Почте":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.Email).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Статусу":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.RegistrationStatus).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                }
            }
            else
            {
                switch (selectedSort)
                {
                    case "Имени":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.FirstName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Фамилии":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.LastName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Почте":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.Email).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Статусу":
                        list = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId).ToList();
                        list = list.OrderBy(c => c.Registration.RegistrationStatus).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                }
            }
        }
        private void DropButton_Click(object sender, RoutedEventArgs e)
        {
            StatusComboBox.SelectedIndex = 0;
            DistanceComboBox.SelectedIndex = 0;
            SortComboBox.SelectedIndex = 0;
            RunnerDataGrid.ItemsSource = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId).ToList();
        }

        private void CSVfileButton_Click(object sender, RoutedEventArgs e)
        {
            ForCSVDataGrid.ItemsSource = RunnerDataGrid.ItemsSource;

            ForCSVDataGrid.SelectAllCells();
            ForCSVDataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, ForCSVDataGrid);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            ForCSVDataGrid.UnselectAllCells();


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                System.IO.StreamWriter file1 = new System.IO.StreamWriter($@"{saveFileDialog.FileName}.csv");
                file1.WriteLine(result.Replace(',', ' '));
                file1.Close();

                MessageBox.Show("Таблица экспортирована в csv-файл");
            }

        }

        private void EmailListButton_Click(object sender, RoutedEventArgs e)
        {
            List<RegistrationEvent> runnersList = (List<RegistrationEvent>)RunnerDataGrid.ItemsSource;
            InfoWindow infoWindow = new InfoWindow(6,regEventList:runnersList);
            infoWindow.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new SelectedRunnerManagePage(((Button)e.Source).DataContext as RegistrationEvent));
    }
}
