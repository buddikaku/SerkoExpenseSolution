using Autofac;
using Autofac.Integration.WebApi;
using SerkoExpense.Api.Filters;
using SerkoExpense.Business;
using SerkoExpense.Parser;
using System.Reflection;
using System.Web.Http;

namespace SerkoExpense.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /// Configure log4net
            log4net.Config.XmlConfigurator.Configure();

            /// Register global action filter
            config.Filters.Add(new ExceptionFilter());

            /// Web API routes
            config.MapHttpAttributeRoutes();

            /// Set the dependency resolver to be Autofac.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(GetAutofacContainer());

        }

        /// <summary>
        /// Gets the autofac container.
        /// </summary>
        /// <returns>Container</returns>
        public static IContainer GetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            /// Register Web API controllers and dependencies. 
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ExpenseService>()
            .As<IService>()
            .InstancePerLifetimeScope();

            builder.RegisterType<XmlParser>()
            .As<IParser>()
            .InstancePerLifetimeScope();

            /// return Autofac container 
            IContainer container = builder.Build();
            return container;

        }
    }
}
