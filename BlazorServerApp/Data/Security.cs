using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Specialized;
using Microsoft.Extensions.Options;

namespace BlazorServerApp.Data
{
    public class Security
    {
        private readonly IOptions<AppSettingsApi> options;

        private const String SECRET_KEY = "7b0e0ce73e0045a4a58497120069f9f299bcbc7f25454df4bfd9ec2f713a15ae460701665b5847f0b699f814a2bacca1f2eed0a8341d40c89814a5e248313bd4e98d29ca77514cee9b769321a37a8ec61da563c9e8a243e8b1a9336541ec4a04600f1f3a4cf849fc97ec9daead95cd0167978aeddc5347e1b1c7aa7b910199a2";
        //private String SECRET_KEY = "6c21b794e95e40f2b00559630e6ee297888fa6a0cdbd47ed9b683e3e9518a2ca87ebc279351b4261af7371bdcf4bd358d008cf0e0a6b47da804dbb754b4e81190d345fd66a744e1cbabcc6223443c2a09b455f105fe44a67b5df1e6bc219b18dba7d2a0185814cbaafe028f7e95c8143924ebd2579d64c579100ee53364cb13d";
        
        //private string SECRET_KEY = "";
    /*    public Security(IOptions<AppSettingsApi> options, IOptions<AppSettings> optionsPayment)
        {
            if (options.Value.type == "live")
                SECRET_KEY = optionsPayment.Value.live.SECRET_KEY;
            else
                SECRET_KEY = optionsPayment.Value.test.SECRET_KEY;
        }*/
        public String sign(IDictionary<string, string> paramsArray)  {
            return sign(buildDataToSign(paramsArray), SECRET_KEY);
        }

        private String sign(String data, String secretKey) {
            UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secretKey);

            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
            byte[] messageBytes = encoding.GetBytes(data);
            return Convert.ToBase64String(hmacsha256.ComputeHash(messageBytes));
        }

        private String buildDataToSign(IDictionary<string,string> paramsArray) {
            String[] signedFieldNames = paramsArray["signed_field_names"].Split(',');
            IList<string> dataToSign = new List<string>();

	        foreach (String signedFieldName in signedFieldNames)
	        {
	             dataToSign.Add(signedFieldName + "=" + paramsArray[signedFieldName]);
	        }

            return commaSeparate(dataToSign);
        }

        private String commaSeparate(IList<string> dataToSign) {
            return String.Join(",", dataToSign);                         
        }
    }
}
