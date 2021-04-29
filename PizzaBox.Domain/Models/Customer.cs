using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  /// <summary></summary>
  public class Customer
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
    public Customer() { }

    public Customer(int id, string name)
    {
      Name = name;
      Orders = new List<Order>();
    }
    public override string ToString()
    {
      return $"{ID} : {Name}";
    }
  }
}