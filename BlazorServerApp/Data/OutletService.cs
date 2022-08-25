using Microsoft.Extensions.Options;
using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public class OutletService : IOutletService
    {
        string testApi = "";
        string liveApi = "";
        string apiType = "";
        private readonly HttpClient httpClient;
        private readonly IOptions<AppSettingsApi> options;

        public OutletService(HttpClient httpClient, IOptions<AppSettingsApi> options)
        {
            this.httpClient = httpClient;
            testApi = options.Value.test;
            liveApi = options.Value.live;
            apiType = options.Value.type;
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

        public async Task<IEnumerable<Outlet>> GetAllOutlets()
        {
            Token token = (await GetToken());
            using (httpClient)
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), GetAPI()+"/api/v1/Outlet/all"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", token.token_type+" "+token.access_token);

                    var response = await httpClient.SendAsync(request);

                    return await response.Content.ReadFromJsonAsync<Outlet[]>();
                }
            }
        }
    }
}
