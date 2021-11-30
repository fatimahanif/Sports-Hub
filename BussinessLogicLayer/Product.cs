using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
    public enum ProductCategory { Badminton, Tennis, TableTennis}
    public class Product
    {
        public static int totalProducts { get; } //to automatically assign an id
        //data fields
        public int ProductID { get; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public ProductCategory productCategory { get; set; }
    }
}