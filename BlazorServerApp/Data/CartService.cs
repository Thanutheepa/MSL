using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public class CartService : ICartService
    {
        private List<CartItem> cartItems;
        private bool viewCartPopup { get; set; } = false;

        [Inject]
        private ApiService apiSerivce { get; set; }

        [Inject]
        private AppState appState { get; set; }  

        public CartService()
        {
            cartItems = new List<CartItem> { };
        }

        public void SetCart(List<CartItem> cartItems)
        {
            this.cartItems = cartItems;
        }
        
        public void SetCartPopup(bool status)
        {
            this.viewCartPopup = status;
        }

        public List<CartItem> GetCartProducts()
        {
            return cartItems;
        }
        
        public bool GetCartPopup()
        {
            return viewCartPopup;
        }

        public List<CartItem> AddToCart(CartItem cartItem)
        {
            foreach (var item in cartItems)
            {
                if (item.Product.productId == cartItem.Product.productId)
                {
                    //cartItems.Remove(item);
                    item.Qty = cartItem.Qty;
                    return cartItems;
                }
            }
            cartItems.Add(cartItem);
            return cartItems;
        }

        public List<CartItem> RemoveFromCart(CartItem cartItem)
        {
            cartItems.Remove(cartItem);
   /*         foreach (var item in cartItems)
            {
                if (item.Product.productId == cartItem.Product.productId)
                {
                    cartItems.Remove(item);
                    return cartItems;
                }
            }*/
            return cartItems;
        }

        public List<CartItem> RemoveFromCartItem(Product product)
        {
            CartItem cartItemRemove = null;
            foreach(var cartItem in cartItems)
            {
                if(cartItem.Product.productId == product.productId)
                {
                    cartItemRemove = cartItem;
                    break;
                }
            }
            return RemoveFromCart(cartItemRemove);
        }

        public Product GetProductInCart(int productId)
        {
            CartItem item = null;
            foreach (var cartItem in cartItems)
            {
                if (cartItem.Product.productId == productId)
                {
                    item = cartItem;
                    break;
                }
            }
            return item.Product;
        }

        public void EmptyCart()
        {
            cartItems = new List<CartItem> { };
        }

        public double GetTotal()
        {
            double total = 0;
            if (cartItems.Count() > 0)
            {
                foreach (var cartProduct in cartItems)
                {
                    total += cartProduct.Product.SellingPrice * cartProduct.Qty;
                }
            }
            return total;
        }

        public int GetTotalCount()
        {
            int total = 0;
            if (cartItems.Count() > 0)
            {
                foreach (var cartProduct in cartItems)
                {
                    total += cartProduct.Qty;
                }
            }
            return total;
        }

        public double GetTotalWeight()
        {
            double total = 0;
            if (cartItems.Count() > 0)
            {
                foreach (var cartProduct in cartItems)
                {
                    total += cartProduct.Product.Weight * cartProduct.Qty;
                }
            }
            return Math.Round(total,3);
        }

        public bool IsAdded(Product product)
        {
            foreach(var cartItem in cartItems)
            {
                if (cartItem.Product.productId == product.productId)
                    return true;
            }
            return false;
        }

        public List<ListOrderDetail> GetCheckoutItems()
        {
            List<ListOrderDetail> checkoutList = new List<ListOrderDetail>();

            foreach(var cartItem in cartItems)
            {
                checkoutList.Add(new ListOrderDetail(cartItem.Product.productId, cartItem.Product.name, cartItem.Qty.ToString(), (cartItem.Product.SellingPrice*cartItem.Qty).ToString()));
            }

            return checkoutList;
        }

        public CheckoutCart GetCheckout(string name, string phone, string address, string billing, string paymentType, double total, int selectedOutlet, double deliveryFee, string coupon, double discount, int deliveryType, int deliveryOption)
        {
            List<ListOrderDetail> cartItems = GetCheckoutItems();
            CheckoutCart checkoutCart = new CheckoutCart();
            checkoutCart.CustomerName = name;
            checkoutCart.ContactNumber = phone;
            checkoutCart.CustomerAddress = address;
            checkoutCart.BillingAddress = billing;
            checkoutCart.DeliveryFee = deliveryFee.ToString();
            checkoutCart.OutletId = selectedOutlet.ToString();
            checkoutCart.TotalAmount = total.ToString();
            checkoutCart.ListOrderDetails = cartItems;
            checkoutCart.PaymentTypeId = paymentType;
            checkoutCart.PromotionCode = coupon;
            checkoutCart.DiscountAmount = discount.ToString();
            checkoutCart.DeliveryModeId = deliveryType.ToString();
            checkoutCart.DeliveryOptionId = deliveryOption.ToString();

            if (paymentType == "2")
            {
                checkoutCart.OrderStatusId = "0";
            }

            return checkoutCart;
        }
        
        public CheckoutCart GetCheckoutDonate(ListOrderDetail item, string name, string phone, string address, string billing, string paymentType, double total, int selectedOutlet, double deliveryFee, string coupon, double discount, int deliveryType, int deliveryOption)
        {
            List<ListOrderDetail> cartItems = new List<ListOrderDetail>();
            cartItems.Add(item);
            CheckoutCart checkoutCart = new CheckoutCart();
            checkoutCart.CustomerName = name;
            checkoutCart.ContactNumber = phone;
            checkoutCart.CustomerAddress = address;
            checkoutCart.BillingAddress = billing;
            checkoutCart.DeliveryFee = deliveryFee.ToString();
            checkoutCart.OutletId = selectedOutlet.ToString();
            checkoutCart.TotalAmount = total.ToString();
            checkoutCart.ListOrderDetails = cartItems;
            checkoutCart.PaymentTypeId = paymentType;
            checkoutCart.PromotionCode = coupon;
            checkoutCart.DiscountAmount = discount.ToString();
            checkoutCart.DeliveryModeId = deliveryType.ToString();
            checkoutCart.DeliveryOptionId = deliveryOption.ToString();

            if (paymentType == "2")
            {
                checkoutCart.OrderStatusId = "0";
            }

            return checkoutCart;
        }

        public int GetProductCountInCart(Product product)
        {
            foreach (var cartItem in cartItems)
            {
                if (cartItem.Product.productId == product.productId)
                    return cartItem.Qty;
            }
            return 0;
        }
    }
}
