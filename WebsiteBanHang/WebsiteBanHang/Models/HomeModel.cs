using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Models
{
    public class HomeModel
    {
        public List<Sanpham> ListSanpham { get; set; }
        public List<Hangsanxuat> ListHangsanxuat { get; set; }

    }
}