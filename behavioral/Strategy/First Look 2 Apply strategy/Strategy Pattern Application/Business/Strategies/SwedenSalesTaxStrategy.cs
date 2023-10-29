using Strategy_Pattern_First_Look.Business.Strategies.SalesTax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Strategies
{
  public class SwedenSalesTaxStrategy : ISalesTaxStrategy
  {
    public decimal GetTaxFor(Order order)
    {
      string destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
      var origin = order.ShippingDetails.OriginCountry.ToLowerInvariant();

      decimal totalTax = 0m;
      foreach (var item in order.LineItems)
      {

        switch (item.Type)
        {
          case ItemType.Literature:
            totalTax += (item.OrderSize) * 0.08m;
            break;
          case ItemType.Food:
            totalTax += (item.OrderSize) * 0.08m;
            break;
          case ItemType.Services:
          case ItemType.Hardware:
            totalTax += (item.OrderSize) * 0.08m;
            break;
          default: throw new ArgumentOutOfRangeException($"Item typs is not defined: {item.Type}");
        }
      }
      return totalTax;

      if (destination == origin)
      {
        var totalTaxRate = (decimal)order.TotalPrice * 0.25m;
        return totalTaxRate;
      }

      return 0;
    }
  }
}
