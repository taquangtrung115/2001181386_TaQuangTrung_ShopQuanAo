using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using Model;
using PagedList;
namespace Model
{
    public class KhachHangModel
    {
        private ShopQuanAodbConText db = null;
        public KhachHangModel()
        {
            db = new ShopQuanAodbConText();
        }
        public long ThemTK(KhachHang ncc)
        {
            db.KhachHangs.Add(ncc);
            db.SaveChanges();
            return ncc.MaKH;
        }
        public bool Sua(KhachHang dm)
        {
            try
            {
                var danhMuc = db.KhachHangs.Find(dm.MaKH);
                danhMuc.MaKH = dm.MaKH;
                danhMuc.TaiKhoan = dm.TaiKhoan;
                danhMuc.MatKhau = dm.MatKhau;
                danhMuc.TenKH = dm.TenKH;
                danhMuc.Email = dm.Email;
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
                var danhMuc = db.KhachHangs.Find(madm);
                db.KhachHangs.Remove(danhMuc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public KhachHang xemChiTiet(int ma)
        {
            return db.KhachHangs.Find(ma);
        }
        public KhachHang layTKTheoTen(string ten)
        {
            return db.KhachHangs.SingleOrDefault(t => t.TenKH == ten);
        }
        public IEnumerable<KhachHang> dsDanhMuc(string TimKiem, int trang, int sizeTrang)
        {
            IQueryable<KhachHang> model = db.KhachHangs;

            if (!string.IsNullOrEmpty(TimKiem))
            {
                model = model.Where(t => t.TenKH.Contains(TimKiem) || t.TenKH.Contains(TimKiem));
            }
            return model.OrderByDescending(x => x.MaKH).ToPagedList(trang, sizeTrang);
        }
    }
}
