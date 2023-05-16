using Marathon.Entities;
using Microsoft.Win32;
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

namespace Marathon.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для CharityEditPage.xaml
    /// </summary>
    public partial class CharityEditPage : Page
    {
        public CharityEditPage()
        {
            InitializeComponent();
            charity = new Charity();
        }

        Charity charity;

        public CharityEditPage(Charity _charity)
        {
            InitializeComponent();
            charity = _charity;
            CharityNameTextBox.Text = charity.CharityName;
            CharityDescriptionTextBox.Text = charity.CharityDescription;
            CharityLogoImage.DataContext = charity.CharityLogoImage;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharityNameTextBox.Text != null && CharityDescriptionTextBox.Text != null)
            {
                charity.CharityName = CharityNameTextBox.Text;
                charity.CharityDescription = CharityDescriptionTextBox.Text;
                if (CharityLogoImage.DataContext != null)
                    charity.CharityLogoImage = (byte[])CharityLogoImage.DataContext;

                if (charity.CharityId == 0)
                    DB.entities.Charity.Add(charity);

                DB.entities.SaveChanges();
                MessageBox.Show("Изменения успешно сохранены!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            else
                MessageBox.Show("Поля не могут быть пустыми!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();
        private void FileDialogButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Image | *.jpg; *.png; *jpeg; *gif; *bmp"
            };

            if (fileDialog.ShowDialog() == true)
            {
                CharityLogoImage.DataContext = File.ReadAllBytes(fileDialog.FileName);
                FileTextBox.Text = fileDialog.FileName;
            }
        }
    }
}
