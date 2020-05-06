using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Geo.Models;

namespace Geo.Controllers
{
    public class FloorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Floors
        public ActionResult Index()
        {
            var floors = db.Floors.Include(f => f.Building);
            return View(floors.ToList());
        }

        // GET: Floors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floor floor = db.Floors.Find(id);
            if (floor == null)
            {
                return HttpNotFound();
            }
            return View(floor);
        }

        // GET: Floors/Create
        public ActionResult Create()
        {
            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Nameof");
            return View();
        }

        //public void AddFloor(Floor floor)
        //{
        //    if (floor == null) return;
        //    db.Floors.Add(floor);
        //    db.SaveChanges();
        //}
        // POST: Floors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Level,BuildingId")] Floor floor)
        {
            if (ModelState.IsValid)
            {
                db.Floors.Add(floor);
                db.Floors.ToList().Count();
                var xxx = db.Buildings.FirstOrDefault(x => x.Id == floor.BuildingId);
                //db.Buildings.Find(floor.BuildingId).Floors.Add(floor);//.Add(floor);
                //var obj = db.Buildings.FirstOrDefault(x => x.Id == floor.BuildingId);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Nameof", floor.BuildingId);
            return View(floor);
        }

        // GET: Floors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floor floor = db.Floors.Find(id);
            if (floor == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Nameof", floor.BuildingId);
            return View(floor);
        }

        // POST: Floors/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Level,BuildingId")] Floor floor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(floor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuildingId = new SelectList(db.Buildings, "Id", "Nameof", floor.BuildingId);
            return View(floor);
        }

        // GET: Floors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floor floor = db.Floors.Find(id);
            if (floor == null)
            {
                return HttpNotFound();
            }
            return View(floor);
        }

        // POST: Floors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Floor floor = db.Floors.Find(id);
            db.Floors.Remove(floor);
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
