using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace HotelBooking.Pages
{
    /// <summary>
    /// Interaction logic for Buffets.xaml
    /// </summary>
    public partial class Buffets : Page
    {
        private Model model = new Model();

        public Buffets()
        {
            InitializeComponent();
        }

        //Events to send values for the UI display when buttons are clicked
        private void Western_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            model.Name = "Western";
            model.ListTitle = "Menu includes:";
            model.ListDesc = new List<string>
            {
                "Scrambled Eggs",
                "Pancakes",
                "Cereal",
                "Mac N Cheese",
                "Apple Pie",
                "Milk",
                "Tea and Coffee"
            };
            model.ItemDesc = "Western serves Western cuisines from Apple Pies to Mac N Cheese. This buffet serves delicious cuisine from all over the 50 States in the United States.The environment is very soothing and relaxing, designed to look remind you of America, you will surely enjoy it as you eat your meal. (Only for Breakfast 0800-1100)";
            model.ImagePath = "/HotelBooking;component/BuffetPictures/Western.jpg";
            Application.Current.Properties["PageData"] = model;
            ns.Navigate(new Uri("/HotelBooking;component/Layout/BuffetLayoutPage.xaml", UriKind.Relative));
        }

        private void Chinese_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            model.Name = "Chinese";
            model.ListTitle = "Menu includes:";
            model.ListDesc = new List<string>
            {
                "Chow Mien",
                "Xiao Long Bao",
                "La Mien",
                "Fried Rice",
                "Herbal Soup",
                "Chinese Tea"
            };
            model.ItemDesc = "Grandtel's Chinese Buffet is filled with many Chinese delicacies and is also aptly decorated with decors from China. The surroundings will make you feel as though you are in China eating. We serve many Chinese foods like Xiao Long Bao and Chow Mien. If you are a fan of Chinese food, then we are sure that you will enjoy your meal at Grandtel's Chinese Buffet. (Only for Dinner 1900-2300)";
            model.ImagePath = "/HotelBooking;component/BuffetPictures/Chinese.jpg";
            Application.Current.Properties["PageData"] = model;
            ns.Navigate(new Uri("/HotelBooking;component/Layout/BuffetLayoutPage.xaml", UriKind.Relative));
        }

        private void Italian_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            model.Name = "Italian";
            model.ListTitle = "Menu includes:";
            model.ListDesc = new List<string>
            {
                "Hawaiian Pizza",
                "Beef Spaghetti",
                "Macaroni",
                "Aglio Olio",
                "Seafood Spaghetti",
                "Tomato Soup",
                "Mushroom Soup",
                "Can Drinks"
            };
            model.ItemDesc = "Our Italian Buffet draws inspiration from Italy's finest restaurants. It is decorated to look like one too! With pictures and decors representing Italy. The food that we serve here are delicacies of Italy from Pasta to Pizza.Our Pasta that we serve are also made fresh daily and taste very good. We are sure that you will enjoy your meal here. (Only for Lunch 1230-1600)";
            model.ImagePath = "/HotelBooking;component/BuffetPictures/Italian.jpg";
            Application.Current.Properties["PageData"] = model;
            ns.Navigate(new Uri("/HotelBooking;component/Layout/BuffetLayoutPage.xaml", UriKind.Relative));
        }
    }
}
