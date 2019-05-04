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
        OnlineShopDbConText db = new OnlineShopDbConText();
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
        public ActionResult Contact (FormCollection f)
        {
            
            string hoten = Request.Form["hotenLH"];
            string email = Request.Form["emailLH"];
            string noidung = Request.Form["noidungLH"];

            LienHe lienhe = new LienHe();
            lienhe.HoTen = hoten;
            lienhe.Email = email;
            lienhe.NoiDung =  noidung;
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
            List<TinTuc> listT = db.TinTucs.ToList();
            return View(listT);

        }
        //public ActionResult News()
        //{
        //    return View();
        //}
        //public ActionResult listNews(int? pageIndex)
        //{
        //    var lstNew = db.TinTucs.ToList();
        //    int _pageIndex = pageIndex ?? 1;
        //    return PartialView(lstNew.OrderBy(t => t.IDTinTuc).ToPagedList(_pageIndex, 3));
        //}
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
                items = db.SanPhams.Where(n => n.MaLoai == loaiSP && n.DaXoa == false).ToList();
                //items = (from sp in db.SanPhams
                //         where sp.MaLoai == loaiSP && sp.DaXoa
                //         select sp).ToList();

            }
            return PartialView(items.OrderBy(i => i.TenSanPham).ToPagedList(_pageIndex, 9));
        }
        public ActionResult Product1(int IDLoai)
        {
            var loaiSP = db.LoaiSanPhams.SingleOrDefault(s => s.ID == IDLoai);
            return View(loaiSP);
        }
        

        public PartialViewResult BreadcrumbsPartial()
        {
            return PartialView();
        }
        public ActionResult NewsDetail (int IdNew)
        {
            TinTuc tin = db.TinTucs.SingleOrDefault(t => t.ID == IdNew);
            return View(tin);
        }
        public ActionResult ProductDetail(int IdPro)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(s => s.IDSanPham == IdPro);
            return View(sp);
        }
        public ActionResult Profile(int? IdTK)
        {

            if(IdTK == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account tk = db.Accounts.SingleOrDefault(t => t.IDTaiKhoan == IdTK);
            return View(tk);
        }
        [HttpPost]
        public ActionResult Profile([Bind(Include = "IdTaiKhoan,TaiKhoan1,MatKhau,HoTen,Email,SDT,DiaChi,NgayTao")] Account taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taikhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taikhoan);
        }
        //public ActionResult listProductSearch(string strSearch)
        //{
        //    var items = new List<SanPham>();
        //    if(strSearch == null)
        //    {
        //        items = db.SanPhams.ToList();
        //    }
        //    else
        //    {
        //        items = db.SanPhams.Where(s => s.TenSanPham.Contains(strSearch)).ToList();
        //    }
        //    return PartialView(items);
        //}

        //public ActionResult News( string strSearch)
        //{
        //    var items = new List<TinTuc>;
        //    if(strSearch == null)
        //    {

        //    }
        //}
    }
}