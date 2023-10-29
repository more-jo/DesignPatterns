using Strategy_Pattern_First_Look.Business.Model;

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

      order.LineItems.Add(
        new Item
        (
          "CSHARP_SMORGASBORD",
          "C# Smorgasbord",
          100m,
          ItemType.Literature
        ),
        1 
        );

      Console.Write( order.GetTax() );
    }
  }
}