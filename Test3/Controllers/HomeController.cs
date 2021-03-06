﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Test3.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [CustomAuth(Roles ="admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Index()
        {
            RolePrincipal r = (RolePrincipal)User;
            String[] a = r.GetRoles();
            switch (a[0])
            {
                case "ob": return RedirectToAction("AfterLogin", "Users"); break;
                case "patron": return RedirectToAction("PatronHome", "Users"); break;
            }
            ViewBag.Message = "Home Page ";
            ViewData["uname"] = User.Identity.Name;
            
            return View();
        }
        
    }
}