﻿using Marathon.Entities;
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

namespace Marathon.Pages.MainMenu.DetailedInfo
{
    /// <summary>
    /// Логика взаимодействия для RunnerCardPage.xaml
    /// </summary>
    public partial class RunnerCardPage : Page
    {
        public RunnerCardPage(Runner _runner)
        {
            InitializeComponent();
            runner = _runner;
            RaceResults.ItemsSource = DB.entities.RegistrationEvent.Where(c => c.Registration.RunnerId == runner.RunnerId).ToList();
        }

        Runner runner;

        private void Page_Loaded(object sender, RoutedEventArgs e) => this.DataContext = runner;
    }
}
