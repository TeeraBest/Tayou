using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Utac.Api
{
    public static class  RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // DEV ENV
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
           "Help Area",
           "",
           new { controller = "Help", action = "Index" }
       ).DataTokens = new RouteValueDictionary(new { area = "HelpPage" });

            // UAT ENV
            //routes.MapRoute(
            //    name: "Default",
            //    url: "UtacApi/{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
