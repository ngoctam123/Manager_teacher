using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication2.Controllers;

namespace WebApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "trang chủ",
                url: "Home/{id}",
                defaults: new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication2.Controllers" });
            routes.MapRoute(
                name: "Quản lý sinh viên",
                url: "StudentManagement",
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication2.Controllers" }
            );
        }
    }
}
