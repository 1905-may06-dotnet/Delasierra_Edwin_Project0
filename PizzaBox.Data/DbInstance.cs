using PizzaBox.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Data
{
    public sealed class DbInstance
    {
        private static PizzaContext instance = null;
        private DbInstance()
        {
        }
        public static PizzaContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PizzaContext();
                    return instance;
                }
                else
                {
                    return instance;
                }
            }
        }
    }
}
