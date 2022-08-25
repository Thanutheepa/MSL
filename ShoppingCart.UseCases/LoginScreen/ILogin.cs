using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.LoginScreen
{
    public interface ILogin
    {
        void SaveUser(int loginid, int id, string email, string password);
        User GetUsers();
        User LoginUser(User user);
    }
}
