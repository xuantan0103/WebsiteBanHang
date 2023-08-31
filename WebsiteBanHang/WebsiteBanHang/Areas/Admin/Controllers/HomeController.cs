using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using PagedList;
using System.IO;
using System.Data.Entity;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        QLdienthoai db = new QLdienthoai();
        // GET: Admin/Home


        [HttpGet]
        public ActionResult Index(string CurrenFiler, int? page, string search)
        {

            var sanpham = new List<Sanpham>();
            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = CurrenFiler;
            }
            if (!string.IsNullOrEmpty(search))
            {
                sanpham = db.Sanpham.Where(n => n.Tensp.Contains(search)).ToList();
            }
            else
            {
                sanpham = db.Sanpham.ToList();
            }
            ViewBag.CurrenFiler = search;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            sanpham = sanpham.OrderByDescending(n => n.Masp).ToList();
            return View(sanpham.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        // Xem chi tiết người dùng GET: Admin/Home/Details/5 
        public ActionResult Details(int id)
        {
            var dt = db.Sanpham.Find(id);
            return View(dt);
        }

        // Tạo sản phẩm mới phương thức GET: Admin/Home/Create
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }

        // Tạo sản phẩm mới phương thức POST: Admin/Home/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Sanpham sanpham)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    int check = db.Sanpham.Count(m => m.Tensp == sanpham.Tensp);
                    if (check > 0)
                    {
                        TempData["Thongbao"] = "Tên sản phẩm đã tồn tại";
                        return View();
                    }
                    else
                    {


                        if (sanpham.UploadAnh != null)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(sanpham.UploadAnh.FileName);
                            string extension = Path.GetExtension(sanpham.UploadAnh.FileName);
                            fileName = fileName + extension;
                            sanpham.Anhbia = fileName;
                            sanpham.UploadAnh.SaveAs(Path.Combine(Server.MapPath("~/images/"), fileName));
                        }
                        //Thêm  sản phẩm mới
                        db.Sanpham.Add(sanpham);
                        // Lưu lại
                        db.SaveChanges();
                        TempData["Thongbao"] = "Thêm sản phẩm thành công";
                      
                        return View();

                    }
                }

                catch
                {
                    return View();
                }
            }
            else
            {
                TempData["Thongbao"] = "Chưa nhập đủ dữ liệu";
            }

            return View(sanpham);

        }

        // Sửa sản phẩm GET lấy ra ID sản phẩm: Admin/Home/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Hiển thị dropdownlist
            var dt = db.Sanpham.Find(id);
            this.LoadData();
            // 
            return View(dt);

        }

        // POST: Admin/Home/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Sanpham sanpham)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    int check = db.Sanpham.Count(m => m.Tensp == sanpham.Tensp);
                    if (check > 0)
                    {
                        TempData["Thongbao"] = "Tên sản phẩm đã tồn tại";
                        return View();
                    }
                    else
                    {
                        if (sanpham.UploadAnh != null && sanpham.UploadAnh.ContentLength > 0 )
                        {
                            string fileName = Path.GetFileNameWithoutExtension(sanpham.UploadAnh.FileName);
                            string extension = Path.GetExtension(sanpham.UploadAnh.FileName);
                            fileName = fileName + extension;
                            sanpham.Anhbia = fileName;
                            sanpham.UploadAnh.SaveAs(Path.Combine(Server.MapPath("~/images/"), fileName));
                        }
                        db.Entry(sanpham).State = EntityState.Modified;
                        // Lưu lại
                        db.SaveChanges();
                        TempData["Thongbao"] = "Sửa sản phẩm thành công";
                        // Thành công chuyển đến trang index
                        return View();
                    }
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                TempData["Thongbao"] = "Chưa nhập đủ dữ liệu";
            }

            return View(sanpham);
        }
        // Xoá sản phẩm phương thức GET: Admin/Home/Delete/5
        

      [HttpDelete]
        public ActionResult Delete(int id)
        {

            var dao = new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
        //Để tạo dropdownList bên view
        void LoadData()
        {

            var hangselected = new SelectList(db.Hangsanxuat, "Mahang", "Tenhang");
            ViewBag.Mahang = hangselected;
            var hdhselected = new SelectList(db.Hedieuhanh, "Mahdh", "Tenhdh");
            ViewBag.Mahdh = hdhselected;
        }

    }
}