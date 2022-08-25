using ShoppingCart.CoreBusiness.Models;
using ShoppingCart.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppinCart.DataStore
{
    public class RegisterRepository : IRegisterRepository
    {
        private RegisterUser customers;
        public RegisterRepository()
        {
            customers = new RegisterUser();
        }

        public RegisterUser GetUser()
        {
            return customers;
        }

        public RegisterUser UserRegister(int Id, string CustomerFirstName, string CustomerLastName, string CustomerEmailAddress, string CustomerMobileNo, string CustomerRegistrdDate, string CountryName)
        {
            customers.CustomerId = Id;
            customers.CustomerFirstName = CustomerFirstName;
            customers.CustomerLastName = CustomerLastName;
            customers.CustomerEmailAddress = CustomerEmailAddress;
            customers.CustomerMobileNo = CustomerMobileNo;
            customers.CustomerMobileValidated = 0;
            customers.CustomerRegistrdDate = CustomerRegistrdDate;
            customers.CustomerStatus = 0;
            customers.OTP = 0;
            customers.CountryName = CountryName;
            customers.NumberOfOrders = 0;

            return customers;
        }
    }
}
