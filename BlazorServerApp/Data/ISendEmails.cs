//put this inside data
using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlazorServerApp.Data
{
    public interface ISendEmails
    {
        List<CartItem> AllCartItems { get; set; }

        string SendEmail(string receiverEmail, string satatus, StringBuilder message, string customerName, string subject);
        void SendEmailContact(StringBuilder message);
        StringBuilder GetEmailBodyContact(string fullName, string email, string msg, string tel, string country);
        StringBuilder GetEmailBody(List<CartItem> allItems, string customerName, string totalPrice, string today, string orderId, string customerAddress, string paymentType);

        StringBuilder GetEmailBodyContact(string fullName, string email, string subject, string msg);

    }
}
