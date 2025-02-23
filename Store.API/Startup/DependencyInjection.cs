using Store.Business.Startup;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

namespace Store.API.Startup
{
    public static class DependencyInjection
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();

            DependencyInjectionConfig.RegisterTypes(container);

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}