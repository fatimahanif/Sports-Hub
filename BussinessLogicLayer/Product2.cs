using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
    public enum ProductCategory2 { Badminton, Tennis, TableTennis}
    public class Product2
    {
        public static int totalProducts { get; set; } //to automatically assign an id
        //data fields
        public int ProductID { get; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public ProductCategory2 productCategory { get; set; }
        public string ImagePath { get; set; }
        public string Unit { get; set; }

        //constructor 
        public Product2(string name, int price, ProductCategory2 category, string imgPath, string unit )
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