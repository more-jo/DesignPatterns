using Strategy_Pattern_First_Look.Business.Models;
using Strategy_Pattern_First_Look.Business.Strategies.Invoice;
using Strategy_Pattern_First_Look.Business.Strategies.SalesTax;
using System.ComponentModel;
using System.ComponentModel.Design;
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

    public decimal GetTax(ISalesTaxStrategy salesTaxStrategy = default)
    {
      var strategy = SalesTaxStrategy ?? SalesTaxStrategy;
      if(strategy == null)
      {
        return 0m;
      }

      return strategy.GetTaxFor(this);
    }

    public void Finalizeorder()
    {
      if (SelectedPayments
        .Any(x => x.PaymentProvider == PaymentProvider.Invoice) &&
        AmoutnDue > 0 &&
        ShippingStatus == ShippingStatus.WaitinForPayment
        )
      {
        InvoiceStrategy.Generate(this);
      }
      else if (AmountDue > 0)
      {
      }
    }

        public IInvoiceStrategy InvoiceStrategy { get; set; }

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