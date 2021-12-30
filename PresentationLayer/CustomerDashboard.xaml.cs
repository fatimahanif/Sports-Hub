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
        #region Fields
        Customer customer;
        SportsHubDbEntities db = new SportsHubDbEntities();
        #endregion


        #region ALL CONSTRUCTORS
        #region Customer Dashboard Default Constructor
        /// <summary>
        /// dEFAULT CONSTRUCTOR
        /// </summary>
        public CustomerDashboard()
        {
            //products_listBox.ItemsSource = new List<string>() { "A", "B", "C"};
            //products_listBox.ItemsSource = DataLists.products;
            InitializeComponent();
            var productsItems = from product in db.Products
                                select product;
            products_listBox.ItemsSource = productsItems.ToList();
            orders_listbox.ItemsSource = customer.Orders;
            customerName_label.Content = "" + customer.FirstName + " " + customer.LastName;


        }
        #endregion

        #region Customer Dashboard With Customer Parameter

        /// <summary>
        /// PARAMTERIZED CONSTRUCTOR
        /// </summary>
        /// <param name="customer"></param>
        public CustomerDashboard(Customer customer)
        {
            //products_listBox.ItemsSource = new List<string>() { "A", "B", "C"};
            //products_listBox.ItemsSource = DataLists.products;
            InitializeComponent();
            this.customer = customer;
            var productsItems = from product in db.Products
                                select product;
            products_listBox.ItemsSource = productsItems.ToList();

            var cartList = from cart in db.Carts
                           where cart.CustomerID == customer.ID
                           select cart;
            cart_listBox.ItemsSource = cartList.ToList();

            orders_listbox.ItemsSource = customer.Orders;

            customerName_label.Content = "" + customer.FirstName + " " + customer.LastName;


        }
        #endregion 
        #endregion

        #region Menu Button Clicks

        /// <summary>
        /// MENU BUTTONS (EXPLORE, ORDER, PAYMENT, FEEBACK, )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exploreProducts_btn_Click(object sender, RoutedEventArgs e)
        {
            menu_tab.SelectedIndex = 1;
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
        #endregion

        #region When the list Box seletion is chnaged
        private void products_listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListBox listBox = sender as ListBox;
            //Product product = listBox.SelectedItem as Product;
            //var productsItems = from p in db.Products
            //                    select p;
            ////products_listBox.ItemsSource = productsItems.ToList();
            //foreach (Product item in productsItems)
            //{
            //    if (item.ID == product.ID)
            //    {
            //        //displayProductDetails(item);
            //        displayProductDetails(item.ID);
            //    }
            //}
        }
        #endregion

        #region Display Product Detail Widow mETHOD
        /// <summary>
        /// HELPER METHOD THAT DISPLAY THE PRODUCT DETAIL WINDOW AND TAKE THE PRODUCT 
        /// ID AS THE PARAMTER
        /// </summary>
        /// <param name="itemId"></param>
        private void displayProductDetails(int itemId) // (Prodct product)
        {
            //ProductDetails productDetails = new ProductDetails(product, customer);
            ProductDetails productDetails = new ProductDetails(itemId, customer.ID);
            productDetails.Show();
            //MessageBox.Show(""+product.ProductName);
        }
        #endregion

        #region Logout Button
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
        #endregion

        #region Refresh Cart Button
        private void cart_refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            RefreshHelperMethod();
        }
        #endregion

        #region Refresher Helper Method
        /// <summary>
        /// Helper method so that we dont need to press 
        /// the refresh button every time
        /// </summary>
        public void RefreshHelperMethod()
        {
            var cartList = from cart in db.Carts
                           where cart.CustomerID == customer.ID
                           select cart;
            cart_listBox.ItemsSource = cartList.ToList();
            cart_listBox.Items.Refresh();
        }
        #endregion

        #region For the profile button click
        private void profile_button_Click(object sender, RoutedEventArgs e)
        {
            EditProfile editProfile = new EditProfile(this.customer.ID);
            editProfile.Show();
        }
        #endregion


        #region Select the ListBox Item when Any Button is clicked
        /// <summary>
        /// This event fires when any button inside the curremt LISTITEM is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void products_listBox_Button_Click(object sender, RoutedEventArgs e)
        {
            object clicked = (e.OriginalSource as FrameworkElement).DataContext;
            var lbi = products_listBox.ItemContainerGenerator.ContainerFromItem(clicked) as ListBoxItem;
            lbi.IsSelected = true;
        }
        #endregion


        #region Button inside the ListItem of Product
        /// <summary>
        /// Button (View Cart Button and Add to Cart Button)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region When the add to cart button is clciked
        private void Cart_Btn_Click(object sender, RoutedEventArgs e)
        {
            products_listBox_Button_Click(sender, e);
            Product product = this.products_listBox.SelectedItem as Product;

            //Cart Object
            Cart newCartItem = new Cart()
            {
                ProductID = product.ID,
                CustomerID = customer.ID
            };


            db.Carts.Add(newCartItem);

            db.SaveChanges();
            RefreshHelperMethod();
            MessageBox.Show("Product added to cart");

        }
        #endregion

        #region When the view Button is clicked 
        /// <summary>
        /// WHEN THE VIEW BUTTON IS CLCIKED 
        /// NEED A LITTLE CHNAGE (DIRECT SEND THE PRODUCT ID TO DISPLAYPRODUCTDETAIL METHOD)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productDetail_btn_Click(object sender, RoutedEventArgs e)
        {

            products_listBox_Button_Click(sender, e);
            Product product = this.products_listBox.SelectedItem as Product;
            var productsItems = from p in db.Products
                                select p;
            //products_listBox.ItemsSource = productsItems.ToList();
            foreach (Product item in productsItems)
            {
                if (item.ID == product.ID)
                {
                    //displayProductDetails(item);
                    displayProductDetails(item.ID);
                }
            }


        }




        #endregion

        #endregion


        #region tabControl selection changed
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }
        #endregion


        #region For the Carts listItem Button Base Event
        private void carts_listBox_Button_Click(object sender, RoutedEventArgs e)
        {
            object clicked = (e.OriginalSource as FrameworkElement).DataContext;
            var lbiForCart = cart_listBox.ItemContainerGenerator.ContainerFromItem(clicked) as ListBoxItem;
            lbiForCart.IsSelected = true;

        }
        #endregion


        #region Delete item from cart button event handler
        private void Delete_From_Cart(object sender, RoutedEventArgs e)
        {
            carts_listBox_Button_Click(sender, e);
            Cart cartItem = this.cart_listBox.SelectedItem as Cart;
            db.Carts.Remove(cartItem);
            db.SaveChanges();
            //RefreshHelperMethod();

        }
        #endregion

        private void cart_listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //button event handler to place an order
        private void cart_order_btn_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrder order = new PlaceOrder(this.customer.ID);
            order.Show();
        }

        private void orders_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            Order order = listBox.SelectedItem as Order;
            OrderDescription description = new OrderDescription(order);
            description.Show();
        }
    }
}
