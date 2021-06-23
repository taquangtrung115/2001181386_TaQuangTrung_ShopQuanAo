using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagedList;
namespace Model
{
    public class NhaCungCapModel
    {
        private ShopQuanAodbConText db = null;
        public NhaCungCapModel()
        {
            db = new ShopQuanAodbConText();
        }
        public long ThemTK(NhaCungCap ncc)
        {
            db.NhaCungCaps.Add(ncc);
            db.SaveChanges();
            return ncc.MaNCC;
        }
        public bool Sua(NhaCungCap dm)
        {
            try
            {
                var danhMuc = db.NhaCungCaps.Find(dm.MaNCC);
                danhMuc.MaNCC = dm.MaNCC;
                danhMuc.TenNCC = dm.TenNCC;
                danhMuc.Logo = dm.Logo;
                danhMuc.SDT = dm.SDT;
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
                var danhMuc = db.NhaCungCaps.Find(madm);
                db.NhaCungCaps.Remove(danhMuc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public NhaCungCap xemChiTiet(int ma)
        {
            return db.NhaCungCaps.Find(ma);
        }
        public NhaCungCap layTKTheoTen(string ten)
        {
            return db.NhaCungCaps.SingleOrDefault(t => t.TenNCC == ten);
        }
        public IEnumerable<NhaCungCap> dsDanhMuc(string TimKiem, int trang, int sizeTrang)
        {
            IQueryable<NhaCungCap> model = db.NhaCungCaps;

            if (!string.IsNullOrEmpty(TimKiem))
            {
                model = model.Where(t => t.TenNCC.Contains(TimKiem) || t.TenNCC.Contains(TimKiem));
            }
            return model.OrderByDescending(x => x.MaNCC).ToPagedList(trang, sizeTrang);
        }
    }
}
