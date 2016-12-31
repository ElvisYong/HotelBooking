using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class ResourceType
    {
        public List<HotelResource> hotelRooms { get; set; }
        public List<BallRoomResource> ballRooms { get; set; }
        public List<DiningResource> dining { get; set; }
    }
}
