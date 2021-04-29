namespace PizzaBox.Domain.Abstracts
{
  /// <summary></summary>
  public abstract class AComponent
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
    protected AComponent()
    {
      Name = "";
      Price = 0.00M;
    }
    protected AComponent(string name, decimal price)
    {
      Name = name;
      Price = price;
    }
  }
}
