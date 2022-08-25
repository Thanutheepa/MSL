using ShoppingCart.CoreBusiness.Models;
using ShoppingCart.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppinCart.DataStore
{
    public class CartRepository : ICartRepository
    {
        private List<Product> products;

        public CartRepository()
        {
            products = new List<Product> { };
        }

        public void SetCart(List<Product> products)
        {
            this.products = products;
        }

        public List<Product> GetCartProducts()
        {
            return products;
        }

        public List<Product> AddToCart(Product product)
        {
            products.Add(product);
            return products;
        }

        public List<Product> RemoveFromCart(Product product)
        {
            products.Remove(product);
            return products;
        }

        public void EmptyCart()
        {
            products = new List<Product> { };
        }
    }
}
