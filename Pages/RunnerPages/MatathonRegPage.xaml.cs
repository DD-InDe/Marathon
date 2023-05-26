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

namespace Marathon.Pages.RunnerPages
{
    /// <summary>
    /// Логика взаимодействия для MatathonRegPage.xaml
    /// </summary>
    public partial class MatathonRegPage : Page
    {
        int priceMatathon = 0;
        int selectedBoxPrice = 0;
        char raceKitId = ' ';

        public MatathonRegPage(Runner runner)
        {
            InitializeComponent();
            CharityComboBox.ItemsSource = DB.entities.Charity.ToList();
            _runner = runner;

            SumTextBlock.Text = "$0";
        }

        Runner _runner;
        Charity charity;
        Event _event;
        List<Event> eventList = new List<Event>();
        Entities.Marathon marathon = DB.entities.Marathon.ToList().Last();

        /* CheckBoxes */
        private void BigCheckBox_Click(object sender, RoutedEventArgs e)
        {
            _event = DB.entities.Event.Where(c => c.EventType.EventTypeId == "FM").ToList().Last();

            if (BigCheckBox.IsChecked == true)
            {
                priceMatathon += 145;
                eventList.Add(_event);
            }
            else
            {
                priceMatathon -= 145;
                eventList.Remove(_event);
            }
            SumTextBlock.Text = Convert.ToString(priceMatathon);
        }
        private void MediumCheckBox_Click(object sender, RoutedEventArgs e)
        {
            _event = DB.entities.Event.Where(c => c.EventType.EventTypeId == "HM").ToList().Last();

            if (MediumCheckBox.IsChecked == true)
            {
                priceMatathon += 75;
                eventList.Add(_event);
            }
            else
            {
                priceMatathon -= 75;
                eventList.Remove(_event);
            }
            SumTextBlock.Text = Convert.ToString(priceMatathon);
        }
        private void SmallCheckBox_Click(object sender, RoutedEventArgs e)
        {
            _event = DB.entities.Event.Where(c => c.EventType.EventTypeId == "FR").ToList().Last();

            if (SmallCheckBox.IsChecked == true)
            {
                priceMatathon += 20;
                eventList.Add(_event);
            }
            else
            {
                priceMatathon -= 20;
                eventList.Remove(_event);
            }
            SumTextBlock.Text = Convert.ToString(priceMatathon);
        }
        /* RadioButtons */
        private void VarARadioButton_Click(object sender, RoutedEventArgs e)
        {
            priceMatathon -= selectedBoxPrice;
            selectedBoxPrice = 0;
            raceKitId = 'A';
            SumTextBlock.Text = Convert.ToString(priceMatathon);
        }
        private void VarBRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            priceMatathon -= selectedBoxPrice;
            selectedBoxPrice = 20;
            priceMatathon += selectedBoxPrice;
            raceKitId = 'B';
            SumTextBlock.Text = Convert.ToString(priceMatathon);
        }
        private void VarCRadionButton_Checked(object sender, RoutedEventArgs e)
        {
            priceMatathon -= selectedBoxPrice;
            selectedBoxPrice = 45;
            priceMatathon += selectedBoxPrice;
            raceKitId = 'C';
            SumTextBlock.Text = Convert.ToString(priceMatathon);
        }
        /* Charity select and info */
        private void CharityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => charity = CharityComboBox.SelectedItem as Charity;
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharityComboBox.SelectedItem != null)
            {
                InfoWindow infoWindow = new InfoWindow(3, null, CharityComboBox.SelectedItem as Charity);
                infoWindow.ShowDialog();
            }
        }
        /* Buttons */
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (eventList.Count != 0)
            {
                if (raceKitId != ' ')
                {
                    if (CharityComboBox.SelectedItem != null)
                    {
                        if (SumTextBox.Text != null)
                        {
                            List<RegistrationEvent> regEventList = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId && c.Registration.RunnerId == _runner.RunnerId).ToList();
                            Registration registration;
                            //проверка на регистрацию до этого
                            if (regEventList.Count == 0)
                            {
                                registration = new Registration
                                {
                                    RunnerId = _runner.RunnerId,
                                    RegistrationDateTime = DateTime.Now,
                                    RaceKitOptionId = Convert.ToString(raceKitId),
                                    RegistrationStatusId = 3,
                                    Cost = Convert.ToDecimal(SumTextBlock.Text),
                                    CharityId = charity.CharityId,
                                    SponsorshipTarget = Convert.ToDecimal(SumTextBox.Text)
                                };

                                DB.entities.Registration.Add(registration);
                                DB.entities.SaveChanges();
                            }
                            else
                            {
                                var f = regEventList.Last();
                                registration = DB.entities.Registration.Where(c => c.RegistrationId == f.RegistrationId).ToList().Last();
                            }

                            RegistrationEvent regEvent;
                            int bibNumber;

                            foreach (var events in eventList)
                            {
                                if (DB.entities.RegistrationEvent.FirstOrDefault(c => c.RegistrationId == registration.RegistrationId && c.EventId == events.EventId) == null)
                                {
                                    bibNumber = Convert.ToInt32(DB.entities.RegistrationEvent.Where(c => c.EventId == events.EventId).ToList().Last().BibNumber) + 1;
                                    regEvent = new RegistrationEvent
                                    {
                                        RegistrationId = registration.RegistrationId,
                                        EventId = events.EventId,
                                        BibNumber = (short?)bibNumber
                                    };

                                    DB.entities.RegistrationEvent.Add(regEvent);
                                    DB.entities.SaveChanges();
                                }
                                else
                                    MessageBox.Show("Вы уже зарегистрированы на этот вид марафона", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                            NavigationService.Navigate(new RegistrationConfirmationPage(_runner));
                        }
                        else
                            MessageBox.Show("Поле <Сумма взноса> не может быть пустым!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                        MessageBox.Show("Выберите благотворительную организацию!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Выберите вариант комплекта!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Выберите хотя бы 1 вид марафона!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void SumTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = "0123456789".IndexOf(e.Text) < 0;

        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new RunnerMenu(_runner));

    }
}
