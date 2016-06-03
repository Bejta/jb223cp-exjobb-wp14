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
    public class OrderRowStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderRowStatus
        public ActionResult Index()
        {
            return View(db.OrderRowStatus.ToList());
        }

        // GET: OrderRowStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRowStatus orderRowStatus = db.OrderRowStatus.Find(id);
            if (orderRowStatus == null)
            {
                return HttpNotFound();
            }
            return View(orderRowStatus);
        }

        // GET: OrderRowStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderRowStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RowStatus")] OrderRowStatus orderRowStatus)
        {
            if (ModelState.IsValid)
            {
                db.OrderRowStatus.Add(orderRowStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderRowStatus);
        }

        // GET: OrderRowStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRowStatus orderRowStatus = db.OrderRowStatus.Find(id);
            if (orderRowStatus == null)
            {
                return HttpNotFound();
            }
            return View(orderRowStatus);
        }

        // POST: OrderRowStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RowStatus")] OrderRowStatus orderRowStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderRowStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderRowStatus);
        }

        // GET: OrderRowStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRowStatus orderRowStatus = db.OrderRowStatus.Find(id);
            if (orderRowStatus == null)
            {
                return HttpNotFound();
            }
            return View(orderRowStatus);
        }

        // POST: OrderRowStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderRowStatus orderRowStatus = db.OrderRowStatus.Find(id);
            db.OrderRowStatus.Remove(orderRowStatus);
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
