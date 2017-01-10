using HotelBooking.Models;
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

namespace HotelBooking.MainNavItems
{
    /// <summary>
    /// Interaction logic for ReceiptPage.xaml
    /// </summary>
    public partial class ReceiptPage : Page
    {
        public ReceiptPage()
        {
            InitializeComponent();
            ReceiptListBox.ItemsSource = CartPage.transaction;
            totalCostTB.Text = string.Format("Total cost: {0:C}", Transaction.TotalTransactionCost());
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CartPage.transaction != null)
            {
                CartPage.transaction.Clear();
            }
            MainWindow.Details.Clear();
            totalCostTB.Text = string.Format("Total cost: {0:C}", 0);
            //NEED TO USE DIRECT PATH TO READ WRITE FILE
            File.WriteAllText(@"BookedDetails.json", String.Empty);
        }
    }
}
