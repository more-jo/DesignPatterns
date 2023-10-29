using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Strategies.Invoice
{
  public interface IInvoiceStrategy
  {
    public void Generate(Order order);
  }
}
