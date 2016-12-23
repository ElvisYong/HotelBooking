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
//added references
using System.IO;
using Newtonsoft.Json;
namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string jsonReader = File.ReadAllText("BookingData.json");
            JsonProperties.FacilityType ft = JsonConvert.DeserializeObject<JsonProperties.FacilityType>(jsonReader);
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

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Main_Navigated_1(object sender, NavigationEventArgs e)
        {

        }
    }
}
