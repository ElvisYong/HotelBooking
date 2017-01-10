using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace HotelBooking.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Rooms : Page
    {
        private Model model = new Model();

        public Rooms()
        {
            InitializeComponent();
        }

        //Events to send values for the UI display when buttons are clicked
        private void ClassicRoom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            model.Name = "Classic Room";
            model.ListTitle = "Includes:";
            model.ListDesc = new List<string>
            {
                "Bathrobes (Complimentary)",
                "Slippers (Complimentary)",
                "Toiletries (Complimentary)",
                "Food and Beverages (Pay as you take)",
                "Safe",
                "Television"
            };
            model.ItemDesc = "The Classic Rooms in Grandtel. They are bright and airy thanks to the high ceilings and tall windows, which capture Rome’s beautiful light. Their exquisite design incorporates fine fabrics and beautiful woodworks.Modern luxuries include master controlled lighting and climate control, Wi - Fi, Bang and Olufsen televisions. Revel in the sleek new bathrooms decorated in white and woody hues, we are sure you will enjoy your stay.";
            model.ImagePath = "/HotelBooking;component/RoomPictures/ClassicRoom.jpg";
            Application.Current.Properties["PageData"] = model;
            ns.Navigate(new Uri("/HotelBooking;component/Layout/LayoutPage.xaml", UriKind.Relative));
        }

        private void DeluxeRoom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            model.Name = "Deluxe Room";
            model.ListTitle = "Includes:";
            model.ListDesc = new List<string>
            {
                "Bathrobes (Complimentary)",
                "Slippers (Complimentary)",
                "Toiletries (Complimentary)",
                "Food and Beverages (Pay as you take)",
                "Safe",
                "Television"
            };
            model.ItemDesc = "Your dream escape awaits at Grandtel. The Deluxe Room welcomes you with warm, earth toned furnishings and abundant natural light from the large balcony windows. The queen size bed will be a serene place to rest your tired body at the end of the day. A huge hot tub will also help you in your rest as you relax in the large bath much like the hot springs in Japan.";
            model.ImagePath = "/HotelBooking;component/RoomPictures/DeluxeRoom.jpg";
            Application.Current.Properties["PageData"] = model;
            ns.Navigate(new Uri("/HotelBooking;component/Layout/LayoutPage.xaml", UriKind.Relative));
        }

        private void PrestigeRoom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            model.Name = "Prestige Room";
            model.ListTitle = "Includes:";
            model.ListDesc = new List<string>
            {
                "Bathrobes (Complimentary)",
                "Slippers (Complimentary)",
                "Toiletries (Complimentary)",
                "Food and Beverages (Pay as you take)",
                "Safe",
                "Television"
            };
            model.ItemDesc = "These sophisticated and elegant Prestige Rooms at Grandtel are decorated with timeless Italian furnishings. With soaring ceilings and tall windows, which have been designed to make the most of the natural daylight. Enjoy fine fabrics and exquisite design.";
            model.ImagePath = "/HotelBooking;component/RoomPictures/PrestigeRoom.jpg";
            Application.Current.Properties["PageData"] = model;
            ns.Navigate(new Uri("/HotelBooking;component/Layout/LayoutPage.xaml", UriKind.Relative));
        }
    }
}
