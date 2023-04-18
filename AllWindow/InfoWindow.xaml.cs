using Marathon.Entities;
using Marathon.Pages;
using Marathon.Pages.RunnerPages;
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
using System.Windows.Shapes;

namespace Marathon.AllWindow
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow(int numPage, RegistrationEvent regEvent = null)
        {
            InitializeComponent();

            /* Гид по страницам
            1 - SponsorCharityInfoPage - Страница с информаций о благотворительной организации на странице SponsorPage
            2 - ContactPage - Информция с выводом контактной информацией на страницу RunnerMenu
            */

            switch (numPage)
            {
                case 1:
                    mainFrame.Navigate(new SponsorCharityInfoPage(regEvent));
                    break;
                case 2:
                    mainFrame.Navigate(new ContactPage());
                    break;
            }
        }
    }
}
