using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Girft_shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Shop",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Shop", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "Blog",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "Checkout",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Checkout", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "Faq",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Faq", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "product",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
