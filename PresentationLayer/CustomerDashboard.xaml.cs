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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL;
using BussinessLogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for CustomerDashboard.xaml
    /// </summary>
    public partial class CustomerDashboard : Page
    {
        Customer customer;
        public CustomerDashboard()
        {
            //products_listBox.ItemsSource = new List<string>() { "A", "B", "C"};
            //products_listBox.ItemsSource = DataLists.products;
            InitializeComponent();
            //products_listBox.ItemsSource = DataLists.products;
            orders_listbox.ItemsSource = customer.Orders;
            customerName_label.Content = ""+customer.FirstName + " " + customer.LastName;

        }
        public CustomerDashboard(Customer customer)
        {
            //products_listBox.ItemsSource = new List<string>() { "A", "B", "C"};
            //products_listBox.ItemsSource = DataLists.products;
            InitializeComponent();
            this.customer = customer;
            //products_listBox.ItemsSource = DataLists.products;
            //cart_listBox.ItemsSource = customer.cart;
            //orders_listbox.ItemsSource = customer.Orders;
        }

        private void exploreProducts_btn_Click(object sender, RoutedEventArgs e)
        {
            menu_tab.SelectedIndex = 1;
        }

        private void Logout_Btn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).Main.Content = new LoginPage();
                }
            }
        }

        private void manageOrders_btn_Click(object sender, RoutedEventArgs e)
        {
            menu_tab.SelectedIndex = 2;
        }

        private void managePayments_btn_Click(object sender, RoutedEventArgs e)
        {
            menu_tab.SelectedIndex = 3;
        }

        private void feedback_btn_Click(object sender, RoutedEventArgs e)
        {
            menu_tab.SelectedIndex = 4;
        }

        private void products_listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            Product product = listBox.SelectedItem as Product;
            //foreach (Product item in DataLists.products)
            //{
            //    if (item.ProductID == product.ProductID) 
            //    {
            //        displayProductDetails(item);
            //    }
            //}
        }

        private void displayProductDetails( Product product )
        {
            ProductDetails productDetails = new ProductDetails(product, customer);
            productDetails.Show();
            //MessageBox.Show(""+product.ProductName);
        }

        private void cart_refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            cart_listBox.Items.Refresh();
        }
    }
}
