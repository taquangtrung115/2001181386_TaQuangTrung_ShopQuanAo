using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.Entity;
namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /Admin/KhachHang/

        public ActionResult Index(string TimKiem, int trang=1,int sizeTrang=10)
        {
            var tk = new KhachHangModel();
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
            var model = new KhachHangModel().xemChiTiet(ma);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(KhachHang dm)
        {
            if (ModelState.IsValid)
            {
                var model = new KhachHangModel();



                long maTK = model.ThemTK(dm);
                if (maTK > 0)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại !");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(KhachHang dm)
        {
            if (ModelState.IsValid)
            {
                var model = new KhachHangModel();
                var maTK = model.Sua(dm);
                if (maTK)
                {
                    return RedirectToAction("Index", "KhachHang");
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
            new KhachHangModel().Xoa(ma);
            return RedirectToAction("Index");
        }
    }
}
