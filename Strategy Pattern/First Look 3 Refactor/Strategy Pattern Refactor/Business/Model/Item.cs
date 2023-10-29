using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern_First_Look.Business.Models
{
  public class Item
  {
    public Item(string name, string description, decimal orderSize, ItemType type)
    {
      Name = name;
      Description = description;
      OrderSize = orderSize;
      Type = type;
    }

    public string Name
    {
      get; set;
    }
    public string Description
    {
      get; set;
    }
    public decimal OrderSize
    {
      get; set;
    }
    public ItemType Type
    {
      get; set;
    }
  }
}
