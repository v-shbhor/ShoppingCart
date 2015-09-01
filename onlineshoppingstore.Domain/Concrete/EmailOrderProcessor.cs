using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using onlineshoppingstore.Domain.Entities;
using System.Net;
using onlineshoppingstore.Domain.Abstract;

namespace onlineshoppingstore.Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
            private EmailSettings emailSettings;
            public EmailOrderProcessor(EmailSettings settings)
            {
                emailSettings = settings;
            }
            public void ProcessOrder(Cart cart,ShippingDetails shippingInfo)
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = emailSettings.UseSsl;
                    smtpClient.Host = emailSettings.ServerName;
                    smtpClient.Port = emailSettings.ServerPort;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                    //removed code from here
                    StringBuilder body = new StringBuilder()
                        .AppendLine("A new order has been submitted")
                        .AppendLine("...........")
                        .AppendLine("Items:");
                    foreach(var line in cart.lines)
                    {
                        var subtotal = line.Product.Price * line.Quantity;
                        body.AppendFormat("{0} X {1} (subtotal: {2:c}",
                            line.Quantity,
                            line.Product.Name,
                            subtotal);

                    }
                    body.AppendFormat("Total order value: {0:c}",
                        cart.ComputeTotalValue())
                        .AppendLine("...")
                        .AppendLine(shippingInfo.Name)
                        .AppendLine(shippingInfo.Line1)
                        .AppendLine(shippingInfo.Line2 ?? "")
                        .AppendLine(shippingInfo.Line3 ?? "")
                        .AppendLine(shippingInfo.City)
                        .AppendLine(shippingInfo.State ?? "")
                        .AppendLine(shippingInfo.Country)
                        .AppendLine(shippingInfo.Zip)
                        .AppendLine("...")
                        .AppendFormat("Gift Wrap: {0}",
                        shippingInfo.GiftWrap ? "Yes" : "No");
                    MailMessage mailmessage = new MailMessage(
                        emailSettings.MailFromAddress,
                        emailSettings.MailToAddress,
                        "New order submitted!",
                        body.ToString());
                    
                    smtpClient.Send(mailmessage);
                }

            }
        }
    }

