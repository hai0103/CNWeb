using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNWeb.Models;


namespace CNWeb.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        OnlineShopDbConText db = new OnlineShopDbConText();

        public ActionResult Edit(int id)
        {
            return View(db.Admins.Find(id));
        }
        
        [HttpPost]
        public ActionResult Edit(Admins ad)
        {
            var admin = db.Admins.SingleOrDefault(n=>n.ID == ad.ID);

            if (admin == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            if (ad.MatKhau != null)
            {
                admin.MatKhau = ad.MatKhau;
            }
            if (ad.Email != null)
            {
                admin.Email = ad.Email;
            }
            if(ad.SDT != null)
            {
                admin.SDT = ad.SDT;
            }

            db.SaveChanges();

            return View(admin);
        }
    }
}