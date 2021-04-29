using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  /// <summary></summary>
  public class Menu
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public Menu() { }

    public Menu(int id, string name, string text)
    {
      Text = text;
    }
    public override string ToString()
    {
      return $"{Text}";
    }
  }
}