using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using Utac.BusinessLogic.Services;
using Utac.Resolver.Components;

namespace Utac.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterType<IProductServices, ProductServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());

            RegisterTypes(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static void RegisterTypes(IUnityContainer container)
        {

            //Component initialization via MEF
            //ComponentLoader.LoadContainer(container, ".\\bin", "Wave.BusinessLogic.dll");
            //ComponentLoader.LoadContainer(container, ".\\bin", "Wave.DataAccessLogic.dll");
            //ComponentLoader.LoadContainer(container, ".\\bin", "Wave.Entity.dll");
            //ComponentLoader.LoadContainer(container, ".\\bin", "Wave.Resolver.dll");

            ComponentLoader.LoadContainer(container, ".\\bin", "Utac*.dll");

        }

    }
}