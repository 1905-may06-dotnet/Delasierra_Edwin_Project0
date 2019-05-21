using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain
{
    public class Order
    {
        public int id { get; private set; }
        public int userId { get; set; }
        public Location store { get; set; }
        public List<Pizza> pizzas = new List<Pizza>();
        public double totalCost { get; set; }
        public DateTime time { get; set; }

        public Order()
        {
            id = 999999;
            Pizza p1 = new Pizza();
            p1.setOrderId(id);
            pizzas.Add(p1);
            totalCost = 0;
            foreach (Pizza p in pizzas)
                totalCost += p.cost;
            time = DateTime.Now;
        }

        public Order(List<Pizza> pizzaList)
        {
            id = 111111;
            int index = 0;
            if (pizzaList.Count > 100)
                Console.WriteLine("Max order size exceeded, will only take first 100");
            while (pizzas.Count <= 100 && totalCost <= 5000 && index < pizzaList.Count && index < 100)
            {
                if (totalCost + pizzaList[index].cost > 5000)
                {
                    Console.WriteLine("Order cost too high, will not exceed $5000");
                    break;
                }
                pizzas.Add(pizzaList[index]);
                totalCost += pizzas[index].cost;
                index++;
            }
            time = DateTime.Now;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Number of pizzas: {pizzas.Count}, Total cost: ${totalCost}, Time of order: {time}");
        }
    }
}
