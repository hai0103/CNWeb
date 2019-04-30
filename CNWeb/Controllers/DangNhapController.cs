using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNWeb.Models;

namespace CNWeb.Controllers
{
    public class DangNhapController : Controller
    {
        OnlineShop db = new OnlineShop();
        //  DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap (TaiKhoan taikhoan)
        {
            string tk = Request.Form["tk"];
            string mk = Request.Form["mk"];
            taikhoan = db.TaiKhoans.SingleOrDefault(t => t.TaiKhoan1 == tk && t.MatKhau.Trim() == mk);
            if(taikhoan != null)
            {
                ViewBag.message = "Đăng nhập thành công";
                Session["Login"] = taikhoan;
                return RedirectToAction("Index", "Trangchu");
            }
            ViewBag.message = "Đăng nhập thất bại";
            return View();
        }


        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(TaiKhoan taikhoan)
        {
            taikhoan.HoTen = Request.Form["hotenDK"];
            taikhoan.Email = Request.Form["emailDK"];
            taikhoan.SDT = Request.Form["sdtDK"];
            taikhoan.DiaChi = Request.Form["diachiDK"];
            taikhoan.TaiKhoan1 = Request.Form["tkDK"];
            taikhoan.MatKhau = Request.Form["mkDK"];
            db.TaiKhoans.Add(taikhoan);
            db.SaveChanges();
            return RedirectToAction("DangNhap","DangNhap");
        }

        public ActionResult DangXuat()
        {
            Session["Login"] = null;
            return RedirectToAction("Index", "Trangchu");
        }
       
        //public ActionResult HoSoTK(int? IdTK)
        //{
        //    TaiKhoan tk = db.TaiKhoans.SingleOrDefault(t => t.IdTaiKhoan == IdTK);
        //    return View(tk);
        //}
        //[HttpPost, ActionName("HoSoTK")]
        //[ValidateAntiForgeryToken]
        //public ActionResult HoSoTK(int Id)
        //{

        //}
    }
}