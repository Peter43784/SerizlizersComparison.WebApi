using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SerializersComparison.Utils;
using WebApiContrib.Formatting;

namespace SerializersComparison
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            AutofacConfig.Initialize(config);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new ProtoBufFormatter());
            config.Formatters.Add(new BufferedMessagePackFormatter());
        }
    }
}
