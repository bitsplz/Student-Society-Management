﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Test3.Models;

namespace Test3.Controllers
{
    public class UsersController : Controller
    {
        private Model1Container db = new Model1Container();
        private int? s;
        public ActionResult PatronHome()
        {
            return View();
        }
        public ActionResult AfterLogin()
        {
            return View();
        }
        // GET: Users
        public ActionResult Index()
        {
            s = ((User)Session["CurrentUser"]).Society_ID;
            RolePrincipal roles = (RolePrincipal)User;
            String[] role = roles.GetRoles();

            var users = db.Users.Include(u => u.User_Type).Include(u => u.Society);
            if (role[0].Equals("patron"))
            {
                users = db.Users.Where(u => u.User_Type.Type_Name.Equals("ob"))
                                .Where(u => u.Society.Society_ID == s);/*.Where(u => u.Society.Society_ID == 1)*/;
            }

            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            s = ((User)Session["CurrentUser"]).Society_ID;
            RolePrincipal roles = (RolePrincipal)User;
            String[] role = roles.GetRoles();

            if (role[0].Equals("patron"))
            {
                ViewBag.Type_ID = new SelectList(db.User_Type.Where(x=>x.Type_Name.Equals("ob")), "Type_ID", "Type_Name");
                ViewBag.Society_ID = new SelectList(db.Societies.Where(x=>x.Society_ID==s), "Society_ID", "Society_Name");
            }
            else
            {
                ViewBag.Type_ID = new SelectList(db.User_Type, "Type_ID", "Type_Name");
                ViewBag.Society_ID = new SelectList(db.Societies, "Society_ID", "Society_Name");
            }
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,User_Name,User_Pass,Type_ID,Society_ID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type_ID = new SelectList(db.User_Type, "Type_ID", "Type_Name", user.Type_ID);
            ViewBag.Society_ID = new SelectList(db.Societies, "Society_ID", "Society_Name", user.Society_ID);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type_ID = new SelectList(db.User_Type, "Type_ID", "Type_Name", user.Type_ID);
            ViewBag.Society_ID = new SelectList(db.Societies, "Society_ID", "Society_Name", user.Society_ID);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,User_Name,User_Pass,Type_ID,Society_ID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type_ID = new SelectList(db.User_Type, "Type_ID", "Type_Name", user.Type_ID);
            ViewBag.Society_ID = new SelectList(db.Societies, "Society_ID", "Society_Name", user.Society_ID);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
