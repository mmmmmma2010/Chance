using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Give_Pro.Models;
using WebApplication1.Models;

namespace Give_Pro.Controllers
{
    public class GovernoratesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Governorates
        public ActionResult Index()
        {
            var governorates = db.Governorates.Include(g => g.Countries);
            return View(governorates.ToList());
        }

        // GET: Governorates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governorates governorates = db.Governorates.Find(id);
            if (governorates == null)
            {
                return HttpNotFound();
            }
            return View(governorates);
        }

        // GET: Governorates/Create
        public ActionResult Create()
        {
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName");
            return View();
        }

        // POST: Governorates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GovernoratesName,CountriesID")] Governorates governorates)
        {
            if (ModelState.IsValid)
            {
                db.Governorates.Add(governorates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", governorates.CountriesID);
            return View(governorates);
        }

        // GET: Governorates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governorates governorates = db.Governorates.Find(id);
            if (governorates == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", governorates.CountriesID);
            return View(governorates);
        }

        // POST: Governorates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GovernoratesName,CountriesID")] Governorates governorates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(governorates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", governorates.CountriesID);
            return View(governorates);
        }

        // GET: Governorates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governorates governorates = db.Governorates.Find(id);
            if (governorates == null)
            {
                return HttpNotFound();
            }
            return View(governorates);
        }

        // POST: Governorates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Governorates governorates = db.Governorates.Find(id);
            db.Governorates.Remove(governorates);
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
