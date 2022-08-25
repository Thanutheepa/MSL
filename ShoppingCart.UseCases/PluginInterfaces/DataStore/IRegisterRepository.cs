using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.PluginInterfaces.DataStore
{
    public interface IRegisterRepository
    {
        RegisterUser UserRegister(int Id, string CustomerFirstName, string CustomerLastName, string CustomerEmailAddress, string CustomerMobileNo, string CustomerRegistrdDate, string CountryName);
        RegisterUser GetUser();
    }
}
