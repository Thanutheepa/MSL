using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.CoreBusiness.Models
{
    public class Gallery
    {
        public int galleryId { get; set; }
        public string Title { get; set; }
        public string mainImage { get; set; }
    }
    public class GalleryItem
    {
        public int galleryId { get; set; }
        public string imagePath { get; set; }
    }
}
