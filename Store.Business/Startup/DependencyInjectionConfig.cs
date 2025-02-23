using Store.Business.Interfaces;
using Store.Business.Services;
using Store.Data.Interfaces;
using Store.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Lifetime;
using Unity;
using Store.Data;

namespace Store.Business.Startup
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            // Registro de servicios
            container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());

            // Registro de repositorios
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());

            // Registro del DbContext
            container.RegisterType<MyDbContext>(new HierarchicalLifetimeManager());
        }
    }
}
