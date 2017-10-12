using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Model;
using System.Collections.Generic;

namespace MyApp.DataAccess.Tests
{
    [TestClass]
    public class UnitTestProductRepository
    {
        [TestMethod]
        public void TestGetAll()
        {
            ProductRepository repo = new ProductRepository();
            List<Product> products = (List<Product>)repo.GetAll();

            Assert.AreEqual(products[0].Id, 1);
        }
    }
}
