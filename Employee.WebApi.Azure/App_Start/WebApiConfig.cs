using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Employee.WebApi.Azure.App_Start;
using Employee.WebApi.Azure.DataAccess;
using Employee.WebApi.Azure.Services;
using Unity;

namespace Employee.WebApi.Azure
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var container = new UnityContainer();

            container.RegisterType<ILogProvider, LogProvider>();
            container.RegisterType<IEmployeeDataService, EmployeeDataService>();

            config.DependencyResolver= new UnityResolver(container);

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
