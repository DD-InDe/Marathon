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

namespace Marathon.Pages
{
    /// <summary>
    /// Логика взаимодействия для SponsorCharityInfoPage.xaml
    /// </summary>
    public partial class SponsorCharityInfoPage : Page
    {
        public SponsorCharityInfoPage(RegistrationEvent regEvent)
        {
            InitializeComponent();
            _regEvent = regEvent;
        }

        RegistrationEvent _regEvent;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _regEvent.Registration.Charity;
        }
    }
}
