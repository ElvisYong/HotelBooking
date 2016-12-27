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
using System.Windows.Shapes;

namespace HotelBooking.Popups
{
    /// <summary>
    /// Interaction logic for BookingEntryNull.xaml
    /// </summary>
    public partial class BookingEntryNull : Window
    {
        public BookingEntryNull()
        {
            InitializeComponent();
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
