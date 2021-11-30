using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
    public class Cart
    {
        public Dictionary<Product, int> cartItems = new Dictionary<Product, int>(); // to store details of all products in cart
    }
}