using System.Collections.Generic;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using PizzaBox.Domain.Abstracts;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
  public class ComponentRepository : IRepository<AComponent>
  {
    private readonly PizzaBoxDbContext context;
    private readonly ComponentMapper mapper = new ComponentMapper();

    public ComponentRepository(PizzaBoxDbContext context)
    {
      this.context = context;
    }

    public void Add(AComponent t)
    {
      context.Add(mapper.Map(t));
      context.SaveChanges();
    }

    public List<AComponent> GetList()
    {
      return context.Components.AsEnumerable().GroupBy(s => s.Name).Select(s => s.First()).Select(mapper.Map).ToList();
    }

    public void Remove(AComponent t)
    {
      Component existingComponent = context.Components.ToList().Find(component => component.Name.Equals(t.Name));
      if (existingComponent is not null)
      {
        context.Remove(existingComponent);
        context.SaveChanges();
      }
    }

    public void Update(AComponent existing, AComponent updated)
    {
      Component existingInDb = context.Components.ToList().Find(component => component.Name.Equals(existing.Name));
      if (existingInDb is not null)
      {
        Component mappedUpdated = mapper.Map(updated);
        existingInDb.Name = mappedUpdated.Name;
        existingInDb.ComponentType = mappedUpdated.ComponentType;
        context.SaveChanges();
      }
    }
  }
}