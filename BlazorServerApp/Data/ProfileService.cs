using Newtonsoft.Json;
using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public class ProfileService : IProfileService
    {
        private readonly HttpClient httpClient;
        public ProfileService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Address> BillingAddress(int customerId)
        {
            var url = "/api/v1/GetCustomerBillingByCustomerId/" + customerId;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Address>(response);
        }

        public async Task<string> ChangePassword(int id, string password)
        {
            var url = "/api/v1/UpdatePasswordByUserId/" + id+"/"+password;
            var changepwjson = new StringContent("", Encoding.UTF8, "application/json");
            var req = await httpClient.PostAsync(url, changepwjson);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(response);
        }

        public async Task<int> CreateCustomerBilling(Address address)
        {
            var customerBillingJson = new StringContent(JsonConvert.SerializeObject(address), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/CreateCustomerBilling1", customerBillingJson);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(content);
        }

        public async Task<int> CreateCustomerShipping(Address address)
        {
            var customerShippingJson = new StringContent(JsonConvert.SerializeObject(address), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/CreateCustomerShipping", customerShippingJson);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(content);
        }

        public async Task<int> DeleteCustomerBilling(int billingId)
        {
            var url = "/api/v1/DeleteCustomerBillingsById/" + billingId;
            var response= await httpClient.DeleteAsync(url);
            Int32 responseHttpStatusCode = (Int32)response.StatusCode;
            if (responseHttpStatusCode == 200)
            {
                return responseHttpStatusCode;
            }
            else
            {
                return 400;
            }
        }

        public async Task<int> DeleteCustomerShipping(int shippingId)
        {
            var url = "/api/v1/DeleteCustomerShippingById/" + shippingId;
            var response = await httpClient.DeleteAsync(url);
            Int32 responseHttpStatusCode = (Int32)response.StatusCode;
            if (responseHttpStatusCode == 200)
            {
                return responseHttpStatusCode;
            }
            else
            {
                return 400;
            }
        }

        public async Task<RegisterUser> GetCustomer(int CustomerId)
        {
            var url = "/api/v1/GetCustomerById/" + CustomerId;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RegisterUser>(response);
        }

        public async Task<Address> GetCustomerBilling(int customerid)
        {
            var url = "/api/v1/GetCustomerBillingByCustomerId/" + customerid;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Address>(response);
        }

        public async Task<List<Address>> GetCustomerShipping(int customerid)
        {
            var url = "/api/v1/GetCustomerShippingByCustomerId/" + customerid;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Address>>(response);
        }

        public async Task<List<Orders>> OrderDetails(int CustomerId)
        {
            var url = "/api/v1/OrderDetailsByCustomerId/" + CustomerId;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Orders>>(response);
        }

        public async Task<List<ListOrderDetail>> OrderDetailsByOrderId(int OrderId)
        {
            var url = "/api/v1/OrderDetails/" + OrderId;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ListOrderDetail>>(response);
        }

        public async Task<List<Product>> OrderItemDetails(List<int> orderid)
        {
            string combindedString = string.Join(",", orderid.ToArray());
            var url = "/api/v1/GetProductsByProductIdList/" + combindedString;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Product>>(response);
        }

        public async Task<List<Address>> ShippingAddress(int customerId)
        {
            var url = "/api/v1/GetCustomerShippingByCustomerId/" + customerId;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Address>>(response);
        }

        public async Task<int> UpdateCustomerBilling(Address address)
        {
            var customerBillingJson = new StringContent(JsonConvert.SerializeObject(address), Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync("/api/v1/UpdateCustomerBillings", customerBillingJson);
         //   response.EnsureSuccessStatusCode();
            Int32 responseHttpStatusCode = (Int32)response.StatusCode;
            if (responseHttpStatusCode == 200)
            {
                return responseHttpStatusCode;
            }
            else
            {
                return 400;
            }
          //  var content = await response.Content.ReadAsStringAsync();
           // return JsonConvert.DeserializeObject<string>(content);
        }

        public async Task<int> UpdateCustomerShipping(Address address)
        {
            var customerShippingJson = new StringContent(JsonConvert.SerializeObject(address), Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync("/api/v1/UpdateCustomerShipping", customerShippingJson);
            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<string>(content);

            Int32 responseHttpStatusCode = (Int32)response.StatusCode;
            if (responseHttpStatusCode == 200)
            {
                return responseHttpStatusCode;
            }
            else
            {
                return 400;
            }
        }
    }
}
