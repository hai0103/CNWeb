using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNWeb.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index","Login");
            }

            var admin = Session["HoTen"];
            return View(admin);
        }
       
    }
}
