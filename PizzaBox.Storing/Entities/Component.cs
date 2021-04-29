using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{
  public enum COMPONENT_TYPE
  {
    Crust,
    Size,
    Topping
  }
  public class Component
  {
    [Key]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public COMPONENT_TYPE ComponentType { get; set; }
  }
}