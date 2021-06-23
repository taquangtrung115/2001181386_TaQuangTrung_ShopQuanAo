using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DanhMucNguoiDung
    {
        private ShopQuanAodbConText db = null;
        public DanhMucNguoiDung()
        {
            db = new ShopQuanAodbConText();
        }
        public List<TheLoai> dsDanhMuc()
        {
            return db.TheLoais.OrderBy(x => x.Ten).ToList();
        }
        public TheLoai XemChiTiet(int madm)
        {
            return db.TheLoais.Find(madm);
        }
        public List<SanPham> SanPhamTheoDanhMuc(int madm)
        {
            //var a = db.TheLoais.Find(madm);
            return db.SanPhams.Where(x => x.MaTL == madm).OrderBy(x => x.DonGia).ToList();
        }
    }
}
