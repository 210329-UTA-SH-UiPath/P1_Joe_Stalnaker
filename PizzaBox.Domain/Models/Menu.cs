using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Models
{
  /// <summary></summary>
  public class Menu
  {
     public int ID { get; set; }
     [Required]
     [StringLength(50)]
     public string Name { get; set; }
     [Required]
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