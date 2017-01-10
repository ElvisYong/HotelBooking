using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace HotelBooking.Models
{
    public class TableId
    {
        public List<Bookings> bookings { get; set; }
        public int id { get; set; }
    }
}
