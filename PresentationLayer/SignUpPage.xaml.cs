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
using Microsoft.Win32;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        Customer customer;
        SportsHubDbEntities db = new SportsHubDbEntities();
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void loginNow_btn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).Main.Content = new LoginPage();
                }
            }
        }

        private void createCustomer()
        {
            Gender gender = Gender.Female;
            if (gender_combo.SelectedIndex == 0)
            {
                gender = Gender.Male;
            }
            else if (gender_combo.SelectedIndex == 1)
            {
                gender = Gender.Female;
            }
            else if (gender_combo.SelectedIndex == 2)
            {
                gender = Gender.PreferNotToSay;
            }
            customer = new Customer
            {
                FirstName = firstName_txtBox.Text,
                LastName = lastName_txtBox.Text,
                UserName = userName_txtBox.Text,
                Password = password_txtBox.Password,
                Gender = gender.ToString(),
                DOB = (DateTime)dob_datePicker.SelectedDate,
                PhoneNumber = phone_txtBox.Text,
                Email = email_txtBox.Text
            };
            db.Customers.Add(customer);
            db.SaveChanges();
            //DataLists.customers.Add(customer);
        }

        private void SignUp_Btn_Click(object sender, RoutedEventArgs e)
        {
            //checking data validity
            //username
            var usernamesList = from customer in db.Customers
                                select customer;
            foreach (var user in usernamesList)
            {
                if (user.UserName.Equals(userName_txtBox.Text))
                {
                    MessageBox.Show("Username already exsits!");
                    return;
                }
            }
            // email
            if (!email_txtBox.Text.Contains("@"))
            {
                MessageBox.Show("Incorrect Email!");
                return;
            }
            //password
            if (!(password_txtBox.Password.Equals(confirmPass_txtBox.Password) && password_txtBox.Password.Length > 8))
            {
                MessageBox.Show("Recheck Your Password!\nIt should be minimum 8 characters long");
                return;
            }
            //phone number
            for (int i = 0; i < phone_txtBox.Text.Length; i++)
            {
                if (!char.IsDigit(phone_txtBox.Text[i]))
                {
                    MessageBox.Show("Invalid Phone Number");
                    return;
                }
            }
            createCustomer();
            // logging in
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).Main.Content = new CustomerDashboard(customer);
                }
            }
        }

        private void uploadPic_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                profilePic_img.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
    }
}
