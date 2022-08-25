using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.CoreBusiness.Models
{
    public class ItemRating
    {
        public int ItemId { get; set; }
        public string Review { get; set; }
        public int CustomerId { get; set; }
        public int StartCount { get; set; }

        public ItemRating(int ItemId, string Review, int CustomerId, int StartCount)
        {
            this.ItemId = ItemId;
            this.Review = Review;
            this.CustomerId = CustomerId;
            this.StartCount = StartCount;
        }
    }

    public class ItemReviews
    {
        public int ItemReviewId { get; set; }
        public int ItemId { get; set; }
        public string Review { get; set; }
        public int CustomerId { get; set; }
        public int StartCount { get; set; }
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
    }
}
