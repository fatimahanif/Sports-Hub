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
using Microsoft.Win32;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {
        SportsHubDbEntities db = new SportsHubDbEntities();   
        int customerID;
        Customer customerToChange;

        public EditProfile()
        {
            InitializeComponent();
        }

        public EditProfile(int customerId)
        {
            InitializeComponent();
            this.customerID = customerId;
            FillData();
        }

        //helper method to fill the text boxes
        private void FillData() 
        {
            //SportsHubDbEntities db = new SportsHubDbEntities();
            var cutsomer = (from c in db.Customers
                           where c.ID == this.customerID
                           select c).Single();

            customerToChange = cutsomer;

            this.firstName_txtBox.Text = cutsomer.FirstName;
            this.lastName_txtBox.Text = cutsomer.LastName;
            this.userName_txtBox.Text = cutsomer.UserName;
            this.email_txtBox.Text = cutsomer.Email;
            this.phone_txtBox.Text = cutsomer.PhoneNumber;
            this.gender_combo.SelectedItem = cutsomer.Gender;
            this.dob_datePicker.SelectedDate = cutsomer.DOB;
        }

        private void save_Btn_Click(object sender, RoutedEventArgs e)
        {
            //checking data validity
            //username
            var usernamesList = from customer in db.Customers
                                select customer;
            foreach (var user in usernamesList)
            {
                if (user.UserName.Equals(userName_txtBox.Text) && user.ID != customerToChange.ID )
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

            //saving changes
            customerToChange.UserName = userName_txtBox.Text;
            customerToChange.PhoneNumber = phone_txtBox.Text;
            customerToChange.Email = email_txtBox.Text;
            customerToChange.FirstName = firstName_txtBox.Text;
            customerToChange.LastName = lastName_txtBox.Text;

            db.SaveChanges();
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