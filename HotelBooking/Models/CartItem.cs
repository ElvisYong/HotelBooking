using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class CartItem
    {
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public string itemName { get; set; }
        public double cost { get; set; }
        public int itemId { get; set; }
        public string itemImage { get; set; }
        public double subTotal
        {
            get
            {
                return ((BookingEnd - BookingStart).TotalDays + 1) * cost;
            }
        }
    }

}
