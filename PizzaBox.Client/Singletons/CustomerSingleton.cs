using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary></summary>
  public class CustomerSingleton
  {
    private static CustomerSingleton _instance;
    private readonly CustomerRepository repository = null;
    public List<Customer> Customers { get; set; }
    public static CustomerSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new CustomerSingleton();
        }

        return _instance;
      }
    }
    /// <summary></summary>
    private CustomerSingleton()
    {
      repository = new CustomerRepository(DbContextSingleton.Instance.Context);
      Customers = repository.GetList();
    }
    public void AddCustomer(Customer newCustomer)
    {
      Boolean found = false;
      foreach (Customer customer in Customers)
      {
        if (newCustomer.ID == customer.ID)
        {
          found = true;
          break;
        }
      }
      if (!found) Customers.Add(newCustomer);
    }
    public Customer GetCustomer(int id)
    {
      foreach (Customer customer in Customers)
      {
        if (customer.ID == id) return customer;
      }
      return null;
    }
    public void ShowCustomers()
    {
      foreach (Customer customer in Customers)
      {
        Console.WriteLine(customer);
      }
    }
  }
}
