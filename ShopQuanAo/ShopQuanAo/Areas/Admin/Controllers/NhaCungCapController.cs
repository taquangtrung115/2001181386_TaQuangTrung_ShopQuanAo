using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class NhaCungCapController : BaseController
    {
        //
        // GET: /Admin/NhaCungCap/

        public ActionResult Index(string TimKiem, int trang =1,int sizeTrang=10)
        {
            var tk = new NhaCungCapModel();
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
            var model = new NhaCungCapModel().xemChiTiet(ma);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(NhaCungCap dm)
        {
            if (ModelState.IsValid)
            {
                var model = new NhaCungCapModel();



                long maTK = model.ThemTK(dm);
                if (maTK > 0)
                {
                    return RedirectToAction("Index", "NhaCungCap");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại !");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(NhaCungCap dm)
        {
            if (ModelState.IsValid)
            {
                var model = new NhaCungCapModel();
                var maTK = model.Sua(dm);
                if (maTK)
                {
                    return RedirectToAction("Index", "NhaCungCap");
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
            new NhaCungCapModel().Xoa(ma);
            return RedirectToAction("Index");
        }
    }
}
