using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class SuccessfulHuntsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SuccessfulHunts
        public ActionResult Index()
        {
            var successfulHunts = db.SuccessfulHunts.Include(s => s.Stand).Include(s => s.Time);
            return View(successfulHunts.ToList());
        }

        // GET: SuccessfulHunts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuccessfulHunts successfulHunts = db.SuccessfulHunts.Find(id);
            if (successfulHunts == null)
            {
                return HttpNotFound();
            }
            return View(successfulHunts);
        }

        // GET: SuccessfulHunts/Create
        public ActionResult Create()
        {
            ViewBag.StandID = new SelectList(db.Stands, "ID", "Name");
            ViewBag.TimeID = new SelectList(db.Times, "ID", "Name");
            return View();
        }

        // POST: SuccessfulHunts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StandID,Wind,Temperature,TimeID,Date,AnimalType,NumberOfAnimals,WeatherConditions,Description")] SuccessfulHunts successfulHunts)
        {
            if (ModelState.IsValid)
            {
                db.SuccessfulHunts.Add(successfulHunts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StandID = new SelectList(db.Stands, "ID", "Name", successfulHunts.StandID);
            ViewBag.TimeID = new SelectList(db.Times, "ID", "Name", successfulHunts.TimeID);
            return View(successfulHunts);
        }

        // GET: SuccessfulHunts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuccessfulHunts successfulHunts = db.SuccessfulHunts.Find(id);
            if (successfulHunts == null)
            {
                return HttpNotFound();
            }
            ViewBag.StandID = new SelectList(db.Stands, "ID", "Name", successfulHunts.StandID);
            ViewBag.TimeID = new SelectList(db.Times, "ID", "Name", successfulHunts.TimeID);
            return View(successfulHunts);
        }

        // POST: SuccessfulHunts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StandID,Wind,Temperature,TimeID,Date,AnimalType,NumberOfAnimals,WeatherConditions,Description")] SuccessfulHunts successfulHunts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(successfulHunts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StandID = new SelectList(db.Stands, "ID", "Name", successfulHunts.StandID);
            ViewBag.TimeID = new SelectList(db.Times, "ID", "Name", successfulHunts.TimeID);
            return View(successfulHunts);
        }

        // GET: SuccessfulHunts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuccessfulHunts successfulHunts = db.SuccessfulHunts.Find(id);
            if (successfulHunts == null)
            {
                return HttpNotFound();
            }
            return View(successfulHunts);
        }

        // POST: SuccessfulHunts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuccessfulHunts successfulHunts = db.SuccessfulHunts.Find(id);
            db.SuccessfulHunts.Remove(successfulHunts);
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
