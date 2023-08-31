using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class ProductController : Controller
    {
        QLdienthoai db = new QLdienthoai();

        // GET: Product
        public ActionResult Detail(int Masp)
        {
            var objSanpham = db.Sanpham.Where(n => n.Masp == Masp).FirstOrDefault();
            return View(objSanpham);
        }
    }
}