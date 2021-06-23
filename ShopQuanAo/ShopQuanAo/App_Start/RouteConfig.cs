using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopQuanAo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopQuanAo.Controllers" }
            );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "ChiTiet",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "SanPham", action = "ChiTietSP", id = UrlParameter.Optional },
                namespaces: new[] { "ShopQuanAo.Controllers" }
            );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "SPTheoDM",
                url: "SanPham/Category",
                defaults: new { controller = "SanPham", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "ShopQuanAo.Controllers" }
            );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "GioHang",
                url: "GioHang/themGioHang",
                defaults: new { controller = "GioHang", action = "themGioHang", id = UrlParameter.Optional },
                namespaces: new[] { "ShopQuanAo.Controllers" }
            );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "ThanhToan",
                url: "GioHang/ThanhToan",
                defaults: new { controller = "GioHang", action = "ThanhToan", id = UrlParameter.Optional },
                namespaces: new[] { "ShopQuanAo.Controllers" }
            );
        }
    }
}