using HotelBooking.Models;
using HotelBooking.Pages;
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

namespace HotelBooking.Facility
{
    /// <summary>
    /// Interaction logic for BuffetLongerGrid.xaml
    /// </summary>
    public partial class BuffetLongerGrid : UserControl
    {
        private static string westernName;
        private static double westernCost;
        private static string chineseName;
        private static double chineseCost;
        private static string italianName;
        private static double italianCost;

        public BuffetLongerGrid()
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

        private void BookNowButton_Click(object sender, RoutedEventArgs e)
        {
            Model model = Application.Current.Properties["PageData"] as Model;
            if (model.Name == "Western")
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
                            foreach (var booking in ids.bookings)
                            {
                                if (booking.dates == null)
                                {
                                    bookingFull = false;
                                    facilityId = ids.id;
                                    break;
                                }
                                //Booking full on selected date
                                else if (BookingStart.SelectedDate.Equals(booking.dates))
                                {
                                    bookingFull = true;
                                }
                                else if (BookingStart.SelectedDate != booking.dates)
                                {
                                    bookingFull = false;
                                    facilityId = ids.id;
                                    break;
                                }
                            }
                        }
                        if (facilityId > 0) break;
                    }
                }
                //when booking dates not chosen, user is alerted to select the dates
                if (BookingStart == null)
                {
                    MessageBox.Show("Please choose your booking dates");
                }
                //Check if booking is full on selected dates for all selected facilities
                else if (bookingFull == true)
                {
                    MessageBox.Show("The booking's that you've chosen are currently full");
                }
                //Add item to Cart
                else
                {
                    //Add to cart
                    CartItem Item = new CartItem()
                    {
                        itemName = westernName,
                        BookingStart = BookingStart.SelectedDate.Value,
                        BookingEnd = BookingStart.SelectedDate.Value,
                        cost = westernCost,
                        itemId = facilityId
                    };
                    MainWindow.Cart.Add(Item);                }
            }
            else if (model.Name == "Chinese")
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
                            foreach (var booking in ids.bookings)
                            {
                                if (booking.dates == null)
                                {
                                    bookingFull = false;
                                    facilityId = ids.id;
                                    break;
                                }
                                //booking full on selected dates
                                else if (BookingStart.SelectedDate.Equals(booking.dates))
                                {
                                    bookingFull = true;
                                }
                                else if (BookingStart.SelectedDate != booking.dates)
                                {
                                    bookingFull = false;
                                    facilityId = ids.id;
                                    break;
                                }
                            }
                        }
                        if (facilityId > 0) break;
                    }
                }
                //when booking dates not chosen, user is alerted to select the dates
                if (BookingStart.SelectedDate == null)
                {
                    MessageBox.Show("Please choose your booking dates");
                }
                //Check if booking is full on selected dates for all selected facilities
                else if (bookingFull == true)
                {
                    MessageBox.Show("The booking's that you've chosen are currently full");
                }
                //Add item to Cart
                else
                {
                    //Add to cart
                    CartItem Item = new CartItem()
                    {
                        itemName = chineseName,
                        BookingStart = BookingStart.SelectedDate.Value,
                        BookingEnd = BookingStart.SelectedDate.Value,
                        cost = chineseCost,
                        itemId = facilityId
                    };
                    MainWindow.Cart.Add(Item);
                }
            }
            else if (model.Name == "Italian")
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
                            foreach (var booking in ids.bookings)
                            {
                                if (booking.dates == null)
                                {
                                    bookingFull = false;
                                    facilityId = ids.id;
                                    break;
                                }
                                //booking full on selected dates
                                else if (BookingStart.SelectedDate.Equals(booking.dates))
                                {
                                    bookingFull = true;
                                }
                                else if (BookingStart.SelectedDate != booking.dates)
                                {
                                    bookingFull = false;
                                    facilityId = ids.id;
                                    break;
                                }
                            }
                        }
                        if (facilityId > 0) break;
                    }
                }
                //when booking dates not chosen, user is alerted to select the dates
                if (BookingStart.SelectedDate == null)
                {
                    MessageBox.Show("Please choose your booking dates");
                }
                //Check if booking is full on selected dates for all selected facilities
                else if (bookingFull == true)
                {
                    MessageBox.Show("The booking's that you've chosen are currently full");
                }
                //Add item to Cart
                else
                {
                    //Add to cart
                    CartItem Item = new CartItem()
                    {
                        itemName = italianName,
                        BookingStart = BookingStart.SelectedDate.Value,
                        BookingEnd = BookingStart.SelectedDate.Value,
                        cost = italianCost,
                        itemId = facilityId
                    };
                    MainWindow.Cart.Add(Item);
                }
            }
        }
    }
}
