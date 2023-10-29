using Strategy_Pattern_First_Look.Business.Model;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Strategy_Pattern_First_Look
{
  public class Order
  {
    public ShippingDetails ShippingDetails
    {
      get;
      set;
    }

    public List<Item> LineItems
    {
      get;
      internal set;
    }

    public decimal GetTax()
    {
      var destination = ShippingDetails.DestinationCountry.ToLowerInvariant();

      if (destination == "sweden")
      {
        var origin = ShippingDetails.OriginCountry.ToLowerInvariant();
        if (destination == origin)
        {
          return (decimal)TotalPrice * 0.25m;
        }

        return 0;
      }

      if (destination == "us")
      {
        switch (ShippingDetails.DestinationState.ToLowerInvariant())
        {
          case "la":
            return (decimal)TotalPrice * 0.095m;
          case "ny":
            return (decimal)TotalPrice * 0.04m;
          case "nyc":
            return (decimal)TotalPrice * 0.045m;
          default:
            return 0m;
        }
      }

      return 0m;
    }

    public decimal TotalPrice
    {
      get; set;
    }
  }
}