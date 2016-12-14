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
using System.IO;
namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string JSONstring = File.ReadAllText("BookingData.json");
            InitializeComponent();
        }

        private void BtnRooms_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Rooms();
        }

        private void BtnSuites_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Suites();
        }

        private void BtnBallRooms_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.BallRooms();
        }

        private void BtnDining_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Dining();
        }

        private void Popular_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Popular();
        }

        private void BtnBooking_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.BookingScreen();
        }

        private void BtnCart_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Cart();
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.UserInfo();
        }
    }
}
