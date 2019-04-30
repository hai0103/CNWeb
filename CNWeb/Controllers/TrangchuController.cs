using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNWeb.Models;
using PagedList;

namespace CNWeb.Controllers
{
    
    public class TrangchuController : Controller
    {
        OnlineShop db = new OnlineShop();
        // GET: Trangchu
        public ActionResult Index()
        {
            List<SanPham> lstProduct = db.SanPhams.Take(8).ToList();
            return View(lstProduct);
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact (LienHe lienhe)
        {
            string hoten = Request.Form["hotenLH"];
            string email = Request.Form["emailLH"];
            string noidung = Request.Form["noidungLH"];

            lienhe.Email = email;
            lienhe.NoiDung = hoten + " : " + noidung;
            db.LienHes.Add(lienhe);
            db.SaveChanges();
            return RedirectToAction("Contact", "Trangchu");
        }
        public ActionResult Introduce()
        {
            return View();
        }
        public ActionResult News()
        {
            var lstNew = db.TinTucs.ToList();
            return View(lstNew);
        }
        public ActionResult ResentNew()
        {
            List<TinTuc> resent = db.TinTucs.OrderByDescending((t => t.NgayDang)).Take(3).ToList();
            return PartialView(resent);
        }
        public ActionResult Products()
        {
            var lstCategory = db.LoaiSanPhams.ToList();
            return View(lstCategory);
        }
        public ActionResult listProduct(int ?loaiSP, int? pageIndex)
        {
            var items = new List<SanPham>();
            int _pageIndex = pageIndex ?? 1;
            if(loaiSP == null)
            {
                items = db.SanPhams.ToList();
            }
            else
            {
                //items = db.SanPhams.Select(i=>i.IDLoaiSanPham).Where();
                items = (from sp in db.SanPhams
                         where sp.IDLoaiSanPham == loaiSP
                         select sp).ToList();

            }
            return PartialView(items.OrderBy(i => i.IDSanPham).ToPagedList(_pageIndex, 9));
        }
        public ActionResult Cart()
        {
            return View();
        }

        public PartialViewResult BreadcrumbsPartial()
        {
            return PartialView();
        }
        public ActionResult NewsDetail (int IdNew)
        {
            TinTuc tin = db.TinTucs.SingleOrDefault(t => t.IDTinTuc == IdNew);
            return View(tin);
        }
        public ActionResult ProductDetail(int IdPro)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(s => s.IDSanPham == IdPro);
            return View(sp);
        }
        public ActionResult HoSoTK(int? IdTK)
        {

            if(IdTK == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(t => t.IdTaiKhoan == IdTK);
            return View(tk);
        }
        [HttpPost]
        public ActionResult HoSoTK([Bind(Include = "IdTaiKhoan,TaiKhoan1,MatKhau,HoTen,Email,SDT,DiaChi,NgayTao")] TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taikhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taikhoan);
        }
    }
}