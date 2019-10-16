using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using CNWeb.Models;
using System.Net;

namespace CNWeb.Areas.Admin.Controllers
{
    public class QuanLiHoaDonController : Controller
    {
        OnlineShopDbConText db = new OnlineShopDbConText();
       
        public ActionResult HDChuaGiao(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;

            return View(db.DonHangs.Where(n=>n.TinhTrangGiao == false).ToList().OrderBy(n=>n.NgayDat).ToPagedList(pageNumber,pageSize));
        }
        public ActionResult HDDaGiao(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;

            return View(db.DonHangs.Where(n => n.TinhTrangGiao == true).ToList().OrderBy(n => n.NgayDat).ToPagedList(pageNumber, pageSize));
        }
        
        public ActionResult DuyetDon(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DonHang dh = db.DonHangs.SingleOrDefault(n => n.IDDonHang == id);
            if (dh == null)
            {
                return HttpNotFound();
            }

            ViewBag.CTDH = db.ChiTietDonHangs.Where(n => n.MaDH == id).ToList().OrderBy(n=>n.SanPham.TenSanPham);
            return View(dh);
        }

        [HttpPost]
        public ActionResult DuyetDon(DonHang dh)
        {
            DonHang item = db.DonHangs.SingleOrDefault(n => n.IDDonHang == dh.IDDonHang);

            if (item == null)
            {
                return HttpNotFound();
            }

            item.TinhTrangGiao = dh.TinhTrangGiao;
            if (item.TinhTrangGiao == true)
            {
                item.NgayGiao = DateTime.Now;
            }
            else
            {
                item.NgayGiao = null;
            }

            db.SaveChanges();
            ViewBag.CTDH = db.ChiTietDonHangs.Where(n => n.MaDH == dh.IDDonHang).ToList().OrderBy(n => n.SanPham.TenSanPham);
            return View(item);
        }
    }
}
