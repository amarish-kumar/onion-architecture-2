using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using MyApp.Model;

namespace MyApp.DependencyResolution
{
    public class UnityContainerFactory
    {
        public IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<MyApp.ServiceContracts.IProductService, MyApp.Services.ProductService>(new HierarchicalLifetimeManager());
            //TODO: uncomment line 19 for Entitiy Framework, comment line 20 and 21, add reference to the MyApp.DataAccess.EF project
            //container.RegisterType<MyApp.RepositoryContracts.IProductRepository, MyApp.DataAccess.EF.ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<MyApp.RepositoryContracts.IRepository<Product>, MyApp.DataAccess.ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterInstance<MyApp.RepositoryContracts.IRepository<Product>>(new MyApp.DataAccess.ProductRepository());

            return container;
        }
    }
}
