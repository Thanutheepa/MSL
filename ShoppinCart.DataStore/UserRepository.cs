using ShoppingCart.CoreBusiness.Models;
using ShoppingCart.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppinCart.DataStore
{
    public class UserRepository : IUserRepository
    {
        //private List<User> users;

        private User users;

        public UserRepository()
        {

            users = new User();
        }

        public void SaveUser(int loginid, int id, string email, string password)
        {
            users.LoginId = loginid;
            users.CustomerId = id;
            users.UserName = email;
            users.Password = password;
            users.LastLogin = "2021-10-07T07:05:44.838Z";
            users.LoginAttempt = 0;
            users.IsLocked = 0;
            users.ResetCode = "";
            users.ResetExpiryDate = "2021-10-07T07:05:44.838Z";
            users.CustomerMobileValidated = 0;
        }

        public User GetUsers()
        {
            return users;
        }

        public User LoginUser(User user)
        {
            users = user;
            return users;
        }
    }
}
