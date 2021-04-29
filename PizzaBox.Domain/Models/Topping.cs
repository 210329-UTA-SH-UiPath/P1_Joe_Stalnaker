using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary></summary>
  public class Topping : AComponent
  {
    /*
    Cheese    $1.00
    Pepperoni $1.00
    Olives    $1.00
    Pineapple $1.00
    Ham       $1.00
    */
    public Topping() : base()
    {
      Name = "Cheese";
      Price = 1.00M;
    }
    public Topping(string name, decimal price) : base(name, price) { }
  }
}
