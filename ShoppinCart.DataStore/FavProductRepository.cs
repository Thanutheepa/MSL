using ShoppingCart.CoreBusiness.Models;
using ShoppingCart.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppinCart.DataStore
{
    public class FavProductRepository : IFavProductRepository
    {
        private List<Product> products;

        public FavProductRepository()
        {
            products = new List<Product> { };
        }

        public void AddToFav(Product product)
        {
            products.Add(product);
        }

        public void EmptyFav()
        {
            products = new List<Product> { };
        }

        public List<Product> GetFavProducts()
        {
            return products;
        }

        public List<Product> RemoveFromFav(Product product)
        {
            //products.Remove(product);
            foreach(var pro in products)
            {
                if(pro.productId == product.productId)
                {
                    products.Remove(pro);
                    return products;
                }
            }
            return products;
        }

        public void SetFav(List<Product> products)
        {
            this.products = products;
        }
        public int GetTotalCount()
        {
            int total = 0;
            if (products.Count() > 0)
            {
                total = products.Count();
            }
            return total;
        }

        public bool IsAdded(Product product)
        {
            foreach (var isproduct in products)
            {
                if (isproduct.productId == product.productId)
                    return true;
            }
            return false;
        }
    }
}
