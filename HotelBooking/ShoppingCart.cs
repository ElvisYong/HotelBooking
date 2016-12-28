using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{
    class ShoppingCart
    {
        public static void InitializeCart()
        { 
            List<CartItem> cart = new List<CartItem>();
        }
        public static List<CartItem> cart { get; set; }

        public static void AddCartItem(CartItem inItem)//method to add items into cart
        {
            cart.Add(inItem);
        }
    }
}
