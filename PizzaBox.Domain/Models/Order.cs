using PizzaBox.Domain.Abstracts;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;

namespace PizzaBox.Domain.Models
{
  /// <summary></summary>
  public class Order
  {
    public int ID { get; set; }
    public AStore Store { get; set; }
    public Customer Customer { get; set; }
    public List<APizza> Pizzas { get; set; }
    public DateTime DateTime { get; set; }
    public Order() : base() { }
    public Order(Customer customer, AStore store, APizza pizza, DateTime dateTime)
    {
      Customer = customer;
      Store = store;
      Pizzas = new List<APizza>();
      AddPizza(pizza);
      DateTime = dateTime;
    }
    public bool AddPizza(APizza pizza)
    {
      Pizzas.Add(pizza);
      return true;
    }
    public override string ToString()
    {
      string order = "";
      foreach (APizza pizza in Pizzas)
      {
        order += $"{DateTime} {Store.Name} {Customer.Name} {pizza.Name}";
      }
      return order;
    }
  }
}