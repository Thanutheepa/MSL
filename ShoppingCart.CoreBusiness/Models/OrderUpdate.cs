using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.CoreBusiness.Models
{
    public class OrderUpdate
    {
        public int statusId { get; set; } = 1;
        public int longitude { get; set; } = 0;
        public int latitude { get; set; } = 0;
    }
}
