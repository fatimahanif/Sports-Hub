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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Admin admin;
        SportsHubDbEntities db = new SportsHubDbEntities();

        public LoginPage()
        {
            InitializeComponent();
        }

        private bool checkUser()
        {
            //checking username and password validity
            // SportsHubDbEntities db = new SportsHubDbEntities();
            var usernamesList = from admin in db.Admins
                                select admin;
            foreach (var user in usernamesList)
            {
                //Console.WriteLine(user.ToString());
                if (user.UserName.Equals(userName_txtBox.Text) && user.Password.Equals(password_txtBox.Password))
                {
                    admin = user;
                    return true;
                }
            }
            return false;
        }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!checkUser())
            {
                MessageBox.Show("Invalid Username or Password!");
            }

            else
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).Main.Content = new AdminDashboard();
                    }
                }
        }

        private void register_btn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                  //  (window as MainWindow).Main.Content = new SignUpPage();
                }
            }
        }
    }
}
