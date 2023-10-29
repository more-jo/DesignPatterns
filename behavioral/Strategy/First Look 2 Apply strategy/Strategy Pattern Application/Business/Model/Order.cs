using Strategy_Pattern_First_Look.Business.Models;
using Strategy_Pattern_First_Look.Business.Strategies.SalesTax;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Strategy_Pattern_First_Look
{
  public class Order
  {
    private decimal _totalPrice;

    public ShippingDetails ShippingDetails
    {
      get;
      set;
    }

    public ISalesTaxStrategy SalesTaxStrategy
    {
      get; set;
    }

    public List<Item> LineItems
    {
      get;
      set;
    }

    public decimal GetTax()
    {
      if(SalesTaxStrategy == null)
      {
        return 0m;
      }

      return SalesTaxStrategy.GetTaxFor(this);
    }

    public decimal TotalPrice
    {
      get 
      {
        decimal totalPrice = 0;
        foreach (var item in LineItems)
        {
          totalPrice += item.OrderSize;
        }
        return totalPrice;
      } 
      
      set 
      {
        _totalPrice = value; 
      }
    }
  }
}