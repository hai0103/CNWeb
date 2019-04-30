using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAPI.Models;
namespace TestAPI.Controllers
{
    public class DatVeAPIController : Controller
    {
        // GET: DatVeAPI
        public ActionResult Index()
        {
            return View();
        }
        public IEnumerable<DatVe> Get()
        {
            return new DatVeAPIFunction().TestAPIs.ToList();
        }
    }
}