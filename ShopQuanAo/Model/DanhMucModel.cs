using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using System.Data.SqlClient;
using Model.Entity;
using PagedList;
namespace Model
{
    public class DanhMucModel
    {

        private ShopQuanAodbConText db = null;
        public DanhMucModel()
        {
            db = new ShopQuanAodbConText();
        }
        public long ThemTK(TheLoai dm)
        {
            db.TheLoais.Add(dm);
            db.SaveChanges();
            return dm.MaTL;
        }
        public bool Sua(TheLoai dm)
        {
            try
            {
                var danhMuc = db.TheLoais.Find(dm.MaTL);
                danhMuc.MaTL = dm.MaTL;
                danhMuc.Ten = dm.Ten;
    
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
                var danhMuc = db.TheLoais.Find(madm);
                db.TheLoais.Remove(danhMuc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public TheLoai xemChiTiet(int ma)
        {
            return db.TheLoais.Find(ma);
        }
        public TheLoai layTKTheoTen(string ten)
        {
            return db.TheLoais.SingleOrDefault(t => t.Ten == ten);
        }
        public IEnumerable<TheLoai> dsDanhMuc(string TimKiem, int trang, int sizeTrang)
        {
            IQueryable<TheLoai> model = db.TheLoais;

            if (!string.IsNullOrEmpty(TimKiem))
            {
                model = model.Where(t => t.Ten.Contains(TimKiem) || t.Ten.Contains(TimKiem));
            }
            return model.OrderByDescending(x => x.MaTL).ToPagedList(trang, sizeTrang);
        }
    }
}
