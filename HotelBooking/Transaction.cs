using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{
    class Transaction: Models.CartItem
    {
        public DateTime transactionTime { get; set; }
        public string transactionId { get; set; }
    }
}
