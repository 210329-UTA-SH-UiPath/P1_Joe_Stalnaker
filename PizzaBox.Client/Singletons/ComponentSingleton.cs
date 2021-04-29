using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class ComponentSingleton
  {
    private static ComponentSingleton _instance;
    private readonly ComponentRepository repository = null;
    public List<AComponent> Components { get; set; }
    public static ComponentSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new ComponentSingleton();
        }

        return _instance;
      }
    }

    /// <summary></summary>
    private ComponentSingleton()
    {
      repository = new ComponentRepository(DbContextSingleton.Instance.Context);
      Components = repository.GetList();
    }

  }
}
