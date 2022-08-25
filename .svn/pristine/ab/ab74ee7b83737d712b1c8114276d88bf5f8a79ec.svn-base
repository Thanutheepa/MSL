//put this inside data
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Email_Sending.Data;
using System.Net.Mail;
using ShoppingCart.CoreBusiness.Models;
using BlazorServerApp.Data;
using Microsoft.AspNetCore.Components;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BlazorServerApp.Data
{
    public class SendEmails : ISendEmails
    {
        [Inject]
        public ICartService cartService { get; set; }

        [Inject]
        IConfiguration Configuration { get; set; }
        private readonly IOptions<AppSettingsEmail> options;

        public SendEmails(IOptions<AppSettingsEmail> options)
        {
            this.options = options;
        }
        public List<CartItem> AllCartItems { get; set; }


        public StringBuilder GetEmailBody(List<CartItem> allItems, string customerName, string totalPrice, string today, string orderId, string customerAddress, string paymentType)
        {
            /*public StringBuilder GetEmailBody(List<CartItem> allItems, string total, string delivery, string customerName, string totalPrice, string today, string orderId, string customerAddress, string billingAdd, string paymentType)
            {
    */
            StringBuilder body = new StringBuilder();

            body.Append("<div style= 'width:90%; margin:auto;'>");
            body.Append("<div style='width:100%; text-align:center'><img src='https://www.mothersrilanka.lk/images/logo.png' style='width:250px'/></div>");
            body.Append("<div style = 'margin-top: 25px;text-align: center; font-size: medium;font-weight: 600;margin-top: 25px;font-family:arial,sans-serif;' ><h3>Dear "); body.Append(customerName); body.Append(", Thank you for ordering with Mother Sri Lanka.</h3> <br> <h4 style='color: #500050;' >Order Id:  #"); body.Append(orderId); body.Append(" Total Rs. "); body.Append(totalPrice);
            body.Append("  <br>Order Date & Time: "); body.Append(today);
            body.Append("  <br>Delivery Address: "); body.Append(customerAddress);
            body.Append("  <br>Payment Type: "); body.Append(paymentType);
            body.Append("</h4></div>");
            body.Append("<div style='margin-top: 25px; text-align: center;'><form action = 'https://www.mothersrilanka.lk/' ><button style = 'background-color: rgba(254,0,2,1);border: none;color: white;padding: 15px 20px;text-align: center;text-decoration: none;display: inline-block;font-size: 16px;margin-top: 25px;margin-bottom: 25px;border-radius: 10px;'> Visit Store </button></form></div>");


            body.Append("<center>");
            body.Append("<table style = 'border: 1px solid rgba(254,0,2,1);border-collapse: collapse; table-layout: fixed;width: 100%;'>");
            body.Append("<thead>");
            body.Append("<tr>");
            body.Append("<td style = 'color: #500050;border: 1px solid rgba(254,0,2,1);border-collapse: collapse;text-align: center;font-size: 15px;font-weight: bold; font-family:Verdana;' > Your Product </td>");
            body.Append("<td style = 'color: #500050;border: 1px solid rgba(254,0,2,1);border-collapse: collapse;text-align: center;font-size: 15px;font-weight: bold; font-family:Verdana;' > Quantity </td>");
            body.Append("<td style = 'color: #500050;border: 1px solid rgba(254,0,2,1);border-collapse: collapse;text-align: center;font-size: 15px;font-weight: bold; font-family:Verdana;' > Price </td>");
            body.Append("</tr>");
            body.Append("</thead>");
            body.Append("<tbody>");
            foreach (var item in allItems)
            {
                body.Append("<tr style = 'height: 200px;border-collapse: collapse;'>");
                body.Append("<td style = 'color: #500050;border: 1px solid rgba(254,0,2,1);border-collapse: collapse;text-align: center;font-size: 15px;font-weight: bold; font-family:Verdana;' > <img src = '"); body.Append(item.Product.ImageUrl); body.Append("'"); body.Append("alt = 'img' title = 'img' width = '150' style='display: block;'> </td>");
                body.Append("<td style = 'color: #500050;border: 1px solid rgba(254,0,2,1);border-collapse: collapse;text-align: center;font-size: 15px;font-weight: bold; font-family:Verdana;' >"); body.Append(item.Qty.ToString()); body.Append("</td>");
                body.Append("<td style = 'color: #500050;border: 1px solid rgba(254,0,2,1);border-collapse: collapse;text-align: center;font-size: 15px;font-weight: bold; font-family:Verdana;' > Rs."); body.Append(item.Product.SellingPrice); body.Append("</td>");
                body.Append("</tr>");
            }
            body.Append("</tbody>");
            body.Append("</table>");
            body.Append("</center>");

            body.Append("<br><br>");
            body.Append("<center>");
            body.Append("<table style = 'border: 1px solid rgba(254,0,2,1);border-collapse: collapse; table-layout: fixed;width: 100%;'>");
            body.Append("<thead>");
            body.Append("<tr>");
            body.Append("<td style = 'color: #500050;border: 1px solid rgba(254,0,2,1);border-collapse: collapse;text-align: center;font-size: 15px;font-weight: bold; font-family:Verdana;' > Customer Address </td>");
            body.Append("<td style = 'color: #500050;border: 1px solid rgba(254,0,2,1);border-collapse: collapse;text-align: center;font-size: 15px;font-weight: bold; font-family:Verdana;' > Payment Type </td>");
            body.Append("</tr>");
            body.Append("</thead>");
            body.Append("<tbody>");

            body.Append("<tr style = 'height: 200px;border-collapse: collapse;'>");

            body.Append("<td style = 'color: #500050;border: 1px solid rgba(254,0,2,1);border-collapse: collapse;text-align: center;font-size: 15px;font-weight: bold; font-family:Verdana;' >"); body.Append(customerAddress); body.Append("</td>");
            body.Append("<td style = 'color: #500050;border: 1px solid rgba(254,0,2,1);border-collapse: collapse;text-align: center;font-size: 15px;font-weight: bold; font-family:Verdana;' >"); body.Append(paymentType); body.Append("</td>");
            body.Append("</tr>");

            body.Append("</tbody>");
            body.Append("</table>");
            body.Append("</center>");

            body.Append("<div style='margin-top: 30px;text-align: center;align-items: center;'>");
            body.Append("<div style='height: auto; width: 100%; margin: auto; color: #686868; padding: 10px; border-top: 1px solid rgba(254,0,2,1);'>");
            body.Append("<h2>Get in Touch</h2><h4> This email was sent by: "); body.Append(options.Value.emailAddress); body.Append("</h4><h3> For any questions please send an email to "); body.Append(options.Value.emailAddress); body.Append(" </h3>");
            body.Append("</div></div>");

            body.Append("</div>");

            return body;

            /*StringBuilder EmailBody = new StringBuilder();

            EmailBody.Append("<div class='moz - forward - container'>");
            EmailBody.Append("<div class='moz -forward-container'>");
            EmailBody.Append("<div dir = 'ltr'>");
            EmailBody.Append("<div class='gmail_quote'> <br>");
            EmailBody.Append("<div");
            EmailBody.Append("style = 'background:#f6f6f6;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:12px;margin:0;padding:0'>");
            EmailBody.Append("<div");
            EmailBody.Append("style ='background:#f6f6f6;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:12px;margin:0;padding:0'>");
            EmailBody.Append("<table width = '100%' cellspacing='0' cellpadding='0'");
            EmailBody.Append("border ='0'>");
            EmailBody.Append("<tbody>");
            EmailBody.Append("<tr>");
            EmailBody.Append("<td style = 'padding:20px 0 20px 0' valign='top'");
            EmailBody.Append("  align ='center'>");
            EmailBody.Append("  <table style = 'border:1px solid #e0e0e0' width='650'");
            EmailBody.Append("    cellspacing ='0' cellpadding='10' border='0'");
            EmailBody.Append("    bgcolor ='#FFFFFF'>");
            EmailBody.Append("    <tbody>");
            EmailBody.Append("     <tr>");
            EmailBody.Append("        <td valign = 'top'><a ");
            EmailBody.Append("href ='http://url1320.stassentea.com/ls/click?upn=EHEGhGYZyfhB3kk9dRMWaKMCkyraRdYd8mhZF18toN2lg5eBs86W1FwcRb3sidMpGAcO_O-2FU6FgVzkniEfvVtvPoR7AyKbfSgAGq8XBX6MDdMELDpiPv2IBfb-2BcRG24F4Z85l-2FvF63-2BRhFbHCLtPukQMx96OC4nN51ZnAKuUgshJbXkVhJGL-2FkmWDXH-2BI-2Fp2ME9noG6xlbFsngi8-2FJVIPtKRwKmGrxjIw47yvyvPf5Iggo1-2Bx-2BpARtvOd1ij-2FOO32kl3GF2B0zUZm-2BfQ6sYefKdMA3tMEZF1SjqBg5GHAhVPWqpfKYJjEMZOkwqq3LT5jKtQeF7T6Np7sWqfif6lwb0kO6w-3D-3D' ");
            EmailBody.Append("                             target ='_blank' moz-do-not-send='true'><img ");
            EmailBody.Append(" src = 'https://www.stassentea.com/media/email/logo/default/logo.png' ");
            EmailBody.Append("                               alt ='Stassen Tea' ");
            EmailBody.Append("                              style ='margin-bottom:10px' ");
            EmailBody.Append("                              moz -do-not-send='true' border='0'></a></td> ");
            EmailBody.Append("                      </tr> ");
            EmailBody.Append(" <tr> ");
            EmailBody.Append(" <td valign = 'top'> ");
            EmailBody.Append("   <h1 ");
            EmailBody.Append("     style ='font-size:22px;font-weight:normal;line-height:22px;margin:0 ");
            EmailBody.Append("       0 11px 0'>Hello, "); EmailBody.Append(customerName); EmailBody.Append("</h1> ");
            EmailBody.Append("       <p ");
            EmailBody.Append("        style = 'font-size:12px;line-height:16px;margin:0 ");
            EmailBody.Append("         0 10px 0'> Thank you for your order from ");
            EmailBody.Append("         Stassen Tea.Once your package ships we ");
            EmailBody.Append("          will send an email with a link to track ");
            EmailBody.Append("           your order.If you have any questions ");
            EmailBody.Append("           about your order please contact us at <a ");
            EmailBody.Append("              href = 'mailto:sales@stassentea.com' ");
            EmailBody.Append("              style = 'color:#1e7ec8' target= '_blank' ");
            EmailBody.Append("              moz -do-not-send= 'true' ");
            EmailBody.Append("               class='moz-txt-link-freetext'>sales @stassentea.com</a> ");
            EmailBody.Append("            or call us at <span>(+94) 11 522 4200</span> ");
            EmailBody.Append("             Monday - Friday, 8am - 5pm PST. </p> ");
            EmailBody.Append("           <p ");
            EmailBody.Append("style = 'font-size:12px;line-height:16px;margin:0'> Your ");


            EmailBody.Append("                 order confirmation is below.Thank you ");
            EmailBody.Append("                 again for your business.</p> ");
            EmailBody.Append("            </td> ");
            EmailBody.Append("          </tr> ");
            EmailBody.Append("          <tr> ");
            EmailBody.Append("            <td> ");
            EmailBody.Append("              <h2 ");
            EmailBody.Append("                style = 'font-size:18px;font-weight:normal;margin:0'> Your ");

            EmailBody.Append("                Order #"); EmailBody.Append(orderId); EmailBody.Append(" <small>(placed on "); EmailBody.Append(today);
            EmailBody.Append("                  )</small></h2> ");
            EmailBody.Append("            </td> ");
            EmailBody.Append("         </tr> ");
            EmailBody.Append("         <tr> ");
            EmailBody.Append("            <td> ");
            EmailBody.Append("             <table width = '650' cellspacing='0' ");
            EmailBody.Append("                cellpadding ='0' border='0'> ");
            EmailBody.Append("                  <thead> <tr> ");
            EmailBody.Append("                     <th style = 'font-size:13px;padding:5px ");
            EmailBody.Append(" 9px 6px 9px;line-height:1em' ");
            EmailBody.Append("                        width ='325' bgcolor='#EAEAEA'");
            EmailBody.Append("                        align ='left'>Billing Information:</th>");
            EmailBody.Append("                      <th width = '10'><br>");
            EmailBody.Append("                     </th>");
            EmailBody.Append("                      <th style='font-size:13px;padding:5px ");
            EmailBody.Append("                       9px 6px 9px;line-height:1em' ");
            EmailBody.Append("                        width ='325' bgcolor='#EAEAEA' ");
            EmailBody.Append("                       align ='left'>Payment Method:</th> ");
            EmailBody.Append("                    </tr> ");
            EmailBody.Append("                   </thead> <tbody> ");
            EmailBody.Append("                    <tr> ");
            EmailBody.Append("                      <td style = 'font-size:12px;padding:7px ");
            EmailBody.Append("                        9px 9px 9px;border-left:1px solid ");
            EmailBody.Append("                        #eaeaea;border-bottom:1px solid ");
            EmailBody.Append("                        #eaeaea;border-right:1px solid ");
            EmailBody.Append("                        #eaeaea' valign='top'> "); EmailBody.Append(customerName); EmailBody.Append(" <br>");
            EmailBody.Append("                        "); EmailBody.Append(billingAdd); EmailBody.Append(" </td> ");
            EmailBody.Append("                      <td> </td> ");
            EmailBody.Append("                      <td style = 'font-size:12px;padding:7px ");
            EmailBody.Append("                        9px 9px 9px; border-left:1px solid ");
            EmailBody.Append(" # eaeaea;border-bottom:1px solid ");
            EmailBody.Append(" # eaeaea;border-right:1px solid ");
            EmailBody.Append(" # eaeaea' valign='top'> ");
            EmailBody.Append("                         <p><strong>HNB Payment Gateway</strong></p> ");
            EmailBody.Append("                       </td> ");
            EmailBody.Append("                     </tr> ");
            EmailBody.Append("                   </tbody> ");
            EmailBody.Append("                 </table> ");
            EmailBody.Append("                 <br> ");
            EmailBody.Append("                  <table width = '100%' cellspacing= '0' cellpadding = '0' border= '0'> ");


            EmailBody.Append(" <thead> <tr>");


            EmailBody.Append(" <th style= 'font-size:13px;padding:5px  9px 6px 9px; line-height:1em'  width='325' bgcolor='#EAEAEA' align='left'>Shipping Information:</th> ");
            EmailBody.Append("<th width = '10'><br> </th> ");
            EmailBody.Append(" <th style='font-size:13px;padding:5px 9px 6px 9px;line-height:1em' width='325' bgcolor='#EAEAEA' align='left'>Shipping Method:</th> ");
            EmailBody.Append(" </tr> </thead> <tbody> ");
            EmailBody.Append(" <tr> ");
            EmailBody.Append("                      <td style = 'font-size:12px;padding:7px ");
            EmailBody.Append("                       9px 9px 9px;border-left:1px solid ");
            EmailBody.Append("                       #eaeaea;border-bottom:1px solid ");
            EmailBody.Append("                       #eaeaea;border-right:1px solid ");
            EmailBody.Append("                      #eaeaea' valign='top'>  ");
            EmailBody.Append("                      "); EmailBody.Append(customerName); EmailBody.Append(" <br>");
            EmailBody.Append("                    "); EmailBody.Append(customerAddress); EmailBody.Append("   </td>");
            EmailBody.Append("                 <td> </td>");
            EmailBody.Append("                <td style = 'font-size:12px;padding:7px");
            EmailBody.Append("                9px 9px 9px; border-left:1px solid");
            EmailBody.Append("               #eaeaea;border-bottom:1px solid");
            EmailBody.Append("               #eaeaea;border-right:1px solid");
            EmailBody.Append("               #eaeaea' valign='top'> Select");
            EmailBody.Append("                Shipping Method - International");
            EmailBody.Append("                Courier - With Tracking</td>");
            EmailBody.Append("            </tr>");
            EmailBody.Append("         </tbody>");
            EmailBody.Append("        </table> ");
            EmailBody.Append("        <br>");
            EmailBody.Append("       </td> ");
            EmailBody.Append("     </tr> ");
            EmailBody.Append("           <tr>");
            EmailBody.Append("            <td>");
            EmailBody.Append("               <table cellspacing = '0' cellpadding= '0'");
            EmailBody.Append("                 border = '1'>");
            EmailBody.Append("                  <thead> <tr>");
            EmailBody.Append("                      <th> Item in your order </th>");
            EmailBody.Append("                      <th> Qty</th>");
            EmailBody.Append("                      <th> Price</th>");
            EmailBody.Append("                    </tr>");
            EmailBody.Append("                  </thead> <tbody>");
            foreach (var item in allItems)
            {
                EmailBody.Append("                    <tr> ");
                EmailBody.Append("                      <td> ");
                EmailBody.Append("                        <p>"); EmailBody.Append(item.Product.name); EmailBody.Append("</p>");
                EmailBody.Append("                        <p>SKU: "); EmailBody.Append(item.Product.ItemCode); EmailBody.Append("</p> ");
                EmailBody.Append("                      </td> ");
                EmailBody.Append("                      <td>"); EmailBody.Append(item.Qty); EmailBody.Append("</td> ");
                EmailBody.Append("                      <td> <span>$"); EmailBody.Append(String.Format("{0:0.00}", Math.Round(item.Product.SellingPrice * item.Qty, 2))); EmailBody.Append("</span> </td> ");
                EmailBody.Append("                    </tr> ");
            }
            EmailBody.Append("                  </tbody> ");
            EmailBody.Append("                </table> ");
            EmailBody.Append("              </td> </tr> <tr>  <td>  <table cellspacing = '0' cellpadding= '0'  border= '1'> <tbody> <tr>  <td>  <table cellspacing= '0'  cellpadding= '0' border= '0'> ");
            EmailBody.Append("                          <tbody>  <tr> <td colspan= '3'  style= 'padding:3px 9px' align= 'right'> Subtotal </td> <td style= 'padding:3px 9px'");
            EmailBody.Append("                                align = 'right'> <span>$"); EmailBody.Append(String.Format("{0:0.00}", Math.Round((Convert.ToDouble(total) - Convert.ToDouble(delivery)), 2))); EmailBody.Append("</span> ");
            EmailBody.Append("</td></tr> <tr> <td colspan = '3' style= 'padding:3px 9px'  align= 'right'> Shipping & amp; Handling</td> ");
            EmailBody.Append("<td style = 'padding:3px 9px' align ='right'> <span>$"); EmailBody.Append(String.Format("{0:0.00}", Math.Round(Convert.ToDouble(delivery), 2))); EmailBody.Append("</span> ");
            EmailBody.Append("</td> </tr> <tr> <td colspan = '3' style='padding:3px 9px' align='right'> <strong>Grand Total</strong> </td> ");
            EmailBody.Append("<td style = 'padding:3px 9px'  align = 'right'> <strong><span>$"); EmailBody.Append(String.Format("{0:0.00}", Math.Round(Convert.ToDouble(total), 2))); EmailBody.Append("</span></strong> ");
            EmailBody.Append("</td>  </tr></tbody>  </table> </td>  </tr> </tbody>  </table> </td> </tr>  <tr> <td> <br>  </td> </tr>  <tr>  <td ");
            EmailBody.Append("style = 'background:#eaeaea;text-align:center'  bgcolor = '#EAEAEA' align= 'center'> <center> <p style= 'font-size:12px;margin:0'> ");
            EmailBody.Append("Thank you again, <strong>Stassen Tea</strong></p> ");
            EmailBody.Append(" </center></td> </tr></tbody> </table>  </td> </tr>  </tbody> </table> </div> ");
            EmailBody.Append("<img   src = 'http://url1320.stassentea.com/wf/open?upn=kB-2FPSFKU0ohDbvHSiKAoKTqslNgJ3HlNelZtY5z7bdRyie0XpyzQi5tFmGlZdBZVwUVYkSoApD-2BgnHKM8oG2RWAqrn8d-2BdsgNzMvsIiFd9b5t4NYhEjqbGwJxCLNeGU1ENUBJEXI7H-2B7xE6eU3GSYZlDNyw04tJsD0xKkQyVI9CE39zuad5SehlERyCTBpqemYveSvJfDO795gNFThu5c78NquHs1LkPlqtRf0jR0r6RvfbtKwuUpL0lU1ORVOJtdIL-2FzTvrHM-2BClGeV1OTnNtbf-2F-2BP-2BB4ZwhYXDICawFm0-3D' ");
            EmailBody.Append("alt= '' style = 'height:1px!important;width:1px!important;border-width:0!important;margin-top:0!important;margin-bottom:0!important;margin-right:0!important;margin-left:0!important;padding-top:0!important;padding-bottom:0!important;padding-right:0!important;padding-left:0!important' ");
            EmailBody.Append(" moz-do-not-send= 'true' width= '1' height= '1' border= '0'></div> ");
            EmailBody.Append("</div></div><br></div></div>");


            return EmailBody;*/
        }

        public StringBuilder GetEmailBodyContact(string fullName, string email, string msg, string tel, string country)
        {
            StringBuilder EmailBody = new StringBuilder();

            EmailBody.Append("<div class='moz - forward - container'>");
            EmailBody.Append("<div class='moz -forward-container'>");
            EmailBody.Append("<div dir = 'ltr'>");
            EmailBody.Append("<div class='gmail_quote'> <br>");
            EmailBody.Append("<div");
            EmailBody.Append("style = 'background:#f6f6f6;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:12px;margin:0;padding:0'>");
            EmailBody.Append("<div");
            EmailBody.Append("style ='background:#f6f6f6;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:12px;margin:0;padding:0'>");
            EmailBody.Append("<table width = '100%' cellspacing='0' cellpadding='0'");
            EmailBody.Append("border ='0'>");
            EmailBody.Append("<tbody>");
            EmailBody.Append("<tr>");
            EmailBody.Append("<td style = 'padding:20px 0 20px 0' valign='top'");
            EmailBody.Append("  align ='center'>");
            EmailBody.Append("  <table style = 'border:1px solid #e0e0e0' width='650'");
            EmailBody.Append("    cellspacing ='0' cellpadding='10' border='0'");
            EmailBody.Append("    bgcolor ='#FFFFFF'>");
            EmailBody.Append("    <tbody>");
            EmailBody.Append("     <tr>");
            EmailBody.Append("        <td valign = 'top'><a ");
            EmailBody.Append("href ='http://url1320.stassentea.com/ls/click?upn=EHEGhGYZyfhB3kk9dRMWaKMCkyraRdYd8mhZF18toN2lg5eBs86W1FwcRb3sidMpGAcO_O-2FU6FgVzkniEfvVtvPoR7AyKbfSgAGq8XBX6MDdMELDpiPv2IBfb-2BcRG24F4Z85l-2FvF63-2BRhFbHCLtPukQMx96OC4nN51ZnAKuUgshJbXkVhJGL-2FkmWDXH-2BI-2Fp2ME9noG6xlbFsngi8-2FJVIPtKRwKmGrxjIw47yvyvPf5Iggo1-2Bx-2BpARtvOd1ij-2FOO32kl3GF2B0zUZm-2BfQ6sYefKdMA3tMEZF1SjqBg5GHAhVPWqpfKYJjEMZOkwqq3LT5jKtQeF7T6Np7sWqfif6lwb0kO6w-3D-3D' ");
            EmailBody.Append("                             target ='_blank' moz-do-not-send='true'><img ");
            EmailBody.Append(" src = 'https://www.stassentea.com/media/email/logo/default/logo.png' ");
            EmailBody.Append("                               alt ='Stassen Tea' ");
            EmailBody.Append("                              style ='margin-bottom:10px' ");
            EmailBody.Append("                              moz -do-not-send='true' border='0'></a></td> ");
            EmailBody.Append("                      </tr> ");
            EmailBody.Append(" <tr> ");
            EmailBody.Append(" <td valign = 'top'> ");
            EmailBody.Append("   <h1 ");
            EmailBody.Append("     style ='font-size:22px;font-weight:normal;line-height:22px;margin:0 ");
            EmailBody.Append("       0 11px 0'>New Message</h1> ");
            EmailBody.Append("            </td> ");
            EmailBody.Append("          </tr> ");
            EmailBody.Append("          <tr> ");
            EmailBody.Append("            <td> ");
            EmailBody.Append("              <h2 style = 'font-size:18px;font-weight:normal;margin:0'> Full Name:  ");EmailBody.Append(fullName);
            EmailBody.Append("                  </h2> ");            
            EmailBody.Append("              <h2 style = 'font-size:18px;font-weight:normal;margin:0'> Email:  ");EmailBody.Append(email);
            EmailBody.Append("                  </h2> ");
            EmailBody.Append("              <h2 style = 'font-size:18px;font-weight:normal;margin:0'> Message:  ");EmailBody.Append(msg);
            EmailBody.Append("                  </h2> ");
            EmailBody.Append("              <h2 style = 'font-size:18px;font-weight:normal;margin:0'> Telephone No:  ");EmailBody.Append(tel);
            EmailBody.Append("                  </h2> ");
            EmailBody.Append("              <h2 style = 'font-size:18px;font-weight:normal;margin:0'> Country:  ");EmailBody.Append(country);
            EmailBody.Append("                  </h2> ");
            EmailBody.Append("            </td> ");
            EmailBody.Append("         </tr> ");
            EmailBody.Append("                 ");
            EmailBody.Append("                 <br> ");

            EmailBody.Append("<tr> <td> <br>  </td> </tr>  <tr>  <td ");
            EmailBody.Append("style = 'background:#eaeaea;text-align:center'  bgcolor = '#EAEAEA' align= 'center'> <center> <p style= 'font-size:12px;margin:0'> ");
            EmailBody.Append("Thank you again, <strong>Mother Sri Lanka</strong></p> ");
            EmailBody.Append(" </center></td> </tr></tbody> </table>  </td> </tr>  </tbody> </table> </div> ");
            EmailBody.Append("<img   src = 'http://url1320.stassentea.com/wf/open?upn=kB-2FPSFKU0ohDbvHSiKAoKTqslNgJ3HlNelZtY5z7bdRyie0XpyzQi5tFmGlZdBZVwUVYkSoApD-2BgnHKM8oG2RWAqrn8d-2BdsgNzMvsIiFd9b5t4NYhEjqbGwJxCLNeGU1ENUBJEXI7H-2B7xE6eU3GSYZlDNyw04tJsD0xKkQyVI9CE39zuad5SehlERyCTBpqemYveSvJfDO795gNFThu5c78NquHs1LkPlqtRf0jR0r6RvfbtKwuUpL0lU1ORVOJtdIL-2FzTvrHM-2BClGeV1OTnNtbf-2F-2BP-2BB4ZwhYXDICawFm0-3D' ");
            EmailBody.Append("alt= '' style = 'height:1px!important;width:1px!important;border-width:0!important;margin-top:0!important;margin-bottom:0!important;margin-right:0!important;margin-left:0!important;padding-top:0!important;padding-bottom:0!important;padding-right:0!important;padding-left:0!important' ");
            EmailBody.Append(" moz-do-not-send= 'true' width= '1' height= '1' border= '0'></div> ");
            EmailBody.Append("</div></div><br></div></div>");


            return EmailBody;
        }

        public StringBuilder GetEmailBodyContact(string fullName, string email, string subject, string msg)
        {
            StringBuilder EmailBody = new StringBuilder();

            EmailBody.Append("<div class='moz - forward - container'>");
            EmailBody.Append("<div class='moz -forward-container'>");
            EmailBody.Append("<div dir = 'ltr'>");
            EmailBody.Append("<div class='gmail_quote'> <br>");
            EmailBody.Append("<div");
            EmailBody.Append("style = 'background:#f6f6f6;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:12px;margin:0;padding:0'>");
            EmailBody.Append("<div");
            EmailBody.Append("style ='background:#f6f6f6;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:12px;margin:0;padding:0'>");
            EmailBody.Append("<table width = '100%' cellspacing='0' cellpadding='0'");
            EmailBody.Append("border ='0'>");
            EmailBody.Append("<tbody>");
            EmailBody.Append("<tr>");
            EmailBody.Append("<td style = 'padding:20px 0 20px 0' valign='top'");
            EmailBody.Append("  align ='center'>");
            EmailBody.Append("  <table style = 'border:1px solid #e0e0e0' width='650'");
            EmailBody.Append("    cellspacing ='0' cellpadding='10' border='0'");
            EmailBody.Append("    bgcolor ='#FFFFFF'>");
            EmailBody.Append("    <tbody>");
            EmailBody.Append("     <tr>");
            EmailBody.Append("        <td valign = 'top'><a ");
            EmailBody.Append("href ='https://www.mothersrilanka.lk' ");
            EmailBody.Append("                             target ='_blank' moz-do-not-send='true'><img ");
            EmailBody.Append(" src = 'https://www.mothersrilanka.lk/images/logo.png' ");
            EmailBody.Append("                               alt ='Stassen Tea' ");
            EmailBody.Append("                              style ='margin-bottom:10px' ");
            EmailBody.Append("                              moz -do-not-send='true' border='0'></a></td> ");
            EmailBody.Append("                      </tr> ");
            EmailBody.Append(" <tr> ");
            EmailBody.Append(" <td valign = 'top'> ");
            EmailBody.Append("   <h1 ");
            EmailBody.Append("     style ='font-size:22px;font-weight:normal;line-height:22px;margin:0 ");
            EmailBody.Append("       0 11px 0'>New Message</h1> ");
            EmailBody.Append("            </td> ");
            EmailBody.Append("          </tr> ");
            EmailBody.Append("          <tr> ");
            EmailBody.Append("            <td> ");
            EmailBody.Append("              <h2 style = 'font-size:18px;font-weight:normal;margin:0'> Name:  "); EmailBody.Append(fullName);
            EmailBody.Append("                  </h2> ");
            EmailBody.Append("              <h2 style = 'font-size:18px;font-weight:normal;margin:0'> Email:  "); EmailBody.Append(email);
            EmailBody.Append("                  </h2> ");
            EmailBody.Append("              <h2 style = 'font-size:18px;font-weight:normal;margin:0'> Subject:  "); EmailBody.Append(subject);
            EmailBody.Append("                  </h2> ");
            EmailBody.Append("              <h2 style = 'font-size:18px;font-weight:normal;margin:0'> Message:  "); EmailBody.Append(msg);
            EmailBody.Append("                  </h2> ");
            EmailBody.Append("            </td> ");
            EmailBody.Append("         </tr> ");
            EmailBody.Append("                 ");
            EmailBody.Append("                 <br> ");

            EmailBody.Append("<tr> <td> <br>  </td> </tr>  <tr>  <td ");
            EmailBody.Append("style = 'background:#eaeaea;text-align:center'  bgcolor = '#EAEAEA' align= 'center'> <center> <p style= 'font-size:12px;margin:0'> ");
            EmailBody.Append("Thank you again, <strong>Mother Sri Lanka</strong></p> ");
            EmailBody.Append(" </center></td> </tr></tbody> </table>  </td> </tr>  </tbody> </table> </div> ");
            EmailBody.Append("<img   src = 'http://url1320.stassentea.com/wf/open?upn=kB-2FPSFKU0ohDbvHSiKAoKTqslNgJ3HlNelZtY5z7bdRyie0XpyzQi5tFmGlZdBZVwUVYkSoApD-2BgnHKM8oG2RWAqrn8d-2BdsgNzMvsIiFd9b5t4NYhEjqbGwJxCLNeGU1ENUBJEXI7H-2B7xE6eU3GSYZlDNyw04tJsD0xKkQyVI9CE39zuad5SehlERyCTBpqemYveSvJfDO795gNFThu5c78NquHs1LkPlqtRf0jR0r6RvfbtKwuUpL0lU1ORVOJtdIL-2FzTvrHM-2BClGeV1OTnNtbf-2F-2BP-2BB4ZwhYXDICawFm0-3D' ");
            EmailBody.Append("alt= '' style = 'height:1px!important;width:1px!important;border-width:0!important;margin-top:0!important;margin-bottom:0!important;margin-right:0!important;margin-left:0!important;padding-top:0!important;padding-bottom:0!important;padding-right:0!important;padding-left:0!important' ");
            EmailBody.Append(" moz-do-not-send= 'true' width= '1' height= '1' border= '0'></div> ");
            EmailBody.Append("</div></div><br></div></div>");


            return EmailBody;
        }

        public string SendEmail(string receiverEmail, string EmailStatus, StringBuilder message, string customerName, string subject)
        {
            /*AllCartItems = cartService.GetCartProducts();
            emailBody = GetEmailBody(AllCartItems);*/
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(options.Value.emailAddress);
                    mail.To.Add(receiverEmail);
                    mail.CC.Add("mothersrilankatrust2015@gmail.com");
                    mail.Subject = subject;//"Dear "+ customerName + " , Thank You For Ordering From Lanka Sathosa!";
                    mail.Body = @message.ToString();
                        /*mail.Body = message.ToString();*/
                        mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(options.Value.domain, options.Value.port))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(options.Value.emailAddress, options.Value.password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        EmailStatus = "mail sent";
                    }
                }
            }

            catch (Exception ex)
            {
                EmailStatus = ex.Message;
                throw;
            }
            return EmailStatus;
        }

        public void SendEmailContact(StringBuilder message)
        {
            /*AllCartItems = cartService.GetCartProducts();
            emailBody = GetEmailBody(AllCartItems);*/
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(options.Value.emailAddress);
                    mail.To.Add("mothersrilankatrust2015@gmail.com ");
                    mail.Subject = "New Message!";//"Dear "+ customerName + " , Thank You For Ordering From Lanka Sathosa!";
                    mail.Body = @message.ToString();
                    /*mail.Body = message.ToString();*/
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(options.Value.domain, options.Value.port))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(options.Value.emailAddress, options.Value.password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }


}
