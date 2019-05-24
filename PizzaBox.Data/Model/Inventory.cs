using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Model
{
    public partial class Inventory
    {
        public int Locationid { get; set; }
        public int Smallcrust { get; set; }
        public int Mediumcrust { get; set; }
        public int Largecrust { get; set; }
        public int Cheese { get; set; }
        public int Pepperoni { get; set; }
        public int Sausage { get; set; }
        public int Ham { get; set; }
        public int Chicken { get; set; }
        public int Beef { get; set; }
        public int Pineapple { get; set; }
        public int Peppers { get; set; }
        public int Onions { get; set; }
        public int Jalapenos { get; set; }
        public int Mushrooms { get; set; }

        public virtual Location Location { get; set; }
    }
}
