using System;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Mappers
{
  public class StoreMapper : IMapper<PizzaBox.Storing.Entities.Store, PizzaBox.Domain.Abstracts.AStore>
  {
    public Domain.Abstracts.AStore Map(Entities.Store model)
    {
      AStore store = null;
      switch (model.StoreType)
      {
        case STORE_TYPE.Chicago:
          store = new ChicagoStore();
          break;
        case STORE_TYPE.NewYork:
          store = new NewYorkStore();
          break;
      }
      store.Name = model.Name;
      return store;
    }

    public Entities.Store Map(Domain.Abstracts.AStore model)
    {
      STORE_TYPE storeType;
      switch (model)
      {
        case ChicagoStore:
          storeType = STORE_TYPE.Chicago;
          break;
        case NewYorkStore:
          storeType = STORE_TYPE.NewYork;
          break;
        default:
          throw new ArgumentException("Store mapper is attempting to map a store instance that does not exist in the database");
      }
      Store store = new Store();
      store.Name = model.Name;
      store.StoreType = storeType;
      return store;
    }
  }
}