using HotelBooking.Properties;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Rooms : Page
    {
        public Rooms()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {   //if either booking entry or exit date not selected, user is prompted with a new window to alert them
            if (entryBooking.SelectedDate == null || exitBooking.SelectedDate == null)
            {
                Popups.BookingEntryNull popup = new Popups.BookingEntryNull();
                popup.Show();
            }
            else if()
            {

            }
        }
    }
}
