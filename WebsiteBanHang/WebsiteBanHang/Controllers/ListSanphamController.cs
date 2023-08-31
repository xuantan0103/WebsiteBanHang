using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
  

    public class ListSanphamController : Controller
    {
        QLdienthoai db = new QLdienthoai();
        // GET: ListSanpham
        public ActionResult Index(int Mahang)
        {

            var listSanpham = db.Sanpham.Where(n => n.Mahang == Mahang).ToList();
            return View(listSanpham);
        }

        [HttpGet]
        public ActionResult Index(string CurrenFiler, int? page, string search, int Mahang)
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
            sanpham = db.Sanpham.Where(n => n.Mahang == Mahang).ToList();
            return View(sanpham.ToPagedList(pageNumber, pageSize));
        }

    }
}