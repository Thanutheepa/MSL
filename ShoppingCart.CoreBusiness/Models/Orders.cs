using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.CoreBusiness.Models
{
    public class Orders
    {
        public int OrderID { get; set; } 
        public string OrderDate { get; set; }
        public int DistrictId { get; set; }
        public int OutletId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int ContactNumber { get; set; }
        public object CustomerNic { get; set; } 
        public string TotalAmount { get; set; }
        public string DeliveryFee { get; set; }
        public int OrderTypeId { get; set; } 
        public string Remarks { get; set; } 
        public int OrderStatusId { get; set; } 
        public int PaymentTypeId { get; set; } 
        public string TsrAssignedDate { get; set; }
        public string Longitude { get; set; } 
        public string Latitude { get; set; } 
        public int QuarantinePlace { get; set; }
        public int DeliveryModeId { get; set; }
        public string PromotionCode { get; set; }
        public string DiscountAmount { get; set; }
        public int DeliveryOptionId { get; set; }
        public List<ListOrderDetail> ListOrderDetails { get; set; }
        public Outlet Outlet { get; set; }
    }
}
