using ShoppingCart.CoreBusiness.Models;
using ShoppingCart.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.RegisterScreen
{
    public class Register : IRegister
    {
        private readonly IRegisterRepository registerRepository;

        public Register(IRegisterRepository registerRepository)
        {
            this.registerRepository = registerRepository;
        }
        public RegisterUser GetUser()
        {
            return registerRepository.GetUser();
        }

        public RegisterUser UserRegistration(int Id, string CustomerFirstName, string CustomerLastName, string CustomerEmailAddress, string CustomerMobileNo, string CustomerRegistrdDate, string CountryName)
        {
            return registerRepository.UserRegister(Id, CustomerFirstName, CustomerLastName, CustomerEmailAddress, CustomerMobileNo, CustomerRegistrdDate, CountryName);
        }
    }
}
