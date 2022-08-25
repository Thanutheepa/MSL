using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.PluginInterfaces.DataStore
{
    public interface ICartRepository
    {
        void SetCart(List<Product> products);
        List<Product> GetCartProducts();
        List<Product> AddToCart(Product product);
        List<Product> RemoveFromCart(Product product);
        void EmptyCart();
    }
}
