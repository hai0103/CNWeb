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
    public class QuanLiLienHeController : Controller
    {
        OnlineShopDbConText db = new OnlineShopDbConText();
        // GET: Admin/QuanLiLienHe
        public ActionResult Index(int?page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10; 
            return View(db.LienHes.ToList().OrderBy(n=>n.HoTen).ToPagedList(pageNumber,pageSize));
        }

        /// <summary>
        /// Xóa nội dung liên hệ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var item = db.LienHes.Find(id);
                db.LienHes.Remove(item);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
