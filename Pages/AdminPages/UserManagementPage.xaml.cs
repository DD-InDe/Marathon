using Marathon.Entities;
using Marathon.Pages.CoordinatorPages;
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

namespace Marathon.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для UserManagementPage.xaml
    /// </summary>
    public partial class UserManagementPage : Page
    {
        public UserManagementPage()
        {
            InitializeComponent();

            //сортировка по колонкам
            List<string> sortList = new List<string>
            {
                "Имени",
                "Фамилии",
                "Почте",
                "Ролям"
            };
            SortByComboBox.SelectedIndex = 0;
            SortByComboBox.ItemsSource = sortList;

            List<Role> roleList = new List<Role>();
            role = new Role() { RoleName = "Все роли" };
            roleList.Add(role);
            roleList.AddRange(DB.entities.Role.ToList());
            RoleComboBox.ItemsSource = roleList;
            RoleComboBox.SelectedIndex = 0;
        }

        Role role;
        List<User> userList;

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoleComboBox.SelectedIndex == 0 && SearchTextBox.Text == "")
                userList = DB.entities.User.ToList();
            if (RoleComboBox.SelectedIndex != 0 && SearchTextBox.Text == "")
                userList = DB.entities.User.Where(c => c.Role.RoleId == ((Role)RoleComboBox.SelectedItem).RoleId).ToList();
            if (RoleComboBox.SelectedIndex == 0 && SearchTextBox.Text != "")
                userList = DB.entities.User.Where(c => c.FirstName.Contains(SearchTextBox.Text) || c.LastName.Contains(SearchTextBox.Text) || c.Email.Contains(SearchTextBox.Text)).ToList();
            if (RoleComboBox.SelectedIndex != 0 && SearchTextBox.Text != "")
            {
                userList = DB.entities.User.Where(c => c.FirstName.Contains(SearchTextBox.Text) || c.LastName.Contains(SearchTextBox.Text) || c.Email.Contains(SearchTextBox.Text)).ToList();
                userList = userList.Where(c => c.RoleId == ((Role)RoleComboBox.SelectedItem).RoleId).ToList();
            }

            switch (SortByComboBox.SelectedItem)
            {
                case "Имени":
                    userList = userList.OrderBy(c => c.FirstName).ToList();
                    countTextBlock.Text = userList.Count.ToString();
                    break;
                case "Фамилии":
                    userList = userList.OrderBy(c => c.LastName).ToList();
                    countTextBlock.Text = userList.Count.ToString();
                    break;
                case "Почте":
                    userList = userList.OrderBy(c => c.Email).ToList();
                    countTextBlock.Text = userList.Count.ToString();
                    break;
                case "Ролям":
                    userList = userList.OrderBy(c => c.Role.RoleName).ToList();
                    countTextBlock.Text = userList.Count.ToString();
                    break;
            }
            UserDataGrid.ItemsSource = userList;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new UserEditPage(((Button)e.Source).DataContext as User));

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            userList = DB.entities.User.ToList();
            UserDataGrid.ItemsSource = userList;
            countTextBlock.Text = userList.Count.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new UserAddPage());
    }
}
