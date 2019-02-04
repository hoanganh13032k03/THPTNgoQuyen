using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Website
{
    public class RouteConfig
    {
        

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "News Category",
             url: "Tin-tuc/{metatitle}-{cateId}",
             defaults: new { controller = "NewsDT", action = "Category", id = UrlParameter.Optional },
             namespaces: new[] { "Website.Controllerss" }
         );
            routes.MapRoute(
            name: "News Detail",
            url: "chi-tiet/{metatitle}-{id}",
            defaults: new { controller = "NewsDT", action = "Detail", id = UrlParameter.Optional},
            namespaces: new[] { "Website.Controllers" }
        );
            routes.MapRoute(
             name: "Tags",
             url: "tag/{tagId}",
             defaults: new { controller = "NewsDT", action = "Tag", id = UrlParameter.Optional },
             namespaces: new[] { "Website.Controllers" }
         );
            routes.MapRoute(
            name: "Search",
            url: "tim-kiem",
            defaults: new { controller = "NewsDT", action = "Search", id = UrlParameter.Optional },
            namespaces: new[] { "Website.Controllers" }
        );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                    namespaces: new[] { "Website.Controllers" }
            );
        }
    }
}
