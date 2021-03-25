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
    public class AlwaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Always
        public ActionResult Index()
        {
            return View(db.Always.ToList());
        }

        // GET: Always/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Always always = db.Always.Find(id);
            if (always == null)
            {
                return HttpNotFound();
            }
            return View(always);
        }

        // GET: Always/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Always/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ContinuityName")] Always always)
        {
            if (ModelState.IsValid)
            {
                db.Always.Add(always);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(always);
        }

        // GET: Always/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Always always = db.Always.Find(id);
            if (always == null)
            {
                return HttpNotFound();
            }
            return View(always);
        }

        // POST: Always/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ContinuityName")] Always always)
        {
            if (ModelState.IsValid)
            {
                db.Entry(always).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(always);
        }

        // GET: Always/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Always always = db.Always.Find(id);
            if (always == null)
            {
                return HttpNotFound();
            }
            return View(always);
        }

        // POST: Always/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Always always = db.Always.Find(id);
            db.Always.Remove(always);
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
