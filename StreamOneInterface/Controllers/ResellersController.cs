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
    public class ResellersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resellers
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_name" : "";
            ViewBag.CompanySortParm = sortOrder == "company" ? "company_desc" : "company";
            ViewBag.LastnameSortParm = String.IsNullOrEmpty(sortOrder) ? "last_name" : "";
            ViewBag.LastnamedescSortParm = String.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";


            var resellers = from r in db.Resellers
                           select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                resellers = resellers.Where(r => r.Company.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_name":
                    resellers = resellers.OrderBy(r => r.Firstname);
                    break;
                case "first_name_desc":
                    resellers = resellers.OrderByDescending(r => r.Firstname);
                    break;
                case "last_name":
                    resellers = resellers.OrderBy(r => r.Lastname);
                    break;
                case "last_name_desc":
                    resellers = resellers.OrderByDescending(r => r.Lastname);
                    break;
                case "company":
                    resellers = resellers.OrderBy(r => r.Lastname);
                    break;
                case "company_desc":
                    resellers = resellers.OrderByDescending(r => r.Lastname);
                    break;
                default:
                    resellers = resellers.OrderBy(s => s.CustomerID);
                    break;
            }
            //db.Resellers = resellers.ToList();
            return View(resellers.ToList());
        }

        // GET: Resellers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reseller reseller = db.Resellers.Find(id);
            if (reseller == null)
            {
                return HttpNotFound();
            }
            return View(reseller);
        }

        // GET: Resellers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerID,Firstname,Lastname,Address1,Address2,City,Company,Website,Email,Country,Phone,State,Zip")] Reseller reseller)
        {
            if (ModelState.IsValid)
            {
                db.Resellers.Add(reseller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reseller);
        }

        // GET: Resellers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reseller reseller = db.Resellers.Find(id);
            if (reseller == null)
            {
                return HttpNotFound();
            }
            return View(reseller);
        }

        // POST: Resellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerID,Firstname,Lastname,Address1,Address2,City,Company,Website,Email,Country,Phone,State,Zip")] Reseller reseller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reseller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reseller);
        }

        // GET: Resellers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reseller reseller = db.Resellers.Find(id);
            if (reseller == null)
            {
                return HttpNotFound();
            }
            return View(reseller);
        }

        // POST: Resellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reseller reseller = db.Resellers.Find(id);
            db.Resellers.Remove(reseller);
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
