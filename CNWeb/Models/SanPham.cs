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
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        public int IDSanPham { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa nhập tên sản phẩm")]
        public string TenSanPham { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng")]
        public Nullable<int> SoLuong { get; set; }

        [Display(Name = "Đơn giá")]
       
        [DisplayFormat(DataFormatString ="{0:0,0}")]
        [Required(ErrorMessage = "Bạn chưa nhập đơn giá")]
        public Nullable<decimal> DonGia { get; set; }

        [Display(Name = "Mô tả")]
        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
       
        public string HinhAnh { get; set; }

        [Display(Name = "Đã xóa")]
        [Required(ErrorMessage = "Bạn chưa nhập tên sản phẩm")]
        public Nullable<bool> DaXoa { get; set; }

        [Display(Name = "Loại thú")]
        public Nullable<int> MaLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
