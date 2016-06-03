using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StreamOneInterface.Models;
using StreamOneInterface.Models.Entities;

namespace StreamOneInterface.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.ApplicationUser).Include(o => o.OrderStatus).Include(o => o.OrderType).Include(o => o.Reseller);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email");
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "Id", "Status");
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "Id", "Type");
            ViewBag.ResellerID = new SelectList(db.Resellers, "Id", "CustomerID");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,OrderStreamOneID,ListingID,ResellerID,OrderTypeID,TimeStamp,OrderStatusID,Date")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", order.UserID);
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "Id", "Status", order.OrderStatusID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "Id", "Type", order.OrderTypeID);
            ViewBag.ResellerID = new SelectList(db.Resellers, "Id", "CustomerID", order.ResellerID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", order.UserID);
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "Id", "Status", order.OrderStatusID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "Id", "Type", order.OrderTypeID);
            ViewBag.ResellerID = new SelectList(db.Resellers, "Id", "CustomerID", order.ResellerID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,OrderStreamOneID,ListingID,ResellerID,OrderTypeID,TimeStamp,OrderStatusID,Date")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", order.UserID);
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "Id", "Status", order.OrderStatusID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "Id", "Type", order.OrderTypeID);
            ViewBag.ResellerID = new SelectList(db.Resellers, "Id", "CustomerID", order.ResellerID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
