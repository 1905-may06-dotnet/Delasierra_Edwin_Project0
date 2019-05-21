using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain;

namespace PizzaBox.Client
{
    class Client
    {
        private Dictionary<string, User> userBase = new Dictionary<string, User>();
        private Dictionary<int, Location> locationBase = new Dictionary<int, Location>();
        private User currentUser;
        public void CreateNewUser(string name, string pw)
        {
            User newUser= new User(name, pw);
            userBase.Add(name, newUser);
        }

        public bool LoginReturningUser(string name, string pw)
        {
            foreach (KeyValuePair<string, User> u in userBase)
            {
                if (u.Key == name && u.Value.password == pw)
                    return true;
            }
            return false;
        }

        public void AddLocation(int storeID, string name)
        {
            Location store = new Location(storeID, name);
            locationBase.Add(storeID, store);
        }

        public void SetCurrentUser(User person)
        {
            currentUser = person;
        }
    }
}
