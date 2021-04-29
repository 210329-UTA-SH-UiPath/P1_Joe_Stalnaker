using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{
  public enum PIZZA_TYPE
  {
    Vegan,
    Meat,
    Hawiian,
    Supreme
  }
  public class Pizza
  {
    [Key]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public PIZZA_TYPE PizzaType { get; set; }
  }
}