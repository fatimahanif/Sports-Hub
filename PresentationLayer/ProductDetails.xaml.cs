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
using DAL;
using BussinessLogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : Window
    {
        Product product;
        Customer customer;
        SportsHubDbEntities db = new SportsHubDbEntities();
        public ProductDetails()
        {
            InitializeComponent();
        }
        public ProductDetails(Product product, Customer customer)
        {
            InitializeComponent();
            this.product = product;
            product_id.Content += product.ID.ToString();
            product_title.Content += product.ProductName;
            product_unit.Content += product.Unit;
            product_price.Content += product.Price.ToString();
            product_category.Content += product.ProductCategory1.CategoryName;
            ImageConverter converter = new ImageConverter();
            product_image.Source = (ImageSource)converter.Convert(product.ID, null, converter, null);
            this.customer = customer;
        }

        private void Cart_Btn_Click(object sender, RoutedEventArgs e)
        {
            customer.Carts.Add(new Cart() { CustomerID = this.customer.ID, Customer = this.customer, Product = this.product, ProductID = this.product.ID});
            MessageBox.Show("Product added to cart");
            db.SaveChanges();
        }
    }
}
