using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Entity;
using ShopQuanAo.Models;
namespace ShopQuanAo.Controllers
{
    public class DanhMucController : Controller
    {
        //
        // GET: /DanhMuc/
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult DanhMuc()
        {
            var model = new DanhMucNguoiDung().dsDanhMuc();
            return PartialView(model);
        }
        public ActionResult SanPhamTheoDanhMuc(int madm)
        {
            var chuDe = db.SanPhams.Where(s => s.MaSP == madm).OrderBy(s => s.DonGia).ToList();
            if (chuDe.Count == 0)
            {
                ViewBag.Sach = "Không có sách nào!";
            }
            return View(chuDe);
        }
    }
}
