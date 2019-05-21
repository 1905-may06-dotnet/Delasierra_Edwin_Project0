using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Model
{
    public partial class Inventory
    {
        public int Locationid { get; set; }
        public int Smallthindough { get; set; }
        public int Mediumthindough { get; set; }
        public int Largethindough { get; set; }
        public int Smalloriginaldough { get; set; }
        public int Mediumoriginaldough { get; set; }
        public int Largeoriginaldough { get; set; }
        public int Smallstuffeddough { get; set; }
        public int Mediumstuffeddough { get; set; }
        public int Largestuffeddough { get; set; }
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
