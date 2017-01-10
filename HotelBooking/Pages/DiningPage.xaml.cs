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
            int breaker = 0;
            foreach (var item in MainWindow.resource.dining)
            { 
                if (item.restrauntType.Equals("Western"))
                {
                    foreach (var ids in item.tableId)
                    {
                        foreach (var date in ids.bookings)
                        {
                            if (date.dates == null)
                            {
                                bookingFull = false;
                                breaker = 1;
                                break;
                            }
                            else if (WesternBooking.SelectedDate.Equals(date.dates))
                            {
                                bookingFull = true;
                            }
                        }
                    }
                    if (breaker == 1) break;
                }
            }
            //when booking dates not chosen, user is alerted to select the dates
            if(WesternBooking.SelectedDate == null)
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
            //Add item to Cart
            else
            {
                //Add to cart
                CartItem Item = new CartItem()
                {
                    itemName = westernName,
                    BookingStart = WesternBooking.SelectedDate.Value,
                    BookingEnd = WesternBooking.SelectedDate.Value,
                    cost = westernCost,
                    itemImage = "string" //Add image source
                };
                MainWindow.Cart.Add(Item);
            }
        }

        private void ChineseButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int breaker = 0;
            foreach (var item in MainWindow.resource.dining)
            {
                if (item.restrauntType.Equals("Chinese"))
                {
                    foreach (var ids in item.tableId)
                    {
                        foreach (var date in ids.bookings)
                        {
                            if (date.dates == null)
                            {
                                bookingFull = false;
                                breaker = 1;
                                break;
                            }
                            else if (ChineseBooking.SelectedDate.Equals(date.dates))
                            {
                                bookingFull = true;
                            }
                        }
                        if (breaker == 1) break;
                    }
                }
            }
            //when booking dates not chosen, user is alerted to select the dates
            if (ChineseBooking.SelectedDate == null)
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
            //Add item to Cart
            else
            {
                //Add to cart
                CartItem Item = new CartItem()
                {
                    itemName = chineseName,
                    BookingStart = ChineseBooking.SelectedDate.Value,
                    BookingEnd = ChineseBooking.SelectedDate.Value,
                    cost = chineseCost,
                    itemImage = "string" //Add image source
                };
                MainWindow.Cart.Add(Item);
            }
        }

        private void ItalianButton_Click(object sender, RoutedEventArgs e)
        {
            //scheduler to loop through all the room ids to check for availability
            bool bookingFull = false;
            int breaker = 0;
            foreach (var item in MainWindow.resource.dining)
            {
                if (item.restrauntType.Equals("Italian"))
                {
                    foreach (var ids in item.tableId)
                    {
                        foreach (var date in ids.bookings)
                        {
                            if (date.dates == null)
                            {
                                bookingFull = false;
                                breaker = 1;
                                break;
                            }
                            else if (ItalianBooking.SelectedDate.Equals(date.dates))
                            {
                                bookingFull = true;
                            }
                        }
                        if (breaker == 1) break;
                    }
                }
            }
            //when booking dates not chosen, user is alerted to select the dates
            if (ItalianBooking.SelectedDate == null)
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
            //Add item to Cart
            else
            {
                //Add to cart
                CartItem Item = new CartItem()
                {
                    itemName = italianName,
                    BookingStart = ItalianBooking.SelectedDate.Value,
                    BookingEnd = ItalianBooking.SelectedDate.Value,
                    cost = italianCost,
                    itemImage = "string"//Add image source
                };
                MainWindow.Cart.Add(Item);
            }
        }
    }
}
