using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Service.Models
{
  public enum COMPONENT_TYPE
  {
    Crust,
    Size,
    Topping
  }
  public class Component
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public COMPONENT_TYPE ComponentType { get; set; }
  }
}
