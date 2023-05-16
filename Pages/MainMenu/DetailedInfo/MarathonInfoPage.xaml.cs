using Marathon.Entities;
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
    /// Логика взаимодействия для MarathonInfoPage.xaml
    /// </summary>
    public partial class MarathonInfoPage : Page
    {
        public MarathonInfoPage()
        {
            InitializeComponent();
            string path = @"C:\Users\deer\source\repos\Marathon\Resources\";
            DescriptionTextBlock.Text = File.ReadAllText(path + "marathonInfo.txt", Encoding.UTF8);
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) => NavigationService.Navigate(new InteractiveMapPage());
    }
}