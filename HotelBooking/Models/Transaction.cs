using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
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
        public int TransactionId { get; set; }
        private static DateTime transactionDateTime = DateTime.Now;
        public DateTime TransactionDateTime { get { return transactionDateTime; } }
       
        public static double TotalTransactionCost()
        {
            double fullCost = 0;
            foreach(var item in MainWindow.Details)
            {
                foreach(var transactions in item)
                {
                    fullCost += transactions.TransactionSubtotal;
                    break;
                }
            } return fullCost;
        }
        public static double TotalCartCost()
        {
            double fullCost = 0;
            foreach (var item in MainWindow.Cart)
            {
                fullCost += item.subTotal;
            }
            return fullCost;
        }
       
    }
}
