using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using API.Models;

namespace API.Controllers
{
    public class APPLICATIONsController : Controller
    {
        private Entities db = new Entities();

        // GET: APPLICATIONs
        public ActionResult Index()
        {
            var aPPLICATIONs = db.APPLICATIONs.Include(a => a.JOB).Include(a => a.STUDENT);
            return View(aPPLICATIONs.ToList());
        }

        // GET: APPLICATIONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPLICATION aPPLICATION = db.APPLICATIONs.Find(id);
            if (aPPLICATION == null)
            {
                return HttpNotFound();
            }
            return View(aPPLICATION);
        }

        // GET: APPLICATIONs/Create
        public ActionResult Create()
        {
            ViewBag.JOB_ID = new SelectList(db.JOBs, "JOB_ID", "SITE_ID");
            ViewBag.SRN = new SelectList(db.STUDENTs, "SRN", "FIRST_NAME");
            return View();
        }

        // POST: APPLICATIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "APPLICATION_ID,JOB_ID,SRN,APP_STATUS,DATE_SUBMITTED")] APPLICATION aPPLICATION)
        {
            if (ModelState.IsValid)
            {
                db.APPLICATIONs.Add(aPPLICATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JOB_ID = new SelectList(db.JOBs, "JOB_ID", "SITE_ID", aPPLICATION.JOB_ID);
            ViewBag.SRN = new SelectList(db.STUDENTs, "SRN", "FIRST_NAME", aPPLICATION.SRN);
            return View(aPPLICATION);
        }

        // GET: APPLICATIONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPLICATION aPPLICATION = db.APPLICATIONs.Find(id);
            if (aPPLICATION == null)
            {
                return HttpNotFound();
            }
            ViewBag.JOB_ID = new SelectList(db.JOBs, "JOB_ID", "SITE_ID", aPPLICATION.JOB_ID);
            ViewBag.SRN = new SelectList(db.STUDENTs, "SRN", "FIRST_NAME", aPPLICATION.SRN);
            return View(aPPLICATION);
        }

        // POST: APPLICATIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "APPLICATION_ID,JOB_ID,SRN,APP_STATUS,DATE_SUBMITTED")] APPLICATION aPPLICATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPPLICATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JOB_ID = new SelectList(db.JOBs, "JOB_ID", "SITE_ID", aPPLICATION.JOB_ID);
            ViewBag.SRN = new SelectList(db.STUDENTs, "SRN", "FIRST_NAME", aPPLICATION.SRN);
            return View(aPPLICATION);
        }

        // GET: APPLICATIONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPLICATION aPPLICATION = db.APPLICATIONs.Find(id);
            if (aPPLICATION == null)
            {
                return HttpNotFound();
            }
            return View(aPPLICATION);
        }

        // POST: APPLICATIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            APPLICATION aPPLICATION = db.APPLICATIONs.Find(id);
            db.APPLICATIONs.Remove(aPPLICATION);
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
