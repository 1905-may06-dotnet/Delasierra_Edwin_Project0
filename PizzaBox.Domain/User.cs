using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain
{ 
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public List<Order> orderHistory { get; set; }
        public DateTime lastOrderTime { get; set; }
        public bool recentlyOrdered { get; set; }

        public User()
        {
            username = "guest";
            password = "password";
            recentlyOrdered = false;
        }

        public User(string name, string pw)
        {
            username = name;
            password = pw;
            recentlyOrdered = false;
        }
    }
}
