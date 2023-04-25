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

namespace Marathon.Pages.MainMenu
{
    /// <summary>
    /// Логика взаимодействия для MatathonRegPage.xaml
    /// </summary>
    public partial class MatathonRegPage : Page
    {
        int priceMatathon = 0;
        int selectedBoxPrice = 0;
        public MatathonRegPage(Runner runner)
        {
            InitializeComponent();
            CharityComboBox.ItemsSource = DB.entities.Charity.ToList();

            SumTextBlock.Text = "$0";
        }

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
        private void VarARadioButton_Click(object sender, RoutedEventArgs e)
        {
            priceMatathon -= selectedBoxPrice;
            selectedBoxPrice = 0;
            SumTextBlock.Text = Convert.ToString(priceMatathon);
        }

        private void VarBRadioButton_Checked(object sender, RoutedEventArgs e)
        {

            priceMatathon -= selectedBoxPrice;
            selectedBoxPrice = 20;
            priceMatathon += selectedBoxPrice;
            SumTextBlock.Text = Convert.ToString(priceMatathon);
        }

        private void VarCRadionButton_Checked(object sender, RoutedEventArgs e)
        {

            priceMatathon -= selectedBoxPrice;
            selectedBoxPrice = 45;
            priceMatathon += selectedBoxPrice;
            SumTextBlock.Text = Convert.ToString(priceMatathon);
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharityComboBox.SelectedItem != null)
            {
                InfoWindow infoWindow = new InfoWindow(3,null,CharityComboBox.SelectedItem as Charity);
                infoWindow.ShowDialog();
            }
        }
    }
}
