using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetNewProducts();
        Task<IEnumerable<Product>> GetProductById(int productId);
        Task<IEnumerable<Product>> GetNewProductsByOutletId(int outletId);
        Task<IEnumerable<Product>> GetProductsByOutletId(int outletId);
        Task<IEnumerable<Product>> GetMostBuyingProducts(int outletId);
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
        Task<IEnumerable<Product>> GetProductsByCatIdAndOutletId(int outletId, int categoryId, bool isSathosa);
        Task<Product> GetProductByIdAndOutletId(int outletId, int productId);
        Task AddReview(int itemId, string review, int userId, int starCount);
        Task<ItemReviews[]> GetItemReviews(int productId);
        Task<ItemImages> GetItemImages(int itemId);
    }
}
