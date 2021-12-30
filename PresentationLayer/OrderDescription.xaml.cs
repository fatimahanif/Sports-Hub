using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for OrderDescription.xaml
    /// </summary>
    public partial class OrderDescription : Window
    {
        int orderid;
        Order order;
        SportsHubDbEntities db = new SportsHubDbEntities();

        public OrderDescription()
        {
            InitializeComponent();
        }

        //parametrized constructor
        public OrderDescription(Order order) 
        {
            InitializeComponent();
            this.order = order;
            DisplayDetails();
        }

        //utility method to display data
        private void DisplayDetails() 
        {
            this.order_id.Content += order.ID.ToString();
            this.order_date.Content += order.OrderDate.ToString();
            this.order_status.Content += order.OrderStatus.ToString();
            this.payment_method.Content += order.PaymentMethod.ToString();
            this.payment_status.Content += order.PaymentStatus.ToString();
            this.price.Content += order.Price.ToString();

            var orderDetailsList = from detail in db.OrderDetails
                                   where detail.OrderID == this.order.ID
                                   select new 
                                   {
                                       ProductID = detail.Product.ID,
                                       detail.Product.ProductName,
                                       detail.Product.Price,
                                       detail.ProductQuantity
                                   };

            order_details_grid.ItemsSource = orderDetailsList.ToList();
        }


    }
}
