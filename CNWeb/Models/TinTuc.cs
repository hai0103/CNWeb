namespace CNWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        public int ID { get; set; }


        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Bài viết chưa có tiêu đề")]
        public string TieuDe { get; set; }

        [Display(Name = "Ngày đăng")]
        
        public DateTime? NgayDang { get; set; }

        [Display(Name = "Tóm tắt")]
        [Required(ErrorMessage = "Bài viết chưa có tóm tắt")]
        public string TomTat { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Bạn chưa chọn ảnh")]
        public string HinhAnh { get; set; }

        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Bài viết chưa có nội dung")]
        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }
    }
}
