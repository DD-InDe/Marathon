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

            Entities.Marathon marathon = DB.entities.Marathon.ToList().Last();
            List<Event> eventList = DB.entities.Event.Where(c => c.MarathonId == marathon.MarathonId).ToList();

            RegistrationEvent g = new RegistrationEvent();
            foreach (Event item in eventList)
            {
                g = DB.entities.RegistrationEvent.FirstOrDefault(c => c.EventId == item.EventId && c.RegistrationId == registration.RegistrationId);
                if (g != null)
                    break;
            }
            List<Sponsorship> sponsorList = DB.entities.Sponsorship.Where(c => c.RegistrationId == g.RegistrationId).ToList();

            int sum = 0;

            foreach (var item in sponsorList)
                sum += Convert.ToInt32(item.Amount);

            SponsorDateGrid.ItemsSource = sponsorList;
            SumTextBlock.Text = "Итого: " + sum.ToString();

            if (sponsorList.Count == 0)
            {
                SumTextBlock.Visibility = Visibility.Collapsed;
                SponsorDateGrid.Visibility = Visibility.Collapsed;
            }
            else
                InfoTextBlock.Visibility = Visibility.Collapsed;
        }
    }
}
