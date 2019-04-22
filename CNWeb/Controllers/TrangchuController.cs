using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNWeb.Controllers
{
    public class TrangchuController : Controller
    {
        // GET: Trangchu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Introduce()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }

        public PartialViewResult BreadcrumbsPartial()
        {
            return PartialView();
        }

    }
}