using Model;
using Model.Entity;
using ShopQuanAo.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ShopQuanAo.Areas.Admin.Models;
using System.Data;
namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class TaiKhoanController : BaseController
    {
        //
        // GET: /Admin/TaiKhoan/

        public ActionResult Index(string TimKiem,int trang = 1, int sizetrang = 10)
        {
            var tk = new TaiKhoanModel();
            var model = tk.dsTaiKhoan(TimKiem, trang, sizetrang);
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
            var model = new TaiKhoanModel().xemChiTiet(ma);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(TaiKhoan tk)
        {
            if(ModelState.IsValid)
            {
                var model = new TaiKhoanModel();

                var md5pass = MaHoaMK.MD5Hash(tk.MatKhau);
                tk.MatKhau = md5pass;
                long maTK = model.ThemTK(tk);
                if (maTK > 0)
                {
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại !");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                var model = new TaiKhoanModel();

                var md5pass = MaHoaMK.MD5Hash(tk.MatKhau);
                tk.MatKhau = md5pass;
                string tenTK = tk.TenTK;
                var  maTK = model.Sua(tk);
                if (maTK)
                {
                    return RedirectToAction("Index", "TaiKhoan");
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
            new TaiKhoanModel().Xoa(ma);
            return RedirectToAction("Index");
        }
        
    }
}
