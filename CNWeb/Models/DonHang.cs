namespace CNWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [Display(Name = "Mã đơn hàng")]
        public int IDDonHang { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime? NgayDat { get; set; }

        [Display(Name = "Tình trạng giao")]
        public bool? TinhTrangGiao { get; set; }

        [Display(Name = "Ngày giao")]
        public DateTime? NgayGiao { get; set; }

        [Display(Name = "Giảm giá")]
        public int? UuDai { get; set; }

        [Display(Name = "Khách hàng")]
        public int? MaTK { get; set; }

        [Display(Name = "Đã hủy")]
        public bool? DaXoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual Account TaiKhoan { get; set; }
    }
}
