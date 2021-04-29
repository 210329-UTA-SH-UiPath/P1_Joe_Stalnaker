using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary></summary>
  public class Size : AComponent
  {
    /*
    Small  $8.00
    Medium $9.00
    Large $10.00
    */
    public Size() : base()
    {
      Name = "Large";
      Price = 10.00M;
    }
    public Size(string name, decimal price) : base(name, price) { }
  }
}
