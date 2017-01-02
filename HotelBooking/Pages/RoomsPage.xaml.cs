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
//inserted
using HotelBooking.Models;

namespace HotelBooking.Pages
{
    /// <summary>
    /// Interaction logic for RoomsPage.xaml
    /// </summary>
    public partial class RoomsPage : Page
    {
        //Local variables to be assigned
        private static string classicRoomName;
        private static double classicRoomCost;
        private static string deluxeRoomName;
        private static double deluxeRoomCost;
        private static string prestigeRoomName;
        private static double prestigeRoomCost;

        public RoomsPage()
        {
            InitializeComponent();
            foreach (var item in MainWindow.resource.hotelRooms)
            {
                if (item.roomType.Equals("Classic Room"))
                {
                    classicRoomName = item.roomType;
                    classicRoomCost = item.cost;
                }
                else if (item.roomType.Equals("Deluxe Room"))
                {
                    deluxeRoomName = item.roomType;
                    deluxeRoomCost = item.cost;
                }
                else if (item.roomType.Equals("Prestige Room"))
                {
                    prestigeRoomName = item.roomType;
                    prestigeRoomCost = item.cost;
                }
            }
        }

        private void ClassicRoomButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int breaker = 0;
            foreach (var item in MainWindow.resource.hotelRooms)
            {
                if (item.roomType.Equals("Classic Room"))
                {
                    foreach (var ids in item.roomId)
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
                                else if (ClassicRoomBookingStart.SelectedDate.Equals(start.dates)
                                    || ClassicRoomBookingStart.SelectedDate > start.dates && ClassicRoomBookingStart.SelectedDate < end.dates
                                    || ClassicRoomBookingEnd.SelectedDate > start.dates && ClassicRoomBookingEnd.SelectedDate < end.dates
                                    || ClassicRoomBookingEnd.SelectedDate.Equals(end.dates))
                                {
                                    bookingFull = true;
                                }
                            }
                        }
                        if (breaker == 1)
                            break;
                    }
                }
            }
            //when booking dates not chosen, user is alerted to select the dates
            if (ClassicRoomBookingStart.SelectedDate == null || ClassicRoomBookingEnd.SelectedDate == null)
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
            else if (ClassicRoomBookingEnd.SelectedDate < ClassicRoomBookingStart.SelectedDate)
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
                    itemName = classicRoomName,
                    BookingStart = ClassicRoomBookingStart.SelectedDate.Value,
                    BookingEnd = ClassicRoomBookingEnd.SelectedDate.Value,
                    cost = classicRoomCost,
                    itemImage = "string" //Add image source
                };
                MainWindow.Cart.Add(Item);
            }
        }

        private void DeluxeRoomButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int breaker = 0;
            foreach (var item in MainWindow.resource.hotelRooms)
            {
                if (item.roomType.Equals("Deluxe Room"))
                {
                    foreach (var ids in item.roomId)
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
                                else if (DeluxeRoomBookingEnd.SelectedDate.Equals(start.dates)
                                    || DeluxeRoomBookingStart.SelectedDate > start.dates && DeluxeRoomBookingStart.SelectedDate < end.dates
                                    || DeluxeRoomBookingEnd.SelectedDate > start.dates && DeluxeRoomBookingEnd.SelectedDate < end.dates
                                    || DeluxeRoomBookingEnd.SelectedDate.Equals(end.dates))
                                {
                                    bookingFull = true;
                                }
                            }
                        }
                        if (breaker == 1)
                            break;
                    }
                }
            }
            //when booking dates not chosen, user is alerted to select the dates
            if (DeluxeRoomBookingStart.SelectedDate == null || DeluxeRoomBookingEnd.SelectedDate == null)
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
            else if (DeluxeRoomBookingEnd.SelectedDate < DeluxeRoomBookingStart.SelectedDate)
            {
                Popups.DateError BookingError = new Popups.DateError();
                BookingError.Show();
            }
            //When booking start date is before end date, prompt user about it
            else
            {
                //Add to cart
                CartItem Item = new CartItem()
                {
                    itemName = deluxeRoomName,
                    BookingStart = DeluxeRoomBookingStart.SelectedDate.Value,
                    BookingEnd = DeluxeRoomBookingEnd.SelectedDate.Value,
                    cost = deluxeRoomCost,
                    itemImage = "string"
                };
                MainWindow.Cart.Add(Item);
                DeluxeRoomButton.IsEnabled = false;
            }
        }

        private void PrestigeRoomButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int breaker = 1;
            foreach (var item in MainWindow.resource.hotelRooms)
            {
                if (item.roomType.Equals("Prestige Room"))
                {
                    foreach (var ids in item.roomId)
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
                                else if (PrestigeRoomBookingStart.SelectedDate.Equals(start.dates)
                                    || PrestigeRoomBookingStart.SelectedDate > start.dates && PrestigeRoomBookingStart.SelectedDate < end.dates
                                    || PrestigeRoomBookingEnd.SelectedDate > start.dates && PrestigeRoomBookingEnd.SelectedDate < end.dates
                                    || PrestigeRoomBookingEnd.SelectedDate.Equals(end.dates))
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
            if (PrestigeRoomBookingStart.SelectedDate == null || PrestigeRoomBookingEnd.SelectedDate == null)
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
            else if (PrestigeRoomBookingEnd.SelectedDate < PrestigeRoomBookingStart.SelectedDate)
            {
                Popups.DateError BookingError = new Popups.DateError();
                BookingError.Show();
            }
            else
            {
                //Add to cart
                CartItem Item = new CartItem()
                {
                    itemName = prestigeRoomName,
                    BookingStart = PrestigeRoomBookingStart.SelectedDate.Value,
                    BookingEnd = PrestigeRoomBookingEnd.SelectedDate.Value,
                    cost = prestigeRoomCost,
                    itemImage = "string" //Add image source
                };
                MainWindow.Cart.Add(Item);
                PrestigeRoomButton.IsEnabled = false;
            }
        }
    }
}
