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

namespace Marathon.Pages.RunnerPages
{
    /// <summary>
    /// Логика взаимодействия для MySponsorshipPage.xaml
    /// </summary>
    public partial class MySponsorshipPage : Page
    {
        public MySponsorshipPage(Registration registration)
        {
            InitializeComponent();

            CharityStackPanel.DataContext = registration.Charity;
            SponsorDateGrid.ItemsSource = DB.entities.Sponsorship.Where(c => c.Registration.RegistrationId == registration.RegistrationId).ToList();
        }
    }
}
