using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Data;
using PizzaBox.Data.Model;

namespace PizzaBox.Client
{
    class Client
    {
        private Users currentUser;
        private Crud db = new Crud();
        public void CreateNewUser(string name, string pw)
        {
            Users u = new Users();
            bool unique = true;
            u.Username = name;
            u.Password = pw;
            var users = db.GetUsers();
            foreach (var x in users)
            {
                if (u.Username == name)
                {
                    Console.WriteLine("Sorry, username already exists. Choose another.");
                    unique = false;
                    break;
                }
            }
            if (unique)
            {
                db.AddUser(u);
                Console.WriteLine("Account created successfully");
            }
        }

        public bool LoginReturningUser(string name, string pw)
        {
            var users = db.GetUsers();
            foreach (var u in users)
            {
                if (u.Username == name && u.Password == pw)
                {
                    SetCurrentUser(u);
                    return true;
                }
            }
            return false;
            /*
            foreach (KeyValuePair<string, User> u in userBase)
            {
                if (u.Key == name && u.Value.password == pw)
                    return true;
            }
            return false;*/
        }

        public void AddLocation(int storeID, string name)
        {
            
        }

        public void PrintLocations()
        {
            
        }

        public void SetCurrentUser(Users person)
        {
            currentUser = person;
        }
    }
}
