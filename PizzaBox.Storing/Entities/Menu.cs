using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
  public class Menu
  {
    [Key]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Text { get; set; }
  }
}