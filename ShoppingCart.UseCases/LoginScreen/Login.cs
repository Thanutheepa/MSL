using ShoppingCart.CoreBusiness.Models;
using ShoppingCart.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.LoginScreen
{
    public class Login : ILogin
    {
        private readonly IUserRepository userRepository;

        public Login(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void SaveUser(int loginid, int id, string email, string password)
        {
            userRepository.SaveUser(loginid, id, email, password);
        }

        public User GetUsers()
        {
            return userRepository.GetUsers();
        }

        public User LoginUser(User user)
        {
            return userRepository.LoginUser(user);
        }
    }
}
