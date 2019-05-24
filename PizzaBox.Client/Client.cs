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
        private Pizza currentPizza;
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
                if (x.Username == name)
                {
                    Console.WriteLine("Sorry, username already exists. Choose another.");
                    Console.WriteLine("-------------------------------------");
                    unique = false;
                    break;
                }
            }
            if (unique)
            {
                db.AddUser(u);
                Console.WriteLine("Account created successfully");
                Console.WriteLine("-------------------------------------");
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
            Console.WriteLine("-------------------------------------");
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
            Console.WriteLine("-------------------------------------");
        }

        public void PrintSelectedToppings(List<int> tops)
        {
            var toppings = db.GetToppings();
            Console.WriteLine("Toppings selected: ");
            foreach (var t in toppings)
            {
                foreach (var x in tops)
                {
                    if (x == t.Id)
                        Console.Write(t.Name + " ");
                }
            }
            Console.WriteLine("\n");
        }

        public void PrintInventory(int locid)
        {
            var inv = db.GetInventory(locid);
            var loc = db.GetLocation(locid);
            Console.WriteLine($"Inventory for location {loc.Name} #{locid}");
            Console.WriteLine($"Small crust: {inv.Smallcrust}");
            Console.WriteLine($"Medium crust: {inv.Mediumcrust}");
            Console.WriteLine($"Large crust: {inv.Largecrust}");
            Console.WriteLine($"Cheese: {inv.Cheese}");
            Console.WriteLine($"Pepperoni: {inv.Pepperoni}");
            Console.WriteLine($"Sausage: {inv.Sausage}");
            Console.WriteLine($"Ham: {inv.Ham}");
            Console.WriteLine($"Chicken: {inv.Chicken}");
            Console.WriteLine($"Beef: {inv.Beef}");
            Console.WriteLine($"Pineapple: {inv.Pineapple}");
            Console.WriteLine($"Peppers: {inv.Peppers}");
            Console.WriteLine($"Onions: {inv.Onions}");
            Console.WriteLine($"Jalapenos: {inv.Jalapenos}");
            Console.WriteLine($"Mushrooms: {inv.Mushrooms}");
            Console.WriteLine("-------------------------------------");
        }


        public void PrintUserOrderHistory(string name)
        {
            var allorders = db.GetAllOrders();
            List<Orders> myorders = new List<Orders>();
            foreach (Orders o in allorders)
            {
                if (o.Userid == name)
                    myorders.Add(o);
            }
            if (myorders.Count == 0)
            {
                Console.WriteLine("There are no previous orders for this user");
                Console.WriteLine("-------------------------------------");
                return;
            }
            foreach (Orders o in myorders)
            {
                var loc = db.GetLocation(o.Locationid);
                Console.WriteLine($"Order ID: {o.Id}, Location: {loc.Name} #{o.Locationid}, Total Cost: ${o.Totalcost}, Time of order: {o.Ordertime}");
            }
            Console.WriteLine("-------------------------------------");
        }

        public void PrintLocationOrderHistory(int locid)
        {
            var allorders = db.GetAllOrders();
            List<Orders> myorders = new List<Orders>();
            foreach (Orders o in allorders)
            {
                if (o.Locationid == locid)
                    myorders.Add(o);
            }
            if (myorders.Count == 0)
            {
                Console.WriteLine("There are no previous orders for this location");
                Console.WriteLine("-------------------------------------");
                return;
            }
            foreach (Orders o in myorders)
            {
                var loc = db.GetLocation(o.Locationid);
                Console.WriteLine($"Order ID: {o.Id}, User: {o.Userid}, Total Cost: ${o.Totalcost}, Time of order: {o.Ordertime}");
            }
            Console.WriteLine("-------------------------------------");
        }

        public void PrintUsers()
        {
            var users = db.GetAllUsers();
            foreach (Users u in users)
            {
                Console.WriteLine($"Username: {u.Username}, Password: {u.Password}");
            }
            Console.WriteLine("-------------------------------------");
        }

        public Pizza CreateNewPizza(string crust, string size, List<int> tops)
        {
            Pizza p = new Pizza();
            p.Id = db.GetPizzaCount() + 1;
            p.Crust = crust;
            p.Size = size;
            decimal cost = 0;
            if (size == "small")
                cost += 5;
            else if (size == "medium")
                cost += 8;
            else
                cost += 12;
            if (crust == "stuffed")
                cost += 2;
            if (tops.Count > 2)
                cost += (tops.Count - 2);
            p.Cost = cost;
            SavePizza(p);
            db.AddPizzaToppingEntry(p, tops);
            return p;
        }

        public void SavePizza(Pizza p)
        {
            db.AddPizza(p);
        }

        public void PlaceOrder(List<Pizza> currentOrder, decimal cost)
        {
            Orders order = new Orders();
            order.Id = db.GetOrderCount() + 1;
            order.Userid = this.GetCurrentUser().Username;
            order.Locationid = this.GetCurrentLocation().Id;
            order.Totalcost = cost;
            order.Ordertime = DateTime.Now;
            DbInstance.Instance.Orders.Add(order);
            DbInstance.Instance.SaveChanges();
        }
    }
}
