using Microsoft.Extensions.Options;
using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<AppSettings> options;
        private readonly IOptions<AppSettingsUSD> optionsUSD;

        public PaymentService(HttpClient httpClient, IOptions<AppSettings> options, IOptions<AppSettingsUSD> optionsUSD)
        {
            this.httpClient = httpClient;
            this.options = options;
            this.optionsUSD = optionsUSD;
        }
        public async Task<PaymentSession> CreateSession(string orderId, string amount, string fullAddress)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://cbcmpgs.gateway.mastercard.com/api/nvp/version/61"))
                {
                    var contentList = new List<string>();
                    contentList.Add("apiOperation=CREATE_CHECKOUT_SESSION");
                    contentList.Add("apiPassword=" + options.Value.apiPassword);
                    contentList.Add("apiUsername=" + options.Value.apiUsername);
                    contentList.Add("merchant=" + options.Value.merchant);
                    contentList.Add("interaction.merchant.name=" + options.Value.merchantName);
                    contentList.Add("interaction.operation=PURCHASE");
                    contentList.Add("interaction.displayControl.billingAddress=HIDE");
                    contentList.Add("order.id=" + orderId);
                    contentList.Add("order.description=Pay securely by Credit/Debit Card.");
                    contentList.Add("order.amount=" + amount);
                    contentList.Add("order.currency=LKR");
                    contentList.Add("interaction.returnUrl=" + options.Value.returnUrl);
                    contentList.Add("interaction.cancelUrl=" + options.Value.cancelReturnUrl);
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    string[] arr = responseBody.Split('&');
                    PaymentSession paymentSession = new PaymentSession(arr[0].Split('=')[1], arr[1].Split('=')[1], arr[2].Split('=')[1], arr[3].Split('=')[1], arr[4].Split('=')[1], arr[5].Split('=')[1]);

                    return paymentSession;
                }
            }
        }
        public async Task<PaymentSession> CreateSessionUSD(string orderId, string amount, string fullAddress)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://cbcmpgs.gateway.mastercard.com/api/nvp/version/61"))
                {
                    var contentList = new List<string>();
                    contentList.Add("apiOperation=CREATE_CHECKOUT_SESSION");
                    contentList.Add("apiPassword=" + optionsUSD.Value.apiPassword);
                    contentList.Add("apiUsername=" + optionsUSD.Value.apiUsername);
                    contentList.Add("merchant=" + optionsUSD.Value.merchant);
                    contentList.Add("interaction.merchant.name=" + optionsUSD.Value.merchantName);
                    contentList.Add("interaction.operation=PURCHASE");
                    contentList.Add("interaction.displayControl.billingAddress=HIDE");
                    contentList.Add("order.id=" + orderId);
                    contentList.Add("order.description=Pay securely by Credit/Debit Card.");
                    contentList.Add("order.amount=" + amount);
                    contentList.Add("order.currency=USD");
                    contentList.Add("interaction.returnUrl=" + optionsUSD.Value.returnUrl);
                    contentList.Add("interaction.cancelUrl=" + optionsUSD.Value.cancelReturnUrl);
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    string[] arr = responseBody.Split('&');
                    PaymentSession paymentSession = new PaymentSession(arr[0].Split('=')[1], arr[1].Split('=')[1], arr[2].Split('=')[1], arr[3].Split('=')[1], arr[4].Split('=')[1], arr[5].Split('=')[1]);

                    return paymentSession;
                }
            }
        }

        public async Task<PaymentSession> CreateSessionMobile(string orderId, string amount)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://cbcmpgs.gateway.mastercard.com/api/nvp/version/61"))
                {
                    var contentList = new List<string>();
                    contentList.Add("apiOperation=CREATE_CHECKOUT_SESSION");
                    contentList.Add("apiPassword=" + options.Value.apiPassword);
                    contentList.Add("apiUsername=" + options.Value.apiUsername);
                    contentList.Add("merchant=" + options.Value.merchant);
                    contentList.Add("interaction.merchant.name=" + options.Value.merchantName);
                    contentList.Add("interaction.operation=PURCHASE");
                    contentList.Add("interaction.displayControl.billingAddress=HIDE");
                    contentList.Add("order.id=" + orderId);
                    contentList.Add("order.description=Pay securely by Credit/Debit Card.");
                    contentList.Add("order.amount=" + amount);
                    contentList.Add("order.currency=LKR");
                    contentList.Add("interaction.returnUrl=" + options.Value.returnUrlMobile);
                    contentList.Add("interaction.cancelUrl=" + options.Value.cancelReturnUrl);
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    string[] arr = responseBody.Split('&');
                    PaymentSession paymentSession = new PaymentSession(arr[0].Split('=')[1], arr[1].Split('=')[1], arr[2].Split('=')[1], arr[3].Split('=')[1], arr[4].Split('=')[1], arr[5].Split('=')[1]);

                    return paymentSession;
                }
            }
        }
    }
}
