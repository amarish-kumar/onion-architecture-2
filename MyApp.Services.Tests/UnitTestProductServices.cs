using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApp.RepositoryContracts;
using System.Collections.Generic;
using MyApp.Model;
using System.Linq;

namespace MyApp.Services.Tests
{
    [TestClass]
    public class UnitTestProductServices
    {
        [TestMethod]
        public void TestGetAll()
        {
            Mock<IRepository<Product>> productRepository = new Mock<IRepository<Product>>();
            productRepository.Setup(pr => pr.GetAll()).Returns(new List<Product>() { new Product() { Id = 1, Name = "Test"} });

            ProductService productService = new ProductService(productRepository.Object);
            IEnumerable<Product> result = productService.GetAll();
            Assert.AreEqual(result.ToList()[0].Name, "Test");
        }
    }
}
