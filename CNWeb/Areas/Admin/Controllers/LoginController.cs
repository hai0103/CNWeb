using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNWeb.Models;


namespace CNWeb.Areas.Admin.Controllers
{
    
    public class LoginController : Controller
    {
        OnlineShopDbConText db = new OnlineShopDbConText();
      
        public ActionResult Login()
        {
            return View();

        }
       [HttpPost]
       public ActionResult Login (FormCollection f)
        {
            string tk = f["TaiKhoan"].ToString();
            string mk = f.Get("MatKhau").ToString();

            var admin = db.Admins.SingleOrDefault(n => n.TaiKhoan == tk && n.MatKhau == mk);

            if (admin != null)
            {
                Session["id"] = admin.ID;
                Session["HoTen"] = admin.HoTen;
                Session["email"] = admin.Email;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = "Sai tài khoản hoặc mật khẩu";
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session["id"] = null;
            return RedirectToAction("Login");
        }
        
    }
}