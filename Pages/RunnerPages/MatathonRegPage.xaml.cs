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

        /* CheckBoxes */
        private void BigCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (BigCheckBox.IsChecked == true)
            {
                priceMatathon += 145;
            }
            else
            {
                priceMatathon -= 145;
            }
            SumTextBlock.Text = Convert.ToString(priceMatathon);
        }
        private void MediumCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (MediumCheckBox.IsChecked == true)
            {
                priceMatathon += 75;
            }
            else
            {
                priceMatathon -= 75;
            }
            SumTextBlock.Text = Convert.ToString(priceMatathon);
        }
        private void SmallCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (SmallCheckBox.IsChecked == true)
            {
                priceMatathon += 20;
            }
            else
            {
                priceMatathon -= 20;
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
            if (BigCheckBox.IsChecked == true || MediumCheckBox.IsChecked == true || SmallCheckBox.IsChecked == true)
            {
                if (raceKitId != ' ')
                {
                    if (CharityComboBox.SelectedItem != null)
                    {
                        if (SumTextBox.Text != null)
                        {
                            Registration registration = new Registration
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
