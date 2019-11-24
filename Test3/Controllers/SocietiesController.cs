using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test3.Models;

namespace Test3.Views
{
    public class SocietiesController : Controller
    {
        private Model1Container db = new Model1Container();


        
        // GET: Societies
        public ActionResult Index()
        {
            return View(db.Societies.ToList());
        }

        // GET: Societies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Society society = db.Societies.Find(id);
            if (society == null)
            {
                return HttpNotFound();
            }
            return View(society);
        }

        // GET: Societies/Create
        public ActionResult Create()
        {
            int typeid = db.User_Type.Where(x => x.Type_Name == "patron").FirstOrDefault().Type_ID;
            ViewBag.Patron_Name =
                new SelectList(db.Users.Where(x=>x.Type_ID == typeid), "User_Name", "User_Name");
            return View();
        }

        // POST: Societies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Society_ID,Society_Name,Patron_Name")] Society society)
        {
            if (ModelState.IsValid)
            {
                db.Societies.Add(society);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            int typeid = db.User_Type.Where(x => x.Type_Name == "patron").FirstOrDefault().Type_ID;
            ViewBag.Patron_Name =
                new SelectList(db.Users, "User_ID", "User_Name");
            return View(society);
        }

        // GET: Societies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Society society = db.Societies.Find(id);
            if (society == null)
            {
                return HttpNotFound();
            }
            return View(society);
        }

        // POST: Societies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Society_ID,Society_Name,Patron_Name")] Society society)
        {
            if (ModelState.IsValid)
            {
                db.Entry(society).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(society);
        }

        // GET: Societies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Society society = db.Societies.Find(id);
            if (society == null)
            {
                return HttpNotFound();
            }
            return View(society);
        }

        // POST: Societies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Society society = db.Societies.Find(id);
            db.Societies.Remove(society);
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
