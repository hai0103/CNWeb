using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using CNWeb.Models;
using System.IO;


namespace CNWeb.Areas.Admin.Controllers
{
    public class QuanLiTinTucController : Controller
    {
        OnlineShopDbConText db = new OnlineShopDbConText();
        // GET: Admin/QuanLiTinTuc
        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            return View(db.TinTucs.ToList().OrderBy(n=>n.TieuDe).ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/QuanLiTinTuc/Details/5
        public ActionResult Details(int id)
        {

            return View(db.TinTucs.Find(id));
        }

        // GET: Admin/QuanLiTinTuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuanLiTinTuc/Create
        [HttpPost]
        public ActionResult Create(TinTuc tintuc,HttpPostedFileBase HinhAnh)
        {
            if (HinhAnh == null)
            {
                ViewBag.ThongBao = "Bạn chưa chọn ảnh";
                return View();
            }

            if (ModelState.IsValid)
            {
                // lấy ra tên ảnh
                var fileName = Path.GetFileName(HinhAnh.FileName);

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
                    HinhAnh.SaveAs(path);
                }

                // Thêm vào csdl
                tintuc.HinhAnh = HinhAnh.FileName;
                db.TinTucs.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("index");
            }


            return View();
        }

        /// <summary>
        /// lấy ra thông tin bài viết muốn cập nhật
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            return View(db.TinTucs.Find(id));
        }

        /// <summary>
        /// Cập nhật bài viết
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="HinhAnh"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(TinTuc entity, HttpPostedFileBase HinhAnh)
        {

                // Lưu vào csdl
                var item = db.TinTucs.Find(entity.ID);
                if (item != null)
                {
                    item.TieuDe = entity.TieuDe;

                    if (HinhAnh != null)
                    {
                        var fileName = Path.GetFileName(HinhAnh.FileName);
                        var path = Path.Combine(Server.MapPath("/Images"), fileName);
                        HinhAnh.SaveAs(path);

                        item.HinhAnh = HinhAnh.FileName;
                    }
                item.TomTat = entity.TomTat;
                item.NoiDung = entity.NoiDung;

                    db.SaveChanges();
                    return RedirectToAction("Index");
              
        }


            return View();
        }

        /// <summary>
        /// Xóa bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var item = db.TinTucs.Find(id);

            db.TinTucs.Remove(item);

            db.SaveChanges();

            return RedirectToAction("Index");
                
            
        }
    }
}
