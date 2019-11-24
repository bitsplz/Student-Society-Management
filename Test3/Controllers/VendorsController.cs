using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Test3.Models;
namespace Test3.Views
{
    public class VendorsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Vendors
        public ActionResult Index()
        {
            return View(db.Vendors.ToList());
        }

        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendors vendors = db.Vendors.Find(id);
            if (vendors == null)
            {
                return HttpNotFound();
            }
            return View(vendors);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorID,name,email,contactNumber")] Vendors vendors)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendors);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendors vendors = db.Vendors.Find(id);
            if (vendors == null)
            {
                return HttpNotFound();
            }
            return View(vendors);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorID,name,email,contactNumber")] Vendors vendors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendors);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendors vendors = db.Vendors.Find(id);
            if (vendors == null)
            {
                return HttpNotFound();
            }
            return View(vendors);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendors vendors = db.Vendors.Find(id);
            db.Vendors.Remove(vendors);
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
