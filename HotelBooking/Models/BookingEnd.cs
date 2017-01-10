using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace HotelBooking.Models
{
    public class BookingEnd
    {
        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime? dates { get; set; }
    }
}
