using System;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Mappers
{
  public class PizzaMapper : IMapper<PizzaBox.Storing.Entities.Pizza, PizzaBox.Domain.Abstracts.APizza>
  {
    public Domain.Abstracts.APizza Map(Entities.Pizza model)
    {
      APizza pizza = null;
      switch (model.PizzaType)
      {
        case PIZZA_TYPE.Vegan:
          pizza = new VeganPizza();
          break;
        case PIZZA_TYPE.Meat:
          pizza = new MeatPizza();
          break;
        case PIZZA_TYPE.Hawiian:
          pizza = new HawiianPizza();
          break;
        case PIZZA_TYPE.Supreme:
          pizza = new SupremePizza();
          break;
      }
      pizza.Name = model.Name;
      return pizza;
    }

    public Entities.Pizza Map(Domain.Abstracts.APizza model)
    {
      PIZZA_TYPE pizzaType;
      switch (model)
      {
        case VeganPizza:
          pizzaType = PIZZA_TYPE.Vegan;
          break;
        case MeatPizza:
          pizzaType = PIZZA_TYPE.Meat;
          break;
        case HawiianPizza:
          pizzaType = PIZZA_TYPE.Hawiian;
          break;
        case SupremePizza:
          pizzaType = PIZZA_TYPE.Supreme;
          break;
        default:
          throw new ArgumentException("Pizza mapper is attempting to map a pizza instance that does not exist in the database");
      }
      Pizza pizza = new Pizza();
      pizza.Name = model.Name;
      pizza.PizzaType = pizzaType;
      return pizza;
    }
  }
}