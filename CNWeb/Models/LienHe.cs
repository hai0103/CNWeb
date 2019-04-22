namespace CNWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        [Key]
        public int IdLienHe { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }
    }
}
