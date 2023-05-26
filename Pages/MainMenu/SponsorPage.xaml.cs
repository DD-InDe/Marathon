using Marathon.AllWindow;
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

namespace Marathon.Pages
{
    /// <summary>
    /// Логика взаимодействия для SponsorPage.xaml
    /// </summary>
    public partial class SponsorPage : Page
    {
        public SponsorPage()
        {
            InitializeComponent();

            //List<RegistrationEvent> runnersList = new List<RegistrationEvent>();
            //runnersList.AddRange(DB.entities.RegistrationEvent.Where(c => c.EventId == DB.entities.Event.Where(k => k.EventTypeId == "FM").ToList().Last().EventId).ToList());
            //runnersList.AddRange(DB.entities.RegistrationEvent.Where(c => c.EventId == DB.entities.Event.Where(k => k.EventTypeId == "FR").ToList().Last().EventId).ToList());
            //runnersList.AddRange(DB.entities.RegistrationEvent.Where(c => c.EventId == DB.entities.Event.Where(k => k.EventTypeId == "HM").ToList().Last().EventId).ToList());

            Entities.Marathon marathon = DB.entities.Marathon.ToList().Last();
            List<RegistrationEvent> runnersList = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId).ToList();

            RunnerComboBox.ItemsSource = runnersList;

            SumTextBox.Text = "50";
            SumTextBlock.Text = '$' + SumTextBox.Text;
        }

        int sum;
        RegistrationEvent regEvent;

        private void RunnerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            regEvent = RunnerComboBox.SelectedItem as RegistrationEvent;
            CharityNameTextBlock.Text = regEvent.Registration.Charity.CharityName;
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e) => SumTextBox.Text = Convert.ToString(Convert.ToInt32(SumTextBox.Text) + 10);

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (sum >= 10)
                SumTextBox.Text = Convert.ToString(Convert.ToInt32(SumTextBox.Text) - 10);
        }

        private void SumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SumTextBox.Text == "") sum = 0;
            else { sum = Convert.ToInt32(SumTextBox.Text); }
            SumTextBlock.Text = '$' + Convert.ToString(sum);
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
            if (SumTextBox.Text == "") SumTextBox.Text = "0";
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (RunnerComboBox.SelectedItem != null)
            {
                var f = RunnerComboBox.SelectedItem as RegistrationEvent;
                InfoWindow infoWindow = new InfoWindow(1, f);
                infoWindow.ShowDialog();
            }
            else
                MessageBox.Show("Сначала выберите бегуна, которого хотите спонсировать.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(NameOnCard.Text) || string.IsNullOrEmpty(CardNumber.Text) ||
                 string.IsNullOrEmpty(CardValidity.Text) || string.IsNullOrEmpty(CVC.Text) || string.IsNullOrEmpty(SumTextBox.Text))
            {
                MessageBox.Show("Введите данные!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (CardCheck())
                {
                    Sponsorship addSponsorship = new Sponsorship();
                    addSponsorship.Amount = Convert.ToDecimal(SumTextBox.Text);
                    addSponsorship.SponsorName = NameTextBox.Text;
                    addSponsorship.Registration = regEvent.Registration;
                    DB.entities.Sponsorship.Add(addSponsorship);
                    DB.entities.SaveChanges();
                    NavigationService.Navigate(new SponsorThanksPage(regEvent, addSponsorship));
                }
            }
        }

        public bool CardCheck()
        {
            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(CardValidity.Text, "MM yyyy", null);
            }
            catch
            {
                MessageBox.Show("В поле ''Срок Действия'' введены неккоректные данные!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (dateTime <= DateTime.Now)
            {
                MessageBox.Show("Карта недействительна!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
                return true;
        }
    }
}
