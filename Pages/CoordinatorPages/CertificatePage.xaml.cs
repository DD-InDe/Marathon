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
    /// Логика взаимодействия для CertificatePage.xaml
    /// </summary>
    public partial class CertificatePage : Page
    {
        List<RegistrationEvent> regEventList;

        public CertificatePage(List<RegistrationEvent> _regEventList)
        {
            InitializeComponent();

            regEventList = _regEventList;
            List<EventType> eventTypeList = new List<EventType>();
            foreach (var item in regEventList)
            {
                if (item.RaceTime != null || item.RaceTime != 0)
                    eventTypeList.Add(item.Event.EventType);
            }

            EventComboBox.ItemsSource = eventTypeList;
            EventComboBox.SelectedIndex = 0;

            this.DataContext = regEventList.Where(c => c.Event.EventTypeId == ((EventType)EventComboBox.SelectedItem).EventTypeId);
        }

        private void WatermarkComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => this.DataContext = regEventList.First(c => c.Event.EventTypeId == ((EventType)EventComboBox.SelectedItem).EventTypeId);

    }
}
