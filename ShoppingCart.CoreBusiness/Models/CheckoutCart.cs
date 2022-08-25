using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.CoreBusiness.Models
{
    public class CheckoutCart
    {
        public int OrderID { get; set; } = 0;
        public string OrderDate { get; set; } = DateTime.Now.ToString();
        public string DistrictId { get; set; } = "1";
        public string OutletId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string BillingAddress { get; set; }
        public string ContactNumber { get; set; }
        public object CustomerNic { get; set; } = null;
        public string TotalAmount { get; set; }
        public string DeliveryFee { get; set; } = "0";
        public string OrderTypeId { get; set; } = "3";
        public string Remarks { get; set; } = "";
        public string OrderStatusId { get; set; } = "1";
        public string PaymentTypeId { get; set; } = "1";
        public string TsrAssignedDate { get; set; } = DateTime.Now.ToString();
        public string Longitude { get; set; } = "0";
        public string Latitude { get; set; } = "0";
        public string QuarantinePlace { get; set; } = "1";
        public string DeliveryModeId { get; set; }
        public string PromotionCode { get; set; }
        public string DiscountAmount { get; set; }
        public string DeliveryOptionId { get; set; }
        public List<ListOrderDetail> ListOrderDetails { get; set; }
    }
}