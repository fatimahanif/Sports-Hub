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
        public static int totalProducts { get; set; } //to automatically assign an id
        //data fields
        public int ProductID { get; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public ProductCategory productCategory { get; set; }
        public string ImagePath { get; set; }
        public string Unit { get; set; }

        //constructor 
        public Product(string name, int price, ProductCategory category, string imgPath, string unit )
        {
            ProductID = ++totalProducts;
            ProductName = name;
            Price = price;
            productCategory = category;
            ImagePath = imgPath;
            Unit = unit;
        }
    }
}