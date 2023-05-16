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

namespace Marathon.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для VolunteerPage.xaml
    /// </summary>
    public partial class VolunteerPage : Page
    {
        public VolunteerPage()
        {
            InitializeComponent();
            VolunteerDataGrid.ItemsSource = DB.entities.Volunteer.ToList();
            CountTextBlock.Text = Convert.ToString(DB.entities.Volunteer.Count());
            SortComboBox.ItemsSource = AddList();
        }

        public List<string> AddList()
        {
            List<string> soryByList = new List<string>
            {
                "Фамилии",
                "Имени",
                "Стране",
                "Полу"
            };

            return soryByList;
        }
        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sort = Convert.ToString(SortComboBox.SelectedItem);
            switch (sort)
            {
                case "Фамилии":
                    VolunteerDataGrid.ItemsSource = DB.entities.Volunteer.OrderBy(c => c.FirstName).ToList();
                    break;
                case "Имени":
                    VolunteerDataGrid.ItemsSource = DB.entities.Volunteer.OrderBy(c => c.LastName).ToList();
                    break;
                case "Стране":
                    VolunteerDataGrid.ItemsSource = DB.entities.Volunteer.OrderBy(c => c.Country.CountryName).ToList();
                    break;
                case "Полу":
                    VolunteerDataGrid.ItemsSource = DB.entities.Volunteer.OrderBy(c => c.Gender).ToList();
                    break;
            }
        }
        private void VolunteerLoadButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new VolunteerImportPage());
    }
}
