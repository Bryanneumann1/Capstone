﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;
using GoogleMaps.LocationServices;
using Microsoft.AspNet.Identity;

namespace Capstone.Controllers
{
    public class StandsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stands
        public ActionResult Index()
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            return View(db.Stands.ToList());
        }
        public ActionResult IndexReadOnly(Stand stand)
        {

            ViewBag.LoggedUser = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                RedirectToAction("Create", "Customer", stand);
            }
            stand = ViewBag.stand;
            return View(db.Stands.ToList());

        }
        // GET: Stands/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stand stand = db.Stands.Find(id);
            if (stand == null)
            {
                return HttpNotFound();
            }
            return View(stand);
        }

        // GET: Stands/Create
        public ActionResult Create()

        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            return View();
        }

        // POST: Stands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Stand stand)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Stands.Add(stand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stand);
        }

        // GET: Stands/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stand stand = db.Stands.Find(id);
            if (stand == null)
            {
                return HttpNotFound();
            }
            return View(stand);
        }

        // POST: Stands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Stand stand)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Entry(stand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stand);
        }

        // GET: Stands/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stand stand = db.Stands.Find(id);
            if (stand == null)
            {
                return HttpNotFound();
            }
            return View(stand);
        }

        // POST: Stands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            Stand stand = db.Stands.Find(id);
            db.Stands.Remove(stand);
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
