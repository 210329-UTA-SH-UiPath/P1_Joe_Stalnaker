using System;
using System.Collections.Generic;
using System.IO;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
  /// <summary></summary>
  public class MenuSingleton
  {
    private static MenuSingleton _instance;
    private readonly MenuRepository repository = null;
    public List<Menu> Menus { get; set; }
    public static MenuSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new MenuSingleton();
        }
        return _instance;
      }
    }
    /// <summary></summary>
    private MenuSingleton()
    {
      repository = new MenuRepository(DbContextSingleton.Instance.Context);
      Menus = repository.GetList();
    }
  }
}
