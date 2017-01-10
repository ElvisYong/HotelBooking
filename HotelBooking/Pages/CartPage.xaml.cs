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
//insert
using System.Collections.ObjectModel;
using HotelBooking.Models;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace HotelBooking.Pages
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {

        public CartPage()
        {
            InitializeComponent();
            CartListBox.ItemsSource = MainWindow.Cart;
            totalCostTB.Text = string.Format("Total cost: {0:C}", Transaction.TotalCartCost());
        }
        private static ObservableCollection<Transaction> transaction;
        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
            //If the list of receipt is empty, create one
            if(MainWindow.Details == null)
            {
                MainWindow.Details = new ObservableCollection<ObservableCollection<Transaction>>();
            }
            //If list of item in receipt is empty, create one
            if(transaction == null)
            {
                transaction = new ObservableCollection<Transaction>();
            }

            foreach(var item in MainWindow.Cart)
            {
                foreach(var res in MainWindow.resource.hotelRooms)
                {
                    if (item.itemName.Equals(res.roomType))
                    {
                        foreach(var ids in res.roomId)
                        {
                            foreach(var start in ids.bookingStart)
                            {
                                foreach(var end in ids.bookingEnd)
                                {
                                    if(start.dates == null && end.dates == null)
                                    {
                                        item.itemId = ids.id;
                                        break;
                                    }
                                }
                                break;
                            }
                            break;
                        }
                    }
                    break;
                }
            }

            foreach (var item in MainWindow.Cart)
            {
                transaction.Add(new Transaction
                {
                    TransactionBookingStart = item.BookingStart,
                    TransactionBookingEnd = item.BookingEnd,
                    ItemName = item.itemName,
                    TransactionItemId = item.itemId,
                    TransactionSubtotal = item.subTotal,
                });
            }
            
            //Add the list of transaction items into the list of receipts
            MainWindow.Details.Add(transaction);
            //Serialize objects into BookingDetails to store receipts
            string data = JsonConvert.SerializeObject(MainWindow.Details, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"C: \Users\elvis\Desktop\AppD\Assignment1\HotelBookings\HotelBooking\HotelBooking\BookedDetails.json", data);

            foreach(var items in MainWindow.Cart)
            {
                foreach(var hotelItems in MainWindow.resource.hotelRooms)
                {
                    if (items.itemName.Equals("Classic Room"))
                    {
                        foreach (var ids in hotelItems.roomId)
                        {
                            if (items.itemId == ids.id)
                            {
                                foreach (var start in ids.bookingStart)
                                {
                                    foreach (var end in ids.bookingEnd)
                                    {
                                        start.dates = items.BookingStart;
                                        end.dates = items.BookingEnd;
                                    }
                                } 
                            }
                        }
                    }
                    if(items.itemName.Equals("Deluxe Room"))
                    {
                        foreach(var ids in hotelItems.roomId)
                        {
                            foreach (var start in ids.bookingStart)
                            {
                                foreach (var end in ids.bookingEnd)
                                {
                                    if (items.itemId == ids.id)
                                    {
                                        start.dates = items.BookingStart;
                                        end.dates = items.BookingEnd;
                                    }
                                }
                            }
                        }
                    }
                    if (items.itemName.Equals("Prestige Room"))
                    {
                        foreach (var ids in hotelItems.roomId)
                        {
                            foreach (var start in ids.bookingStart)
                            {
                                foreach (var end in ids.bookingEnd)
                                {
                                    if (items.itemId == ids.id)
                                    {
                                        start.dates = items.BookingStart;
                                        end.dates = items.BookingEnd;
                                    }
                                }
                            }
                        }
                    }
                }
                foreach(var ballRoomItems in MainWindow.resource.ballRooms)
                {
                    if (items.itemName.Equals("The Golden"))
                    {
                        foreach (var ids in ballRoomItems.ballroomId)
                        {
                            foreach (var start in ids.bookingStart)
                            {
                                foreach (var end in ids.bookingEnd)
                                {
                                    if (items.itemId == ids.id)
                                    {
                                        start.dates = items.BookingStart;
                                        end.dates = items.BookingEnd;
                                    }
                                }
                            }
                        }
                    }
                    if (items.itemName.Equals("The Vintage"))
                    {
                        foreach (var ids in ballRoomItems.ballroomId)
                        {
                            foreach (var start in ids.bookingStart)
                            {
                                foreach (var end in ids.bookingEnd)
                                {
                                    if (items.itemId == ids.id)
                                    {
                                        start.dates = items.BookingStart;
                                        end.dates = items.BookingEnd;
                                    }
                                }
                            }
                        }
                    }
                    if (items.itemName.Equals("The Willow"))
                    {
                        foreach (var ids in ballRoomItems.ballroomId)
                        {
                            foreach (var start in ids.bookingStart)
                            {
                                foreach (var end in ids.bookingEnd)
                                {
                                    if (items.itemId == ids.id)
                                    {
                                        start.dates = items.BookingStart;
                                        end.dates = items.BookingEnd;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //edit BookingData json file to mark down dates booked
            string edited = JsonConvert.SerializeObject(MainWindow.resource, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"C: \Users\elvis\Desktop\AppD\Assignment1\HotelBookings\HotelBooking\HotelBooking\BookingData.json", edited);
            //clear cart so if user adds new item into cart, no item duplicate
            MainWindow.Cart.Clear();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Cart.Clear();
        }
    }
}
