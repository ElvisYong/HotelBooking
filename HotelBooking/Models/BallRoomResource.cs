﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class BallRoomResource
    {
        public string ballroomType { get; set; }
        public List<BallroomId> ballroomId { get; set; }
        public int availability { get; set; }
        public double cost { get; set; }
    }
}
