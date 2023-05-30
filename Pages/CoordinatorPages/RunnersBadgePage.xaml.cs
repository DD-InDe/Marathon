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

namespace Marathon.Pages.CoordinatorPages
{
    /// <summary>
    /// Логика взаимодействия для RunnersBadgePage.xaml
    /// </summary>
    public partial class RunnersBadgePage : Page
    {
        public RunnersBadgePage(RegistrationEvent regEvent)
        {
            InitializeComponent();

            Entities.Marathon marathon = DB.entities.Marathon.ToList().Last();
            List<Event> eventList = new List<Event>();
            foreach (var item in DB.entities.Event.Where(c => c.MarathonId == marathon.MarathonId).ToList())
            {
                if (DB.entities.RegistrationEvent.FirstOrDefault(c => c.RegistrationId == regEvent.RegistrationId && c.EventId == item.EventId) != null)
                    eventList.Add(item);
            }

            string raceTotal = "Участник: ";

            foreach (var item in eventList)
                raceTotal += item.EventType.EventTypeName + "; ";

            eventInfoTextBlock.Text = raceTotal;
            this.DataContext = regEvent;
        }
    }
}
