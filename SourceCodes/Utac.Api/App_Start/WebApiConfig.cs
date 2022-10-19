using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Utac.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable CORS
            //config.EnableCors();

            var cors = new EnableCorsAttribute("*", "*", "*"); // (origin, headers, methods)
            //var cors = new EnableCorsAttribute("http://localhost", "*", "*"); // (origin, headers, methods)
            //var cors = new EnableCorsAttribute("http://localhost:5000", "*", "*"); // (origin, headers, methods)
            //var cors = new EnableCorsAttribute("http://localhost:5000/Wave", "*", "*"); // (origin, headers, methods)
            //var cors = new EnableCorsAttribute("http://localhost:58745", "*", "*"); // (origin, headers, methods)
            //var cors = new EnableCorsAttribute("http://localhost:56984", "*", "*"); // (origin, headers, methods)
            //var cors = new EnableCorsAttribute("http://localhost:80", "*", "*"); // (origin, headers, methods)
            config.EnableCors(cors);

            // Web API configuration and services
        
            // Web API routes
            config.MapHttpAttributeRoutes();

            // DEV ENV
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{version}/{controller}/{guid}",
            //    defaults: new { guid = RouteParameter.Optional }
            //);
            //config.Routes.MapHttpRoute(
            //    name: "ActionBased",
            //    routeTemplate: "api/{version}/{controller}/{action}/{guid}",
            //    defaults: new { guid = RouteParameter.Optional }
            //);
            //config.Routes.MapHttpRoute(
            //    name: "ActionParamBased",
            //    routeTemplate: "api/{version}/{controller}/{action}/{guid}",
            //    defaults: new { guid = RouteParameter.Optional }
            //);
            //config.Routes.MapHttpRoute(
            //    name: "MethodBased",
            //    routeTemplate: "api/{version}/{controller}/{action}/{method}/{guid}",
            //    defaults: new { guid = RouteParameter.Optional }
            //);
            //config.Routes.MapHttpRoute(
            //    name: "MethodParamBased",
            //    routeTemplate: "api/{version}/{controller}/{action}/{method}/{guid}",
            //    defaults: new { guid = RouteParameter.Optional }
            //);

            // UAT ENV
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{version}/{controller}/{guid}",
                defaults: new { guid = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "ActionBased",
                routeTemplate: "api/{version}/{controller}/{action}/{guid}",
                defaults: new { guid = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "ActionParamBased",
                routeTemplate: "api/{version}/{controller}/{action}/{guid}",
                defaults: new { guid = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "MethodBased",
                routeTemplate: "api/{version}/{controller}/{action}/{method}/{guid}",
                defaults: new { guid = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "MethodParamBased",
                routeTemplate: "api/{version}/{controller}/{action}/{method}/{guid}",
                defaults: new { guid = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //config.Filters.Add(new LoggingFilterAttribute());

        }
    }
}
