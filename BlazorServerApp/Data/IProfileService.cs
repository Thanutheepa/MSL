using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public interface IProfileService
    {
        Task<RegisterUser> GetCustomer(int CustomerId);

        Task <List<Orders>> OrderDetails(int CustomerId);

        Task<List<ListOrderDetail>> OrderDetailsByOrderId(int OrderId);

        Task<List<Product>> OrderItemDetails(List<int> orderid);

        Task<Address> BillingAddress(int customerId);

        Task<List<Address>> ShippingAddress(int customerId);

        Task<string> ChangePassword(int id, string password);

        Task<int> CreateCustomerBilling(Address address);

        Task<Address> GetCustomerBilling(int customerid);

        Task<int> UpdateCustomerBilling(Address address);

        Task<int> CreateCustomerShipping(Address address);
        Task<List<Address>> GetCustomerShipping(int customerid);
        Task<int> UpdateCustomerShipping(Address address);
        Task<int> DeleteCustomerBilling(int billingId);
        Task<int> DeleteCustomerShipping(int shippingId);
    }
}
