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
    public class Order2
    {
        //data fields
        public static int totalOrders { get; set; } //to autonatically assign an order id
        public int OrderID { get; }
        public OrderStatus orderStatus { get; set; }
        //public Dictionary<Product, int> orderItems = new Dictionary<Product, int>(); // to store details of all products ordered
        public int Price { get; set; }
        public int Discount { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public PaymentStatus paymentStatus { get; set; }
        public List<Product2> productsList = new List<Product2>();
       // public int CustomerID;
        public DateTime OrderDate { get; set; }
      public  Order2(OrderStatus orderStatus, PaymentMethod paymentMethod, PaymentStatus paymentStatus)
        {
            OrderID = ++totalOrders;
            this.orderStatus = orderStatus;
            this.paymentMethod = paymentMethod;
            this.paymentStatus = paymentStatus;
        }
    }
}
