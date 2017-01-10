using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for BookingView.xaml
    /// </summary>
    public partial class BookingView : UserControl
    {
        public BookingView()
        {
            InitializeComponent();
            //Navigate to Rooms page
            Main.Source = new Uri("/HotelBooking;component/Pages/Rooms.xaml", UriKind.Relative);
        }

        private void Rooms_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Navigate to Rooms page
            Main.Source = new Uri("/HotelBooking;component/Pages/Rooms.xaml", UriKind.Relative);
        }

        private void Ballroom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Navigate to Ballrooms page
            Main.Source = new Uri("/HotelBooking;component/Pages/Ballrooms.xaml", UriKind.Relative);
        }

        private void Buffet_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Navigate to Buffets page
            Main.Source = new Uri("/HotelBooking;component/Pages/Buffets.xaml", UriKind.Relative);
        }
    }
}
