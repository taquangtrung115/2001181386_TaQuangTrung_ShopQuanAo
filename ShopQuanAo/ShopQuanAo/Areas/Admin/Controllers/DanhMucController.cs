using Model;
using Model.Entity;
using ShopQuanAo.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class DanhMucController : BaseController
    {
        //
        // GET: /Admin/DanhMuc/

        public ActionResult Index(string TimKiem, int trang =1,int sizeTrang=10)
        {
            var tk = new DanhMucModel();
            var model = tk.dsDanhMuc(TimKiem, trang, sizeTrang);
            ViewBag.TimKiem = TimKiem;
            return View(model);
        }

        //
        // GET: /Admin/DanhMuc/Details/5

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int ma = 0)
        {
            var model = new DanhMucModel().xemChiTiet(ma);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(TheLoai dm)
        {
            if (ModelState.IsValid)
            {
                var model = new DanhMucModel();

                
                
                long maTK = model.ThemTK(dm);
                if (maTK > 0)
                {
                    return RedirectToAction("Index", "DanhMuc");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại !");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(TheLoai dm)
        {
            if (ModelState.IsValid)
            {
                var model = new DanhMucModel();
                string ten = dm.Ten;
                var maTK = model.Sua(dm);
                if (maTK)
                {
                    return RedirectToAction("Index", "DanhMuc");
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
            new DanhMucModel().Xoa(ma);
            return RedirectToAction("Index");
        }
    }
}
