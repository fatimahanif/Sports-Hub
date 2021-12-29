﻿using DAL;
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

        public PlaceOrder()
        {
            InitializeComponent();
        }

        //parametrized constructor
        public PlaceOrder(int customerId) 
        {
            InitializeComponent();
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
            //if (payment_method_combo.SelectedIndex == 1) 
            //{
            //    card_spanel.Visibility = Visibility.Hidden;
            //}
            //else if (payment_method_combo.SelectedIndex == 0) 
            //{
            //    card_spanel.Visibility = Visibility.Visible;
            //}
        }

        private void confirm_order_btn_Click(object sender, RoutedEventArgs e)
        {
            //adding to order table;
            MessageBox.Show("Order Placed!");
            this.Close();
        }
    }
}
