using Autofac;
using Autofac.Integration.WebApi;
using legion_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;

namespace legion_service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{userID}",
                defaults: new { id = RouteParameter.Optional }
            );


            //AutoFac Configuration
            var builder = new ContainerBuilder();           
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());          
            builder.RegisterInstance<ISensorRepository>(new legion_service_api(new legion_serviceContext()));
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
            //DependencyResolver
        }
    }
}
