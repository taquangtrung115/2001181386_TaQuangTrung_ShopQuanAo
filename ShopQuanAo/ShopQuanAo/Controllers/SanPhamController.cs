using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAo.Models;
namespace ShopQuanAo.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();
        public ActionResult Index()
        {
            var model = new SanPhamNguoiDung().dsSanPham();
            return View(model);
        }
        public ActionResult ChiTietSP(int masp)
        {
            var model = new SanPhamNguoiDung().XemChiTiet(masp);
            return View(model);
        }
        public ActionResult SanPhamTheoDanhMuc(int masp)
        {
            var model = new DanhMucNguoiDung().XemChiTiet(masp);
            return View(model);
        }
        public ActionResult Category(int ma = 0)
        {
            var danhmuc = new DanhMucNguoiDung().XemChiTiet(ma);
            ViewBag.DanhMuc = danhmuc;
            var model = new SanPhamNguoiDung().SPTheoDM(ma);
            return View(model);
        }
        public ActionResult XemChiTiet(int ms)
        {
            SanPham sach = db.SanPhams.Single(s => s.MaSP == ms);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }
    }
}
