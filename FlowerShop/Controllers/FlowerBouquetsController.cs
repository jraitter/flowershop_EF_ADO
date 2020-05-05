using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlowerShop.Models;

namespace FlowerShop.Controllers
{
    public class FlowerBouquetsController : Controller
    {
        private myflowershopEntities db = new myflowershopEntities();

        // GET: FlowerBouquets
        public ActionResult Index()
        {
            var flowerBouquets = db.FlowerBouquets.Include(f => f.Bouquet).Include(f => f.Flower);
            return View(flowerBouquets.ToList());
        }

        // GET: FlowerBouquets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerBouquet flowerBouquet = db.FlowerBouquets.Find(id);
            if (flowerBouquet == null)
            {
                return HttpNotFound();
            }
            return View(flowerBouquet);
        }

        // GET: FlowerBouquets/Create
        public ActionResult Create()
        {
            ViewBag.BouquetID = new SelectList(db.Bouquets, "BouquetID", "BouquetName");
            ViewBag.FlowerID = new SelectList(db.Flowers, "FlowerID", "FlowerName");
            return View();
        }

        // POST: FlowerBouquets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlowerBouquetID,BouquetID,FlowerID,Quantity")] FlowerBouquet flowerBouquet)
        {
            if (ModelState.IsValid)
            {
                db.FlowerBouquets.Add(flowerBouquet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BouquetID = new SelectList(db.Bouquets, "BouquetID", "BouquetName", flowerBouquet.BouquetID);
            ViewBag.FlowerID = new SelectList(db.Flowers, "FlowerID", "FlowerName", flowerBouquet.FlowerID);
            return View(flowerBouquet);
        }

        // GET: FlowerBouquets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerBouquet flowerBouquet = db.FlowerBouquets.Find(id);
            if (flowerBouquet == null)
            {
                return HttpNotFound();
            }
            ViewBag.BouquetID = new SelectList(db.Bouquets, "BouquetID", "BouquetName", flowerBouquet.BouquetID);
            ViewBag.FlowerID = new SelectList(db.Flowers, "FlowerID", "FlowerName", flowerBouquet.FlowerID);
            return View(flowerBouquet);
        }

        // POST: FlowerBouquets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlowerBouquetID,BouquetID,FlowerID,Quantity")] FlowerBouquet flowerBouquet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flowerBouquet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BouquetID = new SelectList(db.Bouquets, "BouquetID", "BouquetName", flowerBouquet.BouquetID);
            ViewBag.FlowerID = new SelectList(db.Flowers, "FlowerID", "FlowerName", flowerBouquet.FlowerID);
            return View(flowerBouquet);
        }

        // GET: FlowerBouquets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerBouquet flowerBouquet = db.FlowerBouquets.Find(id);
            if (flowerBouquet == null)
            {
                return HttpNotFound();
            }
            return View(flowerBouquet);
        }

        // POST: FlowerBouquets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlowerBouquet flowerBouquet = db.FlowerBouquets.Find(id);
            db.FlowerBouquets.Remove(flowerBouquet);
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
