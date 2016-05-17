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
using StreamOneInterface.ViewModels;

namespace StreamOneInterface.Controllers
{
    public class ReceivedOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReceivedOrders
        public ActionResult Index(int? id, int? orderrowID)
        {

            var viewModel = new ReceivedOrdersViewModel();

            viewModel.Orders = db.Orders
                .Include(o => o.ApplicationUser)
                .Include(i => i.OrderStatus)
                .Include(i => i.Reseller)
                .Include(i=> i.OrderType)
                .Include(i => i.OrderRows.Select(c => c.Product))
                .OrderBy(i => i.Date);

            if (id != null)
            {
                ViewBag.Id = id.Value;
                viewModel.OrderRows = viewModel.Orders.Where(
                    i => i.Id == id.Value).Single().OrderRows;
            }

            //if (orderrowID != null)
            //{
            //    ViewBag.Id = orderrowID.Value;
            //    viewModel.Products = viewModel.OrderRows.Where(
            //        x => x.Id == orderrowID).Single().Products;
            //}


           // var orders = db.Orders.Include(o => o.ApplicationUser).Include(o => o.OrderStatus).Include(o => o.OrderType).Include(o => o.Reseller);
           // return View(orders.ToList());
           return View(viewModel);
        }

        // GET: ReceivedOrders/Details/5
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

        // GET: ReceivedOrders/Create
        public ActionResult Create()
        {
          // ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email");
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "Id", "Status");
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "Id", "Type");
            ViewBag.ResellerID = new SelectList(db.Resellers, "Id", "CustomerID");
            return View();
        }

        // POST: ReceivedOrders/Create
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

           // ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", order.UserID);
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "Id", "Status", order.OrderStatusID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "Id", "Type", order.OrderTypeID);
            ViewBag.ResellerID = new SelectList(db.Resellers, "Id", "CustomerID", order.ResellerID);
            return View(order);
        }

        // GET: ReceivedOrders/Edit/5
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
           // ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", order.UserID);
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "Id", "Status", order.OrderStatusID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "Id", "Type", order.OrderTypeID);
            ViewBag.ResellerID = new SelectList(db.Resellers, "Id", "CustomerID", order.ResellerID);
            return View(order);
        }

        // POST: ReceivedOrders/Edit/5
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
           // ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", order.UserID);
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "Id", "Status", order.OrderStatusID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "Id", "Type", order.OrderTypeID);
            ViewBag.ResellerID = new SelectList(db.Resellers, "Id", "CustomerID", order.ResellerID);
            return View(order);
        }

        // GET: ReceivedOrders/Delete/5
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

        // POST: ReceivedOrders/Delete/5
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
