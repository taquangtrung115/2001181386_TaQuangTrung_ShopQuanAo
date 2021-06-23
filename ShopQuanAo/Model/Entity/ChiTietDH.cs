namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDH")]
    public partial class ChiTietDH
    {
        [Key]
        public int MaCTDH { get; set; }

        public int? MaDH { get; set; }

        public int? MaSP { get; set; }

        public int SoLuong { get; set; }

        public int DonGia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
