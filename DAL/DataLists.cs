using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogicLayer;

namespace DAL
{
    public class DataLists
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer("Fatima", "Hanif", "fatimahanif", "Fatima123!", Gender.Female, new DateTime(2002,8,31), "03185152910"),
            new Customer("Dawood", "Saeed", "dawoodsaeed", "Dawood123!", Gender.Male, new DateTime(2001,3,20), "03339876543"),
            new Customer("Kashaf", "Fatima", "kashaffatima", "Kashaf123!", Gender.Female, new DateTime(2001,1,26), "03187654321"),
            new Customer("Maryam", "Fatima", "maryamfatima", "Maryam123!", Gender.Female, new DateTime(2000,6,24), "03121234567")
        };

        public static List<Product> products = new List<Product>()
        {
            new Product("Badminton Racket", 1000, ProductCategory.Badminton, "badminton_racket", "1 Pack x 2 Rackets"),
            new Product("Badminton ShuttleCock", 450, ProductCategory.Badminton, "badminton_shuttlecock", "1 Box x 6 Shuttles"),
            new Product("Badminton Net", 500, ProductCategory.Badminton, "badminton_net", "1 Pack x 1 Net"),
            new Product("Badminton Set", 1800, ProductCategory.Badminton, "badminton_set", "2 Rackets + 6 Shuttles + 1 Net")
        };

    }
}
