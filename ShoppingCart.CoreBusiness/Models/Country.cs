using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.CoreBusiness.Models
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public List<State> ListState { get; set; }
    }

    public class State
    {
        public int StateId { get; set; }
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }
}
