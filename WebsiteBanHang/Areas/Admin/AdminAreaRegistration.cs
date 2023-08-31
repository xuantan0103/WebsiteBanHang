﻿using System.Web.Mvc;

namespace WebsiteBanHang.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Delete_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home",action = "Delete", id = UrlParameter.Optional }
            );
        }
    }
}