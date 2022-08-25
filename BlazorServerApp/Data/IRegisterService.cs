using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public interface IRegisterService
    {
        Task<RegisterUser> RegisterCustomer(RegisterUser registerUser);

        Task<bool> VerifedOtp(int id, int otp);

        Task<string> SaveLogin(List<User> user);

        Task<User> LoginUser(string email, string password);

        Task<bool> ResendOtp(int id);

        Task<int> UpdateCustomer(RegisterUser registerUser);

        Task<string> VerifyOTPforUpdateCustomer(int id, int otp);
        Task<int> LoginIdByUserName(string username);
        Task<bool> ResendOtpById(int id);
        Task<bool> VerifedOtpById(int id, int otp);
        Task<string> UpdatePasswordByUserId(int id, string password);
        Task<RegisterUser> GetCustomerById(int id);
    }
}
