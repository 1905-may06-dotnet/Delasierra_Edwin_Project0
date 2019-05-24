using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Data.Model;
using System.Linq;

namespace PizzaBox.Data
{
    public class Crud : ICrud
    {
        public void AddUser(Users u)
        {
            DbInstance.Instance.Users.Add(u);// calling insert Query
            DbInstance.Instance.SaveChanges();
            Console.WriteLine($"User {u.Username} added into Db");
        }

        public void DeleteUser(Users u)
        {
            var user = DbInstance.Instance.Users.Where<Users>(x => x.Username == u.Username).FirstOrDefault();
            DbInstance.Instance.Users.Remove(user);
            DbInstance.Instance.SaveChanges();
            Console.WriteLine($"User {u.Username} removed from Db");
        }

        public List<Users> GetUsers()
        {
            var users = DbInstance.Instance.Users.ToList();
            return users;
        }

        public Users GetUser(string id)
        {
            var user = DbInstance.Instance.Users.Where<Users>(u => u.Username == id).FirstOrDefault();
            return user;
        }

        public List<Location> GetLocations()
        {
            var locations = DbInstance.Instance.Location.ToList();
            return locations;
        }

        public Location GetLocation(int id)
        {
            var location = DbInstance.Instance.Location.Where<Location>(loc => loc.Id == id).FirstOrDefault();
            return location;
        }

        public List<Toppings> GetToppings()
        {
            var toppings = DbInstance.Instance.Toppings.ToList();
            return toppings;
        }

        public Inventory GetInventory(int id)
        {
            var inventory = DbInstance.Instance.Inventory.Where<Inventory>(inv => inv.Locationid == id).FirstOrDefault();
            return inventory;
        }

        public Orders GetOrder(string user)
        {
            var order = DbInstance.Instance.Orders.Where<Orders>(ord => ord.Userid == user).FirstOrDefault();
            //var order = DbInstance.Instance.Orders.Where<Orders>(ord => ord.Id == id).FirstOrDefault();
            return order;
        }

        public List<Orders> GetAllOrders()
        {
            var orders = DbInstance.Instance.Orders.ToList();
            return orders;
        }

        public List<Users> GetAllUsers()
        {
            var users = DbInstance.Instance.Users.ToList();
            return users;
        }
        public void AddPizza(Pizza p)
        {
            DbInstance.Instance.Pizza.Add(p);
            DbInstance.Instance.SaveChanges();
        }

        public void AddOrder(Orders o)
        {
            DbInstance.Instance.Orders.Add(o);
            DbInstance.Instance.SaveChanges();
        }

        public int GetOrderCount()
        {
            var orders = DbInstance.Instance.Orders.ToList();
            return orders.Count;
        }

        public int GetPizzaCount()
        {
            var pizzas = DbInstance.Instance.Pizza.ToList();
            return pizzas.Count;
        }

        public void AddPizzaToppingEntry(Pizza p, List<int> toppings)
        {
            var tops = DbInstance.Instance.Toppings.ToList();
            foreach (var t in tops)
            {
                foreach (int i in toppings)
                {
                    if (i == t.Id)
                    {
                        PizzaToppings pt = new PizzaToppings();
                        pt.Pizzaid = p.Id;
                        pt.Toppingid = i;
                        DbInstance.Instance.PizzaToppings.Add(pt);
                        DbInstance.Instance.SaveChanges();
                    }
                }
            }
        }
    }
}
