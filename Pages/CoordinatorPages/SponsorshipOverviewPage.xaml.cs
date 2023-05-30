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
    /// Логика взаимодействия для SponsorshipOverviewPage.xaml
    /// </summary>
    public partial class SponsorshipOverviewPage : Page
    {
        List<Charity> charityList = DB.entities.Charity.ToList();

        public SponsorshipOverviewPage()
        {
            InitializeComponent();

            List<string> sortList = new List<string>() { "Названию", "Сумме" };
            SortByComboBox.ItemsSource = sortList;
            SortByComboBox.SelectedIndex = 1;

            int totalSum = 0;

            foreach (Charity charity in charityList)
                totalSum += charity.TotalSum;

            AmountTextBlock.Text = totalSum.ToString();
            CharityCountTextBlock.Text = charityList.Count.ToString();
            SponsorDataGrid.ItemsSource = charityList;
        }

        private void SortByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortByComboBox.SelectedIndex == 0)
                charityList = charityList.OrderByDescending(c => c.CharityName).ToList();
            else
                charityList = charityList.OrderByDescending(c => c.TotalSum).ToList();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e) => SponsorDataGrid.ItemsSource = charityList;

    }
}
