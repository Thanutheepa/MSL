using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.PluginInterfaces.DataStore
{
    public interface IUserRepository
    {
        void SaveUser(int loginid, int id, string email, string password);
        User GetUsers();
        User LoginUser(User user);
    }
}
