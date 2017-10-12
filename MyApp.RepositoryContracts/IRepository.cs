using MyApp.Model;
using System.Collections.Generic;

namespace MyApp.RepositoryContracts
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Add(T item);
        void Remove(int id);
        T Update(T item);
    }
}
