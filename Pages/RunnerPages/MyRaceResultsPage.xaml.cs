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
    /// Логика взаимодействия для MyRaceResultsPage.xaml
    /// </summary>
    public partial class MyRaceResultsPage : Page
    {
        public MyRaceResultsPage(Runner runner)
        {
            InitializeComponent();
            MarathonDataGrid.ItemsSource = DB.entities.RegistrationEvent.Where(c => c.Registration.RunnerId == runner.RunnerId).ToList();
            runnerInfoTextBlock.DataContext = runner; 
        }

        private void AllResults_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
