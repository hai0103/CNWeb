using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using CNWeb.Models;

namespace CNWeb.Areas.Admin.Controllers
{
    public class QuanLiTaiKhoanController : Controller
    {
        OnlineShopDbConText db = new OnlineShopDbConText();

        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            return View(db.Accounts.Where(n=>n.DaXoa == false).ToList().OrderBy(n=>n.TaiKhoan).ToPagedList(pageNumber,pageSize));
        }

        
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var item = db.Accounts.Find(id);
            item.DaXoa = true;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
    }
}
