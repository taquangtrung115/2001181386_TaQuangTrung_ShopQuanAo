using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using PagedList;
using Model.Entity;
namespace Model
{
    public class SanPhamModel
    {
        private ShopQuanAodbConText db = null;
        public SanPhamModel()
        {
            db = new ShopQuanAodbConText();
        }
        public long ThemTK(SanPham ncc)
        {
            db.SanPhams.Add(ncc);
            db.SaveChanges();
            return ncc.MaSP;
        }
        public bool Sua(SanPham dm)
        {
            try
            {
                var danhMuc = db.SanPhams.Find(dm.MaSP);
                danhMuc.MaSP = dm.MaSP;
                danhMuc.MaTL = dm.MaTL;
                danhMuc.MaNCC = dm.MaNCC;
                danhMuc.TenSP = dm.TenSP;
                danhMuc.DonGia = dm.DonGia;
                danhMuc.Anh = dm.Anh;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Xoa(int madm)
        {
            try
            {
                var danhMuc = db.SanPhams.Find(madm);
                db.SanPhams.Remove(danhMuc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public SanPham xemChiTiet(int ma)
        {
            return db.SanPhams.Find(ma);
        }
        public SanPham layTKTheoTen(string ten)
        {
            return db.SanPhams.SingleOrDefault(t => t.TenSP == ten);
        }
        public IEnumerable<SanPham> dsDanhMuc(string TimKiem, int trang, int sizeTrang)
        {
            IQueryable<SanPham> model = db.SanPhams;

            if (!string.IsNullOrEmpty(TimKiem))
            {
                model = model.Where(t => t.TenSP.Contains(TimKiem) || t.TenSP.Contains(TimKiem));
            }
            return model.OrderByDescending(x => x.MaNCC).ToPagedList(trang, sizeTrang);
        }
    }
}
