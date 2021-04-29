using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace PizzaBox.Storing.Repositories
{
  public class MenuRepository : IRepository<Domain.Models.Menu>
  {
    private readonly MenuMapper mapper = new MenuMapper();
    private readonly PizzaBoxDbContext context;
    public MenuRepository(PizzaBoxDbContext context)
    {
      this.context = context;
    }
    public void Add(Domain.Models.Menu t)
    {
      context.Menus.Add(mapper.Map(t));
      context.SaveChanges();
    }

    public List<Domain.Models.Menu> GetList()
    {

      return context.Menus./*
        Include(m => m.Name).
        Include(m => m.Text).*/
        Select(mapper.Map).ToList();
    }

    public void Remove(Domain.Models.Menu t)
    {
      var menu = context.Menus.ToList().Find(s => s.Equals(t));
      if (menu is not null)
      {
        context.Menus.Remove(menu);
        context.SaveChanges();
      }
    }

    public void Update(Domain.Models.Menu existing, Domain.Models.Menu updated)
    {
      var menu = context.Menus.ToList().Find(menu => menu.Equals(existing));
      if (menu is not null)
      {
        menu.Text = updated.Text;
        context.SaveChanges();
      }
    }
  }
}