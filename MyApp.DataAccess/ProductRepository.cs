using System.Collections.Generic;
using MyApp.RepositoryContracts;
using MyApp.Model;
using System;

namespace MyApp.DataAccess
{
    public class ProductRepository : IRepository<Product>
    {
        private JSONContext<Product> _context;

        public ProductRepository()
        {
            _context = new JSONContext<Product>("~/App_Data/products.json");
        }

        public IEnumerable<Model.Product> GetAll()
        {
            return _context.GetAll();
        }

        public MyApp.Model.Product Get(int id)
        {
            return _context.Read(id);
        }

        public MyApp.Model.Product Add(MyApp.Model.Product item)
        {
            return _context.Create(item);
        }

        public void Remove(int id)
        {
            _context.Delete(id);
        }

        public MyApp.Model.Product Update(MyApp.Model.Product item)
        {
            return _context.Update(item);
        }

    }
}