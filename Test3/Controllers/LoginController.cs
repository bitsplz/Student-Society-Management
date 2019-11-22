using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Test3.Models;

namespace Test3.Controllers
{
    public class LoginController : Controller
    {
        private Model1Container db = new Model1Container();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Login/Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "User_Name,User_Pass")] User u, string ReturnUrl = "")
        {

            var v = db.Users.Where(model => model.User_Name.Equals(u.User_Name) && model.User_Pass.Equals(u.User_Pass)).FirstOrDefault();

            if (v != null)
            {
                FormsAuthentication.SetAuthCookie(u.User_Name, false);
                if (ReturnUrl != "")
                    return Redirect(ReturnUrl);
                else
                    return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return View(u);
            }
        }
    }
}