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
        private static string theGoldenName;
        private static double theGoldenCost;
        private static string theVintageName;
        private static double theVintageCost;
        private static string theWillowName;
        private static double theWillowCost;

        public BallroomsPage()
        {
            InitializeComponent();
            foreach (var item in MainWindow.resource.ballRooms)
            {
                if (item.ballroomType.Equals("The Golden"))
                {
                    theGoldenName = item.ballroomType;
                    theGoldenCost = item.cost;
                }
                else if (item.ballroomType.Equals("The Vintage"))
                {
                    theVintageName = item.ballroomType;
                    theVintageCost = item.cost;
                }
                else if (item.ballroomType.Equals("The Willow"))
                {
                    theWillowName = item.ballroomType;
                    theWillowCost = item.cost;
                }
            }
        }
        private void TheGoldenButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int breaker = 0;
            foreach (var item in MainWindow.resource.ballRooms)
            {
                if (item.ballroomType.Equals("The Golden"))
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
                                    breaker = 1;
                                    break;
                                }
                                else if (TheGoldenBookingStart.SelectedDate.Equals(start.dates)
                                    || TheGoldenBookingStart.SelectedDate > start.dates && TheGoldenBookingStart.SelectedDate < end.dates
                                    || TheGoldenBookingEnd.SelectedDate > start.dates && TheGoldenBookingEnd.SelectedDate < end.dates
                                    || TheGoldenBookingEnd.SelectedDate.Equals(end.dates))
                                {
                                    bookingFull = true;
                                }
                            }
                        }
                        if (breaker == 1) break;
                    }
                }
            }
            //when booking dates not chosen, user is alerted to select the dates
            if (TheGoldenBookingStart.SelectedDate == null || TheGoldenBookingEnd.SelectedDate == null)
            {
                Popups.BookingEntryNull Popup = new Popups.BookingEntryNull();
                Popup.Show();
            }
            //Check if booking is full on selected dates for all selected facilities
            else if (bookingFull == true)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //When booking start date is before end date, prompt user about it
            else if (TheGoldenBookingEnd.SelectedDate < TheGoldenBookingStart.SelectedDate)
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
                    itemName = theGoldenName,
                    BookingStart = TheGoldenBookingStart.SelectedDate.Value,
                    BookingEnd = TheGoldenBookingEnd.SelectedDate.Value,
                    cost = theGoldenCost,
                    itemImage = "string" //Add item source
                };
                MainWindow.Cart.Add(Item);
            }
        }

        private void TheVintageButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int breaker = 0;
            foreach (var item in MainWindow.resource.ballRooms)
            {
                if (item.ballroomType.Equals("The Vintage"))
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
                                    break;
                                }
                                else if (TheVintageBookingStart.SelectedDate.Equals(start.dates)
                                    || TheVintageBookingStart.SelectedDate > start.dates && TheVintageBookingStart.SelectedDate < end.dates
                                    || TheVintageBookingEnd.SelectedDate > start.dates && TheVintageBookingEnd.SelectedDate < end.dates
                                    || TheVintageBookingEnd.SelectedDate.Equals(end.dates))
                                {
                                    bookingFull = true;
                                }
                            }
                        }
                        if (breaker == 1) break;
                    }
                }
            }
            //when booking dates not chosen, user is alerted to select the dates
            if (TheVintageBookingStart.SelectedDate == null || TheVintageBookingEnd.SelectedDate == null)
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
            else if (TheVintageBookingEnd.SelectedDate < TheVintageBookingStart.SelectedDate)
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
                    itemName = theVintageName,
                    BookingStart = TheVintageBookingStart.SelectedDate.Value,
                    BookingEnd = TheVintageBookingEnd.SelectedDate.Value,
                    cost = theVintageCost,
                    itemImage = "string" //Add image source
                };
                MainWindow.Cart.Add(Item);
            }
        }

        private void TheWillowButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int breaker = 0;
            foreach (var item in MainWindow.resource.ballRooms)
            {
                if (item.ballroomType.Equals("The Willow"))
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
                                    break;
                                }
                                else if (TheWillowBookingStart.SelectedDate.Equals(start.dates)
                                    || TheWillowBookingStart.SelectedDate > start.dates && TheWillowBookingStart.SelectedDate < end.dates
                                    || TheWillowBookingEnd.SelectedDate > start.dates && TheWillowBookingEnd.SelectedDate < end.dates
                                    || TheWillowBookingEnd.SelectedDate.Equals(end.dates))
                                {
                                    bookingFull = true;
                                }
                            }
                        }
                        if (breaker == 1) break;
                    }
                }
            }
            //when booking dates not chosen, user is alerted to select the dates
            if (TheWillowBookingStart.SelectedDate == null || TheWillowBookingEnd.SelectedDate == null)
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
            else if (TheWillowBookingEnd.SelectedDate < TheWillowBookingStart.SelectedDate)
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
                    itemName = theWillowName,
                    BookingStart = TheWillowBookingStart.SelectedDate.Value,
                    BookingEnd = TheWillowBookingEnd.SelectedDate.Value,
                    cost = theWillowCost,
                    itemImage = "string"//Image source
                };
                MainWindow.Cart.Add(Item);
            }
        }
    }
}
