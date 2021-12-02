using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
    //gender enum
    public enum Gender { Male, Female, PreferNotToSay}
    public class Customer
    {
        //data fields / properties
        public static int totalCustomers { get; set; } //to automatically assign an id
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Gender gender { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        //orders of the customer
        public List<Order> Orders { get; set; }
        //cart of the customer
        public Cart cart { get; set; }

        //constructor
        public Customer(string firstname, string lastname, string username, string passwoord, Gender gender, DateTime dob, string phoneno) 
        {
            FirstName = firstname;
            LastName = lastname;
            UserName = username;
            Password = passwoord;
            this.gender = gender;
            DOB = dob;
            PhoneNumber = phoneno;
            Orders = new List<Order>();
            cart = new Cart();
            totalCustomers++;
            ID = totalCustomers;
        }
    }
}
