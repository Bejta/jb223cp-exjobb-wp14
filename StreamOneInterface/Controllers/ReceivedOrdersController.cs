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
using PagedList;

namespace StreamOneInterface.Controllers
{
    public class ReceivedOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReceivedOrders
        public ActionResult Index(int? id, int? orderrowID, int? OrderPage, string currentFilter, string sortOrder, string searchString, int? page)
        {
            /*
             * ViewBag property provides the view with the current sort order, 
             * because this must be included in the paging links 
             * in order to keep the sort order the same while paging:
             * */
            ViewBag.CurrentSort = sortOrder;

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            int orderPageNumber = (OrderPage ?? 1);

            ViewBag.StatusSortParm = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            ViewBag.StatusDescParm = String.IsNullOrEmpty(sortOrder) ? "status" : "";
            ViewBag.CompanySortParm = sortOrder == "company" ? "company" : "company";
            ViewBag.CompanyDescSortParm = sortOrder == "company" ? "company_desc" : "company";
            ViewBag.StreamOneSortParm = String.IsNullOrEmpty(sortOrder) ? "streamone" : "";
            ViewBag.StreamOneDescSortParm = String.IsNullOrEmpty(sortOrder) ? "streamone_desc" : "";
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date" : "";
            ViewBag.DateDescSortParm = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var viewModel = new ReceivedOrdersViewModel();

            viewModel.Orders = db.Orders
                .Include(o => o.ApplicationUser)
                .Include(i => i.OrderStatus)
                .Include(i => i.Reseller)
                .Include(i=> i.OrderType)
                .Include(i => i.OrderRows.Select(c => c.Product))
                .OrderBy(i => i.Date) ;

            

            if (!String.IsNullOrEmpty(searchString))
            {
                viewModel.Orders = viewModel.Orders.Where(o => o.OrderStreamOneID.Contains(searchString)
                                                        || o.OrderStatus.Status.Contains(searchString)
                                                        || o.Reseller.Company.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "status":
                    viewModel.Orders = viewModel.Orders.OrderBy(r => r.OrderStatus.Status).ToPagedList(pageNumber, pageSize);
                    break;
                case "status_desc":
                    viewModel.Orders = viewModel.Orders.OrderByDescending(r => r.OrderStatus.Status).ToPagedList(pageNumber, pageSize);
                    break;
                case "streamone":
                    viewModel.Orders = viewModel.Orders.OrderBy(r => r.OrderStreamOneID).ToPagedList(pageNumber, pageSize);
                    break;
                case "streamone_desc":
                    viewModel.Orders = viewModel.Orders.OrderByDescending(r => r.OrderStreamOneID).ToPagedList(pageNumber, pageSize);
                    break;
                case "company":
                    viewModel.Orders = viewModel.Orders.OrderBy(r => r.Reseller.Company).ToPagedList(pageNumber, pageSize);
                    break;
                case "company_desc":
                    viewModel.Orders = viewModel.Orders.OrderByDescending(r => r.Reseller.Company).ToPagedList(pageNumber, pageSize);
                    break;
                case "date":
                    viewModel.Orders = viewModel.Orders.OrderBy(r => r.Date).ToPagedList(pageNumber, pageSize);
                    break;
                case "date_desc":
                    viewModel.Orders = viewModel.Orders.OrderByDescending(r => r.Date).ToPagedList(pageNumber, pageSize);
                    break;
                default:
                    viewModel.Orders = viewModel.Orders.OrderByDescending(s => s.Id).ToPagedList(pageNumber, pageSize);
                    break;
            }

            if (id != null)
            {
                ViewBag.Id = id.Value;
                viewModel.OrderRows = viewModel.Orders.Where(
                    i => i.Id == id.Value).Single().OrderRows;
            }

           
            viewModel.Orders.ToPagedList(pageNumber, pageSize);

            //Use the following two formulas so that it doesn't round down on the returned integer
            decimal totalPages = ((decimal)(viewModel.Orders.Count() / (decimal)pageSize));
            ViewBag.TotalPages = Math.Ceiling(totalPages);

            ViewBag.OnePageofOrders = viewModel.Orders;
            ViewBag.PageNumber = pageNumber;
            
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
