using System.Collections.Generic;

namespace HotelBooking.Pages
{
    internal class Model
    {
        //Used to save and pass values for the UI display
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string ItemDesc { get; set; }
        public string ListTitle { get; set; }
        public List<string> ListDesc { get; set; }
    }
}