using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI.Models
{
    public class DatVe
    {
        public int MaVe { set; get; }
        public string TenNguoiDat { set; get; }
        public DateTime NgayDat { set; get; }
        public int SoGhe { set; get; }

    }
    public class DatVeAPIFunction
    {
        public List<DatVe> TestAPI()
        {

        }
    }
}