using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /Admin/SanPham/

        public ActionResult Index(string TimKiem, int trang=1, int sizeTrang =10)
        {
            var tk = new SanPhamModel();
            var model = tk.dsDanhMuc(TimKiem, trang, sizeTrang);
            ViewBag.TimKiem = TimKiem;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int ma = 0)
        {
            var model = new SanPhamModel().xemChiTiet(ma);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(SanPham dm)
        {
            if (ModelState.IsValid)
            {
                var model = new SanPhamModel();



                long maTK = model.ThemTK(dm);
                if (maTK > 0)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại !");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(SanPham dm)
        {
            if (ModelState.IsValid)
            {
                var model = new SanPhamModel();
                var maTK = model.Sua(dm);
                if (maTK)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thành công !");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int ma)
        {
            new SanPhamModel().Xoa(ma);
            return RedirectToAction("Index");
        }
    }
}
