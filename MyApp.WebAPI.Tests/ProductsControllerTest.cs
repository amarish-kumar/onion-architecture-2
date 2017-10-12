using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.WebAPI.Controllers;
using System.Collections.Generic;
using MyApp.Model;
using Moq;
using MyApp.ServiceContracts;
using System.Linq;

namespace MyApp.WebAPI.Tests
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void Get()
        {
            Mock<IProductService> productService = MockProductService();

            // Arrange
            ProductsController controller = new ProductsController(productService.Object);

            // Act
            IEnumerable<Product> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Toy2", result.ElementAt(1).Name);
        }

        private static Mock<IProductService> MockProductService()
        {
            Mock<IProductService> productService = new Mock<IProductService>();
                        
            Product product1 = new Product() { Id = 1, Name = "Toy1", Price = 10 };
            Product product2 = new Product() { Id = 2, Name = "Toy2", Price = 12 };
            
            List<Product> products = new List<Product>();

            products.Add(product1);
            products.Add(product2);

            productService.Setup(ps => ps.GetAll()).Returns(products);
            return productService;
        }
       
    }
}
