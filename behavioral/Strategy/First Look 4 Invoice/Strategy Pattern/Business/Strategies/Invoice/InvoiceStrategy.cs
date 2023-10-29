using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Strategies.Invoice
{
  public abstract class InvoiceStrategy : IInvoiceStrategy
  {
    public abstract void Generate(Order order);

    public string GenerateTextInvoice(Order order)
    {
      var invoice = $"INVOICE DATE: {DateTimeOffset.Now}{Environment.NewLine}";

      invoice += $"ID|NAME|PRICE|QUATITY{Environment.NewLine}";

      foreach (var item in order.LineItems)
      {
        invoice += $"{item.Name}|{item.Type}";
      }

      invoice += Environment.NewLine + Environment.NewLine;

      var tax = order.GetTax();
      var total = order.TotalPrice + tax;

      invoice += $"TAX TOTAL: {tax}{Environment.NewLine}";
      invoice += $"TOTAL: {total}{Environment.NewLine}";

      return invoice;
    }
  }
}
