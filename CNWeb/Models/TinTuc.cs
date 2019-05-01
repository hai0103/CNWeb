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

        public string TieuDe { get; set; }

        public DateTime? NgayDang { get; set; }

        public string TomTat { get; set; }

        [StringLength(250)]
        public string HinhAnh { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }
    }
}
