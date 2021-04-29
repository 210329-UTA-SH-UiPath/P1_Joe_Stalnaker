using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary></summary>
  public class Crust : AComponent
  {
    /*
    Regular     $1.00
    Stuffed     $2.00
    Cauliflower $3.00
    */
    public Crust() : base()
    {
      Name = "Regular";
      Price = 1.00M;
    }
    public Crust(string name, decimal price) : base(name, price) { }
  }
}
