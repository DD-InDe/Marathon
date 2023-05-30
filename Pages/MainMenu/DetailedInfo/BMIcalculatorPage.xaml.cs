using System;
using System.Collections.Generic;
using System.IO;
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

namespace Marathon.Pages.MainMenu.DetailedInfo
{
    /// <summary>
    /// Логика взаимодействия для BMIcalculatorPage.xaml
    /// </summary>
    public partial class BMIcalculatorPage : Page
    {
        public BMIcalculatorPage()
        {
            InitializeComponent();
        }

        double bmi, growth, weight;

        private void CalculationButton_Click(object sender, RoutedEventArgs e)
        {
            if (GrowthTextBox.Text != "" && WeightTextBox.Text != "")
            {
                if (DateConvert())
                {
                    bmi = weight / ((growth / 100) * (growth / 100));
                    BMISlider.Value = bmi;

                    if (bmi < 18.5)
                        StatusImage.DataContext = File.ReadAllBytes(@"photo/bmi-underweight-icon.png");
                    else if (bmi < 25)
                        StatusImage.DataContext = File.ReadAllBytes(@"photo/bmi-healthy-icon.png");
                    else if (bmi < 30)
                        StatusImage.DataContext = File.ReadAllBytes(@"photo/bmi-overweight-icon.png");
                    else
                        StatusImage.DataContext = File.ReadAllBytes(@"photo/bmi-obese-icon.png");
                }
            }
            else
                MessageBox.Show("Поля не могут быть пустыми!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();

        private void MaleButton_Click(object sender, RoutedEventArgs e)
        {
            MaleButton.Opacity = 0.8;
            GenderButton.Opacity = 1;
        }

        private void GenderButton_Click(object sender, RoutedEventArgs e)
        {
            MaleButton.Opacity = 1;
            GenderButton.Opacity = 0.8;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = "0123456789.".IndexOf(e.Text) < 0;

        private bool DateConvert()
        {
            try
            {
                growth = Convert.ToDouble(GrowthTextBox.Text);
                weight = Convert.ToDouble(WeightTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Проверьте правильность введенных данных!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            return true;
        }
    }
}
