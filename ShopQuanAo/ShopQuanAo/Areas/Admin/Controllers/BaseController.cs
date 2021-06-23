using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ShopQuanAo.NewFolder1;
using Model;
namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Admin/Base/

        //protected override void OnActionExcuting(ActionExecutingContext context)
        //{
        //    var se = (TaiKhoanModel)Session[NguoiDungSesstion.nguoiDung];
        //    if (se == null)
        //    {
        //        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "DangNhap", action = "Index", Area = "Admin" }));
        //    }
        //    base.OnActionExecuting(context);
        //}
       protected override void OnActionExecuting(ActionExecutingContext filterContext)
       {
           var session = (NguoiDungDangNhap)Session[NguoiDungSesstion.nguoiDung];
           if (session == null)
           {
               filterContext.Result = new RedirectToRouteResult(new
                   RouteValueDictionary(new { controller = "DangNhap", action = "Index", Area = "Admin" }));
           }
           base.OnActionExecuting(filterContext);
       }

    }
}
