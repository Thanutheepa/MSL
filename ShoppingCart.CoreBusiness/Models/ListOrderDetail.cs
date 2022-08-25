using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.CoreBusiness.Models
{
    public class ListOrderDetail
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string OrderQuantity { get; set; }
        public string Amount { get; set; }
        
        public ListOrderDetail(int itemId, string itemName, string orderQuantity, string amount)
        {
            this.ItemId = itemId;
            this.ItemName = itemName;
            this.OrderQuantity = orderQuantity;
            this.Amount = amount;
        }
    }
}