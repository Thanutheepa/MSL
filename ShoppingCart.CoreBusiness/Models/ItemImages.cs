using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.CoreBusiness.Models
{
    public class ItemImages
    {
        public int imageId { get; set; }
        public int itemId { get; set; }
        public List<string> imagePath { get; set; }
    }
}
