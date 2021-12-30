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
    /// Interaction logic for PlaceOrder.xaml
    /// </summary>
    public partial class PlaceOrder : Window
    {
        SportsHubDbEntities db = new SportsHubDbEntities();
        double totalPrice;
        int customerId;
        public PlaceOrder()
        {
            InitializeComponent();
        }

        //parametrized constructor
        public PlaceOrder(int customerId) 
        {
            InitializeComponent();
            this.customerId = customerId;
            var dataList = from cart in db.Carts
                           where customerId == cart.CustomerID
                           select new 
                           {
                               cart.ProductID,
                               cart.Product.ProductName,
                               cart.Product.Price
                           };
            orders_data.ItemsSource = dataList.ToList();
            foreach (var item in dataList)
            {
                totalPrice += (double)item.Price;
            }
            price_lbl.Content = totalPrice;
        }

        private void payment_method_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (payment_method_combo.SelectedIndex == 1)
            {
                //card_spanel.Visibility = Visibility.Hidden;
                cardno_txtbox.IsEnabled = false;
            }
            else if (payment_method_combo.SelectedIndex == 0)
            {
                //card_spanel.Visibility = Visibility.Visible;
                cardno_txtbox.IsEnabled = true;
            }
        }

        private void confirm_order_btn_Click(object sender, RoutedEventArgs e)
        {
            //checking card number
            if (payment_method_combo.SelectedIndex == 0)
            {
                string cardNo = cardno_txtbox.Text;
                if (cardNo.Length != 16)
                {
                    MessageBox.Show("Card number should be of 16 digits");
                    return;
                }
                for (int i = 0; i < cardNo.Length; i++)
                {
                    if (!char.IsDigit(cardNo[i]))
                    {
                        MessageBox.Show("Invalid Number");
                        return;
                    }
                }
            }

            ///selecting payment method
            string paymentMethod = "Online";
            string paymentStatus = "Paid";
            if (payment_method_combo.SelectedIndex == 1) 
            {
                paymentMethod = "Cash-on-Delivery";
                paymentStatus = "Pending";
            }

            //adding to order table;
            Order order = new Order()
            {
                CustomerID = customerId,
                OrderDate = DateTime.Now,
                Price = (decimal)totalPrice,
                PaymentMethod = paymentMethod,
                OrderStatus = "Pending",
                PaymentStatus = paymentStatus
            };
            db.Orders.Add(order);
            db.SaveChanges();
            MessageBox.Show("Order Placed!");
            

            //make the cart empty
            var dataList = from cart in db.Carts
                           where customerId == cart.CustomerID
                           select cart;
            
            foreach (var item in dataList)
            {
                db.Carts.Remove(item);
            }

            db.SaveChanges();

            this.Close();
        }
    }
}
