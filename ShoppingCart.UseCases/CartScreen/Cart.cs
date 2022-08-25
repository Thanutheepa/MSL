using ShoppingCart.CoreBusiness.Models;
using ShoppingCart.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.CartScreen
{
    public class Cart : ICart
    {
        private readonly ICartRepository cartRepository;

        public Cart(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public void SetCart(List<Product> products)
        {
            this.cartRepository.SetCart(products);
        }

        public List<Product> GetCartProducts()
        {
            return cartRepository.GetCartProducts();
        }

        public List<Product> AddToCart(Product product)
        {
            return cartRepository.AddToCart(product);
        }

        public List<Product> RemoveFromCart(Product product)
        {
            return cartRepository.RemoveFromCart(product);
        }

        public void EmptyCart()
        {
            cartRepository.EmptyCart();
        }
    }
}
