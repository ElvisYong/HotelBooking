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
using HotelBooking.Models;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace HotelBooking.Pages
{
    /// <summary>
    /// Interaction logic for Receipt.xaml
    /// </summary>
    public partial class ReceiptPage : Page
    {
        public ReceiptPage()
        {
            InitializeComponent();
            ReceiptListBox.ItemsSource = MainWindow.Details;
            totalCostTB.Text = string.Format("Total cost: {0:C}", Transaction.TotalTransactionCost());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Details.Clear();
            File.WriteAllText(@"C:\Users\elvis\Desktop\AppD\Assignment1\HotelBookings\HotelBooking\HotelBooking\BookedDetails.json", string.Empty);
        }
    }

}
