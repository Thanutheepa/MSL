using Newtonsoft.Json;
using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await httpClient.GetFromJsonAsync<Product[]>("api/v1/GetAllProducts");
        }

        public async Task<IEnumerable<Product>> GetNewProducts()
        {
            return await httpClient.GetFromJsonAsync<Product[]>("api/v1/NewProducts");
        }

        public async Task<IEnumerable<Product>> GetProductById(int productId)
        {
            return await httpClient.GetFromJsonAsync<Product[]>("api/v1/GetProductsByProductIdList/"+productId);
        }

        public async Task<IEnumerable<Product>> GetNewProductsByOutletId(int outletId)
        {
            if (outletId > 0)
            {
                return await httpClient.GetFromJsonAsync<Product[]>("api/v1/NewProductsByOutletId/" + outletId);
            }
            else
            {
                return (await GetNewProducts());
            }
        }

        public async Task<IEnumerable<Product>> GetMostBuyingProducts(int outletId)
        {
            if (outletId > 0)
            {
                return await httpClient.GetFromJsonAsync<Product[]>("api/v1/MostBuyingProducts/" + outletId);
            }
            else
            {
                return (await GetNewProducts());
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByOutletId(int outletId)
        {
            if(outletId > 0)
            {
                return await httpClient.GetFromJsonAsync<Product[]>("api/v1/OutletItemByOutletId/" + outletId);
            }
            else
            {
                return (await GetAllProducts());
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            if (categoryId > 0)
            {
                return await httpClient.GetFromJsonAsync<Product[]>("api/v1/GetProductsByCategoryId/" + categoryId);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByCatIdAndOutletId(int outletId, int categoryId, bool isSathosa)
        {
            IEnumerable<Product> outletItems = await GetProductsByOutletId(outletId);
            //IEnumerable<Product> categoryItems = await GetProductsByCategoryId(categoryId);
            if(isSathosa)
                outletItems = outletItems.Where(product => product.IsSathosa == 1);

            if (categoryId > 0)
                return outletItems.Where(product => product.ProductCategoryId == categoryId);
            else
                return outletItems.GroupBy(a => a.ItemCode).Select(o => o.FirstOrDefault()); ;

        }

        public async Task<Product> GetProductByIdAndOutletId(int outletId, int productId)
        {
            IEnumerable<Product> outletItems = await GetProductsByOutletId(outletId);
            return outletItems.Where(product => product.productId == productId).ElementAt(0);
        }

        public async Task AddReview(int itemId, string review, int userId, int starCount)
        {
            ItemRating itemRating = new ItemRating(itemId,review,userId,starCount);
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(itemRating), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/v1/SaveItemReview", orderDataJson);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            //product = await response.Content.ReadAsAsync<Product>();
            //return product;
        }

        public async Task<ItemReviews[]> GetItemReviews(int productId)
        {
            return await httpClient.GetFromJsonAsync<ItemReviews[]>("api/v1/GetItemReviewByItemId/" + productId);
        }

        public async Task<ItemImages> GetItemImages(int itemId)
        {
            return await httpClient.GetFromJsonAsync<ItemImages>("api/v1/GetItemImages/" + itemId);
        }

    }
}
