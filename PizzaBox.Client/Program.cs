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
            User CurrentUser;
            //Crud d = new Crud();
            //var users = d.GetUsers();
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
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("Username or password is incorrect");
                goto BEGIN;
            }

            HOME:
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

            PIZZA:
                Pizza pizza = new Pizza();
                Console.WriteLine();
                Console.WriteLine("Choose a crust (type the number)");
                Console.WriteLine("1. Original");
                Console.WriteLine("2. Thin");
                Console.WriteLine("3. Stuffed");
                response1 = Console.ReadLine();
                if (response1.StartsWith("1"))
                    pizza.Crust = "original";
                else if (response1.StartsWith("2"))
                    pizza.Crust = "thin";
                else
                    pizza.Crust = "stuffed";
                Console.WriteLine("Choose a size (type the number)");
                Console.WriteLine("1. Small");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Large");
                response1 = Console.ReadLine();
                if (response1.StartsWith("1"))
                    pizza.Size = "small";
                else if (response1.StartsWith("2"))
                    pizza.Size = "medium";
                else
                    pizza.Size = "large";

                int toppingcount = 0;
                TOPPINGS:
                Console.WriteLine("Select your toppings (one at a time, max is 5)");
                
                client.PrintToppings();
                response1 = Console.ReadLine();
                List<int> toppings = new List<int>();
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
                client.PrintSelectedToppings(toppings);
                goto HOME;
            }
            else if (response1.StartsWith("2"))
            {
                goto HOME;
            }
            else
            {
                Console.WriteLine($"Current user is {client.GetCurrentUser().Username}");
                Console.WriteLine("Are you sure you want to logout? (y/n)");
                response1 = Console.ReadLine();
                if (response1.StartsWith("y"))
                    goto BEGIN;
                goto HOME;
            }
            /*
            Client client = new Client();
            Console.WriteLine("Do you have an account? (y/n)");
            string response1, response2;
            response1 = Console.ReadLine();
            /*
            LOGIN:
            if (response1.StartsWith('y'))
            {
                Console.WriteLine("Please login");
                Console.Write("Enter your username: ");
                response1 = Console.ReadLine();
                Console.Write("Enter your password: ");
                response2 = Console.ReadLine();
                if (client.LoginReturningUser(response1, response2))
                    Console.WriteLine("Login successful");
                else
                {
                    Console.WriteLine("The username and password are incorrect");
                    goto LOGIN;
                }
            }
            else
            {
                Console.WriteLine("Please create a new account");
                Console.Write("Create username: ");
                response1 = Console.ReadLine();
                Console.Write("Create password: ");
                response2 = Console.ReadLine();
                client.CreateNewUser(response1, response2);
                Console.WriteLine("New account created");
                response1 = "y";
                goto LOGIN;
                //Console.Write("Re-enter password: ");
            }
            HOME:
            Console.WriteLine("Select an action (enter the number)");
            Console.WriteLine("1. Place order");
            Console.WriteLine("2. View order history");
            Console.WriteLine("3. Logout");
            string homeselect = Console.ReadLine();
            if (homeselect.StartsWith("1"))
            {
                Console.WriteLine("Select a location");
                client.PrintLocations();
                response1 = Console.ReadLine();
            }
            else if (homeselect.StartsWith("2"))
            {

            }
            else
            {
                Console.WriteLine("Are you sure you want to logout? (y/n)");
                response1 = Console.ReadLine();
                if (response1.StartsWith("y"))
                    goto LOGIN;
                goto HOME;
            }
            */
        }
    }
}
