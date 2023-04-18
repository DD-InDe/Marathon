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

            RunnerComboBox.ItemsSource = DB.entities.RegistrationEvent.Where(c => c.EventId == "15_5HM").ToList();

            SumTextBox.Text = "50";
            SumTextBlock.Text = '$' + SumTextBox.Text;
        }

        int sum;
        RegistrationEvent f;

        private void RunnerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            f = RunnerComboBox.SelectedItem as RegistrationEvent;
            CharityNameTextBlock.Text = f.Registration.Charity.CharityName;
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
                InfoWindow infoWindow = new InfoWindow(1,f);
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
                Sponsorship addSponsorship = new Sponsorship();
                addSponsorship.Amount = Convert.ToDecimal(SumTextBox.Text);
                addSponsorship.SponsorName = NameTextBox.Text;
                addSponsorship.Registration = f.Registration;
                DB.entities.Sponsorship.Add(addSponsorship);
                //DB.entities.SaveChanges();
                NavigationService.Navigate(new SponsorThanksPage(f,addSponsorship));
            }
        }
    }
}
