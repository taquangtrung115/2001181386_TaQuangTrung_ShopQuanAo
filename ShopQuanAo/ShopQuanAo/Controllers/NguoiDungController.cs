using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAo.Models;
using Model;
using ShopQuanAo.Code;
using Model.Entity;
using ShopQuanAo.NewFolder1;
namespace ShopQuanAo.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        public ActionResult DangNhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection f, ShopQuanAo.Models.KhachHang kh)
        {
            var hoTen = f["HoTenKH"];
            var tenDN = f["TenDN"];
            var matKhau = f["MatKhau"];
            var reMatKhau = f["reMatKhau"];
            var email = f["Email"];
            if (String.IsNullOrEmpty(hoTen))
            {
                ViewData["Loi1"] = "Họ tên không được bỏ trống";
            }
            if (String.IsNullOrEmpty(tenDN))
            {
                ViewData["Loi2"] = "Tên đăng nhập không được bỏ trống";
            }
            if (String.IsNullOrEmpty(matKhau))
            {
                ViewData["Loi3"] = "Mật khẩu không được bỏ trống";
            }
            if (String.IsNullOrEmpty(reMatKhau))
            {
                ViewData["Loi4"] = "Vui lòng nhập lại mật khẩu";
            }

            if (!String.IsNullOrEmpty(hoTen) && !String.IsNullOrEmpty(tenDN) && !String.IsNullOrEmpty(matKhau) && !String.IsNullOrEmpty(reMatKhau))
            {
                kh.TenKH = hoTen;
                kh.TaiKhoan = tenDN;
                kh.MatKhau = MaHoaMK.MD5Hash(matKhau);
                kh.Email = email;
                //ghi xuống csdl
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("DangNhap", "NguoiDung");
            }

            return View();
            //if (ModelState.IsValid)
            //{
            //    var dao = new TaiKhoanModel();
            //    if (dao.kiemTraTKKH(model.taiKhoan))
            //    {
            //        ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
            //    }
            //    else
            //    {
            //        var user = new Model.Entity.KhachHang();
            //        user.TaiKhoan = model.taiKhoan;
            //        user.MatKhau = MaHoaMK.MD5Hash(model.matKhau);
            //        user.TenKH = model.tenHienThi;
            //        user.Email = model.email;
            //        var result = dao.ThemTKKH(user);
            //        if (result > 0)
            //        {
            //            return Redirect("DangNhap");
            //        }
            //        else
            //        {
            //            ModelState.AddModelError("", "Đăng ký không thành công.");
            //        }
            //    }
            //}
            //return View(model);
        }
        ShopQuanAoDataContext db = new ShopQuanAoDataContext();
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            var tenDN = f["TenDN"];
            var mk = f["MatKhau"];
            if (String.IsNullOrEmpty(tenDN) && String.IsNullOrEmpty(mk))
            {
                ViewBag.Error = "Tên đăng nhập và mật khẩu không được bỏ trống";
            }
            else
            {
                var tenTK = db.KhachHangs.SingleOrDefault(m => m.TaiKhoan == tenDN);
                if (tenTK == null)
                {
                    ViewBag.Error = "Không có tên đăng nhập này";

                }
                else
                {
                    if (tenTK.MatKhau != MaHoaMK.MD5Hash(mk))
                    {
                        ViewBag.Error = "Sai mật khẩu";
                    }
                    else
                    {
                        Session[NguoiDungSesstion.nguoiDung] = tenTK;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
            //if (ModelState.IsValid)
            //{


            //    var tkm = new TaiKhoanModel();
            //    var rs = tkm.DangNhap(tk.taiKhoan, MaHoaMK.MD5Hash(tk.matKhau));
            //    if (rs)
            //    {
            //        var nguoidung = tkm.layTKTheoTen(tk.taiKhoan);
            //        var nguoiDungSesstion = new NguoiDungDangNhap();
            //        nguoiDungSesstion.tenDN = nguoidung.TenTK;
            //        nguoiDungSesstion.maTK = nguoidung.MaTK;
            //        Session.Add(ShopQuanAo.NewFolder1.NguoiDungSesstion.nguoiDung, nguoiDungSesstion);
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai !");
            //    }
            //}
            //return View(tk);
        }
    }
}
