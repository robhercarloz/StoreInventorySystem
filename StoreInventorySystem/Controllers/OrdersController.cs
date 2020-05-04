using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreInventorySystem.Models;

namespace StoreInventorySystem.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.OrderOwner).Include(o => o.OrderPriority).Include(o => o.OrderStatus).Include(o => o.Product);
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
            ViewBag.OrderOwnerId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.OrderPriorityId = new SelectList(db.OrderPriorities, "Id", "PriorityName");
            ViewBag.OrderStatusId = new SelectList(db.OrderStatus, "Id", "OrderStatusName");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,OrderPriorityId,OrderStatusId,OrderOwnerId,OrderName,OrderDescription,OrderQuantity,OrderCreated,OrderDue")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderOwnerId = new SelectList(db.Users, "Id", "FirstName", order.OrderOwnerId);
            ViewBag.OrderPriorityId = new SelectList(db.OrderPriorities, "Id", "PriorityName", order.OrderPriorityId);
            ViewBag.OrderStatusId = new SelectList(db.OrderStatus, "Id", "OrderStatusName", order.OrderStatusId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", order.ProductId);
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
            ViewBag.OrderOwnerId = new SelectList(db.Users, "Id", "FirstName", order.OrderOwnerId);
            ViewBag.OrderPriorityId = new SelectList(db.OrderPriorities, "Id", "PriorityName", order.OrderPriorityId);
            ViewBag.OrderStatusId = new SelectList(db.OrderStatus, "Id", "OrderStatusName", order.OrderStatusId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", order.ProductId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,OrderPriorityId,OrderStatusId,OrderOwnerId,OrderName,OrderDescription,OrderQuantity,OrderCreated,OrderDue")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderOwnerId = new SelectList(db.Users, "Id", "FirstName", order.OrderOwnerId);
            ViewBag.OrderPriorityId = new SelectList(db.OrderPriorities, "Id", "PriorityName", order.OrderPriorityId);
            ViewBag.OrderStatusId = new SelectList(db.OrderStatus, "Id", "OrderStatusName", order.OrderStatusId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", order.ProductId);
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
