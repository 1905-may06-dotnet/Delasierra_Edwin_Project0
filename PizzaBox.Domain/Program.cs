using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    class Program
    {
        static void Main(string[] args)
        {/*
            List<Topping> myToppings = new List<Topping>();
            myToppings.Add(Topping.cheese);
            //myToppings.Add(Topping.sausage);
            myToppings.Add(Topping.jalapenos);
            myToppings.Add(Topping.onions);
            myToppings.Add(Topping.pineapple);
            myToppings.Add(Topping.pepperoni);
            Pizza myPizza = new Pizza(Crust.original, Size.medium, myToppings);
            Pizza ourPizza = new Pizza();
            myPizza.PrintDetails();

            List<Pizza> myPizzas = new List<Pizza>();
            for (int i = 0; i < 1001; ++i)
            {
                //myPizzas.Add(myPizza);
                myPizzas.Add(ourPizza);
            }
            
            //myPizzas.Add(ourPizza);
            Order myOrder = new Order(myPizzas);
            myOrder.PrintDetails();
            */
            foreach (Crust c in Enum.GetValues(typeof(Crust)))
            {
                Console.WriteLine($"Crust type {c}");
            }
        }
    }
}
