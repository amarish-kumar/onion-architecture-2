using MyApp.Model;
using MyApp.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccess.EF
{
    public class ProductRepository : IRepository<Product>
    {
        private DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Model.Product> GetAll()
        {
            return _context.Producs;
        }

        public Model.Product Get(int id)
        {
            return _context.Producs.Find(id);
        }

        public Model.Product Add(Product item)
        {
            _context.Producs.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Remove(int id)
        {
            Product product = this.Get(id);
            _context.Producs.Remove(product);
            _context.SaveChanges();
        }

        public Model.Product Update(Product item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
