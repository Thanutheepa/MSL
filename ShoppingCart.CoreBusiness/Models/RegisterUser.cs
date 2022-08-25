using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.CoreBusiness.Models
{
    [Serializable]
    public class RegisterUser
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string CustomerMobileNo { get; set; }
        public int CustomerMobileValidated { get; set; }
        public string CustomerRegistrdDate { get; set; }
        public int CustomerStatus { get; set; }
        public int OTP { get; set; }
        public string CountryName { get; set; }
        public int IsAbhimana { get; set; }
        public int AbhimanaNumer { get; set; }
        public int NumberOfOrders { get; set; }
    }
}
