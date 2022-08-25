using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public interface IPaymentService
    {
        Task<PaymentSession> CreateSession(string orderId, string amount, string fullAddress);
        Task<PaymentSession> CreateSessionUSD(string orderId, string amount, string fullAddress);
        Task<PaymentSession> CreateSessionMobile(string orderId, string amount);
    }
}
