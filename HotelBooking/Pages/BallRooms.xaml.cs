﻿using System;
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

namespace HotelBooking.Pages
{
    /// <summary>
    /// Interaction logic for Ballrooms.xaml
    /// </summary>
    public partial class Ballrooms : Page
    {
        public Ballrooms()
        {
            InitializeComponent();
        }

        private void Golden_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("/HotelBooking;component/Pages/Buffets.xaml", UriKind.Relative));
        }
    }
}