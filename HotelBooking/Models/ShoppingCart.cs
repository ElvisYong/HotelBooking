using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    class ShoppingCart
    {
        public static string TotalCost()
        {
            double fullCost = 0;
            foreach(var item in MainWindow.Cart)
            {
                fullCost += item.subTotal;
            }
            string totalFullCost = string.Format("Total cost: {0:C}", fullCost);
            return totalFullCost;
        }
    }
}
