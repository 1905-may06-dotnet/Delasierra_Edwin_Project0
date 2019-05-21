using System;
using PizzaBox.Domain;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            Console.WriteLine("Do you have an account? (y/n)");
            string response1, response2;
            response1 = Console.ReadLine();

            login:
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
                    Console.WriteLine("The username and password are incorrect");
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
                goto login;
                //Console.Write("Re-enter password: ");
            }

            /*
            Console.WriteLine("Please login");
            string name = "Edwin";
            string password = "1234";
            client.CreateNewUser(name, password);
            name = "wrong";
            bool exists = client.LoginReturningUser(name, password);
            Console.WriteLine($"This user exists: {exists}");
            */
        }
    }
}
