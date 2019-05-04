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
        public int ID { get; set; }
        [Display(Name = "Họ tên")]
        [StringLength(250)]
        public string HoTen { get; set; }

        [Display(Name = "Email")]
        [StringLength(250)]
        public string Email { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
    }
}
