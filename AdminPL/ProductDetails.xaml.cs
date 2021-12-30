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
        int itemId;
        SportsHubDbEntities db = new SportsHubDbEntities();
        Product product;
        

        //NEED THIS FIELDS FOR THE ADD TO CART METHOD

        
        #endregion

        #region DEFAULT CONSTRUCTOR
        public ProductDetails()
        {
            InitializeComponent();
        }
        #endregion


        //DA: Take two paramter ITEM ID (PRODUCT ID) and CUST ID (Customer ID)
        //Whn calls by displayProductDetails() method
        #region Prouduct Detail Constructor That takes Two paramter Customer ID and Product ID
        public ProductDetails(int itemId)
        {
            InitializeComponent();
            this.itemId = itemId;

            var product = (from items in db.Products
                           where items.ID == itemId
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
