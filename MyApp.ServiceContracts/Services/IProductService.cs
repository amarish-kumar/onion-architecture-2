using MyApp.Model;
using System.Collections.Generic;

namespace MyApp.ServiceContracts
{
    public interface IProductService
    {
        RepositoryContracts.IRepository<Product> _productRepo { get; }

        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Add(Product item);
        void Remove(int id);
        Product Update(Product item);
        
    }
}
