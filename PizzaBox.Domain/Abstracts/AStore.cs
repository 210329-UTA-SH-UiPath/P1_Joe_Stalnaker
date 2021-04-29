using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using System;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// Represents the Store Abstract Class
  /// </summary>
  [XmlInclude(typeof(ChicagoStore))]
  [XmlInclude(typeof(NewYorkStore))]
  public class AStore
  {
    public string Name { get; set; }
    public List<Order> Orders { get; set; }

    /// <summary></summary>
    protected AStore()
    {
      Orders = new List<Order>();
    }
    public Dictionary<DateTime, int> GetLedger(int timeFrame)
    {
      //1. Weekly
      //2. Monthly
      //weeks end on Sunday and start on Monday
      //ledger consits of the end date for the month or year and the total sales
      Dictionary<DateTime, int> ledger = new Dictionary<DateTime, int>();
      return ledger;
    }
    /// <summary></summary>
    /// <returns></returns>
    public override string ToString()
    {
      return $"{Name}";
    }
  }
}
