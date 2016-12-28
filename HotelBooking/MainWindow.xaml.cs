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
using System.IO;
using Newtonsoft.Json;
using HotelBooking.Pages;

namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //local variable for Deluxe Room
        private static string deluxeRoomName = "";
        private static int deluxeRoomAvailability = 0;
        private static double deluxeRoomCost = 0;
        //local variable for Premium Room
        private static string premiumRoomName = "";
        private static int premiumRoomAvailability = 0;
        private static double premiumRoomCost = 0;
        //local variable for Family Room
        private static string familyRoomName = "";
        private static int familyRoomAvailability = 0;
        private static double familyRoomCost = 0;
        //local variable for VIP Room
        private static string vipRoomName = "";
        private static int vipRoomAvailability = 0;
        private static double vipRoomCost = 0;
        //local variable for Wedding Ballroom
        private static string wedBallroomName = "";
        private static int wedBallroomAvailability = 0;
        private static double wedBallroomCost = 0;
        //local variable for Large Ballroom
        private static string largeBallroomName = "";
        private static int largeBallroomAvailability = 0;
        private static double largeBallroomCost = 0;
        //local variable for Grand Ballroom
        private static string grandBallroomName = "";
        private static int grandBallroomAvailability = 0;
        private static double grandBallroomCost = 0;

        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Pages.Rooms();

            //too initialize cart
            ShoppingCart.InitializeCart();

            //To deseralize the json file
            string jsonReader = File.ReadAllText("BookingData.json");
            JsonProperties.ResourceType resource = JsonConvert.DeserializeObject<JsonProperties.ResourceType>(jsonReader);
            //Assign data to local variable for deluxe room
            foreach (var item in resource.hotelRooms)
            {
                if (item.roomType == "Deluxe Room")
                {
                    deluxeRoomName = item.roomType;
                    deluxeRoomAvailability = item.availability;
                    deluxeRoomCost = item.cost;
                }
            }
            //Assign data to local variable for Premium Room
            foreach(var item in resource.hotelRooms)
            {
                if (item.roomType == "Premium Room")
                {
                    premiumRoomName = item.roomType;
                    premiumRoomAvailability = item.availability;
                    premiumRoomCost = item.cost;
                }
            }
            //Assign data to local variable for Family Room
            foreach (var item in resource.hotelRooms)
            {
                if (item.roomType == "Family Room")
                {
                    familyRoomName = item.roomType;
                    familyRoomAvailability = item.availability;
                    familyRoomCost = item.cost;
                }
            }
            //Assign data to local variable for VIP Room
            foreach (var item in resource.hotelRooms)
            {
                if (item.roomType == "VIP Room")
                {
                    vipRoomName = item.roomType;
                    vipRoomAvailability = item.availability;
                    vipRoomCost = item.cost;
                }
            }
            //Assign data to local variable for Wedding Ballroom
            foreach (var item in resource.ballRooms)
            {
                if (item.ballroomType == "Wedding Ballroom")
                {
                    wedBallroomName = item.ballroomType;
                    wedBallroomAvailability = item.availability;
                    wedBallroomCost = item.cost;
                }
            }
            //Assign data to local variable for Large Ballroom
            foreach(var item in resource.ballRooms)
            {
                if (item.ballroomType == "Large Ballroom")
                {
                    largeBallroomName = item.ballroomType;
                    largeBallroomAvailability = item.availability;
                    largeBallroomCost = item.cost;
                }
            }
            //Assign data to local variable for Grand ballroom
            foreach (var item in resource.ballRooms)
            {
                if (item.ballroomType == "Grand Ballroom")
                {
                    grandBallroomName = item.ballroomType;
                    grandBallroomAvailability = item.availability;
                    grandBallroomCost = item.cost;
                }
            }
        }
        //Method to return Deluxe Room values
        public static string DeluxeRoomName()
        {
            return deluxeRoomName;
        }
        public static int DeluxeRoomAvailability()
        {
            return deluxeRoomAvailability;
        }
        public static double DeluxeRoomCost()
        {
            return deluxeRoomCost;
        }
        //method to return Premium Room vlaues
        public static string PremiumRoomName()
        {
            return premiumRoomName;
        }
        public static int PremiumRoomAvailability()
        {
            return premiumRoomAvailability;
        }
        public static double PremiumRoomCost()
        {
            return premiumRoomCost;
        }
        //method to return Family Room values
        public static string FamilyRoomName()
        {
            return familyRoomName;
        }
        public static int FamilyRoomAvailability()
        {
            return familyRoomAvailability;
        }
        public static double FamilyRoomCost()
        {
            return familyRoomCost;
        }
        //method to return VIP Room values
        public static string VipRoomName()
        {
            return vipRoomName;
        }
        public static int VipRoomAvailability()
        {
            return vipRoomAvailability;
        }
        public static double VipRoomCost()
        {
            return vipRoomCost;
        }
        //method to return Wedding Ballroom values
        public static string WedBallroomName()
        {
            return wedBallroomName;
        }
        public static int WedBallroomAvailability()
        {
            return wedBallroomAvailability;
        }
        public static double WedBallroomCost()
        {
            return wedBallroomCost;
        }
        //method to return Large Ballroom values
        public static string LargeBallroomName()
        {
            return largeBallroomName;
        }
        public static int LargeBallroomAvailability()
        {
            return largeBallroomAvailability;
        }
        public static double LargeBallroomCost()
        {
            return largeBallroomCost;
        }
        //method to return Grand Ballroom values
        public static string GrandBallroomName()
        {
            return grandBallroomName;
        }
        public static int GrandBallroomAvailability()
        {
            return grandBallroomAvailability;
        }
        public static double GrandBallroomCost()
        {
            return grandBallroomCost;
        }
        private void Rooms_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new Pages.Rooms();
        }

        private void Ballroom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new Pages.Ballrooms();
        }
    }
}
