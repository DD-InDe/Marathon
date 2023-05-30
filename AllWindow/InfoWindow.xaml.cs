using Marathon.Entities;
using Marathon.Pages;
using Marathon.Pages.AdminPages;
using Marathon.Pages.CoordinatorPages;
using Marathon.Pages.MainMenu.DetailedInfo;
using Marathon.Pages.RunnerPages;
using System;
using System.Collections.Generic;
using System.IO.Ports;
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

namespace Marathon.AllWindow
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow(int numPage, RegistrationEvent regEvent = null, Charity charity = null, Runner runner = null, List<RegistrationEvent> regEventList = null)
        {
            InitializeComponent();

            /* Гид по страницам
            1 - SponsorCharityInfoPage - Страница с информаций о благотворительной организации на странице SponsorPage
            2 - ContactPage - Информция с выводом контактной информацией на страницу RunnerMenu
            3 - SponsorCharityInfoPage - Страница с информаций о благотворительной организации на странице MatathonRegPage
            4 - InventoryReportPage - Страница с отчетом о закупке инвенатря для марафона на странице InventoryPage
            5 - RunnerCardPage - Страница с подробной информацией выбранного бегуна на странице RaceResultPage
            6 - EmailOutputPage - Страница с почтой бегунов на странице RunnerManagementPage
            7 - RunnersBadgePage - Страница с бейджиком бегуна на странице SelectresRunnerManagePage
            */

            switch (numPage)
            {
                case 1:
                    mainFrame.Navigate(new SponsorCharityInfoPage(regEvent));
                    break;
                case 2:
                    mainFrame.Navigate(new ContactPage());
                    break;
                case 3:
                    mainFrame.Navigate(new SponsorCharityInfoPage(charity));
                    break;
                case 4:
                    mainFrame.Navigate(new InventoryReportPage());
                    break;
                case 5:
                    Width = 800;
                    Height = 350;
                    mainFrame.Navigate(new RunnerCardPage(runner));
                    break;
                case 6:
                    mainFrame.Navigate(new EmailOutputPage(regEventList));
                    Width = 600;
                    break;
                case 7:
                    mainFrame.Navigate(new RunnersBadgePage(regEvent));
                    Width = 700;
                    Height = 400;
                    break;
                case 8:
                    mainFrame.Navigate(new BMRinfoPage());
                    break;
            }
        }
    }
}
