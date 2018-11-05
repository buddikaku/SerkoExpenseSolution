using SerkoExpense.Api.Filters;
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
        }
    }
}
