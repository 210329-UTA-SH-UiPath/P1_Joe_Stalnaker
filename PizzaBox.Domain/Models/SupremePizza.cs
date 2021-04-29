using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary></summary>
  public class SupremePizza : APizza
  {
    public SupremePizza() : base()
    {
      Name = "Supreme Pizza";
      Crust = new Crust();
      Size = new Size();
      Toppings = new List<Topping>();
      Toppings.Add(new Topping("Cheese", 1.00M));
      Toppings.Add(new Topping("Pepperoni", 1.00M));
      Toppings.Add(new Topping("Olives", 1.00M));
      Toppings.Add(new Topping("Pineapple", 1.00M));
      Toppings.Add(new Topping("Ham", 1.00M));
    }
    public override decimal Price()
    {
      decimal price = Crust.Price;
      price += Size.Price;
      foreach (Topping topping in Toppings)
      {
        price += topping.Price;
      }
      return price;
    }
  }
}
