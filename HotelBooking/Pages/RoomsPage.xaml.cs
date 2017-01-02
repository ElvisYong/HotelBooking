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
        private static string deluxeRoomName;
        private static double deluxeRoomCost;
        private static string premiumRoomName;
        private static double premiumRoomCost;
        private static string familyRoomName;
        private static double familyRoomCost;
        private static string vipRoomName;
        private static double vipRoomCost;

        public RoomsPage()
        {
            InitializeComponent();
            foreach (var item in MainWindow.resource.hotelRooms)
            {
                if (item.roomType.Equals("Deluxe Room"))
                {
                    deluxeRoomName = item.roomType;
                    deluxeRoomCost = item.cost;
                }
                else if (item.roomType.Equals("Premium Room"))
                {
                    premiumRoomName = item.roomType;
                    premiumRoomCost = item.cost;
                }
                else if (item.roomType.Equals("Family Room"))
                {
                    familyRoomName = item.roomType;
                    familyRoomCost = item.cost;
                }
                else if (item.roomType.Equals("VIP Room"))
                {
                    vipRoomName = item.roomType;
                    vipRoomCost = item.cost;
                }
            }
        }
        
        private void DeluxeRoomButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int facilityId = 0;
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
                                    facilityId = ids.id;
                                    break;
                                }
                                else if (DeluxeRoomBookingStart.SelectedDate.Equals(start.dates)
                                    || DeluxeRoomBookingStart.SelectedDate > start.dates && DeluxeRoomBookingStart.SelectedDate < end.dates
                                    || DeluxeRoomBookingEnd.SelectedDate > start.dates && DeluxeRoomBookingEnd.SelectedDate < end.dates
                                    || DeluxeRoomBookingEnd.SelectedDate.Equals(end.dates))
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
            //When booking start date is before end date, prompt user about it
            else if (DeluxeRoomBookingEnd.SelectedDate < DeluxeRoomBookingStart.SelectedDate)
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
                    itemName = deluxeRoomName,
                    BookingStart = DeluxeRoomBookingStart.SelectedDate.Value,
                    BookingEnd = DeluxeRoomBookingEnd.SelectedDate.Value,
                    cost = deluxeRoomCost,
                    itemId = facilityId
                };
                MainWindow.Cart.Add(Item);
                DeluxeRoomButton.IsEnabled = false;
            }
        }

        private void PremiumRoomButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int facilityId = 0;
            foreach (var item in MainWindow.resource.hotelRooms)
            {
                if (item.roomType.Equals("Premium Room"))
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
                                    facilityId = ids.id;
                                    break;
                                }
                                else if (PremiumRoomBookingEnd.SelectedDate.Equals(start.dates)
                                    || PremiumRoomBookingStart.SelectedDate > start.dates && PremiumRoomBookingStart.SelectedDate < end.dates
                                    || PremiumRoomBookingEnd.SelectedDate > start.dates && PremiumRoomBookingEnd.SelectedDate < end.dates
                                    || PremiumRoomBookingEnd.SelectedDate.Equals(end.dates))
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
            if (PremiumRoomBookingStart.SelectedDate == null || PremiumRoomBookingEnd.SelectedDate == null)
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
            else if (PremiumRoomBookingEnd.SelectedDate < PremiumRoomBookingStart.SelectedDate)
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
                    itemName = premiumRoomName,
                    BookingStart = PremiumRoomBookingStart.SelectedDate.Value,
                    BookingEnd = PremiumRoomBookingEnd.SelectedDate.Value,
                    cost = premiumRoomCost,
                    itemId = facilityId
                };
                MainWindow.Cart.Add(Item);
                PremiumRoomButton.IsEnabled = false;
            }
        }

        private void FamilyRoomButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int facilityId = 0;
            foreach (var item in MainWindow.resource.hotelRooms)
            {
                if (item.roomType.Equals("Family Room"))
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
                                    facilityId = ids.id;
                                    break;
                                }
                                else if (FamilyRoomBookingStart.SelectedDate.Equals(start.dates)
                                    || FamilyRoomBookingStart.SelectedDate > start.dates && FamilyRoomBookingStart.SelectedDate < end.dates
                                    || FamilyRoomBookingEnd.SelectedDate > start.dates && FamilyRoomBookingEnd.SelectedDate < end.dates
                                    || FamilyRoomBookingEnd.SelectedDate.Equals(end.dates))
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
            if (FamilyRoomBookingStart.SelectedDate == null || FamilyRoomBookingEnd.SelectedDate == null)
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
            else if (FamilyRoomBookingEnd.SelectedDate < FamilyRoomBookingStart.SelectedDate)
            {
                Popups.DateError BookingError = new Popups.DateError();
                BookingError.Show();
            }
            else
            {
                //Add to cart
                CartItem Item = new CartItem()
                {
                    itemName = familyRoomName,
                    BookingStart = FamilyRoomBookingStart.SelectedDate.Value,
                    BookingEnd = FamilyRoomBookingEnd.SelectedDate.Value,
                    cost = familyRoomCost,
                    itemId = facilityId
                };
                MainWindow.Cart.Add(Item);
                FamilyRoomButton.IsEnabled = false;
            }
        }

        private void VipRoomButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int facilityId = 0;
            foreach (var item in MainWindow.resource.hotelRooms)
            {
                if (item.roomType.Equals("VIP Room"))
                {
                    foreach (var ids in item.roomId)
                    {
                        foreach (var start in ids.bookingStart)
                        {
                            foreach (var end in ids.bookingEnd){
                                if (start.dates == null && end.dates == null)
                                {
                                    bookingFull = false;
                                    facilityId = ids.id;
                                    break;
                                }
                                else if (VipRoomBookingStart.SelectedDate.Equals(start.dates)
                                    || VipRoomBookingStart.SelectedDate > start.dates && VipRoomBookingStart.SelectedDate < end.dates
                                    || VipRoomBookingEnd.SelectedDate > start.dates && VipRoomBookingEnd.SelectedDate < end.dates
                                    || VipRoomBookingEnd.SelectedDate.Equals(end.dates))
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
            if (VipRoomBookingStart.SelectedDate == null || VipRoomBookingEnd.SelectedDate == null)
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
            else if (VipRoomBookingEnd.SelectedDate < VipRoomBookingStart.SelectedDate)
            {
                Popups.DateError BookingError = new Popups.DateError();
                BookingError.Show();
            }
            else
            {
                //Add to cart
                CartItem Item = new CartItem()
                {
                    itemName = vipRoomName,
                    BookingStart = VipRoomBookingStart.SelectedDate.Value,
                    BookingEnd = VipRoomBookingEnd.SelectedDate.Value,
                    cost = vipRoomCost,
                    itemId = facilityId
                };
                MainWindow.Cart.Add(Item);
                VipRoomButton.IsEnabled = false;
            }
        }
        //For buttons to be renabled during checkout
        public void EnableButtons()
        {
            DeluxeRoomButton.IsEnabled = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Cart.Clear();
            DeluxeRoomButton.IsEnabled = true;
            PremiumRoomButton.IsEnabled = true;
            FamilyRoomButton.IsEnabled = true;
            VipRoomButton.IsEnabled = true;
        }
    }
}
