using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNWeb.Models;
namespace CNWeb.Controllers
{
    public class GioHangController : Controller
    {
        OnlineShopDbConText db = new OnlineShopDbConText();
        // GET: GioHang
        public List<Item_GioHang> LayGioHang()
        {
            List<Item_GioHang> listGioHang = Session["GioHang"] as List<Item_GioHang>;
            if(listGioHang == null)
            {
                listGioHang = new List<Item_GioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }
        public ActionResult GioHang()
        {
            ViewBag.TongSL = TongSL();
            List<Item_GioHang> listGioHang = LayGioHang();
            return View(listGioHang);
        }
        public ActionResult ThemItemGioHang(int IDSanPham, int SL, string strUrl)
        {
            
            if(Session["Login"] == null)
            {
                return RedirectToAction("DangNhap", "DangNhap");
            }
            else
            {
                SanPham sp = db.SanPhams.SingleOrDefault(s => s.IDSanPham == IDSanPham);
                if(sp == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                List<Item_GioHang> listGioHang = LayGioHang();
                Item_GioHang item = listGioHang.Find(i => i.MaSP == IDSanPham);
                if(item == null)
                {
                    item = new Item_GioHang(IDSanPham, SL);
                    listGioHang.Add(item);
                    return Redirect(strUrl);
                }
                else
                {
                    item.SoLuong = item.SoLuong + SL;
                    return Redirect(strUrl);
                }
            }
        }
        public ActionResult CapNhatItemGioHang (int IDSanPham, int SL)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(s => s.IDSanPham == IDSanPham);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Item_GioHang> listGioHang = LayGioHang();
            Item_GioHang item = listGioHang.Find(i => i.MaSP == IDSanPham);
            if(item != null)
            {
                item.SoLuong = SL;
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult XoaItemGioHang(int IDSanPham)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(s => s.IDSanPham == IDSanPham);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Item_GioHang> listGioHang = LayGioHang();
            Item_GioHang item = listGioHang.Find(i => i.MaSP == IDSanPham);
            if(item != null)
            {
                listGioHang.RemoveAll(s => s.MaSP == IDSanPham);
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHangPartial()
        {
            if(TongSL() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSL = TongSL();

            return PartialView();
        }
        public int TongSL()
        {
            int tong = 0;
            List<Item_GioHang> listGioHang = LayGioHang();
            tong = listGioHang.Sum(t => t.SoLuong);
            return tong;
        }
        [HttpPost]
        //public ActionResult ThanhToan()
        //{
        //    if(Session["GioHang"] == null)
        //    {
        //        return RedirectToAction("Products", "Trangchu");
        //    }
        //    List<Item_GioHang> gio = LayGioHang();
        //    DonHang don = new DonHang();
        //    Account taikhoan = (Account)Session["Login"];
        //    don.MaTK = taikhoan.IDTaiKhoan;
        //    don.NgayDat = DateTime.Now;
        //    db.DonHangs.Add(don);
        //    db.SaveChanges();

        //    foreach(var item in gio)
        //    {
        //        ChiTietDonHang ct = new ChiTietDonHang();
        //        ct.MaDH = don.IDDonHang;
        //        ct.MaDH = item.MaSP;
        //        ct.SoLuong = item.SoLuong;
        //        ct.DonGia = (decimal)item.DonGia;
        //        db.ChiTietDonHangs.Add(ct);
        //    }
        //    db.SaveChanges();
        //    Session["GioHang"] = null;
        //    return RedirectToAction("Products", "Trangchu");
        //}

        public ActionResult TinhTien()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Products", "Trangchu");
            }
            List<Item_GioHang> gio = LayGioHang();
            DonHang don = new DonHang();
            Account taikhoan = (Account)Session["Login"];
            don.MaTK = taikhoan.IDTaiKhoan;
            don.NgayDat = DateTime.Now;
            db.DonHangs.Add(don);
            db.SaveChanges();

            foreach (var item in gio)
            {
                ChiTietDonHang ct = new ChiTietDonHang();
                ct.MaDH = don.IDDonHang;
                ct.MaSanPham = item.MaSP;
                ct.SoLuong = item.SoLuong;
                ct.DonGia = (decimal)item.DonGia;
                db.ChiTietDonHangs.Add(ct);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("Products", "Trangchu");
        }
    }
    
}