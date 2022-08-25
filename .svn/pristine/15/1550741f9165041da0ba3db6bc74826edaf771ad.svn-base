using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public interface IApiService
    {
        HttpClient GetHttpClient();
        Task<Token> GetToken();
        Task<List<CheckoutCart>> GetOrderDetails(string orderId);
        Task<string> Checkout(CheckoutCart checkoutCart, string userId);
        Task UpdateOrder(string orderId);
        Task<string> GetDiscount(string code, string amount);
        Task<double> GetDeliveryFee(double weight, string country, string state);
        Task<Delivery> GetDeliveryFee2(string id);
        Task<double> GetDeliveryFeeNormal(string id);
        Task<string> GetAbhimanaDiscount(string amount);
        Task<List<Country>> GetCountries();
        Task<List<Slide>> GetSliders();
        Task<List<Banner>> GetBanner();
        Task<List<BlogPosts>> GetAllPosts();
        Task<BlogPosts> GetPostById(int id);
        Task<List<BlogPosts>> GetNewestPosts(int count);
        Task<List<Gallery>> GetAllGalleries();
        Task<List<GalleryItem>> GetAllGalleryImages(int id);
        Task<Rate> GetRate(string type);
    }
}
