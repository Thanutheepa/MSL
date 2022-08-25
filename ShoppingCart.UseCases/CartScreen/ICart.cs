using ShoppingCart.CoreBusiness.Models;
using ShoppingCart.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.CartScreen
{
    public interface ICart
    {
        void SetCart(List<Product> products);
        List<Product> GetCartProducts();
        List<Product> AddToCart(Product product);
        List<Product> RemoveFromCart(Product product);
        void EmptyCart();
    }
}
