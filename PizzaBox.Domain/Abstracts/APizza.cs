using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary></summary>
  public abstract class APizza
  {
    public string Name { get; set; }
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public List<Topping> Toppings { get; set; }

    public APizza() { }
    public abstract decimal Price();

    public override string ToString() => $"{Name}: {Price()}";
  }
}
