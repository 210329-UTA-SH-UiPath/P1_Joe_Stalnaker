using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Mappers
{
  public class MenuMapper : IMapper<PizzaBox.Storing.Entities.Menu, PizzaBox.Domain.Models.Menu>
  {
    public Domain.Models.Menu Map(Entities.Menu entity)
    {
      var model = new Domain.Models.Menu();
      model.ID = entity.ID;
      model.Name = entity.Name;
      model.Text = entity.Text;

      return model;
    }

    public Entities.Menu Map(Domain.Models.Menu model)
    {
      var entity = new Entities.Menu();
      entity.ID = model.ID;
      entity.Name = model.Name;
      entity.Text = model.Text;
      return entity;
    }
  }
}