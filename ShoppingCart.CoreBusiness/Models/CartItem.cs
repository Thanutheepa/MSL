using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.CoreBusiness.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Qty { get; set; }

        public CartItem(Product product, int qty)
        {
            this.Product = product;
            this.Qty = qty;
        }
    }
}
