using System.Collections.Generic;

namespace PizzaBox.Domain.Abstracts
{
  public interface IRepository<T>
  {
    void Add(T t);
    List<T> GetList();
    void Remove(T t);
    void Update(T existing, T updated);
  }
}