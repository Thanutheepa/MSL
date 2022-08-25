using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.CoreBusiness.Models
{
    public class PaymentSession
    {
        public string merchant { get; set; }
        public string result { get; set; }
        public string SessionId { get; set; }
        public string SessionUpdateStatus { get; set; }
        public string SessionVersion { get; set; }
        public string successIndicator { get; set; }

        public PaymentSession(string merchant, string result, string SessionId, string SessionUpdateStatus, string SessionVersion, string successIndicator)
        {
            this.merchant = merchant;
            this.result = result;
            this.SessionId = SessionId;
            this.SessionUpdateStatus = SessionUpdateStatus;
            this.SessionVersion = SessionVersion;
            this.successIndicator = successIndicator;
        }
    }
}
