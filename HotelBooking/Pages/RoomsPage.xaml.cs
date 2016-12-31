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
    /// Interaction logic for RoomsPage.xaml
    /// </summary>
    public partial class RoomsPage : Page
    {
        private static string deluxeRoomName;
        private static int deluxeRoomAvailability;
        private static double deluxeRoomCost;
        private static string premiumRoomName;
        private static int premiumRoomAvailability;
        private static double premiumRoomCost;
        private static string familyRoomName;
        private static int familyRoomAvailability;
        private static double familyRoomCost;
        private static string vipRoomName;
        private static int vipRoomAvailability;
        private static double vipRoomCost;

        public RoomsPage()
        {
            InitializeComponent();
            foreach (var item in MainWindow.resource.hotelRooms)
            {
                if (item.roomType.Equals("Deluxe Room"))
                {
                    deluxeRoomName = item.roomType;
                    deluxeRoomAvailability = item.availability;
                    deluxeRoomCost = item.cost;
                }
                else if (item.roomType.Equals("Premium Room"))
                {
                    premiumRoomName = item.roomType;
                    premiumRoomAvailability = item.availability;
                    premiumRoomCost = item.cost;
                }
                else if (item.roomType.Equals("Family Room"))
                {
                    familyRoomName = item.roomType;
                    familyRoomAvailability = item.availability;
                    familyRoomCost = item.cost;
                }
                else if (item.roomType.Equals("VIP Room"))
                {
                    vipRoomName = item.roomType;
                    vipRoomAvailability = item.availability;
                    vipRoomCost = item.cost;
                }
            }
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
            else if (deluxeRoomAvailability == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //When booking start date is before end date, prompt user about it
            else if (DeluxeRoomBookingEnd.SelectedDate.Value < DeluxeRoomBookingStart.SelectedDate.Value)
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
                    cost = deluxeRoomCost
                };
                MainWindow.Cart.Add(Item);
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
            else if (premiumRoomAvailability == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            else if (PremiumRoomBookingEnd.SelectedDate.Value < PremiumRoomBookingStart.SelectedDate.Value)
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
                    cost = premiumRoomCost
                };
                MainWindow.Cart.Add(Item);
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
            else if (familyRoomAvailability == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //When booking start date is before end date, prompt user about it
            else if (FamilyRoomBookingEnd.SelectedDate.Value < FamilyRoomBookingStart.SelectedDate.Value)
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
                    cost = familyRoomCost
                };
                MainWindow.Cart.Add(Item);
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
            else if (vipRoomAvailability == 0)
            {
                Popups.BookingFull PopupFull = new Popups.BookingFull();
                PopupFull.Show();
            }
            //When booking start date is before end date, prompt user about it
            else if (VipRoomBookingEnd.SelectedDate.Value < VipRoomBookingStart.SelectedDate.Value)
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
                    cost = vipRoomCost
                };
                MainWindow.Cart.Add(Item);
            }

        }
    }
}
