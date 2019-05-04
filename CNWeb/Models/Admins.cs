namespace CNWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admins
    {
        public int ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tài khoản")]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [StringLength(250)]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [StringLength(250)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }
    }
}
