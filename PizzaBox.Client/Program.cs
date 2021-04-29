using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
  /// <summary></summary>
  internal class Program
  {
    /*****************************
      Data Members / Singletons
    *****************************/
    private static readonly MenuSingleton _menuSingleton = MenuSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    private static readonly PizzaBoxDbContext _context = DbContextSingleton.Instance.Context;
    /*****************************
      Main & Run
    *****************************/
    /// <summary></summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
      Run();
      //CreateDatabase();
    }
    private static void CreateDatabase()
    {
      //MenuRepository mr = new MenuRepository(_context);
      //mr.Add(new Domain.Models.Menu() { ID = 1, Text = "HelloWorld!" });
      Console.WriteLine(@"HelloWorld!");
    }
    /// <summary></summary>
    private static void Run()
    {
      var running = true;
      while (running)
      {
        DisplayMainMenu();
        DisplayListPrompt();
        var command = SelectMenuOption();
        switch (command)
        {
          case 1:
            DisplayStores();
            break;
          case 2:
            DisplaySalesByStore();
            break;
          case 3:
            DisplayOrdersByStore();
            break;
          case 4:
            DisplayOrdersByCustomer();
            break;
          case 5:
            DisplayPizzasInOrder();
            break;
          case 6:
            CreateOrder();
            break;
          case 7:
            AddCustomer();
            break;
          case 8:
            running = false;
            break;
        }
      }
    }
    /*****************************
      Menu Display Methods
    *****************************/
    /// <summary></summary>
    private static void DisplayMainMenu()
    {
      //string s = "Hello\nWorld!";
      //Console.WriteLine(s);
      Console.WriteLine($"{_menuSingleton.Menus[0]}");
    }
    /// <summary></summary>
    private static void DisplayStores()
    {
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }
    /// <summary></summary>
    private static void DisplaySalesByStore()
    {
      DisplayStores();
      DisplayListPrompt();
      var store = SelectStore();
      DisplaySalesMenu();
      DisplayLedger(store.GetLedger(SelectMenuOption()));
    }
    /// <summary></summary>
    private static void DisplayOrdersByStore()
    {
      DisplayStores();
      DisplayListPrompt();
      var store = SelectStore();
      DisplayOrders(store.Orders);
    }
    /// <summary></summary>
    private static void DisplayOrdersByCustomer()
    {
      DisplayCustomers();
      DisplayListPrompt();
      var customer = SelectCustomer();
      DisplayOrders(customer.Orders);
    }
    /// <summary></summary>
    private static void DisplayPizzasInOrder()
    {
      DisplayOrders(_orderSingleton.Orders);
      DisplayListPrompt();
      var order = SelectOrder();
      DisplayPizzas(order.Pizzas);
    }
    /// <summary></summary>
    private static void CreateOrder()
    {
      DisplayCustomers();
      DisplayListPrompt();
      var customer = SelectCustomer();
      DisplayStores();
      DisplayListPrompt();
      var store = SelectStore();
      DisplayPizzas(_pizzaSingleton.Pizzas);
      DisplayListPrompt();
      var pizza = SelectPizza();
      var orderTime = DateTime.Now;
      bool allowed = true;
      foreach (PizzaBox.Domain.Models.Order order in store.Orders)
      {
        if (order.Customer.Equals(customer)
          && order.DateTime.Add(new TimeSpan(2, 0, 0)) > orderTime)
          allowed = false;
      }
      if (allowed)
      {
        var order = new PizzaBox.Domain.Models.Order(customer, store, pizza, orderTime);
        _orderSingleton.Orders.Add(order);
        customer.Orders.Add(order);
        store.Orders.Add(order);
      }
    }
    /// <summary></summary>
    private static void AddCustomer()
    {
      DisplayCustomerPrompt();
      _customerSingleton.Customers.Add(
        new PizzaBox.Domain.Models.Customer(
          _customerSingleton.Customers.Count,
          Console.ReadLine()
        )
      );
    }
    /// <summary></summary>
    private static void DisplayOrders(List<PizzaBox.Domain.Models.Order> orders)
    {
      var index = 0;
      foreach (PizzaBox.Domain.Models.Order order in orders)
      {
        Console.WriteLine($"{++index} - {order}");
      }
    }
    /// <summary></summary>
    public static void DisplayCustomers()
    {
      foreach (PizzaBox.Domain.Models.Customer customer in _customerSingleton.Customers)
      {
        Console.WriteLine($"{customer}");
      }
    }
    /// <summary></summary>
    public static void DisplayLedger(Dictionary<DateTime, int> ledger)
    {
      foreach (KeyValuePair<DateTime, int> entry in ledger)
      {
        Console.WriteLine($"{0}: {1}", entry.Key, entry.Value);
      }
    }
    /// <summary></summary>
    private static void DisplayPizzas(List<APizza> pizzas)
    {
      var index = 0;

      foreach (var item in pizzas)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }
    /// <summary></summary>
    private static void DisplayCustomerPrompt()
    {
      Console.Write(_menuSingleton.Menus[2]);
    }
    /// <summary></summary>
    private static void DisplayListPrompt()
    {
      Console.Write(_menuSingleton.Menus[3]);
    }
    /// <summary></summary>
    private static void DisplaySalesMenu()
    {
      Console.Write(_menuSingleton.Menus[4]);
      DisplayListPrompt();
    }
    /// <summary></summary>
    private static void DisplayTimePrompt()
    {
      Console.WriteLine(_menuSingleton.Menus[5]);
    }
    /*****************************
      Menu Select Methods
    *****************************/
    /// <summary></summary>
    /// <returns>int</returns>
    private static int SelectMenuOption()
    {
      var input = int.Parse(Console.ReadLine()); // be careful (think execpetion/error handling)

      return input;
    }
    /// <summary></summary>
    /// <returns>int</returns>
    private static int SelectTime()
    {
      var input = SelectMenuOption(); // be careful (think execpetion/error handling)

      return input;
    }
    /// <summary></summary>
    /// <returns></returns>
    private static APizza SelectPizza()
    {
      return _pizzaSingleton.Pizzas[SelectMenuOption() - 1];
    }
    /// <summary></summary>
    /// <returns>Customer</returns>
    private static PizzaBox.Domain.Models.Customer SelectCustomer()
    {
      int id = SelectMenuOption();
      foreach (PizzaBox.Domain.Models.Customer customer in _customerSingleton.Customers)
      {
        if (customer.ID == id) return customer;
      }
      return null;
    }
    /// <summary></summary>
    /// <returns>AStore</returns>
    private static AStore SelectStore()
    {
      return _storeSingleton.Stores[SelectMenuOption() - 1];
    }

    /// <summary></summary>
    /// <returns></returns>
    private static PizzaBox.Domain.Models.Order SelectOrder()
    {
      return _orderSingleton.Orders[SelectMenuOption() - 1];
    }
    /*****************************
      End of Class
    *****************************/
  }//class
}//namespace
