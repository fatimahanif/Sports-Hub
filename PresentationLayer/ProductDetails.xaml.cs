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
        public ProductDetails()
        {
            InitializeComponent();
        }
        public ProductDetails(Product product, Customer customer)
        {
            InitializeComponent();
            this.product = product;
            product_id.Content += product.ProductID.ToString();
            product_title.Content += product.ProductName;
            product_unit.Content += product.Unit;
            product_price.Content += product.Price.ToString();
            product_category.Content += product.productCategory.ToString();
            //product_img.ImageSource = product.ImagePath;
            this.customer = customer;
        }

        private void Cart_Btn_Click(object sender, RoutedEventArgs e)
        {
            customer.cart.Add(this.product);
            MessageBox.Show("Product added to cart");
        }
    }
}
