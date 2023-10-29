using Strategy_Pattern_First_Look.Business.Strategies.SalesTax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Strategies
{
  public class USAStateSalesTaxStrategy : ISalesTaxStrategy
  {
    public decimal GetTaxFor(Order order)
    {
      switch (order.ShippingDetails.DestinationState.ToLowerInvariant())
      {
        case "la":
          return (decimal)order.TotalPrice * 0.095m;
        case "ny":
          return (decimal)order.TotalPrice * 0.04m;
        case "nyc":
          return (decimal)order.TotalPrice * 0.045m;
        default:
          return 0m;
      }
    }
  }
}
