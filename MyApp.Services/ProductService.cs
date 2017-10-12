using MyApp.Model;
using System.Collections.Generic;

namespace MyApp.Services
{
    public class ProductService : ServiceContracts.IProductService
    {
        public RepositoryContracts.IRepository<Product> _productRepo { get; private set; }

        public ProductService(RepositoryContracts.IRepository<Product> repo)
        {
            _productRepo = repo;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepo.GetAll();
        }


        public Product Get(int id)
        {
            return _productRepo.Get(id);
        }

        public Product Add(Product item)
        {
            return _productRepo.Add(item);
        }

        public void Remove(int id)
        {
            _productRepo.Remove(id);
        }

        public Product Update(Product item)
        {
            return _productRepo.Update(item);
        }
    }
}
