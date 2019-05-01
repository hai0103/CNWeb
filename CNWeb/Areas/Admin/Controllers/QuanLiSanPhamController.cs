using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNWeb.Models;
using PagedList.Mvc;
using PagedList;
using System.IO;
namespace CNWeb.Areas.Admin.Controllers
{
    public class QuanLiSanPhamController : Controller
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        /// <summary>
        /// Lấy danh sách sản phẩm
        /// </summary>
        /// <param name="Npage"></param>
        /// <returns></returns>
        public ActionResult Index(int? Npage)
        {
            int page = (Npage ?? 1);
            int pagesize = 10;
            return View(db.SanPhams.Where(n=>n.DaXoa == false).ToList().OrderBy(n=>n.TenSanPham).ToPagedList(page,pagesize));
        }
       
       /// <summary>
       /// Lấy ra loại sản phẩm
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams.ToList().OrderBy(n=>n.TenLoai),"ID","TenLoai");
           
            return View();
        }

        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        /// <param name="entity">Sản phẩm thêm mới</param>
        /// <param name="fileUpLoad">Tên file cần upload</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(SanPham entity,HttpPostedFileBase fileUpLoad)
        {
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams.ToList().OrderBy(n => n.TenLoai), "ID", "TenLoai");

            //Kiểm tra xem đã chọn ảnh chưa
            if (fileUpLoad == null)
            {
                ViewBag.ThongBao = "Bạn chưa chọn ảnh";
                return View();
            }
           
            if (ModelState.IsValid)
            {
                // lấy ra tên ảnh
                var fileName = Path.GetFileName(fileUpLoad.FileName);

                //lưu lại đường dẫn của ảnh
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);

                // kiểm tra hình ảnh đã tồn tại chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    return View();
                }
                else
                {
                    fileUpLoad.SaveAs(path);
                }

                // Thêm vào csdl
                entity.HinhAnh = fileUpLoad.FileName;
                db.SanPhams.Add(entity);
                db.SaveChanges();
                return RedirectToAction("index","QuanLiSanPham");
            }


            return View();
        }

        /// <summary>
        /// Lấy ra sản phẩm cần hỉnh sửa theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.IDSanPham == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams.ToList().OrderBy(n => n.TenLoai), "ID", "TenLoai");
            return View(sp);
        }

        /// <summary>
        /// Cập nhật thông tin sản phẩm
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(SanPham entity, HttpPostedFileBase HinhAnh)
        {
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams.ToList().OrderBy(n => n.TenLoai), "ID", "TenLoai");

            if (ModelState.IsValid)
            {
                
                // Lưu vào csdl
                var item = db.SanPhams.Find(entity.IDSanPham );
                if (item != null)
                {
                    item.SoLuong = entity.SoLuong;
                    item.DonGia = entity.DonGia;
                    if (HinhAnh != null)
                    {
                        var fileName = Path.GetFileName(HinhAnh.FileName);
                        var path = Path.Combine(Server.MapPath("/Images"), fileName);
                        HinhAnh.SaveAs(path);

                        item.HinhAnh = HinhAnh.FileName;
                    }
                    item.MoTa = entity.MoTa;

                    db.SaveChanges();
                    return RedirectToAction("index", "QuanLiSanPham");
                }
                else
                {
                     Response.StatusCode = 404;
                }
            }


            return View();
        }

        /// <summary>
        /// Lấy ra hông tin của sản phẩm muốn xóa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.IDSanPham == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
 
            return View(sp);
            
        }

        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete( int id,FormCollection f)
        {
            var item = db.SanPhams.Find(id);
            item.DaXoa = true;

            db.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
