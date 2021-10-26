using System.Collections.Generic;

namespace Vacay.Interfaces
{
  public interface IRepository<V>
  {
    List<V> Get();
    V Get(int id);
    V Create(V data);
    V Edit(int id, V data);
    void Delete(int id);
  }
}