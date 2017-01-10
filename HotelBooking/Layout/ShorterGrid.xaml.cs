using HotelBooking.Models;
using HotelBooking.Pages;
using System.Windows;
using System.Windows.Controls;

namespace HotelBooking.Facility
{
    /// <summary>
    /// Interaction logic for ShorterGrid.xaml
    /// </summary>
    public partial class ShorterGrid : UserControl
    {
        private static string classicRoomName;
        private static double classicRoomCost;
        private static string deluxeRoomName;
        private static double deluxeRoomCost;
        private static string prestigeRoomName;
        private static double prestigeRoomCost;

        private static string theGoldenName;
        private static double theGoldenCost;
        private static string theVintageName;
        private static double theVintageCost;
        private static string theWillowName;
        private static double theWillowCost;

        public ShorterGrid()
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

        private void BookNowButton_Click(object sender, RoutedEventArgs e)
        {
            Model model = Application.Current.Properties["PageData"] as Model;
            if (model.Name == "Classic Room")
            {
                //scheduler to loop through all the room ids to check for availability
                bool bookingFull = false;
                int facilityId = 0;
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
                                        facilityId = ids.id;
                                        break;
                                    }
                                    //booking full on selected dates
                                    else if (BookingStart.SelectedDate.Equals(start.dates)
                                        || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate.Equals(end.dates))
                                    {
                                        bookingFull = true;
                                    }
                                    else if (BookingStart.SelectedDate != start.dates
                                        || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate > end.dates
                                        || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate > end.dates
                                        || BookingEnd.SelectedDate != end.dates)
                                    {
                                        facilityId = ids.id;
                                        bookingFull = false;
                                        break;
                                    }
                                }
                            }
                            if (facilityId > 0) break;
                        }
                    }
                }
                //when booking dates not chosen, user is alerted to select the dates
                if (BookingStart.SelectedDate == null || BookingEnd.SelectedDate == null)
                {
                    MessageBox.Show("Please choose your booking dates");
                }
                //calls scheduler methods to check if booking is full on selected dates
                else if (bookingFull == true)
                {
                    MessageBox.Show("The booking's that you've chosen are currently full");
                }
                //When booking start date is before end date, prompt user about it
                else if (BookingEnd.SelectedDate < BookingStart.SelectedDate)
                {
                    MessageBox.Show("Your booking end date cannot be before your booking start date!");
                }
                //Add item to Cart
                else
                {
                    //Add to cart
                    CartItem Item = new CartItem()
                    {
                        itemName = classicRoomName,
                        BookingStart = BookingStart.SelectedDate.Value,
                        BookingEnd = BookingEnd.SelectedDate.Value,
                        cost = classicRoomCost,
                        itemId = facilityId
                    };
                    MainWindow.Cart.Add(Item);
                }
            }
            else if (model.Name == "Deluxe Room")
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
                                    //booking full on selected dates
                                    else if (BookingStart.SelectedDate.Equals(start.dates)
                                        || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate.Equals(end.dates))
                                    {
                                        bookingFull = true;
                                    }
                                    else if (BookingStart.SelectedDate != start.dates
                                       || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate > end.dates
                                       || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate > end.dates
                                       || BookingEnd.SelectedDate != end.dates)
                                    {
                                        facilityId = ids.id;
                                        bookingFull = false;
                                        break;
                                    }
                                }
                            }
                            if (facilityId > 0) break;
                        }
                    }
                }
                //when booking dates not chosen, user is alerted to select the dates
                if (BookingStart.SelectedDate == null || BookingEnd.SelectedDate == null)
                {
                    MessageBox.Show("Please choose your booking dates");
                }
                //calls scheduler methods to check if booking is full on selected dates
                else if (bookingFull == true)
                {
                    MessageBox.Show("The booking's that you've chosen are currently full");
                }
                else if (BookingEnd.SelectedDate < BookingStart.SelectedDate)
                {
                    MessageBox.Show("Your booking end date cannot be before your booking start date!");
                }
                //When booking start date is before end date, prompt user about it
                else
                {
                    //Add to cart
                    CartItem Item = new CartItem()
                    {
                        itemName = deluxeRoomName,
                        BookingStart = BookingStart.SelectedDate.Value,
                        BookingEnd = BookingEnd.SelectedDate.Value,
                        cost = deluxeRoomCost,
                        itemId = facilityId
                    };
                    MainWindow.Cart.Add(Item);
                }
            }
            else if (model.Name == "Prestige Room")
            {
                //scheduler to loop through all the room ids to check for availability
                bool bookingFull = false;
                int facilityId = 0;
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
                                        facilityId = ids.id;
                                        break;
                                    }
                                    //booking full on selected dates
                                    else if (BookingStart.SelectedDate.Equals(start.dates)
                                        || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate.Equals(end.dates))
                                    {
                                        bookingFull = true;
                                    }
                                    else if (BookingStart.SelectedDate != start.dates
                                       || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate > end.dates
                                       || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate > end.dates
                                       || BookingEnd.SelectedDate != end.dates)
                                    {
                                        facilityId = ids.id;
                                        bookingFull = false;
                                        break;
                                    }
                                }
                            }
                            if (facilityId > 0) break;
                        }
                    }
                }
                //when booking dates not chosen, user is alerted to select the dates
                if (BookingStart.SelectedDate == null || BookingEnd.SelectedDate == null)
                {
                    MessageBox.Show("Please choose your booking dates");
                }
                //calls scheduler methods to check if booking is full on selected dates
                else if (bookingFull == true)
                {
                    MessageBox.Show("The booking's that you've chosen are currently full");
                }
                //When booking start date is before end date, prompt user about it
                else if (BookingEnd.SelectedDate < BookingStart.SelectedDate)
                {
                    MessageBox.Show("Your booking end date cannot be before your booking start date!");
                }
                else
                {
                    //Add to cart
                    CartItem Item = new CartItem()
                    {
                        itemName = prestigeRoomName,
                        BookingStart = BookingStart.SelectedDate.Value,
                        BookingEnd = BookingEnd.SelectedDate.Value,
                        cost = prestigeRoomCost,
                        itemId = facilityId
                    };
                    MainWindow.Cart.Add(Item);
                }
            }
            else if (model.Name == "The Golden")
            {
                //scheduler to loop through all the room ids to check for availability
                bool bookingFull = false;
                int facilityId = 0;
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
                                        facilityId = ids.id;
                                        break;
                                    }
                                    //booking full
                                    else if (BookingStart.SelectedDate.Equals(start.dates)
                                        || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate.Equals(end.dates))
                                    {
                                        bookingFull = true;
                                    }
                                    else if (BookingStart.SelectedDate != start.dates
                                       || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate > end.dates
                                       || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate > end.dates
                                       || BookingEnd.SelectedDate != end.dates)
                                    {
                                        facilityId = ids.id;
                                        bookingFull = false;
                                        break;
                                    }
                                }
                            }
                            if (facilityId > 0) break;
                        }
                    }
                }
                //when booking dates not chosen, user is alerted to select the dates
                if (BookingStart.SelectedDate == null || BookingEnd.SelectedDate == null)
                {
                    MessageBox.Show("Please choose your booking dates");

                }
                //Check if booking is full on selected dates for all selected facilities
                else if (bookingFull == true)
                {
                    MessageBox.Show("The booking's that you've chosen are currently full");
                }
                //When booking start date is before end date, prompt user about it
                else if (BookingEnd.SelectedDate < BookingStart.SelectedDate)
                {
                    MessageBox.Show("Your booking end date cannot be before your booking start date!");
                }
                //Add item to Cart
                else
                {
                    //Add to cart
                    CartItem Item = new CartItem()
                    {
                        itemName = theGoldenName,
                        BookingStart = BookingStart.SelectedDate.Value,
                        BookingEnd = BookingEnd.SelectedDate.Value,
                        cost = theGoldenCost,
                        itemId = facilityId
                    };
                    MainWindow.Cart.Add(Item);
                }
            }
            else if (model.Name == "The Vintage")
            {
                //scheduler to loop through all the room ids to check for availability
                bool bookingFull = false;
                int facilityId = 0;
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
                                        facilityId = ids.id;
                                        break;
                                    }
                                    //booking full on selected dates
                                    else if (BookingStart.SelectedDate.Equals(start.dates)
                                        || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate.Equals(end.dates))
                                    {
                                        bookingFull = true;
                                    }
                                    else if (BookingStart.SelectedDate != start.dates
                                       || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate > end.dates
                                       || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate > end.dates
                                       || BookingEnd.SelectedDate != end.dates)
                                    {
                                        facilityId = ids.id;
                                        bookingFull = false;
                                        break;
                                    }
                                }
                            }
                            if (facilityId > 0) break;
                        }
                    }
                }
                //when booking dates not chosen, user is alerted to select the dates
                if (BookingStart.SelectedDate == null || BookingEnd.SelectedDate == null)
                {
                    MessageBox.Show("Please choose your booking dates");
                }
                //calls scheduler methods to check if booking is full on selected dates
                else if (bookingFull == true)
                {
                    MessageBox.Show("The booking's that you've chosen are currently full");
                }
                //When booking start date is before end date, prompt user about it
                else if (BookingEnd.SelectedDate < BookingStart.SelectedDate)
                {
                    MessageBox.Show("Your booking end date cannot be before your booking start date!");
                }
                //Add to Cart
                else
                {
                    //Add to cart
                    CartItem Item = new CartItem()
                    {
                        itemName = theVintageName,
                        BookingStart = BookingStart.SelectedDate.Value,
                        BookingEnd = BookingEnd.SelectedDate.Value,
                        cost = theVintageCost,
                        itemId = facilityId
                    };
                    MainWindow.Cart.Add(Item);
                }
            }
            else if (model.Name == "The Willow")
            {
                //scheduler to loop through all the room ids to check for availability
                bool bookingFull = false;
                int facilityId = 0;
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
                                        facilityId = ids.id;
                                        break;
                                    }
                                    //if booking full on selected dates
                                    else if (BookingStart.SelectedDate.Equals(start.dates)
                                        || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate < end.dates
                                        || BookingEnd.SelectedDate.Equals(end.dates))
                                    {
                                        bookingFull = true;
                                    }
                                    else if (BookingStart.SelectedDate != start.dates
                                       || BookingStart.SelectedDate > start.dates && BookingStart.SelectedDate > end.dates
                                       || BookingEnd.SelectedDate > start.dates && BookingEnd.SelectedDate > end.dates
                                       || BookingEnd.SelectedDate != end.dates)
                                    {
                                        facilityId = ids.id;
                                        bookingFull = false;
                                        break;
                                    }
                                }
                            }
                            if (facilityId > 0) break;
                        }
                    }
                }
                //when booking dates not chosen, user is alerted to select the dates
                if (BookingStart.SelectedDate == null || BookingEnd.SelectedDate == null)
                {
                    MessageBox.Show("Please choose your booking dates");
                }
                //calls scheduler methods to check if booking is full on selected dates
                else if (bookingFull == true)
                {
                    MessageBox.Show("The booking's that you've chosen are currently full");
                }
                //When booking start date is before end date, prompt user about it
                else if (BookingEnd.SelectedDate < BookingStart.SelectedDate)
                {
                    MessageBox.Show("Your booking end date cannot be before your booking start date!");
                }
                //Add to Cart
                else
                {
                    //Add to cart
                    CartItem Item = new CartItem()
                    {
                        itemName = theWillowName,
                        BookingStart = BookingStart.SelectedDate.Value,
                        BookingEnd = BookingEnd.SelectedDate.Value,
                        cost = theWillowCost,
                        itemId = facilityId
                    };
                    MainWindow.Cart.Add(Item);
                }
            }
        }
    }
}
