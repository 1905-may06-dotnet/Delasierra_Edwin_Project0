using System;
using PizzaBox.Domain;
using PizzaBox.Data;
using PizzaBox.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
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
                Console.WriteLine("Login successful");
            else
            {
                Console.WriteLine("Username or password is incorrect");
                goto LOGIN;
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
