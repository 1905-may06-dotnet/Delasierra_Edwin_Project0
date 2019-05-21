using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain
{
    public enum Crust
    {
        original,
        thin,
        stuffed
    };
    public enum Size
    {
        small,
        medium,
        large
    };
    public enum Topping
    {
        cheese,
        pepperoni,
        sausage,
        ham,
        chicken,
        beef,
        pineapple,
        peppers,
        onions,
        jalapenos,
        mushrooms
    };

    public enum Specialty
    {
        supreme,
        meatlovers,
        veggie,
        hawaiian
    };

    public class Pizza
    {
        public Crust crust { get; set; }
        public Size size { get; set; }
        public double cost { get; set; }
        public List<Topping> toppings = new List<Topping>();
        public int orderId { get; private set; }

        

        public Pizza()
        {
            crust = 0;
            size = 0;
            cost = 5.0;
            toppings.Add(Topping.cheese);
            toppings.Add(Topping.pepperoni);
        }

        public Pizza(Crust c, Size s, List<Topping> tops)
        {
            crust = c;
            size = s;
            if (tops.Count > 5)
            {
                Console.WriteLine("Max number of toppings exceeded; will only add first 5");
                for (int i = 0; i < 5; ++i)
                    toppings.Add(tops[i]);
            }
            else
            {
                foreach (Topping t in tops)
                    toppings.Add(t);
            }
            ComputeCost();
        }

        public Pizza(Crust c, Size s, Specialty spec)  //for creating a specialty pizza
        {
            crust = c;
            size = s;
            if (spec == Specialty.supreme)
            {
                toppings.Add(Topping.cheese);
                toppings.Add(Topping.pepperoni);
                toppings.Add(Topping.peppers);
                toppings.Add(Topping.onions);
                toppings.Add(Topping.mushrooms);
            }
            if (spec == Specialty.meatlovers)
            {
                toppings.Add(Topping.cheese);
                toppings.Add(Topping.pepperoni);
                toppings.Add(Topping.sausage);
                toppings.Add(Topping.beef);
                toppings.Add(Topping.ham);
            }
            if (spec == Specialty.veggie)
            {
                toppings.Add(Topping.cheese);
                toppings.Add(Topping.peppers);
                toppings.Add(Topping.onions);
                toppings.Add(Topping.mushrooms);
            }
            if (spec == Specialty.hawaiian)
            {
                toppings.Add(Topping.cheese);
                toppings.Add(Topping.pepperoni);
                toppings.Add(Topping.ham);
                toppings.Add(Topping.pineapple);
            }
            ComputeCost();
        }

        /* Cost is calculated as follows:
         * Base price - 5 small, 8 medium, 12 large
         * Stuffed crust - add 2
         * First two toppings included. Additional toppings - add 1 each (max 5 toppings total)
         */
        public void ComputeCost()
        {
            double c = 0;
            if (size == Size.small)
                c += 5;
            else if (size == Size.medium)
                c += 8;
            else
                c += 12;
            if (crust == Crust.stuffed)
                c += 2;
            if (toppings.Count > 2)
                c += (toppings.Count - 2);
            cost = c;
        }

        public void setOrderId(int id)
        {
            orderId = id;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Crust: {crust}");
            Console.WriteLine($"Size: {size}");
            Console.WriteLine("Toppings: ");
            foreach (Topping t in toppings)
                Console.WriteLine($"\t{t}");
            Console.WriteLine($"Cost: ${cost}");
        }
    }
}
