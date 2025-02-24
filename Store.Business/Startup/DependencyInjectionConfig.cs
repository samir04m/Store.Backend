using Store.Business.Interfaces;
using Store.Business.Services;
using Store.Data;
using Store.Data.Interfaces;
using Store.Data.Repositories;
using Unity;
using Unity.Lifetime;

namespace Store.Business.Startup
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());

            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<MyDbContext>(new HierarchicalLifetimeManager());
        }
    }
}
