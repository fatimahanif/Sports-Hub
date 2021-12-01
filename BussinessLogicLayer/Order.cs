using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
    public enum OrderStatus { Shipped, Delivered, Pending }
    public enum PaymentMethod { Online, CashonDelivery }
    public enum PaymentStatus { Paid, Pending }
    public class Order
    {
        //data fields
        public static int totalOrders { get; set; } //to autonatically assign an order id
        public int OrderID { get; }
        public OrderStatus orderStatus { get; set; }
        //public Dictionary<Product, int> orderItems = new Dictionary<Product, int>(); // to store details of all products ordered
        public int Price { get; }
        public int Discount { get; }
        public PaymentMethod paymentMethod { get; set; }
        public PaymentStatus paymentStatus { get; set; }
        public List<Product> products = new List<Product>();
        public int CustomerID;
        public DateTime OrderDate { get; set; }
       Order(OrderStatus orderStatus, PaymentMethod paymentMethod, PaymentStatus paymentStatus, int customerID)
        {
            OrderID = ++totalOrders;
            this.orderStatus = orderStatus;
            this.paymentMethod = paymentMethod;
            this.paymentStatus = paymentStatus;
            this.CustomerID = customerID;
        }
    }
}
