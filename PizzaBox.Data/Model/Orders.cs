using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Model
{
    public partial class Orders
    {
        public Orders()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
        }

        public int Id { get; set; }
        public string Userid { get; set; }
        public int Locationid { get; set; }
        public decimal Totalcost { get; set; }
        public DateTime Ordertime { get; set; }

        public virtual Location Location { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrder { get; set; }
    }
}
