using BlazorServerApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorServerApp.Api
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class PaymentResultController : ControllerBase
    {
        
        // GET: api/<PaymentResultController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PaymentResultController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PaymentResultController>
        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            string decision = "";
            string signature = "";
            string orderId = "";
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (var key in Request.Form.Keys)
            {
                parameters.Add(key, Request.Form[key]);
                if (key == "decision")
                {
                    decision = Request.Form[key];
                }
                if(key == "signature")
                {
                    signature = Request.Form[key];
                }
                if(key == "req_reference_number")
                {
                    orderId = Request.Form[key];
                }
            }
            Security security = new Security();
            IApiService apiService = new ApiService();

            if (signature.Equals(security.sign(parameters)) && (decision == "ACCEPT" || decision == "REVIEW"))
            {
                await apiService.UpdateOrder(orderId);
                byte[] bStatus = System.Text.ASCIIEncoding.ASCII.GetBytes("success");
                string encryptedStatus = Convert.ToBase64String(bStatus);
                return Redirect("/paymentSuccess/"+ encryptedStatus);
            }
            else
            {
                byte[] bStatus = System.Text.ASCIIEncoding.ASCII.GetBytes("fail");
                string encryptedStatus = Convert.ToBase64String(bStatus);
                return Redirect("/paymentSuccess/"+ encryptedStatus);
            }
        }

        // PUT api/<PaymentResultController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentResultController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
