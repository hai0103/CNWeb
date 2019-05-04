using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNWeb.Models;

namespace CNWeb.Controllers
{
    public class TimKiemController : Controller
    {
        OnlineShopDbConText db = new OnlineShopDbConText();

        // GET: TimKiem


        public ActionResult TimKiem_Partial(string sTimKiem)
        {

            //if (string.IsNullOrEmpty(sTimKiem))
            //{
            //    var lst = db.SanPhams.ToList();
            //}
            var lst = db.SanPhams.Where(n => n.TenSanPham.Contains(sTimKiem)).ToList().OrderByDescending(n => n.DonGia);
            ViewBag.TuKhoa = sTimKiem;
            return PartialView(lst);
        }
    }
}