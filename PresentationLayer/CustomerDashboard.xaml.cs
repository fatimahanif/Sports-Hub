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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for CustomerDashboard.xaml
    /// </summary>
    public partial class CustomerDashboard : Page
    {
        public CustomerDashboard()
        {
            InitializeComponent();
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
    }
}
