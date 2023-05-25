using Marathon.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            RunnerDataGrid.ItemsSource = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId).ToList();
           
        }

        RegistrationStatus regStatus;
        EventType distance;
        string selectedSort;
        Event eve = DB.entities.Event.ToList().Last();

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
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1 && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.FirstName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Фамилии":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1 && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.LastName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Почте":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1 && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.Email).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Статусу":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1 && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
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
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.FirstName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Фамилии":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.LastName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Почте":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.Email).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Статусу":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Registration.RegistrationStatus.RegistrationStatus1 == regStatus.RegistrationStatus1).ToList();
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
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.FirstName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Фамилии":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.LastName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Почте":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.Email).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Статусу":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId && c.Event.EventType.EventTypeName == distance.EventTypeName).ToList();
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
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.FirstName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Фамилии":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.User.LastName).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Почте":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId).ToList();
                        list = list.OrderBy(c => c.Registration.Runner.Email).ToList();
                        RunnerDataGrid.ItemsSource = list;
                        break;
                    case "Статусу":
                        list = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId).ToList();
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
            RunnerDataGrid.ItemsSource = DB.entities.RegistrationEvent.Where(c => c.EventId == eve.EventId).ToList();
        }

        private void CSVfileButton_Click(object sender, RoutedEventArgs e)
        {
            ForCSVDataGrid.ItemsSource  = RunnerDataGrid.ItemsSource;

            //RunnerDataGrid.SelectAllCells();
            //RunnerDataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            //ApplicationCommands.Copy.Execute(null, RunnerDataGrid);
            //String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            //String result = (string)Clipboard.GetData(DataFormats.Text);
            //RunnerDataGrid.UnselectAllCells();
            //System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"test.xls");
            //file1.WriteLine(result.Replace(',', ' '));
            //file1.Close();

            //MessageBox.Show(" Exporting DataGrid data to Excel file created.xls");

        }

        private void EmailListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new SelectedRunnerManagePage(((Button)e.Source).DataContext as RegistrationEvent));
    }
}
