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
    /// Interaction logic for DiningPage.xaml
    /// </summary>
    public partial class DiningPage : Page
    {
        private static string westernName;
        private static double westernCost;
        private static string chineseName;
        private static double chineseCost;
        private static string italianName;
        private static double italianCost;
        public DiningPage()
        {
            InitializeComponent();
            foreach (var item in MainWindow.resource.dining)
            {
                if (item.restrauntType.Equals("Western"))
                {
                    westernName = item.restrauntType;
                    westernCost = item.cost;
                }
                else if (item.restrauntType.Equals("Chinese"))
                {
                    chineseName = item.restrauntType;
                    chineseCost = item.cost;
                }
                else if (item.restrauntType.Equals("Italian"))
                {
                    italianName = item.restrauntType;
                    italianCost = item.cost;
                }
            }
        }

        private void WesternButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int facilityId = 0;
            foreach (var item in MainWindow.resource.dining)
            {
                if (item.restrauntType.Equals("Western"))
                {
                    foreach (var ids in item.tableId)
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
                                else if (WesternBookingStart.SelectedDate.Equals(start.dates)
                                    || WesternBookingStart.SelectedDate > start.dates && WesternBookingStart.SelectedDate < end.dates
                                    || WesternBookingEnd.SelectedDate > start.dates && WesternBookingEnd.SelectedDate < end.dates
                                    || WesternBookingEnd.SelectedDate.Equals(end.dates))
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
            if (WesternBookingStart.SelectedDate == null || WesternBookingEnd.SelectedDate == null)
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
            else if (WesternBookingEnd.SelectedDate < WesternBookingStart.SelectedDate)
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
                    itemName = westernName,
                    BookingStart = WesternBookingStart.SelectedDate.Value,
                    BookingEnd = WesternBookingEnd.SelectedDate.Value,
                    cost = westernCost,
                    itemId = facilityId
                };
                MainWindow.Cart.Add(Item);
                WesternButton.IsEnabled = false;
            }
        }

        private void ChineseButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int facilityId = 0;
            foreach (var item in MainWindow.resource.dining)
            {
                if (item.restrauntType.Equals("Chinese"))
                {
                    foreach (var ids in item.tableId)
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
                                else if (ChineseBookingStart.SelectedDate.Equals(start.dates)
                                    || ChineseBookingStart.SelectedDate > start.dates && ChineseBookingStart.SelectedDate < end.dates
                                    || ChineseBookingEnd.SelectedDate > start.dates && ChineseBookingEnd.SelectedDate < end.dates
                                    || ChineseBookingEnd.SelectedDate.Equals(end.dates))
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
            if (ChineseBookingStart.SelectedDate == null || ChineseBookingEnd.SelectedDate == null)
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
            else if (ChineseBookingEnd.SelectedDate < ChineseBookingStart.SelectedDate)
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
                    itemName = chineseName,
                    BookingStart = ChineseBookingStart.SelectedDate.Value,
                    BookingEnd = ChineseBookingEnd.SelectedDate.Value,
                    cost = chineseCost,
                    itemId = facilityId
                };
                MainWindow.Cart.Add(Item);
                ChineseButton.IsEnabled = false;
            }
        }

        private void ItalianButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int facilityId = 0;
            foreach (var item in MainWindow.resource.dining)
            {
                if (item.restrauntType.Equals("Italian"))
                {
                    foreach (var ids in item.tableId)
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
                                else if (ItalianBookingStart.SelectedDate.Equals(start.dates)
                                    || ItalianBookingStart.SelectedDate > start.dates && ItalianBookingStart.SelectedDate < end.dates
                                    || ItalianBookingEnd.SelectedDate > start.dates && ItalianBookingEnd.SelectedDate < end.dates
                                    || ItalianBookingEnd.SelectedDate.Equals(end.dates))
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
            if (ItalianBookingStart.SelectedDate == null || ItalianBookingEnd.SelectedDate == null)
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
            else if (ItalianBookingEnd.SelectedDate < ItalianBookingStart.SelectedDate)
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
                    itemName = italianName,
                    BookingStart = ItalianBookingStart.SelectedDate.Value,
                    BookingEnd = ItalianBookingEnd.SelectedDate.Value,
                    cost = italianCost,
                    itemId = facilityId
                };
                MainWindow.Cart.Add(Item);
                ItalianButton.IsEnabled = false;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Cart.Clear();
            WesternButton.IsEnabled = true;
            ChineseButton.IsEnabled = true;
            ItalianButton.IsEnabled = true;
        }
    }
}
