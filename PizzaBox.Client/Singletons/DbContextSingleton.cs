using PizzaBox.Storing.Entities;

namespace PizzaBox.Client.Singletons
{
  public class DbContextSingleton
  {
    private readonly PizzaBoxDbContext context = null;
    private static DbContextSingleton _instance = null;

    public static DbContextSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new DbContextSingleton();
        }

        return _instance;
      }
    }

    public PizzaBoxDbContext Context
    {
      get
      {
        return context;
      }
    }

    private DbContextSingleton()
    {
      context = new PizzaBoxDbContext();
    }
  }
}