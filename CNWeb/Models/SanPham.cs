namespace CNWeb.Models
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
            ChitietDonHangs = new HashSet<ChitietDonHang>();
        }

        [Key]
        public int IDSanPham { get; set; }

        [StringLength(250)]
        public string TenSanPham { get; set; }

        [StringLength(250)]
        public string HinhAnh { get; set; }

        public int? SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public bool? DaXoa { get; set; }

        public int? IDLoaiSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChitietDonHang> ChitietDonHangs { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
