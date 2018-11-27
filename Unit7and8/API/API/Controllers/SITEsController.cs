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
    public class SITEsController : Controller
    {
        private Entities db = new Entities();

        // GET: SITEs
        public ActionResult Index()
        {
            var sITES = db.SITES.Include(s => s.COMPANY);
            return View(sITES.ToList());
        }

        // GET: SITEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SITE sITE = db.SITES.Find(id);
            if (sITE == null)
            {
                return HttpNotFound();
            }
            return View(sITE);
        }

        // GET: SITEs/Create
        public ActionResult Create()
        {
            ViewBag.COMPANY_ID = new SelectList(db.COMPANies, "COMPANY_ID", "COMPANY_NAME");
            return View();
        }

        // POST: SITEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SITE_ID,COMPANY_ID,SITE_ADDRESS,SITE_POSTCODE")] SITE sITE)
        {
            if (ModelState.IsValid)
            {
                db.SITES.Add(sITE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COMPANY_ID = new SelectList(db.COMPANies, "COMPANY_ID", "COMPANY_NAME", sITE.COMPANY_ID);
            return View(sITE);
        }

        // GET: SITEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SITE sITE = db.SITES.Find(id);
            if (sITE == null)
            {
                return HttpNotFound();
            }
            ViewBag.COMPANY_ID = new SelectList(db.COMPANies, "COMPANY_ID", "COMPANY_NAME", sITE.COMPANY_ID);
            return View(sITE);
        }

        // POST: SITEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SITE_ID,COMPANY_ID,SITE_ADDRESS,SITE_POSTCODE")] SITE sITE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sITE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COMPANY_ID = new SelectList(db.COMPANies, "COMPANY_ID", "COMPANY_NAME", sITE.COMPANY_ID);
            return View(sITE);
        }

        // GET: SITEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SITE sITE = db.SITES.Find(id);
            if (sITE == null)
            {
                return HttpNotFound();
            }
            return View(sITE);
        }

        // POST: SITEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SITE sITE = db.SITES.Find(id);
            db.SITES.Remove(sITE);
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
