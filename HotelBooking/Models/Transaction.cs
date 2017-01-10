using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace HotelBooking.Models
{
    public class Transaction
    {
        public string ItemName { get; set; }
        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime TransactionBookingStart { get; set; }
        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime TransactionBookingEnd { get; set; }
        public double TransactionSubtotal { get; set; }
        public int TransactionItemId { get; set; }
        private static DateTime transactionDateTime = DateTime.Now;
        public DateTime TransactionDateTime { get { return transactionDateTime; } }

        public static double TotalTransactionCost()
        {
            double fullCost = 0;
            if (MainWindow.Details != null)
            {
                foreach (var item in MainWindow.Details)
                {
                    foreach (var transactions in item)
                    {
                        fullCost += transactions.TransactionSubtotal;
                        break;
                    }
                }
                return fullCost;
            }
            else return 0;
        }
    }
}
