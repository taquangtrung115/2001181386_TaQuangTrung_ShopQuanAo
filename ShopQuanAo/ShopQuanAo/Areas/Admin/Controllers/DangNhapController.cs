using Model;
using ShopQuanAo.Areas.Admin.Models;
using ShopQuanAo.Code;
using ShopQuanAo.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        //
        // GET: /Admin/DangNhap/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TaiKhoanModels tk)
        {
            if (ModelState.IsValid)
            {


                var tkm = new TaiKhoanModel();
                var rs = tkm.DangNhap(tk.tenDN,MaHoaMK.MD5Hash(tk.matKhau));
                if (rs)
                {
                    var nguoidung = tkm.layTKTheoTen(tk.tenDN);
                    var nguoiDungSesstion = new NguoiDungDangNhap();
                    nguoiDungSesstion.tenDN = nguoidung.TenTK;
                    nguoiDungSesstion.maTK = nguoidung.MaTK;
                    Session.Add(ShopQuanAo.NewFolder1.NguoiDungSesstion.nguoiDung, nguoiDungSesstion);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai !");
                }
            }
            return View("Index");
        }
    }
}
