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
    public class EventsController : Controller
    {
        private Model1Container db = new Model1Container();
        private int? s;
        // GET: Events
        public ActionResult Index()
        {
            s = ((User)Session["CurrentUser"]).Society_ID;
            var events = db.Events.Where(a => a.Society.Society_ID == s);

            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            s = ((User)Session["CurrentUser"]).Society_ID;
            ViewBag.Society_ID = new SelectList(db.Societies.Where(a => a.Society_ID == s), "Society_ID", "Society_Name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Event_ID,Event_name,Society_ID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            s = ((User)Session["CurrentUser"]).Society_ID;
            ViewBag.Society_ID = new SelectList(db.Societies.Where(a => a.Society_ID == s), "Society_ID", "Society_Name", @event.Society_ID);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            s = ((User)Session["CurrentUser"]).Society_ID;
            ViewBag.Society_ID = new SelectList(db.Societies.Where(a => a.Society_ID == s), "Society_ID", "Society_Name", @event.Society_ID);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Event_ID,Event_name,Society_ID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            s = ((User)Session["CurrentUser"]).Society_ID;
            ViewBag.Society_ID = new SelectList(db.Societies.Where(a => a.Society_ID == s), "Society_ID", "Society_Name", @event.Society_ID);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
        public ActionResult Approve()
        {
            s = ((User)Session["CurrentUser"]).Society_ID;
            var events = db.Events.Where(a => a.Society.Society_ID == s);

            return View(events.ToList());
        }
    }
}
