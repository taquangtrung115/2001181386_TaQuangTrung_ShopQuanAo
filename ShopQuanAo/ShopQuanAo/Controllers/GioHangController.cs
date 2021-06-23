using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Entity;
using Model;
using ShopQuanAo.NewFolder1;
using System.Web.Script.Serialization;
namespace ShopQuanAo.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        
        public ActionResult Index()
        {
            var sesstion = Session[NguoiDungSesstion.SesstionGioHang];
            var list = new List<GioHang>();
            if (sesstion != null)
            {
                list = (List<GioHang>)sesstion;
            }
            return View(list);
            return View();
        }
        //public List<GioHang> LayGioHang()
        //{
        //    List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
        //    if (lstGioHang == null)
        //    {
        //        lstGioHang = new List<GioHang>();
        //        Session["GioHang"] = lstGioHang;
        //    }
        //    return lstGioHang;
        //}
        //public ActionResult ThemGioHang(int ms=0, string strURL="")
        //{
        //    List<GioHang> lstGioHang = LayGioHang();
        //    GioHang sanPham = lstGioHang.Find(sp => sp.iMaSP == ms);
        //    if (sanPham == null)
        //    {
        //        sanPham = new GioHang(ms);
        //        lstGioHang.Add(sanPham);
        //        return Redirect(strURL);
        //    }
        //    else
        //    {
        //        sanPham.iSoLuong++;
        //        return Redirect(strURL);
        //    }
        //}
        //public int tinhTong()
        //{
        //    int tsl = 0;
        //    List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
        //    if (lstGioHang != null)
        //    {
        //        tsl = lstGioHang.Sum(t => t.iSoLuong);
        //    }
        //    return tsl;
        //}
        //private double tongTien()
        //{
        //    double t = 0;
        //    List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
        //    if (lstGioHang != null)
        //    {
        //        t += lstGioHang.Sum(z => z.dThanhTien);
        //    }
        //    return t;
        //}
        //public ActionResult GioHang()
        //{
        //    if (Session["GioHang"] == null)
        //    {
        //        return RedirectToAction("Index1", "Home");
        //    }
        //    List<GioHang> lstGioHang = LayGioHang();
        //    ViewBag.TongSL = tinhTong();
        //    ViewBag.tongTien = tongTien();
        //    return View(lstGioHang);
        //}
        //public ActionResult GioHangPartial()
        //{
        //    ViewBag.TongSL = tinhTong();
        //    return PartialView();
        //}
        //public ActionResult XoaGioHang(int ms=0)
        //{
        //    List<GioHang> lstGioHang = LayGioHang();
        //    GioHang sp = lstGioHang.Single(s => s.iMaSP == ms);

        //    if (sp != null)
        //    {
        //        lstGioHang.RemoveAll(s => s.iMaSP == ms);
        //        return RedirectToAction("GioHang", "GioHang");

        //    }
        //    if (lstGioHang.Count == 0)
        //    {
        //        return RedirectToAction("Index1", "Home");
        //    }
        //    return RedirectToAction("GioHang", "GioHang");
        //}
        //public ActionResult XoaGioHang_All()
        //{

        //    List<GioHang> lstGioHang = LayGioHang();
        //    lstGioHang.Clear();
        //    return RedirectToAction("Index1", "Home");
        //}
        //public ActionResult CapNhatGioHang(int ms, FormCollection f)
        //{
        //    List<GioHang> lstGioHang = LayGioHang();
        //    GioHang sp = lstGioHang.Single(s => s.iMaSP == ms);

        //    if (sp != null)
        //    {
        //        sp.iSoLuong = int.Parse(f["txtSL"].ToString());

        //    }
        //    return RedirectToAction("GioHang", "GioHang");
        //}
        public JsonResult XoaTatCa()
        {
            Session[NguoiDungSesstion.SesstionGioHang] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Xoa(int ma)
        {
            var sessionGioHang = (List<GioHang>)Session[NguoiDungSesstion.SesstionGioHang];
            sessionGioHang.RemoveAll(x => x.sp.MaSP == ma);
            Session[NguoiDungSesstion.SesstionGioHang] = sessionGioHang;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult CapNhat(string gioHangModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<GioHang>>(gioHangModel);
            var sessionGioHang = (List<GioHang>)Session[NguoiDungSesstion.SesstionGioHang];

            foreach (var item in sessionGioHang)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.sp.MaSP == item.sp.MaSP);
                if (jsonItem != null)
                {
                    item.trangThai = jsonItem.trangThai;
                }
            }
            Session[NguoiDungSesstion.SesstionGioHang] = sessionGioHang;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult themGioHang(int ma, int soLuong = 1)
        {
            var sanpham = new SanPhamNguoiDung().XemChiTiet(ma);
            var cart = Session[NguoiDungSesstion.SesstionGioHang];
            if (cart != null)
            {
                var list = (List<GioHang>)cart;
                if (list.Exists(x => x.sp.MaSP == ma))
                {

                    foreach (var item in list)
                    {
                        if (item.sp.MaSP == ma)
                        {
                            item.trangThai += soLuong;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new GioHang();
                    item.sp = sanpham;
                    item.trangThai = soLuong;
                    list.Add(item);
                }
                //Gán vào session
                Session[NguoiDungSesstion.SesstionGioHang] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new GioHang();
                item.sp = sanpham;
                item.trangThai = soLuong;
                var list = new List<GioHang>();
                list.Add(item);
                //Gán vào session
                Session[NguoiDungSesstion.SesstionGioHang] = list;
            }
            return RedirectToAction("Index");
        }
        public ActionResult ThanhToan()
        {
            var giohang = Session[NguoiDungSesstion.SesstionGioHang];
            var list = new List<GioHang>();
            if (giohang != null)
            {
                list = (List<GioHang>)giohang;
            }
            return View(list);
        }
    }
}
