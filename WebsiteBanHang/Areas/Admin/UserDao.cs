using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin
{
    public class UserDao
    {
        QLdienthoai db = new QLdienthoai();
        public bool Delete(int id)
        {
            try
            {
                var dt = db.Sanpham.Find(id);
                db.Sanpham.Remove(dt);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}