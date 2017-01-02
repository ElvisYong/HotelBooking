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
//Inserted
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
        //Create a list of receipt that contains a list of object thus a list in a list.
        public static ObservableCollection<ObservableCollection<Transaction>> Details = JsonConvert.DeserializeObject<ObservableCollection<ObservableCollection<Transaction>>>(File.ReadAllText(@"C:\Users\elvis\Desktop\AppD\Assignment1\HotelBookings\HotelBooking\HotelBooking\BookedDetails.json"));
       
        //instantiate Cart
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

        private void TabItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CartFrame.Content = new CartPage();
        }

        private void TabItem_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            ReceiptFrame.Content = new ReceiptPage();
        }
    }
}
