using System.Web.Mvc;
using Microsoft.Practices.Unity;
using AnimeDB.Services;
using Unity.Mvc5;
using System;
using System.Web.Http;
using System.Web.Mvc;
using AnimeDB.Services.Interfaces;
using AnimeDB.Classes;

namespace AnimeDB
{
    public static class UnityConfig
    {
        private static readonly Lazy<UnityContainer> _container = new Lazy<UnityContainer>(() => new UnityContainer());

        public static UnityContainer GetContainer()
        {
            return _container.Value;
        }

        public static void RegisterComponents(HttpConfiguration config)
        {
            UnityContainer container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IRoleService, RoleService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //  this line is needed so that the resolver can be used by api controllers 
            config.DependencyResolver = new UnityResolver(container);

            var resolver = new UnityDependencyResolver(container);
            //container.RegisterType<IOutputService, OutputService>();


            DependencyResolver.SetResolver(resolver);
            //  we have to make a custom filter injector to provide DI to our custom action filters.
            //  see http://michael-mckenna.com/blog/dependency-injection-for-asp-net-web-api-action-filters-in-3-easy-steps
            //var providers = config.Services.GetFilterProviders().ToList();

            //var defaultprovider = providers.Single(i => i is ActionDescriptorFilterProvider);
            //config.Services.Remove(typeof(System.Web.Http.Filters.IFilterProvider), defaultprovider);

            config.Services.Add(typeof(System.Web.Http.Filters.IFilterProvider), new UnityActionFilterProvider(container));

        }
    }
}