using HotelBooking.MainNavItems;
using HotelBooking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //To deseralize the json file
        //NEED TO USE DIRECT PATH TO READ WRITE FILE
        public static ResourceType resource = JsonConvert.DeserializeObject<ResourceType>(File.ReadAllText(@"BookingData.json"));
        //Create a list of receipt that contains a list of object thus a list in a list.
        public static ObservableCollection<ObservableCollection<Transaction>> Details = JsonConvert.DeserializeObject<ObservableCollection<ObservableCollection<Transaction>>>(File.ReadAllText(@"BookedDetails.json"));

        //Instantiate Cart
        public static ObservableCollection<CartItem> Cart = new ObservableCollection<CartItem>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CartTab_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CartPage cartP = new CartPage();
            TabFrame.Content = cartP;
        }

        private void ReceiptTab_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ReceiptPage receiptP = new ReceiptPage();
            TabFrame.Content = receiptP;
        }

        private void TabItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TabFrame.Content = null;
        }
    }
}
