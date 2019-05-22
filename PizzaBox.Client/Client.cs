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
        private Location currentLocation;
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
                    SetCurrentUser(u.Username);
                    return true;
                }
            }
            return false;
        }

        public void PrintLocations()
        {
            var locations = db.GetLocations();
            int i = 1;
            foreach (var loc in locations)
            {
                Console.WriteLine(i);
                Console.WriteLine($"Location ID: {loc.Id}");
                Console.WriteLine(loc.Name);
                Console.WriteLine(loc.Street1);
                Console.WriteLine(loc.City);
                Console.WriteLine(loc.State);
                Console.WriteLine(loc.Zipcode);
                Console.WriteLine();
                ++i;
            }
        }

        public void SetCurrentLocation(int index)
        {
            var locations = db.GetLocations();
            currentLocation = locations[index - 1];
            //currentLocation = db.GetLocation(id);
        }

        public Location GetCurrentLocation()
        {
            return currentLocation;
        }

        public void SetCurrentUser(string name)
        {
            currentUser = db.GetUser(name);
        }

        public Users GetCurrentUser()
        {
            return currentUser;
        }

        public void PrintToppings()
        {
            var toppings = db.GetToppings();
            foreach (var t in toppings)
                Console.WriteLine(t.Id + ". " + t.Name);
        }

        public void PrintSelectedToppings(List<int> tops)
        {
            var toppings = db.GetToppings();
            int i = 0;
            Console.WriteLine("Toppings selected: ");
            foreach (var t in toppings)
            {
                if (tops[i] == t.Id)
                    Console.Write(t.Name + " ");
            }
        }
    }
}
