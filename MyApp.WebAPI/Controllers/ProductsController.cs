using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MyApp.ServiceContracts;
using MyApp.Model;

namespace MyApp.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            return _productService.GetAll();
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            return _productService.Get(id);
        }

        // POST: api/Products
        public Product Post([FromBody]Product item)
        {
            return _productService.Add(item);
        }

        // PUT: api/Products/5
        public Product Put(int id, [FromBody]Product value)
        {
            return _productService.Update(value);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            _productService.Remove(id);
        }
    }
}
