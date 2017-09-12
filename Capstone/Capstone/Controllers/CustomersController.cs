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
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            var customers = db.Customers.Include(c => c.Stand);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {

            ViewBag.LoggedUser = User.Identity.GetUserId();
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = db.Customers.Include(m => m.Stand).SingleOrDefault(m => m.ID == id);
            //Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            ViewBag.StandID = new SelectList(db.Stands, "ID", "Name");
            Customer customer = new Customer();
            
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, Customer customer)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            Customer newCustomer = new Customer()
            {
                
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                StandID = id,
                Coupon = customer.Coupon,
                Phone = customer.Phone,
                Date = customer.Date,
                 
                
            };
            newCustomer.Stand = db.Stands.Where(x => x.ID == id).SingleOrDefault();
            if (newCustomer.Coupon == "save10")
            {
                newCustomer.FinalPrice = newCustomer.Stand.Price - (newCustomer.Stand.Price * .1m);
            }
            else if (newCustomer.Coupon == null)
            {
                newCustomer.Stand.Price = newCustomer.Stand.Price;
            }
            db.Customers.Add(newCustomer);
            db.SaveChanges();
            return View("Payment");
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.StandID = new SelectList(db.Stands, "ID", "Name", customer.StandID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StandID = new SelectList(db.Stands, "ID", "Name", customer.StandID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.LoggedUser = User.Identity.GetUserId();
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
