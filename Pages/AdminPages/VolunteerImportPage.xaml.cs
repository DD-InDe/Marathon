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
    /// Логика взаимодействия для VolunteerImportPage.xaml
    /// </summary>
    public partial class VolunteerImportPage : Page
    {
        public VolunteerImportPage()
        {
            InitializeComponent();
        }

        Volunteer volunteer;
        int addCount = 0, changeCount = 0;

        private void FileDialogButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.csv;"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                FileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (FileTextBox.Text != null)
            {
                //загрузка файла
                List<string> fileVolunteersList = File.ReadAllLines(FileTextBox.Text).ToList();
                fileVolunteersList.RemoveAt(0);

                string[] volunteerString;
                int id;
                //проходимся по строкам
                for (int i = 0; i < fileVolunteersList.Count; i++)
                {
                    volunteerString = fileVolunteersList[i].Split(',');

                    id = Convert.ToInt32(volunteerString[0]);
                    volunteer = DB.entities.Volunteer.FirstOrDefault(c => c.VolunteerId == id);
                    void DateWrite(Volunteer volunteer)
                    {
                        volunteer.LastName = volunteerString[1];
                        volunteer.FirstName = volunteerString[2];
                        volunteer.CountryCode = volunteerString[3];
                        volunteer.Gender = volunteerString[4];
                    }

                    if (volunteer == null)
                    {
                        volunteer = new Volunteer();

                        DateWrite(volunteer);

                        DB.entities.Volunteer.Add(volunteer);
                        if (volunteer.Gender1 != null && volunteer.Country != null)
                        {
                            DB.entities.SaveChanges();
                            addCount++;
                        }
                        else
                        {
                            MessageBox.Show($"Ошибка добавления Волонтера с id: {id} ");
                            DB.entities.Volunteer.Remove(volunteer);
                        }
                    }
                    else
                    {
                        DateWrite(volunteer);
                        if (volunteer.Gender1 != null && volunteer.Country != null)
                        {
                            changeCount++;
                            DB.entities.SaveChanges();
                        }
                        else
                            MessageBox.Show($"Ошибка изменения Волонтера с id: {id} ");
                    }
                }
            }
            MessageBox.Show($"Добавлено {addCount} записей. Изменено {changeCount} записей.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();
    }
}
