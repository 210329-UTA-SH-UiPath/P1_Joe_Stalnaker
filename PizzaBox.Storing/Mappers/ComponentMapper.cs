using System;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Mappers
{
  public class ComponentMapper : IMapper<PizzaBox.Storing.Entities.Component, PizzaBox.Domain.Abstracts.AComponent>
  {
    public Domain.Abstracts.AComponent Map(Entities.Component model)
    {
      AComponent component = null;
      switch (model.ComponentType)
      {
        case COMPONENT_TYPE.Crust:
          component = new Crust(model.Name, model.Price);
          break;
        case COMPONENT_TYPE.Size:
          component = new Size(model.Name, model.Price);
          break;
        case COMPONENT_TYPE.Topping:
          component = new Topping(model.Name, model.Price);
          break;
      }
      component.Name = model.Name;
      return component;
    }

    public Entities.Component Map(Domain.Abstracts.AComponent model)
    {
      COMPONENT_TYPE componentType;
      switch (model)
      {
        case Crust:
          componentType = COMPONENT_TYPE.Crust;
          break;
        case Size:
          componentType = COMPONENT_TYPE.Size;
          break;
        case Topping:
          componentType = COMPONENT_TYPE.Topping;
          break;
        default:
          throw new ArgumentException("Component mapper is attempting to map a component instance that does not exist in the database");
      }
      Component component = new Component();
      component.Name = model.Name;
      component.ComponentType = componentType;
      return component;
    }
  }
}