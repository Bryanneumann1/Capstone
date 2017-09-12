using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;
using Microsoft.AspNet.Identity;

namespace Capstone.Controllers
{
    public class SuccessfulHuntsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SuccessfulHunts
        public ActionResult Index()
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            var successfulHunts = db.SuccessfulHunts.Include(s => s.Stand);
            return View(successfulHunts.ToList());
        }

        public ActionResult ReadOnlyIndex()
        {
            var successfulHunts = db.SuccessfulHunts.Include(s => s.Stand);
            return View(successfulHunts.ToList());
        }

        // GET: SuccessfulHunts/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            //var successfulHunts = db.SuccessfulHunts.Include(s => s.Stand);
            //newCustomer.Stand = db.Stands.Where(x => x.ID == id).SingleOrDefault();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SuccessfulHunts successfulHunts = db.SuccessfulHunts.Include(s => s.Stand);
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
            ViewBag.LoggedUser = User.Identity.GetUserId();
            ViewBag.StandID = new SelectList(db.Stands, "ID", "Name");
           
            return View();
        }

        // POST: SuccessfulHunts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuccessfulHunts successfulHunts)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.SuccessfulHunts.Add(successfulHunts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StandID = new SelectList(db.Stands, "ID", "Name", successfulHunts.StandID);
            return View(successfulHunts);
        }

        // GET: SuccessfulHunts/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
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
            return View(successfulHunts);
        }

        // POST: SuccessfulHunts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StandID,Wind,Temperature,TimeID,Date,AnimalType,NumberOfAnimals,WeatherConditions,Description")] SuccessfulHunts successfulHunts)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Entry(successfulHunts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StandID = new SelectList(db.Stands, "ID", "Name", successfulHunts.StandID);
            return View(successfulHunts);
        }

        // GET: SuccessfulHunts/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
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
            ViewBag.LoggedUser = User.Identity.GetUserId();
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
