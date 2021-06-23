using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SanPhamNguoiDung
    {
        private ShopQuanAodbConText db = null;
        public SanPhamNguoiDung()
        {
            db = new ShopQuanAodbConText();
        }
        public List<SanPham> dsSanPham()
        {
            return db.SanPhams.ToList();
        }
        public List<SanPham> dsSanPham4()
        {
            return db.SanPhams.Take(4).ToList();
        }
        public SanPham XemChiTiet(int madm)
        {
            return db.SanPhams.Find(madm);
        }
        public List<SanPham> SanPhamTheoDanhMuc(int madm = 0)
        {
            var a = db.SanPhams.Find(madm);
            return db.SanPhams.Where(x => x.MaSP == a.MaSP).ToList();
        }
        public List<SanPham> SPTheoDM(int ma)
        {
            return db.SanPhams.Where(x => x.MaTL == ma).ToList();
        }
    }
}
