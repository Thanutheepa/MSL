using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public interface ICartService
    {
        void SetCart(List<CartItem> cartItems);
        List<CartItem> GetCartProducts();
        void SetCartPopup(bool status);
        bool GetCartPopup();
        List<CartItem> AddToCart(CartItem cartItem);
        List<CartItem> RemoveFromCart(CartItem cartItem);
        void EmptyCart();
        double GetTotal();
        int GetTotalCount();
        double GetTotalWeight();
        bool IsAdded(Product product);
        List<ListOrderDetail> GetCheckoutItems();
        List<CartItem> RemoveFromCartItem(Product product);
        int GetProductCountInCart(Product product);
        Product GetProductInCart(int productId);
        CheckoutCart GetCheckout(string name, string phone, string address, string billing, string paymentType, double total, int selectedOutlet, double deliveryFee, string coupon, double discount, int deliveryType, int deliveryOption);
        CheckoutCart GetCheckoutDonate(ListOrderDetail item, string name, string phone, string address, string billing, string paymentType, double total, int selectedOutlet, double deliveryFee, string coupon, double discount, int deliveryType, int deliveryOption);
    }
}
