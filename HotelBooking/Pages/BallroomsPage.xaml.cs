using HotelBooking.Models;
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
    /// Interaction logic for BallroomsPage.xaml
    /// </summary>
    public partial class BallroomsPage : Page
    {
        private static string wedBallroomName;
        private static int wedBallroomAvailability;
        private static double wedBallroomCost;
        private static string largeBallroomName;
        private static int largeBallroomAvailability;
        private static double largeBallroomCost;
        private static string grandBallroomName;
        private static int grandBallroomAvailability;
        private static double grandBallroomCost;

        public BallroomsPage()
        {
            InitializeComponent();
            InitializeComponent();
            foreach (var item in MainWindow.resource.ballRooms)
            {
                if (item.ballroomType.Equals("Wedding Ballroom"))
                {
                    wedBallroomName = item.ballroomType;
                    wedBallroomAvailability = item.availability;
                    wedBallroomCost = item.cost;
                }
                else if (item.ballroomType.Equals("Large Ballroom"))
                {
                    largeBallroomName = item.ballroomType;
                    largeBallroomAvailability = item.availability;
                    largeBallroomCost = item.cost;
                }
                else if (item.ballroomType.Equals("Grand Ballroom"))
                {
                    grandBallroomName = item.ballroomType;
                    grandBallroomAvailability = item.availability;
                    grandBallroomCost = item.cost;
                }
            }
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
            else if (wedBallroomAvailability == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //When booking start date is before end date, prompt user about it
            else if (WedBallroomBookingEnd.SelectedDate.Value < WedBallroomBookingStart.SelectedDate.Value)
            {
                Popups.DateError BookingError = new Popups.DateError();
                BookingError.Show();
            }
            //Add item to Cart
            else
            {
                //Add to cart
                CartItem Item = new CartItem()
                {
                    itemName = wedBallroomName,
                    BookingStart = WedBallroomBookingStart.SelectedDate.Value,
                    BookingEnd = WedBallroomBookingEnd.SelectedDate.Value,
                    cost = wedBallroomCost
                };
                MainWindow.Cart.Add(Item);
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
            else if (largeBallroomAvailability == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //When booking start date is before end date, prompt user about it
            else if (LargeBallroomBookingEnd.SelectedDate.Value < LargeBallroomBookingStart.SelectedDate.Value)
            {
                Popups.DateError BookingError = new Popups.DateError();
                BookingError.Show();
            }
            //Add to Cart
            else
            {
                //Add to cart
                CartItem Item = new CartItem()
                {
                    itemName = largeBallroomName,
                    BookingStart = LargeBallroomBookingStart.SelectedDate.Value,
                    BookingEnd = LargeBallroomBookingEnd.SelectedDate.Value,
                    cost = largeBallroomCost
                };
                MainWindow.Cart.Add(Item);
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
            else if (grandBallroomAvailability == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //When booking start date is before end date, prompt user about it
            else if (GrandBallroomBookingEnd.SelectedDate.Value < GrandBallroomBookingStart.SelectedDate.Value)
            {
                Popups.DateError BookingError = new Popups.DateError();
                BookingError.Show();
            }
            //Add to Cart
            else
            {
                //Add to cart
                CartItem Item = new CartItem()
                {
                    itemName = grandBallroomName,
                    BookingStart = GrandBallroomBookingStart.SelectedDate.Value,
                    BookingEnd = GrandBallroomBookingEnd.SelectedDate.Value,
                    cost = grandBallroomCost
                };
                MainWindow.Cart.Add(Item);
            }
        }
    }
}
