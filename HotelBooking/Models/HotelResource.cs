﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class HotelResource
    {
        public string roomType { get; set; }
        public List<RoomId> roomId { get; set; }
        public double cost { get; set; }
    }
}
