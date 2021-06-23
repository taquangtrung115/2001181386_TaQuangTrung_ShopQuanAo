namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDHs = new HashSet<ChiTietDH>();
        }

        [Key]
        public int MaSP { get; set; }

        public int? MaTL { get; set; }

        public int? MaNCC { get; set; }

        [StringLength(100)]
        public string TenSP { get; set; }

        public double? DonGia { get; set; }

        [StringLength(50)]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDH> ChiTietDHs { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
