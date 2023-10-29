using Strategy_Pattern_First_Look.Business.Models;
using Strategy_Pattern_First_Look.Business.Strategies;
using Strategy_Pattern_First_Look.Business.Strategies.Invoice;

namespace Strategy_Pattern_First_Look
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var order = new Order
      {
        ShippingDetails = new ShippingDetails
        {
          OriginCountry = "Sweden",
          DestinationCountry = "Sweden"
        }
      };

      var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();

      if (destination == "sweden")
      {
        order.SalesTaxStrategy = new SwedenSalesTaxStrategy();
      }
      else if (destination == "us")
      {
        order.SalesTaxStrategy = new USAStateSalesTaxStrategy();      
      }

      order.LineItems = new List<Item>();
      order.LineItems.Add(
        new Item
        (
          "CSHARP_SMORGASBORD",
          "C# Smorgasbord",
          100m,
          ItemType.Literature
        ) 
      );

      Console.Write( order.GetTax(new SwedenSalesTaxStrategy()) );

      order.InvoiceStrategy = new FileInvoiceStrategy();
      order.Finalizeorder();
    }
  }
}