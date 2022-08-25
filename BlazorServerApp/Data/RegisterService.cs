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
    public class RegisterService : IRegisterService
    {
        private readonly HttpClient httpClient;
        public RegisterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> LoginIdByUserName(string username)
        {
            var url = "/api/v1/LoginIdByUsername?username=" + username;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(response);
        }

        public async Task<User> LoginUser(string email, string password)
        {
            var url = "/api/v1/LoginDetails/" + email + "/" + password;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(response);
        }

        public async Task<RegisterUser> RegisterCustomer(RegisterUser registerUser)
        {
            var customerJson = new StringContent(JsonConvert.SerializeObject(registerUser), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/CreateCustomer", customerJson);
            //  response.EnsureSuccessStatusCode();

            Int32 responseHttpStatusCode = (Int32)response.StatusCode;
            if(responseHttpStatusCode == 200)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RegisterUser>(content);
            }
            else 
            {
                return JsonConvert.DeserializeObject<RegisterUser>("");
            }
            
        }

        public async Task<bool> ResendOtp(int id)
        {
            var url = "/api/v1/ResentVerifyOTPCodeById/" + id;
            var verifyresendotpjson = new StringContent("", Encoding.UTF8, "application/json");
            var req = await httpClient.PostAsync(url,verifyresendotpjson);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<bool>(response);
        }
        public async Task<bool> ResendOtpById(int id)
        {
            var url = "/api/v2/ResentVerifyOTPCodeById/" + id;
            var verifyresendotpjson = new StringContent("", Encoding.UTF8, "application/json");
            var req = await httpClient.PostAsync(url, verifyresendotpjson);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<bool>(response);
        }

        public async Task<string> SaveLogin(List<User> user)
        {

            var saveloginJson = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/SaveLogin", saveloginJson);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(content);
        }

        public async Task<int> UpdateCustomer(RegisterUser registerUser)
        {
            var updateJson = new StringContent(JsonConvert.SerializeObject(registerUser), Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync("/api/v2/UpdateCustomer", updateJson);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(content);
        }

        public async Task<string> UpdatePasswordByUserId(int id, string password)
        {
            var data = "";
            var url = "/api/v1/UpdatePasswordByUserId/" + id +"/" + password;
           // var updatepasswordjson = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
            var req = await httpClient.PostAsync(url,null);
            var response = await req.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<string>(response);
        }

        public async Task<bool> VerifedOtp(int id, int otp)
        {
            var data = otp;
            var url = "/api/v1/VerifyOTPCodeById/" + id;
            var verifyotpjson = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
            Console.WriteLine(verifyotpjson);
            var req = await httpClient.PostAsync(url, verifyotpjson);
            var response = await req.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(response);

        }

        public async Task<bool> VerifedOtpById(int id, int otp)
        {
            var data = otp;
            var url = "/api/v2/VerifyOTPCodeById/" + id;
            var verifyotpjson = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
            Console.WriteLine(verifyotpjson);
            var req = await httpClient.PostAsync(url, verifyotpjson);
            var response = await req.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(response);
        }

        public async Task<string> VerifyOTPforUpdateCustomer(int id, int otp)
        {
            var data = otp;
            var url = "/api/v1/VerifyOTPNumberForUpdateCustomer/" + id;
            var verifyotpjson = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
            var req = await httpClient.PostAsync(url, verifyotpjson);
            var response = await req.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<string>(response);
        }

        public async Task<RegisterUser> GetCustomerById(int id)
        {
            var url = "/api/v1/GetCustomerById/" + id;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RegisterUser>(response);
        }
    }
}
