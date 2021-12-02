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
            new Customer("Fatima", "Hanif", "fatima", "Fatima123!", Gender.Female, new DateTime(2002,8,31), "03185152910")
            {
                Orders = new List<Order>()
                {
                    new Order(OrderStatus.Delivered, PaymentMethod.Online, PaymentStatus.Paid) { Price = 10000 } ,
                    new Order(OrderStatus.Shipped, PaymentMethod.Online, PaymentStatus.Pending) { Price = 35000 },
                    new Order(OrderStatus.Pending, PaymentMethod.CashonDelivery, PaymentStatus.Paid) { Price = 5000 }
                }
            },
            new Customer("Dawood", "Saeed", "dawood", "Dawood123!", Gender.Male, new DateTime(2001,3,20), "03339876543"),
            new Customer("Kashaf", "Fatima", "kashaf", "Kashaf123!", Gender.Female, new DateTime(2001,1,26), "03187654321"),
            new Customer("Maryam", "Fatima", "maryam", "Maryam123!", Gender.Female, new DateTime(2000,6,24), "03121234567")
        };

        public static List<Product> products = new List<Product>()
        {
            new Product("Badminton Racket", 1000, ProductCategory.Badminton, "images\\badminton_racket", "1 Pack x 2 Rackets"),
            new Product("Badminton ShuttleCock", 450, ProductCategory.Badminton, "images\\badminton_shuttlecock", "1 Box x 6 Shuttles"),
            new Product("Badminton Net", 950, ProductCategory.Badminton, "images\\badminton_net", "1 Pack x 1 Net"),
            new Product("Badminton Set", 1800, ProductCategory.Badminton, "images\\badminton_set", "2 Rackets + 6 Shuttles + 1 Net"),
            new Product("Tennis Racket", 2000, ProductCategory.Tennis, "images\\tennis_racket", "1 Pack x 2 Rackets"),
            new Product("Tennis Ball", 500, ProductCategory.Tennis, "images\\tennis_ball", "1 Box x 6 Balls"),
            new Product("Tennis Net", 1200, ProductCategory.Tennis, "images\\tennis_net", "1 Pack x 1 Net"),
            new Product("Tennis Set", 3500, ProductCategory.Tennis, "images\\tennis_set", "2 Rackets + 6 Balls + 1 Net"),
            new Product("Table Tennis Racket", 800, ProductCategory.TableTennis, "images\\tabletennis_racket", "1 Pack x 2 Rackets"),
            new Product("Table Tennis Balls", 400, ProductCategory.TableTennis, "images\\tabletennis_shuttlecock", "1 Box x 12 Balls"),
            new Product("Table Tennis Net", 1000, ProductCategory.TableTennis, "images\\tabletennis_net", "1 Pack x 1 Net"),
            new Product("Table Tennis Set", 2000, ProductCategory.TableTennis, "images\\tabletennis_set", "2 Rackets + 12 Balls + 1 Net"),
            new Product("Table Tennis Table", 2000, ProductCategory.TableTennis, "images\\tabletennis_table", "1 Table")
        };
    }
}
