using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CNWeb.Models
{
    public class DangNhap
    {
        [Required(ErrorMessage ="Vui lòng nhập tên tài khoản !")]
        [Display(Name ="Tài khoản")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập mật khẩu")]
        [Display(Name ="Mật khẩu")]
        [StringLength(100, ErrorMessage ="Mật khẩu phải dài hơn 6 ký tự và ít hơn 100 ký tự",MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}