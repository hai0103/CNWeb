namespace CNWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            DonHangs = new HashSet<DonHang>();
            KhachHangs = new HashSet<KhachHang>();
        }

        [Key]
        public int IDTaiKhoan { get; set; }

        [Column("TaiKhoan")]
        [StringLength(50)]
        public string TaiKhoan1 { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(250)]
        public string HoTen { get; set; }

        [StringLength(10)]
        public string Email { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        public bool? DaXoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
