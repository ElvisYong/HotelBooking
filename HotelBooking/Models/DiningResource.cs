using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class DiningResource
    {
        public string restrauntType { get; set; }
        public List<TableId> tableId { get; set; }
        public int availability { get; set; }
        public double cost { get; set; }
    }
}
