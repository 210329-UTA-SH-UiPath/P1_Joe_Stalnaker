using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using System.Linq;


namespace PizzaBox.Storing.Repositories
{
  public class CustomerRepository : IRepository<PizzaBox.Domain.Models.Customer>
  {
    private readonly CustomerMapper mapper = new CustomerMapper();
    private readonly PizzaBoxDbContext context;
    public CustomerRepository(PizzaBoxDbContext context)
    {
      this.context = context;
    }


    public void Add(Domain.Models.Customer t)
    {
      context.Customers.Add(mapper.Map(t));
      context.SaveChanges();
    }

    public List<Domain.Models.Customer> GetList()
    {
      return context.Customers.AsEnumerable().GroupBy(c => c.Name).Select(c => c.First()).Select(mapper.Map).ToList();
    }

    public void Remove(Domain.Models.Customer t)
    {
      PizzaBox.Storing.Entities.Customer customer = context.Customers.ToList().Find(customer => customer.Name.Equals(t.Name));
      if (customer is not null)
      {
        context.Customers.Remove(customer);
        context.SaveChanges();
      }
    }

    public void Update(Domain.Models.Customer existing, Domain.Models.Customer updated)
    {
      PizzaBox.Storing.Entities.Customer customer = context.Customers.ToList().Find(customer => customer.Name.Equals(existing.Name));
      if (customer is not null)
      {
        customer.Name = updated.Name;
        context.SaveChanges();
      }
    }
  }
}