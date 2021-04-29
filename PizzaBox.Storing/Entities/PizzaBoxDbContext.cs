using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Entities
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Component> Components { set; get; }
    public DbSet<Customer> Customers { set; get; }
    public DbSet<Order> Orders { set; get; }
    public DbSet<Pizza> Pizzas { set; get; }
    public DbSet<Store> Stores { set; get; }
    public DbSet<Menu> Menus { set; get; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=tcp:jsrevature001.database.windows.net,1433;Initial Catalog=PizzaBoxDb;Persist Security Info=False;User ID=joestalnaker;Password=Rm26!0%%1lS3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
      //optionsBuilder.UseSqlServer("Server=tcp:heroesapp.database.windows.net,1433;Initial Catalog=HeroesDb;Persist Security Info=False;User ID=dev;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
      //"Server=tcp:jsrevature001.database.windows.net,1433;Initial Catalog=PizzaBoxDb;Persist Security Info=False;User ID=joestalnaker;Password=Rm26!0%%1lS3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
    }//OnConfiguring(DbContextOptionsBuilder)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }//OnModelCreating(ModelBuilder)
  }//class PizzaBoxDbContext
}//namespace PizzaBox.Storing.Entities