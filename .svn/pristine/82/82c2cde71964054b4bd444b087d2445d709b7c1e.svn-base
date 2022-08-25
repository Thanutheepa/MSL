using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public class ApiService : IApiService
    {
        [Inject]
        IConfiguration Configuration { get; set; }
        string testApi = "";
        string liveApi = "";
        string apiType = "";
        private readonly HttpClient httpClient;
        private readonly IOptions<AppSettingsApi> options;
        public ApiService(HttpClient httpClient, IOptions<AppSettingsApi> options)
        {
            this.httpClient = httpClient;
            testApi = options.Value.test;
            liveApi = options.Value.live;
            apiType = options.Value.type;
        }

        public ApiService()
        {
            //AppSettingsApi appSettingsApi = Configuration.GetSection("ApiLinks").Get<AppSettingsApi>();
            testApi = "http://api.mothersl.melstasoft.com:80";
            liveApi = "http://api.mothersl.melstasoft.com:80";
            apiType = "live";
            var newHttpClient = new HttpClient();
            newHttpClient.BaseAddress = new Uri(GetAPI());
            httpClient = newHttpClient;
        }

        public HttpClient GetHttpClient()
        {
            return httpClient;
        }

        public string GetAPI()
        {
            if (apiType == "live")
                return liveApi;
            else
                return testApi;
        }

        public async Task<Token> GetToken()
        {
            string postBody = "username=user&password=user&grant_type=password";
            var request = new HttpRequestMessage(new HttpMethod("POST"), GetAPI()+"/token");
            request.Content = new StringContent(postBody);
            using var response = await httpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<Token>();
        }


        public async Task<List<CheckoutCart>> GetOrderDetails(string orderId)
        {
            Token token = (await GetToken());
            using (httpClient)
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), GetAPI()+"/api/v1/Order/" + orderId))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", token.token_type + " " + token.access_token);

                    var response = await httpClient.SendAsync(request);

                    /*return await response.Content.ReadFromJsonAsync<List<Orders>>();*/
                    var str = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<CheckoutCart>>(str);
                }
            }
        }

        public async Task<string> Checkout(CheckoutCart checkoutCart, string userId)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(checkoutCart), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/CreateOrder/"+userId, orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task UpdateOrder(string orderId)
        {
            OrderUpdate orderUpdate = new OrderUpdate();
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(orderUpdate), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("/api/v2/UpdateOrderStatus?id="+orderId, orderDataJson);
            response.EnsureSuccessStatusCode();
            
            // Deserialize the updated product from the response body.
            //product = await response.Content.ReadAsAsync<Product>();
            //return product;
        }

        public async Task<string> GetDiscount(string code, string amount)
        {
            var data = new StringContent(amount, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/GetDiscount/" + code, data);
            var content = await response.Content.ReadAsStringAsync();
            return content;
            //return Convert.ToDouble(content);
        }

        public async Task<string> GetAbhimanaDiscount(string amount)
        {
            var data = new StringContent(amount, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/GetAbhimanaDiscount/", data);
            var content = await response.Content.ReadAsStringAsync();
            return content;
            //return Convert.ToDouble(content);
        }

        public async Task<double> GetDeliveryFee(double weight, string country, string state)
        {
            Delivery delivery = await httpClient.GetFromJsonAsync<Delivery>("api/v1/getDeliveryFee/" + weight +"/" + country +"/" +state);
            return delivery.DeliveryFee;
        }
        
        public async Task<double> GetDeliveryFeeNormal(string id)
        {
            Delivery delivery = await httpClient.GetFromJsonAsync<Delivery>("api/v1/GetDeliveryFeeByAddressId/" + id);
            return delivery.DeliveryFee;
        }

        public async Task<List<Country>> GetCountries()
        {
            return await httpClient.GetFromJsonAsync<List<Country>>("/api/v1/country/");
        }

        public async Task<Delivery> GetDeliveryFee2(string id)
        {
            Delivery delivery = await httpClient.GetFromJsonAsync<Delivery>("api/v1/GetDeliveryFeeByAddressId/" + id);
            return delivery;
        }

        public async Task<List<Slide>> GetSliders()
        {
            return await httpClient.GetFromJsonAsync<List<Slide>>("/api/v1/Sliders/");
        }
        public async Task<List<Banner>> GetBanner()
        {
            return await httpClient.GetFromJsonAsync<List<Banner>>("/api/v1/Banners/");
        }

        public async Task<List<BlogPosts>> GetAllPosts()
        {
            return await httpClient.GetFromJsonAsync<List<BlogPosts>>("/api/v1/GetAllBlogPosts/");
        }
        public async Task<BlogPosts> GetPostById(int id)
        {
            return await httpClient.GetFromJsonAsync<BlogPosts>("/api/v1/GetBlogPostById/"+id);
        }

        public async Task<List<BlogPosts>> GetNewestPosts(int count)
        {
            return await httpClient.GetFromJsonAsync<List<BlogPosts>>("/api/v1/GetNewestPosts/"+count);
        }
        public async Task<List<Gallery>> GetAllGalleries()
        {
            return await httpClient.GetFromJsonAsync<List<Gallery>>("/api/v1/GetAllGalleries/");
        }
        public async Task<List<GalleryItem>> GetAllGalleryImages(int id)
        {
            return await httpClient.GetFromJsonAsync<List<GalleryItem>>("/api/v1/GetAllGalleryImages/"+id);
        }
        public async Task<Rate> GetRate(string type)
        {
            return await httpClient.GetFromJsonAsync<Rate>("/api/v1/GetRateByType/"+type);
        }
    }
}
