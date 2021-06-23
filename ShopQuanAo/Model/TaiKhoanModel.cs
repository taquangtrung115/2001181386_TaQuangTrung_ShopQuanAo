using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using System.Data.SqlClient;
using PagedList;
namespace Model
{
    public class TaiKhoanModel
    {
        private ShopQuanAodbConText db = null;
        public TaiKhoanModel()
        {
            db = new ShopQuanAodbConText();
        }
        //public bool DangNhap(string tenDN, string mK)
        //{
        //    object[] sqlP = 
        //    {
        //        new SqlParameter("@TenDN",tenDN),
        //        new SqlParameter("@MK",mK),
        //    };
        //    var res = db.Database.SqlQuery<bool>("ProcTaiKhoan @TenDN, @MK", sqlP).SingleOrDefault();
        //    return res;
        //}
        public int ThemTK(TaiKhoan tk)
        {
            db.TaiKhoans.Add(tk);
            db.SaveChanges();
            return tk.MaTK;
        }
        public int ThemTKKH(KhachHang tk)
        {
            db.KhachHangs.Add(tk);
            db.SaveChanges();
            return tk.MaKH;
        }
        public bool Sua(TaiKhoan tk)
        {
            try
            {
                var taikhoan = db.TaiKhoans.Find(tk.MaTK);
                taikhoan.MaTK = tk.MaTK;
                taikhoan.TenTK = tk.TenTK;
                taikhoan.MatKhau = tk.MatKhau;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Xoa(int matk)
        {
            try
            {
                var taikhoan = db.TaiKhoans.Find(matk);
                db.TaiKhoans.Remove(taikhoan);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public TaiKhoan xemChiTiet(int ma)
        {
            return db.TaiKhoans.Find(ma);
        }
        public TaiKhoan layTKTheoTen(string tenDN)
        {
            return db.TaiKhoans.SingleOrDefault(t => t.TenTK == tenDN);
        }
        public KhachHang layTKTheoTenKH(string tenDN)
        {
            return db.KhachHangs.SingleOrDefault(t => t.TenKH == tenDN);
        }
        public IEnumerable<TaiKhoan> dsTaiKhoan(string TimKiem,int trang, int sizeTrang)
        {
            IQueryable<TaiKhoan> model = db.TaiKhoans;

            if (!string.IsNullOrEmpty(TimKiem))
            {
                model = model.Where(t => t.TenTK.Contains(TimKiem) || t.TenTK.Contains(TimKiem));    
            }
            return model.OrderByDescending(x => x.MaTK).ToPagedList(trang, sizeTrang);
        }
        public bool DangNhap(string tenDN, string mK)
        {

            var res = db.TaiKhoans.Count(x => x.TenTK == tenDN && x.MatKhau == mK);
            if (res >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DangNhapKH(string tenDN, string mK)
        {

            var res = db.KhachHangs.Count(x => x.TaiKhoan == tenDN && x.MatKhau == mK);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool kiemTraTK(string tenDN)
        {
            return db.TaiKhoans.Count(x => x.TenTK == tenDN) > 0;

        }
        public bool kiemTraTKKH(string tenDN)
        {
            return db.KhachHangs.Count(x => x.TaiKhoan== tenDN) > 0;

        }
    }
}
