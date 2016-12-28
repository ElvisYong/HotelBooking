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
    /// Interaction logic for Ballrooms.xaml
    /// </summary>
    public partial class Ballrooms : Page
    {
        public Ballrooms()
        {

        }

        private void WedBallroomButton_Click(object sender, RoutedEventArgs e)
        {
            //when booking dates not chosen, user is alerted to select the dates
            if (WedBallroomBookingStart.SelectedDate == null || WedBallroomBookingEnd.SelectedDate == null)
            {
                Popups.BookingEntryNull Popup = new Popups.BookingEntryNull();
                Popup.Show();
            }
            //when facilty availabilty is 0 on the days chosen alert users about booking full
            else if (MainWindow.WedBallroomAvailability() == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //Add item to cart
            else
            {
                CartItem WedBallroom = new CartItem { itemName = MainWindow.WedBallroomName(), BookingStart = WedBallroomBookingStart.SelectedDate.Value, BookingEnd = WedBallroomBookingEnd.SelectedDate.Value, cost = MainWindow.WedBallroomCost() };
                ShoppingCart.AddCartItem(WedBallroom);
            }
        }

        private void LargeBallroomButton_Click(object sender, RoutedEventArgs e)
        {
            //when booking dates not chosen, user is alerted to select the dates
            if (LargeBallroomBookingStart.SelectedDate == null || LargeBallroomBookingEnd.SelectedDate == null)
            {
                Popups.BookingEntryNull Popup = new Popups.BookingEntryNull();
                Popup.Show();
            }
            //when facilty availabilty is 0 on the days chosen alert users about booking full
            else if (MainWindow.LargeBallroomAvailability() == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //Add to cart
            else
            {
                CartItem LargeBallroom = new CartItem { itemName = MainWindow.LargeBallroomName(), BookingStart = LargeBallroomBookingStart.SelectedDate.Value, BookingEnd = LargeBallroomBookingEnd.SelectedDate.Value, cost = MainWindow.LargeBallroomCost() };
                ShoppingCart.AddCartItem(LargeBallroom);
            }
        }

        private void GrandBallroomButton_Click(object sender, RoutedEventArgs e)
        {
            //when booking dates not chosen, user is alerted to select the dates
            if (GrandBallroomBookingStart.SelectedDate == null || GrandBallroomBookingEnd.SelectedDate == null)
            {
                Popups.BookingEntryNull Popup = new Popups.BookingEntryNull();
                Popup.Show();
            }
            //when facilty availabilty is 0 on the days chosen alert users about booking full
            else if (MainWindow.GrandBallroomAvailability() == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //Add to cart
            else
            {
                CartItem GrandBallroom = new CartItem { itemName = MainWindow.GrandBallroomName(), BookingStart = GrandBallroomBookingStart.SelectedDate.Value, BookingEnd = GrandBallroomBookingEnd.SelectedDate.Value, cost = MainWindow.GrandBallroomCost() };
                ShoppingCart.AddCartItem(GrandBallroom);
            }
        }
    }
}
