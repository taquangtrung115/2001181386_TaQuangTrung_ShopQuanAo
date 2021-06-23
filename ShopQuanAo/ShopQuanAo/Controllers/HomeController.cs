using Model;
using ShopQuanAo.Models;
using ShopQuanAo.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new SanPhamNguoiDung().dsSanPham4();
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult GioHang()
        {
            var sesstion = Session[NguoiDungSesstion.SesstionGioHang];
            var list = new List<GioHang>();
            if (sesstion != null)
            {
                list = (List<GioHang>)sesstion;
            }
            return PartialView(list);
        }
    }
}
