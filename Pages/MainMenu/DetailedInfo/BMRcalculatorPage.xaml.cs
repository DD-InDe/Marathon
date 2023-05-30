using Marathon.AllWindow;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Marathon.Pages.MainMenu.DetailedInfo
{
    /// <summary>
    /// Логика взаимодействия для BMRcalculatorPage.xaml
    /// </summary>
    public partial class BMRcalculatorPage : Page
    {
        public BMRcalculatorPage()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow(8);
            infoWindow.ShowDialog();
        }

        double bmr, growth, weight;
        int age;
        string selectedGender = "";

        private void CalculationButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedGender != "")
            {
                if (WeightTextBox.Text != "" && AgeTextBox.Text != "" && GrowthTextBox.Text != "")
                {
                    if (TextConvert())
                    {
                        switch (selectedGender)
                        {
                            case "Male":
                                bmr = 66 + (13.7 * weight) + (5 * growth) - (6.8 * age);
                                break;
                            case "Female":
                                bmr = 65 + (9.6 * weight) + (1.8 * growth) - (4.7 * age);
                                break;
                        }
                        BMRTextBlock.Text = bmr.ToString();
                        PassiveTextBlock.Text = (bmr * 1.2).ToString();
                        LittleActivityTextBlock.Text = (bmr * 1.375).ToString();
                        MiddleActivityTextBlock.Text = (bmr * 1.55).ToString();
                        BigActivityTextBlock.Text = (bmr * 1.725).ToString();
                        MaxActivityTextBlock.Text = (bmr * 1.9).ToString();
                    }
                }
                else
                    MessageBox.Show("Поля не могут быть пустыми!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Выберите пол!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = "0123456789.".IndexOf(e.Text) < 0;

        private void FemaleButton_Click(object sender, RoutedEventArgs e)
        {
            FemaleButton.Opacity = 0.8;
            MaleButton.Opacity = 1;
            selectedGender = "Female";
        }

        private void MaleButton_Click(object sender, RoutedEventArgs e)
        {
            FemaleButton.Opacity = 1;
            MaleButton.Opacity = 0.8;
            selectedGender = "Male";
        }

        private bool TextConvert()
        {
            try
            {
                growth = Convert.ToDouble(GrowthTextBox.Text); // рост
                weight = Convert.ToDouble(WeightTextBox.Text); // вес
                age = Convert.ToInt32(AgeTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Проверьте правильность введеных данных!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            return true;
        }
    }
}
