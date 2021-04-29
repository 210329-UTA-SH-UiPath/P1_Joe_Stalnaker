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
  public class OrderSingleton
  {
    private static OrderSingleton _instance;
    private readonly OrderRepository repository = null;
    public List<Order> Orders
    { get; set; }
    public static OrderSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new OrderSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private OrderSingleton()
    {
      repository = new OrderRepository(DbContextSingleton.Instance.Context);
      Orders = repository.GetList();
    }
    public void AddOrder(Order order)
    {
      ShowOrders();
      Orders.Add(order);
      ShowOrders();
    }
    public void ShowOrders()
    {
      foreach (Order order in Orders)
      {
        Console.WriteLine(order);
      }
    }
  }
}
