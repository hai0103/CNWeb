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
            ChitietDonHangs = new HashSet<ChitietDonHang>();
        }

        [Key]
        public int IDDonHang { get; set; }

        public DateTime? NgayDat { get; set; }

        public bool? TinhTrangGiao { get; set; }

        public DateTime? NgayGiao { get; set; }

        public int? UuDai { get; set; }

        public int? MaKH { get; set; }

        public bool? DaXoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChitietDonHang> ChitietDonHangs { get; set; }
    }
}
