namespace CNWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        public int IDKhachHang { get; set; }

        [StringLength(250)]
        public string TenKhachHang { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        public int? IDTaiKhoan { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
