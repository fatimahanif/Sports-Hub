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

namespace AdminPL
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Page
    {
        #region Fields
        Admin admin;
        SportsHubDbEntities db = new SportsHubDbEntities();
        #endregion


     
        #region Admin Dashboard Default Constructor
        /// <summary>
        /// dEFAULT CONSTRUCTOR
        /// </summary>
        public AdminDashboard()
        {
            //products_listBox.ItemsSource = new List<string>() { "A", "B", "C"};
            //products_listBox.ItemsSource = DataLists.products;
            InitializeComponent();
            var productsItems = from product in db.Products
                                select product;
            products_listBox.ItemsSource = productsItems.ToList();
            
            orders_listbox.ItemsSource = db.Orders.ToList();
            
            payments_listbox.ItemsSource = db.Orders.ToList();


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
            ProductDetails productDetails = new ProductDetails(itemId);
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




        private void orders_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            Order order = listBox.SelectedItem as Order;
            OrderDescription description = new OrderDescription(order);
            description.Show();
        }

        private void orders_refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            orders_listbox.ItemsSource = db.Orders.ToList();
            orders_listbox.Items.Refresh();

        }
    }
}
