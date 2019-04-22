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
        [Key]
        public int IDTinTuc { get; set; }

        public DateTime? NgayDang { get; set; }

        [StringLength(250)]
        public string TieuDe { get; set; }

        [StringLength(250)]
        public string HinhAnh { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }
    }
}
