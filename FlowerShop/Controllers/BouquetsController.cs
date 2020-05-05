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
    public class BouquetsController : Controller
    {
        private myflowershopEntities db = new myflowershopEntities();

        // GET: Bouquets
        public ActionResult Index()
        {
            return View(db.Bouquets.ToList());
        }

        // GET: Bouquets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet bouquet = db.Bouquets.Find(id);
            if (bouquet == null)
            {
                return HttpNotFound();
            }
            return View(bouquet);
        }

        // GET: Bouquets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bouquets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BouquetID,BouquetName,Description,Price")] Bouquet bouquet)
        {
            if (ModelState.IsValid)
            {
                db.Bouquets.Add(bouquet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bouquet);
        }

        // GET: Bouquets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet bouquet = db.Bouquets.Find(id);
            if (bouquet == null)
            {
                return HttpNotFound();
            }
            return View(bouquet);
        }

        // POST: Bouquets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BouquetID,BouquetName,Description,Price")] Bouquet bouquet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bouquet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bouquet);
        }

        // GET: Bouquets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet bouquet = db.Bouquets.Find(id);
            if (bouquet == null)
            {
                return HttpNotFound();
            }
            return View(bouquet);
        }

        // POST: Bouquets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bouquet bouquet = db.Bouquets.Find(id);
            db.Bouquets.Remove(bouquet);
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
