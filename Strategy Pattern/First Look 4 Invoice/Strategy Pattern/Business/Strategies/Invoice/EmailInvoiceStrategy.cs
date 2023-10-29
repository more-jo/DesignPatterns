using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Strategies.Invoice
{
  internal class EmailInvoiceStrategy : InvoiceStrategy
  {
    public override void Generate(Order order)
    {
      var body = GenerateTextInvoice(order);

      using (SmtpClient client = new SmtpClient("smtp.sendgrd.net", 587))
      {
        NetworkCredential credential = new NetworkCredential(userName: "fekberg", password: "   ");
        client.Credentials = credential;

        MailMessage mail = new MailMessage(from: "filip@ekberg.dev", to: "filip@ekberg.dev")
        {
          Subject = "We've created an voice for you order",
          Body = body
        };

        client.Send(mail);
      }
    }
  }
}
