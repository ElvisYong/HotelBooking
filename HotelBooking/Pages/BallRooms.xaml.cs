using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace HotelBooking.Pages
{
    /// <summary>
    /// Interaction logic for Ballrooms.xaml
    /// </summary>
    public partial class Ballrooms : Page
    {
        private Model model = new Model();

        public Ballrooms()
        {
            InitializeComponent();
        }

        //Events to send values for the UI display when buttons are clicked
        private void Golden_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            model.Name = "The Golden";
            model.ListTitle = "Includes:";
            model.ListDesc = new List<string>
            {
                "Stage",
                "Audio Visual Assistance",
                "Microphones",
                "Course Meals (if ordered)",
                "Piano (if needed)"
            };
            model.ItemDesc = "The Golden is a ballroom perfect for any event you are planning to host. As the name implies, the room is mostly decorated in gold. With gold chandeliers and paintings.The walls are also painted a shade of gold.It was a surround sound system for musics to be played and a stage too, perfect for any performances or talks.A mouth watering course meal can also be ordered for event-goers.";
            model.ImagePath = "/HotelBooking;component/BallroomPictures/TheGolden.jpg";
            Application.Current.Properties["PageData"] = model;
            ns.Navigate(new Uri("/HotelBooking;component/Layout/LayoutPage.xaml", UriKind.Relative));
        }

        private void Vintage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            model.Name = "The Vintage";
            model.ListTitle = "Includes:";
            model.ListDesc = new List<string>
            {
                "Stage",
                "Audio Visual Assistance",
                "Microphones",
                "Course Meals (if ordered)",
                "Piano (if needed)"
            };
            model.ItemDesc = "Grandtel's The Vintage is a great place to hold many events, be it weddings, business related or even just any form of celebrations. Our white themed ballroom has bright lightings, surround sound and a stage for any talks or performances.There is also a piano which can be brought out if needed.A mouth watering course meal can also be ordered for event-goers.";
            model.ImagePath = "/HotelBooking;component/BallroomPictures/TheVintage.jpg";
            Application.Current.Properties["PageData"] = model;
            ns.Navigate(new Uri("/HotelBooking;component/Layout/LayoutPage.xaml", UriKind.Relative));
        }

        private void Willow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            model.Name = "The Willow";
            model.ListTitle = "Includes:";
            model.ListDesc = new List<string>
            {
                "Stage",
                "Audio Visual Assistance",
                "Microphones",
                "Course Meals (if ordered)",
                "Piano (if needed)"
            };
            model.ItemDesc = "The Willow, a nice place to relax and talk about the good ol' times. The wood surroundings will surely make you feel relaxed during your stay for the event. The chandeliers will provide ample lighting for the place during the event. It was a surround sound system for musics to be played and a stage too, perfect for any performances or talks. A mouth watering course meal can also be ordered for event-goers.";
            model.ImagePath = "/HotelBooking;component/BallroomPictures/TheWillow.jpg";
            Application.Current.Properties["PageData"] = model;
            ns.Navigate(new Uri("/HotelBooking;component/Layout/LayoutPage.xaml", UriKind.Relative));
        }
    }
}