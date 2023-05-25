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
using Marathon.Resources;
using System.IO;

namespace Marathon.Pages.CoordinatorPages
{
    /// <summary>
    /// Логика взаимодействия для SelectedRunnerManagePage.xaml
    /// </summary>
    public partial class SelectedRunnerManagePage : Page
    {
        RegistrationEvent baseInfo;
        public SelectedRunnerManagePage(RegistrationEvent regEvent)
        {
            InitializeComponent();
            baseInfo = regEvent;

            if (regEvent.Registration.Runner.RunnerImage == null)
                RunnerPhotoImage.DataContext = File.ReadAllBytes(@"photo/None.png");

            switch (baseInfo.Registration.RegistrationStatusId)
            {
                case 1:
                    Check1.DataContext = File.ReadAllBytes(@"photo/tick-icon.png");
                    Check2.DataContext = File.ReadAllBytes(@"photo/cross-icon.png");
                    Check3.DataContext = File.ReadAllBytes(@"photo/cross-icon.png");
                    Check4.DataContext = File.ReadAllBytes(@"photo/cross-icon.png");
                    break;
                case 2:
                    Check1.DataContext = File.ReadAllBytes(@"photo/tick-icon.png");
                    Check2.DataContext = File.ReadAllBytes(@"photo/tick-icon.png");
                    Check3.DataContext = File.ReadAllBytes(@"photo/cross-icon.png");
                    Check4.DataContext = File.ReadAllBytes(@"photo/cross-icon.png");
                    break;
                case 3:
                    Check1.DataContext = File.ReadAllBytes(@"photo/tick-icon.png");
                    Check2.DataContext = File.ReadAllBytes(@"photo/tick-icon.png");
                    Check3.DataContext = File.ReadAllBytes(@"photo/tick-icon.png");
                    Check4.DataContext = File.ReadAllBytes(@"photo/cross-icon.png");
                    break;
                case 4:
                    Check1.DataContext = File.ReadAllBytes(@"photo/tick-icon.png");
                    Check2.DataContext = File.ReadAllBytes(@"photo/tick-icon.png");
                    Check4.DataContext = File.ReadAllBytes(@"photo/tick-icon.png");
                    Check3.DataContext = File.ReadAllBytes(@"photo/tick-icon.png");
                    break;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) => this.DataContext = baseInfo;
    }
}
