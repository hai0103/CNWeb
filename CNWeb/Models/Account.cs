namespace CNWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int IDTaiKhoan { get; set; }

        [Column("TaiKhoan")]
        [Display(Name ="Tài khoản")]
        [StringLength(50)]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        [Display(Name ="Mật khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [StringLength(250)]
        [Display(Name ="Họ tên")]
        public string HoTen { get; set; }

        [StringLength(250)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Đã xóa")]
        public bool? DaXoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
