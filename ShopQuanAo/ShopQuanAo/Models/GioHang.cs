using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAo.Models
{
    public class GioHang
    {
        //dbShopQuanAoDataContext db = new dbShopQuanAoDataContext();
        public Model.Entity.SanPham sp { get; set; }
        public int trangThai { get; set; }
        //public int iMaSP { set; get; }
        //public string sTenSP { set; get; }
        //public string sAnh { set; get; }
        //public double dDonGia { set; get; }
        //public int iSoLuong { set; get; }
        //public double dThanhTien
        //{
        //    get { return iSoLuong * dDonGia; }
        //}

        //// Khởi tạo giỏ hàng
        //public GioHang(int sanPham)
        //{
        //    iMaSP = sanPham;
        //    SanPham sach = db.SanPhams.SingleOrDefault(s => s.MaSP == iMaSP);
        //    sTenSP = sach.TenSP;
        //    sAnh = sach.Anh;
        //    dDonGia = double.Parse(sach.DonGia.ToString());
        //    iSoLuong = 1;

        //}
    }
}