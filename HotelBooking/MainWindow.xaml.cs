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
using Newtonsoft.Json;
using HotelBooking.Models;
using System.Collections.ObjectModel;
using HotelBooking.Pages;
namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //To deseralize the json file
        public static ResourceType resource = JsonConvert.DeserializeObject<ResourceType>(File.ReadAllText(@"C:\Users\elvis\Desktop\AppD\Assignment1\HotelBookings\HotelBooking\HotelBooking\BookingData.json"));
        public static ObservableCollection<CartItem> Cart = new ObservableCollection<CartItem>();
        
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new RoomsPage();
        }
        private void Rooms_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new RoomsPage();
        }

        private void Ballroom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new BallroomsPage();
        }

        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {

      
        }

        private void TabItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CartFrame.Content = new CartPage();
        }
    }
}
