using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Diagnostics;
using System.Web.Http.ExceptionHandling;
using MyApp.WebAPI.ExceptionHandling;
using System.Web.Http.Cors;

namespace MyApp.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("http://jm-shop.azurewebsites.net", "*", "*");
            config.EnableCors(cors);


            // Web API configuration and services

            // Dependency Injection with Unity
            var container = new MyApp.DependencyResolution.UnityContainerFactory().BuildUnityContainer();
            config.DependencyResolver = new MyApp.WebAPI.Resolver.UnityResolver(container);

            // Adds global error logging
            config.Services.Add(typeof(IExceptionLogger), new TraceSourceExceptionLogger(new MyApp.Logging.Logger()));

            //config.Services.Add(typeof(IExceptionLogger),
            //new TraceSourceExceptionLogger(new
            //TraceSource("MyTraceSource", SourceLevels.All)));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
