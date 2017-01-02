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
        private static double wedBallroomCost;
        private static string largeBallroomName;
        private static double largeBallroomCost;
        private static string grandBallroomName;
        private static double grandBallroomCost;

        public BallroomsPage()
        {
            InitializeComponent();
            foreach (var item in MainWindow.resource.ballRooms)
            {
                if (item.ballroomType.Equals("Wedding Ballroom"))
                {
                    wedBallroomName = item.ballroomType;
                    wedBallroomCost = item.cost;
                }
                else if (item.ballroomType.Equals("Large Ballroom"))
                {
                    largeBallroomName = item.ballroomType;
                    largeBallroomCost = item.cost;
                }
                else if (item.ballroomType.Equals("Grand Ballroom"))
                {
                    grandBallroomName = item.ballroomType;
                    grandBallroomCost = item.cost;
                }
            }
        }
        private void WedBallroomButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int facilityId = 0;
            foreach (var item in MainWindow.resource.ballRooms)
            {
                if (item.ballroomType.Equals("Wedding Ballroom"))
                {
                    foreach (var ids in item.ballroomId)
                    {
                        foreach (var start in ids.bookingStart)
                        {
                            foreach (var end in ids.bookingEnd)
                            {
                                if (start.dates == null && end.dates == null)
                                {
                                    bookingFull = false;
                                    facilityId = ids.id;
                                    break;
                                }
                                else if (WedBallroomBookingStart.SelectedDate.Equals(start.dates)
                                    || WedBallroomBookingStart.SelectedDate > start.dates && WedBallroomBookingStart.SelectedDate < end.dates
                                    || WedBallroomBookingEnd.SelectedDate > start.dates && WedBallroomBookingEnd.SelectedDate < end.dates
                                    || WedBallroomBookingEnd.SelectedDate.Equals(end.dates))
                                {
                                    bookingFull = true;
                                }
                            }
                        }
                        if (facilityId > 0) break;
                    }
                }
            }
            //when booking dates not chosen, user is alerted to select the dates
            if (WedBallroomBookingStart.SelectedDate == null || WedBallroomBookingEnd.SelectedDate == null)
            {
                Popups.BookingEntryNull Popup = new Popups.BookingEntryNull();
                Popup.Show();
            }
            //calls scheduler methods to check if booking is full on selected dates
            else if (bookingFull == true)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //When booking start date is before end date, prompt user about it
            else if (WedBallroomBookingEnd.SelectedDate < WedBallroomBookingStart.SelectedDate)
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
                    cost = wedBallroomCost,
                    itemId = facilityId
                };
                MainWindow.Cart.Add(Item);
                WedBallroomButton.IsEnabled = false;
            }
        }

        private void LargeBallroomButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int facilityId = 0;
            foreach (var item in MainWindow.resource.ballRooms)
            {
                if (item.ballroomType.Equals("Large Ballroom"))
                {
                    foreach (var ids in item.ballroomId)
                    {
                        foreach (var start in ids.bookingStart)
                        {
                            foreach (var end in ids.bookingEnd)
                            {
                                if (start.dates == null && end.dates == null)
                                {
                                    bookingFull = false;
                                    facilityId = ids.id;
                                    break;
                                }
                                else if (LargeBallroomBookingStart.SelectedDate.Equals(start.dates)
                                    || LargeBallroomBookingStart.SelectedDate > start.dates && LargeBallroomBookingStart.SelectedDate < end.dates
                                    || LargeBallroomBookingEnd.SelectedDate > start.dates && LargeBallroomBookingEnd.SelectedDate < end.dates
                                    || LargeBallroomBookingEnd.SelectedDate.Equals(end.dates))
                                {
                                    bookingFull = true;
                                }
                            }
                        }
                        if (facilityId > 0) break;
                    }
                }
            }
            //when booking dates not chosen, user is alerted to select the dates
            if (LargeBallroomBookingStart.SelectedDate == null || LargeBallroomBookingEnd.SelectedDate == null)
            {
                Popups.BookingEntryNull Popup = new Popups.BookingEntryNull();
                Popup.Show();
            }
            //calls scheduler methods to check if booking is full on selected dates
            else if (bookingFull == true)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //When booking start date is before end date, prompt user about it
            else if (LargeBallroomBookingEnd.SelectedDate < LargeBallroomBookingStart.SelectedDate)
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
                    cost = largeBallroomCost,
                    itemId = facilityId
                };
                MainWindow.Cart.Add(Item);
                LargeBallroomButton.IsEnabled = false;
            }
        }

        private void GrandBallroomButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int facilityId = 0;
            foreach (var item in MainWindow.resource.ballRooms)
            {
                if (item.ballroomType.Equals("Grand Ballroom"))
                {
                    foreach (var ids in item.ballroomId)
                    {
                        foreach (var start in ids.bookingStart)
                        {
                            foreach (var end in ids.bookingEnd)
                            {
                                if (ids.bookingStart == null)
                                {
                                    bookingFull = false;
                                    facilityId = ids.id;
                                    break;
                                }
                                else if (GrandBallroomBookingStart.SelectedDate.Equals(start.dates)
                                    || GrandBallroomBookingStart.SelectedDate > start.dates && GrandBallroomBookingStart.SelectedDate < end.dates
                                    || GrandBallroomBookingEnd.SelectedDate > start.dates && GrandBallroomBookingEnd.SelectedDate < end.dates
                                    || GrandBallroomBookingEnd.SelectedDate.Equals(end.dates))
                                {
                                    bookingFull = true;
                                }
                            }
                        }
                        if (facilityId > 0) break;
                    }
                }
            }
            //when booking dates not chosen, user is alerted to select the dates
            if (GrandBallroomBookingStart.SelectedDate == null || GrandBallroomBookingEnd.SelectedDate == null)
            {
                Popups.BookingEntryNull Popup = new Popups.BookingEntryNull();
                Popup.Show();
            }
            //calls scheduler methods to check if booking is full on selected dates
            else if (bookingFull == true)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //When booking start date is before end date, prompt user about it
            else if (GrandBallroomBookingEnd.SelectedDate < GrandBallroomBookingStart.SelectedDate)
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
                    cost = grandBallroomCost,
                    itemId = facilityId
                };
                MainWindow.Cart.Add(Item);
                GrandBallroomButton.IsEnabled = false;
            }
        }
    }
}
