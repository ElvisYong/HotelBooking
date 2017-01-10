using HotelBooking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace HotelBooking.MainNavItems
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
            totalCostTB.Text = string.Format("Total cost: {0:C}", CartItem.TotalCartCost());
        }
        public static ObservableCollection<Transaction> transaction;
        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
            //If the list of receipt is empty, create one
            if (MainWindow.Details == null)
            {
                MainWindow.Details = new ObservableCollection<ObservableCollection<Transaction>>();
            }
            //If list of item in receipt is empty, create one
            if (transaction == null)
            {
                transaction = new ObservableCollection<Transaction>();
            }

            foreach (var items in MainWindow.Cart)
            {
                foreach (var hotelItems in MainWindow.resource.hotelRooms)
                {
                    if (items.itemName.Equals("Classic Room"))
                    {
                        foreach (var ids in hotelItems.roomId)
                        {
                            if (items.itemId == ids.id)
                            {
                                //Tolist() creates a copy for the loop to iterate while allowing editing of the list in a foreach loop
                                foreach (var start in ids.bookingStart.ToList())
                                {
                                    foreach (var end in ids.bookingEnd.ToList())
                                    {
                                        if (start.dates != null && end.dates != null)
                                        {
                                            ids.bookingStart.Add(new BookingStart { dates = items.BookingStart });
                                            ids.bookingEnd.Add(new BookingEnd { dates = items.BookingEnd });
                                            break;
                                        }
                                        else
                                        {
                                            start.dates = items.BookingStart;
                                            end.dates = items.BookingEnd;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    if (items.itemName.Equals("Deluxe Room"))
                    {
                        foreach (var ids in hotelItems.roomId)
                        {
                            if (items.itemId == ids.id)
                            {
                                //Tolist() creates a copy for the loop to iterate while allowing editing of the list in a foreach loop
                                foreach (var start in ids.bookingStart.ToList())
                                {
                                    foreach (var end in ids.bookingEnd.ToList())
                                    {

                                        if (start.dates != null && end.dates != null)
                                        {
                                            ids.bookingStart.Add(new BookingStart { dates = items.BookingStart });
                                            ids.bookingEnd.Add(new BookingEnd { dates = items.BookingEnd });
                                            break;
                                        }
                                        else
                                        {
                                            start.dates = items.BookingStart;
                                            end.dates = items.BookingEnd;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    if (items.itemName.Equals("Prestige Room"))
                    {
                        foreach (var ids in hotelItems.roomId)
                        {
                            if (items.itemId == ids.id)
                            {
                                //Tolist() creates a copy for the loop to iterate while allowing editing of the list in a foreach loop
                                foreach (var start in ids.bookingStart.ToList())
                                {
                                    foreach (var end in ids.bookingEnd.ToList())
                                    {

                                        if (start.dates != null && end.dates != null)
                                        {
                                            ids.bookingStart.Add(new BookingStart { dates = items.BookingStart });
                                            ids.bookingEnd.Add(new BookingEnd { dates = items.BookingEnd });
                                            break;
                                        }
                                        else
                                        {
                                            start.dates = items.BookingStart;
                                            end.dates = items.BookingEnd;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                foreach (var ballRoomItems in MainWindow.resource.ballRooms)
                {
                    if (items.itemName.Equals("The Golden"))
                    {
                        foreach (var ids in ballRoomItems.ballroomId)
                        {
                            if (items.itemId == ids.id)
                            {
                                //Tolist() creates a copy for the loop to iterate while allowing editing of the list in a foreach loop
                                foreach (var start in ids.bookingStart.ToList())
                                {
                                    foreach (var end in ids.bookingEnd.ToList())
                                    {


                                        if (start.dates != null && end.dates != null)
                                        {
                                            ids.bookingStart.Add(new BookingStart { dates = items.BookingStart });
                                            ids.bookingEnd.Add(new BookingEnd { dates = items.BookingEnd });
                                            break;
                                        }
                                        else
                                        {
                                            start.dates = items.BookingStart;
                                            end.dates = items.BookingEnd;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    if (items.itemName.Equals("The Vintage"))
                    {
                        foreach (var ids in ballRoomItems.ballroomId)
                        {
                            if (items.itemId == ids.id)
                            {
                                //Tolist() creates a copy for the loop to iterate while allowing editing of the list in a foreach loop
                                foreach (var start in ids.bookingStart.ToList())
                                {
                                    foreach (var end in ids.bookingEnd.ToList())
                                    {

                                        if (start.dates != null && end.dates != null)
                                        {
                                            ids.bookingStart.Add(new BookingStart { dates = items.BookingStart });
                                            ids.bookingEnd.Add(new BookingEnd { dates = items.BookingEnd });
                                            break;
                                        }
                                        else
                                        {
                                            start.dates = items.BookingStart;
                                            end.dates = items.BookingEnd;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    if (items.itemName.Equals("The Willow"))
                    {
                        foreach (var ids in ballRoomItems.ballroomId)
                        {
                            if (items.itemId == ids.id)
                            {
                                //Tolist() creates a copy for the loop to iterate while allowing editing of the list in a foreach loop
                                foreach (var start in ids.bookingStart.ToList())
                                {
                                    foreach (var end in ids.bookingEnd.ToList())
                                    {

                                        if (start.dates != null && end.dates != null)
                                        {
                                            ids.bookingStart.Add(new BookingStart { dates = items.BookingStart });
                                            ids.bookingEnd.Add(new BookingEnd { dates = items.BookingEnd });
                                            break;
                                        }
                                        else
                                        {
                                            start.dates = items.BookingStart;
                                            end.dates = items.BookingEnd;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (var dinner in MainWindow.resource.dining)
                {
                    if (items.itemName.Equals("Western"))
                    {
                        foreach (var ids in dinner.tableId)
                        {
                            if (items.itemId == ids.id)
                            {
                                //Tolist() creates a copy for the loop to iterate while allowing editing of the list in a foreach loop
                                foreach (var booking in ids.bookings.ToList())
                                {

                                    if (booking.dates != null)
                                    {
                                        ids.bookings.Add(new Bookings { dates = items.BookingStart });
                                        break;
                                    }
                                    else
                                    {
                                        booking.dates = items.BookingStart;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (items.itemName.Equals("Chinese"))
                    {
                        foreach (var ids in dinner.tableId)
                        {
                            if (items.itemId == ids.id)
                            {
                                //Tolist() creates a copy for the loop to iterate while allowing editing of the list in a foreach loop
                                foreach (var booking in ids.bookings.ToList())
                                {

                                    if (booking.dates != null)
                                    {
                                        ids.bookings.Add(new Bookings { dates = items.BookingStart });
                                        break;
                                    }
                                    else
                                    {
                                        booking.dates = items.BookingStart;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (items.itemName.Equals("Italian"))
                    {
                        foreach (var ids in dinner.tableId)
                        {
                            if (items.itemId == ids.id)
                            {
                                //Tolist() creates a copy for the loop to iterate while allowing editing of the list in a foreach loop
                                foreach (var booking in ids.bookings.ToList())
                                {

                                    if (booking.dates != null)
                                    {
                                        ids.bookings.Add(new Bookings { dates = items.BookingStart });
                                        break;
                                    }
                                    else
                                    {
                                        booking.dates = items.BookingStart;
                                        break;
                                    }
                                }
                            }
                        }
                    }
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

            //NEED TO USE DIRECT PATH TO READ WRITE FILE
            //Serialize objects into BookingDetails to store receipts
            string data = JsonConvert.SerializeObject(MainWindow.Details, Formatting.Indented);
            File.WriteAllText(@"BookedDetails.json", data);

            //edit BookingData json file to mark down dates booked
            string edited = JsonConvert.SerializeObject(MainWindow.resource, Formatting.Indented);
            File.WriteAllText(@"BookingData.json", edited);

            //clear cart so if user adds new item into cart, no item duplicate
            MainWindow.Cart.Clear();
            totalCostTB.Text = string.Format("Total cost: {0:C}", 0);
        }
    }
}
