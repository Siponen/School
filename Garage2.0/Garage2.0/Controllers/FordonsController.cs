using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2._0.Models;
using Garage2._0.DataAccessLayer;

namespace Garage2._0.Controllers
{
    public class FordonsController : Controller
    {
        private FordonsContext db = new FordonsContext();

        // GET: Fordons
        public ActionResult Index(int? id)
        {
            ViewBag.CheckedinFordonId = id;
            return View(db.Fordons.ToList());
        }

        public ActionResult GarageVehiclesList()
        {
            IQueryable<Fordon> fordons = db.Fordons
                .OrderByDescending(m => m.IncheckDatum);
            /*
            if (type != FordonsTyp.All)
            {
                fordons = fordons.Where(m => m.Typ == (FordonsTyp)type);
            }
            */
            return View(fordons);
        }

        public ActionResult Checkin()
        {
            return View();
        }

        public ActionResult Checkincomplete()
        {
            return View();
        }

        // POST: Fordons/Checkin
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkin([Bind(Include = "Id,Typ,RegNr,Färg,AntalHjul,Märke,Modell")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                fordon.IncheckDatum = DateTime.Now;
                db.Fordons.Add(fordon);
                db.SaveChanges();
                return RedirectToAction("CheckinConfirmed",fordon);
            }

            return View(fordon);
        }

        public ActionResult CheckinConfirmed(Fordon fordon)
        {
            return View(fordon);
        }

        public ActionResult Checkout(string RegNr, int? id)
        {
            var fordons = db.Fordons.Where(f => f.RegNr == RegNr).ToList();
            if (fordons != null && fordons.Count > 0)
            {
                return View(fordons[0]);
            }

            return View();
        }

        [HttpPost, ActionName("Receipt")]
        [ValidateAntiForgeryToken]
        public ActionResult Receipt(int id)
        {
            Fordon leavingFordon = db.Fordons.Find(id);
            Receipt receipt = new Receipt(
                leavingFordon.RegNr,
                leavingFordon.IncheckDatum,
                DateTime.Now);

            db.Fordons.Remove(leavingFordon);
            db.SaveChanges();
            return View(receipt);
        }

        public ActionResult Statistics()
        {
            return View(db.Fordons.ToList());
        }

        // GET: Fordons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordons.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // GET: Fordons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fordons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Typ,RegNr,Färg,AntalHjul,Märke,Modell")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Fordons.Add(fordon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fordon);
        }

        // GET: Fordons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordons.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // POST: Fordons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Typ,RegNr,Färg,AntalHjul,Märke,Modell")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fordon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fordon);
        }

        // GET: Fordons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordons.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // POST: Fordons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fordon fordon = db.Fordons.Find(id);
            db.Fordons.Remove(fordon);
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
