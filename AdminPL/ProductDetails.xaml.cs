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

namespace AdminPL
{
    /// <summary>
    /// Interaction logic for ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : Window
    {
        #region FIELDS
        SportsHubDbEntities db = new SportsHubDbEntities();
        Product product;
        Customer customer;

        //NEED THIS FIELDS FOR THE ADD TO CART METHOD

        int itemId; int custId;
        #endregion

        #region DEFAULT CONSTRUCTOR
        public ProductDetails()
        {
            InitializeComponent();
        }
        #endregion

        //THIS WILL BE NO LONGER  (TO BE THINK ABOUT iT LATER ON)
        #region PRODUCT DETAIL CONSTRUCTOR TAKE TWO PARAMTER CUSTOMER AND PRODUCT OBJECT
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
        #endregion


        //DA: Take two paramter ITEM ID (PRODUCT ID) and CUST ID (Customer ID)
        //WHehn calls by displayProductDetails() MEthod
        #region Prouduct Detail Constructor That takes Two paramter Customer ID and Product ID
        public ProductDetails(int itemId, int custId)
        {
            InitializeComponent();
            this.custId = custId;
            this.itemId = itemId;

            var product = (from items in db.Products
                           where items.ID == itemId
                           select items).Single();
            var custToFind = (from items in db.Customers
                              where items.ID == custId
                              select items).Single();


            product_id.Content += product.ID.ToString();
            product_title.Content += product.ProductName;
            product_unit.Content += product.Unit;
            product_price.Content += product.Price.ToString();
            product_category.Content += product.ProductCategory1.CategoryName;
            ImageConverter converter = new ImageConverter();
            product_image.Source = (ImageSource)converter.Convert(product.ID, null, converter, null);

        }
        #endregion

        
    }
}
