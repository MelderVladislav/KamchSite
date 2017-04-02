using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KamchatkaSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{seasonName}/{categoryName}",
                defaults: new { controller = "Home", action = "Service", seasonName = UrlParameter.Optional,categoryName=UrlParameter.Optional }
            );
        }
    }
}
