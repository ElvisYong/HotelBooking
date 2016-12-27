using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.JsonProperties
{
    class HotelResource
    {
        public string roomType { get; set; }
        public List<RoomId> roomId { get; set; }
        public int availability { get; set; }
        public int cost { get; set; }
    }
}
