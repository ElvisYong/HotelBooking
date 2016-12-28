using HotelBooking.Properties;
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

namespace HotelBooking.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Rooms : Page
    {
        public Rooms()
        {
            InitializeComponent();
        }
        private void DeluxeRoomButton_Click(object sender, RoutedEventArgs e)
        {   
            //when booking dates not chosen, user is alerted to select the dates
            if (DeluxeRoomBookingStart.SelectedDate == null || DeluxeRoomBookingEnd.SelectedDate == null)
            {
                Popups.BookingEntryNull Popup = new Popups.BookingEntryNull();
                Popup.Show();
            }
            //when facilty availabilty is 0 on the days chosen alert users about booking full
            else if (MainWindow.DeluxeRoomAvailability() == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //Add item to cart
            else
            {
                CartItem DeluxeRoom = new CartItem { itemName = MainWindow.DeluxeRoomName(), BookingStart = DeluxeRoomBookingStart.SelectedDate.Value, BookingEnd = DeluxeRoomBookingEnd.SelectedDate.Value, cost = MainWindow.DeluxeRoomCost() };
                ShoppingCart.AddCartItem(DeluxeRoom);
            }
        }

        private void PremiumRoomButton_Click(object sender, RoutedEventArgs e)
        {
            //when booking dates not chosen, user is alerted to select the dates
            if (PremiumRoomBookingStart.SelectedDate == null || PremiumRoomBookingEnd.SelectedDate == null)
            {
                Popups.BookingEntryNull Popup = new Popups.BookingEntryNull();
                Popup.Show();
            }
            //when facilty availabilty is 0 on the days chosen alert users about booking full
            else if (MainWindow.PremiumRoomAvailability() == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            else
            {
                CartItem PremiumRoom = new CartItem { itemName = MainWindow.PremiumRoomName(), BookingStart = PremiumRoomBookingStart.SelectedDate.Value, BookingEnd = PremiumRoomBookingEnd.SelectedDate.Value, cost = MainWindow.PremiumRoomCost() };
                ShoppingCart.AddCartItem(PremiumRoom);
            }
        }

        private void FamilyRoomButton_Click(object sender, RoutedEventArgs e)
        {
            //when booking dates not chosen, user is alerted to select the dates
            if (FamilyRoomBookingStart.SelectedDate == null || FamilyRoomBookingEnd.SelectedDate == null)
            {
                Popups.BookingEntryNull Popup = new Popups.BookingEntryNull();
                Popup.Show();
            }
            //when facilty availabilty is 0 on the days chosen alert users about booking full
            else if (MainWindow.FamilyRoomAvailability() == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            else
            {
                CartItem FamilyRoom = new CartItem { itemName = MainWindow.FamilyRoomName(), BookingStart = FamilyRoomBookingStart.SelectedDate.Value, BookingEnd = FamilyRoomBookingEnd.SelectedDate.Value, cost = MainWindow.FamilyRoomCost() };
                ShoppingCart.AddCartItem(FamilyRoom);
            }
        }

        private void VipRoomButton_Click(object sender, RoutedEventArgs e)
        {
            //when booking dates not chosen, user is alerted to select the dates
            if (VipRoomBookingStart.SelectedDate == null || VipRoomBookingEnd.SelectedDate == null)
            {
                Popups.BookingEntryNull Popup = new Popups.BookingEntryNull();
                Popup.Show();
            }
            //when facilty availabilty is 0 on the days chosen alert users about booking full
            else if (MainWindow.VipRoomAvailability() == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            else
            {
                CartItem VipRoom = new CartItem { itemName = MainWindow.VipRoomName(), BookingStart = VipRoomBookingStart.SelectedDate.Value, BookingEnd = VipRoomBookingEnd.SelectedDate.Value, cost = MainWindow.VipRoomCost() };
                ShoppingCart.AddCartItem(VipRoom);
            }

        }
    }
}
