using System;
using PizzaBox.Domain;
using PizzaBox.Data;
using PizzaBox.Data.Model;
using System.Linq;
using System.Collections.Generic;
using Pizza = PizzaBox.Data.Model.Pizza;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            string response1, response2;
            
            
            BEGIN:
            Console.WriteLine("Do you have an account? (y/n)");
            response1 = Console.ReadLine();
            if (response1.StartsWith("y"))
                goto LOGIN;
            
            Console.WriteLine("Please create an account");
            Console.Write("Create your username: ");
            response1 = Console.ReadLine();
            Console.Write("Create your password: ");
            response2 = Console.ReadLine();
            client.CreateNewUser(response1, response2);
            goto BEGIN;

            LOGIN:
            Console.WriteLine("Please login");
            Console.Write("Enter your username: ");
            response1 = Console.ReadLine();
            Console.Write("Enter your password: ");
            response2 = Console.ReadLine();
            if (client.LoginReturningUser(response1, response2))
            {
                client.SetCurrentUser(response1);
                Console.WriteLine("Login successful");
                Console.WriteLine("-------------------------------------");
                if (response1.Equals("admin"))
                    goto ADMIN;
                goto HOME;
            }
            else
            {
                Console.WriteLine("Username or password is incorrect");
                Console.WriteLine("-------------------------------------");
                goto BEGIN;
            }
            ADMIN:
            Console.WriteLine("Admin, please make a selection");
            Console.WriteLine("1. View inventory of location");
            Console.WriteLine("2. View order history of location");
            Console.WriteLine("3. View userbase");
            Console.WriteLine("4. Logout");
            response1 = Console.ReadLine();
            if (response1.StartsWith("1"))
            {
                Console.WriteLine("Please select a location");
                client.PrintLocations();
                int locid = Convert.ToInt32(Console.ReadLine());
                client.SetCurrentLocation(locid);
                locid = client.GetCurrentLocation().Id;
                client.PrintInventory(locid);
                goto ADMIN;
            }
            else if (response1.StartsWith("2"))
            {
                Console.WriteLine("Please select a location");
                client.PrintLocations();
                int locid = Convert.ToInt32(Console.ReadLine());
                client.SetCurrentLocation(locid);
                client.PrintLocationOrderHistory(client.GetCurrentLocation().Id);
                goto ADMIN;
            }
            else if (response1.StartsWith("3"))
            {
                client.PrintUsers();
                goto ADMIN;
            }
            else
            {
                Console.WriteLine($"Current user is {client.GetCurrentUser().Username}");
                Console.WriteLine("Are you sure you want to logout? (y/n)");
                response1 = Console.ReadLine();
                Console.WriteLine("-------------------------------------");
                if (response1.StartsWith("y"))
                    goto BEGIN;
                goto ADMIN;
            }
            HOME: //Console.WriteLine("Goodbye");
            
            Console.WriteLine("Welcome! Please make a selection (type the number)");
            Console.WriteLine("1. Place order");
            Console.WriteLine("2. View order history");
            Console.WriteLine("3. Logout");
            response1 = Console.ReadLine();
            if(response1.StartsWith("1"))
            {
                Console.WriteLine("Please select a location");
                client.PrintLocations();
                int index = Convert.ToInt32(Console.ReadLine());
                client.SetCurrentLocation(index);
                Console.WriteLine($"Current location set to {client.GetCurrentLocation().Name}");
                List<Pizza> currentOrder = new List<Pizza>();

            PIZZA:
                string crust, size;
                Console.WriteLine();
                Console.WriteLine("Choose a crust (type the number)");
                Console.WriteLine("1. Original");
                Console.WriteLine("2. Thin");
                Console.WriteLine("3. Stuffed");
                response1 = Console.ReadLine();
                if (response1.StartsWith("1"))
                    crust = "original";
                else if (response1.StartsWith("2"))
                    crust = "thin";
                else
                    crust = "stuffed";
                Console.WriteLine("Choose a size (type the number)");
                Console.WriteLine("1. Small");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Large");
                response1 = Console.ReadLine();
                if (response1.StartsWith("1"))
                    size = "small";
                else if (response1.StartsWith("2"))
                    size = "medium";
                else
                    size = "large";

                int toppingcount = 0;
                List<int> toppings = new List<int>();
            TOPPINGS:
                Console.WriteLine("Select your toppings (one at a time, max is 5)");
                
                client.PrintToppings();
                response1 = Console.ReadLine();
                
                if (response1.StartsWith("0"))
                    toppings.Add(0);
                else if (response1.StartsWith("1"))
                    toppings.Add(1);
                else if (response1.StartsWith("2"))
                    toppings.Add(2);
                else if (response1.StartsWith("3"))
                    toppings.Add(3);
                else if (response1.StartsWith("4"))
                    toppings.Add(4);
                else if (response1.StartsWith("5"))
                    toppings.Add(5);
                else if (response1.StartsWith("6"))
                    toppings.Add(6);
                else if (response1.StartsWith("7"))
                    toppings.Add(7);
                else if (response1.StartsWith("8"))
                    toppings.Add(8);
                else if (response1.StartsWith("9"))
                    toppings.Add(9);
                else
                    toppings.Add(10);
                toppingcount++;
                if (toppingcount < 5)
                {
                    Console.WriteLine("Add more toppings? (y/n)");
                    response1 = Console.ReadLine();
                    if (response1.StartsWith("y"))
                        goto TOPPINGS;
                }
                //client.PrintSelectedToppings(toppings);
                Pizza newPizza = client.CreateNewPizza(crust, size, toppings);
                Console.WriteLine($"Added pizza with {newPizza.Crust} crust, size {newPizza.Size}, cost ${newPizza.Cost}");
                Console.WriteLine($"Crust: {newPizza.Crust}");
                Console.WriteLine($"Size: {newPizza.Size}");
                client.PrintSelectedToppings(toppings);
                Console.WriteLine($"Cost: ${newPizza.Cost}");
                currentOrder.Add(newPizza);
                Console.WriteLine("Add another pizza? (y/n)");
                response1 = Console.ReadLine();
                if (response1.StartsWith("y"))
                    goto PIZZA;
                Console.WriteLine("Preview of order:");
                decimal total = 0;
                foreach (Pizza p in currentOrder)
                {
                    Console.WriteLine($"Pizza with {p.Crust} crust, size {p.Size}, cost ${p.Cost}");
                    total += p.Cost;
                }
                Console.WriteLine($"Order total: ${total}");
                Console.WriteLine("Confirm and place order? (y/n)");
                response1 = Console.ReadLine();
                if (response1.StartsWith("y"))
                {
                    client.PlaceOrder(currentOrder, total);
                    Console.WriteLine($"Your order has been placed successfully!");
                    Console.WriteLine("-------------------------------------");
                }
                goto HOME;
            }
            else if (response1.StartsWith("2"))
            {
                client.PrintUserOrderHistory(client.GetCurrentUser().Username);
                goto HOME;
            }
            else
            {
                Console.WriteLine($"Current user is {client.GetCurrentUser().Username}");
                Console.WriteLine("Are you sure you want to logout? (y/n)");
                response1 = Console.ReadLine();
                Console.WriteLine("-------------------------------------");
                if (response1.StartsWith("y"))
                    goto BEGIN;
                goto HOME;
            }
            
        }
    }
}
