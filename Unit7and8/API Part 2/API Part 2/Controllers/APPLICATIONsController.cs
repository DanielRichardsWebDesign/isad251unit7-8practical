using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_Part_2.Models;

namespace API_Part_2.Controllers
{
    public class APPLICATIONsController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/APPLICATIONs
        public IQueryable<APPLICATION> GetAPPLICATIONs()
        {
            return db.APPLICATIONs;
        }

        // GET: api/APPLICATIONs/5
        [ResponseType(typeof(APPLICATION))]
        public IHttpActionResult GetAPPLICATION(string id)
        {
            APPLICATION aPPLICATION = db.APPLICATIONs.Find(id);
            if (aPPLICATION == null)
            {
                return NotFound();
            }

            return Ok(aPPLICATION);
        }

        // PUT: api/APPLICATIONs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAPPLICATION(string id, APPLICATION aPPLICATION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPPLICATION.APPLICATION_ID)
            {
                return BadRequest();
            }

            db.Entry(aPPLICATION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APPLICATIONExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/APPLICATIONs
        [ResponseType(typeof(APPLICATION))]
        public IHttpActionResult PostAPPLICATION(APPLICATION aPPLICATION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APPLICATIONs.Add(aPPLICATION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (APPLICATIONExists(aPPLICATION.APPLICATION_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aPPLICATION.APPLICATION_ID }, aPPLICATION);
        }

        // DELETE: api/APPLICATIONs/5
        [ResponseType(typeof(APPLICATION))]
        public IHttpActionResult DeleteAPPLICATION(string id)
        {
            APPLICATION aPPLICATION = db.APPLICATIONs.Find(id);
            if (aPPLICATION == null)
            {
                return NotFound();
            }

            db.APPLICATIONs.Remove(aPPLICATION);
            db.SaveChanges();

            return Ok(aPPLICATION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APPLICATIONExists(string id)
        {
            return db.APPLICATIONs.Count(e => e.APPLICATION_ID == id) > 0;
        }
    }
}