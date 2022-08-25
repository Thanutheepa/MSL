using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public class AppSettings
    {
        public const string sectionName = "paymentDetailsLive";

        public string apiPassword { get; set; }
        public string apiUsername { get; set; }
        public string merchant { get; set; }
        public string merchantName { get; set; }
        public string returnUrl { get; set; }
        public string returnUrlMobile { get; set; }
        public string cancelReturnUrl { get; set; }
    }
    public class AppSettingsUSD
    {
        public const string sectionName = "paymentDetailsLiveUSD";

        public string apiPassword { get; set; }
        public string apiUsername { get; set; }
        public string merchant { get; set; }
        public string merchantName { get; set; }
        public string returnUrl { get; set; }
        public string returnUrlMobile { get; set; }
        public string cancelReturnUrl { get; set; }
    }

    public class AppSettingsApi
    {
        public const string sectionName = "ApiLinks";
        public string test { get; set; }
        public string live { get; set; }
        public string type { get; set; }
    }
    
    public class AppSettingsEmail
    {
        public const string sectionName = "EmailDetails";

        public string emailAddress { get; set; }
        public string domain { get; set; }
        public int port { get; set; }
        public string password { get; set; }
    }
}
