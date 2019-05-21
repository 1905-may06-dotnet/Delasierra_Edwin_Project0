using PizzaBox.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Data
{
    public interface ICrud
    {
        List<Users> GetUsers();
        Users GetUsers(string id);

        void AddUser(Users u);
        void DeleteUser(Users u);
    }
}
