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
using Kartastrof.Models;

namespace Kartastrof.Controllers
{
    public class CapitalController : ApiController
    {
        private KartastrofContext db = new KartastrofContext();

        // GET: api/Capital
        public IQueryable<Tbl_Capital> GetTbl_Capital()
        {
            return db.Tbl_Capital;
        }

        // GET: api/Capital/5
        [ResponseType(typeof(Tbl_Capital))]
        public IHttpActionResult GetTbl_Capital(int id)
        {
            Tbl_Capital tbl_Capital = db.Tbl_Capital.Find(id);
            if (tbl_Capital == null)
            {
                return NotFound();
            }

            return Ok(tbl_Capital);
        }

        // PUT: api/Capital/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Capital(int id, Tbl_Capital tbl_Capital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Capital.Ca_Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_Capital).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_CapitalExists(id))
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

        // POST: api/Capital
        [ResponseType(typeof(Tbl_Capital))]
        public IHttpActionResult PostTbl_Capital(Tbl_Capital tbl_Capital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Capital.Add(tbl_Capital);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Capital.Ca_Id }, tbl_Capital);
        }

        // DELETE: api/Capital/5
        [ResponseType(typeof(Tbl_Capital))]
        public IHttpActionResult DeleteTbl_Capital(int id)
        {
            Tbl_Capital tbl_Capital = db.Tbl_Capital.Find(id);
            if (tbl_Capital == null)
            {
                return NotFound();
            }

            db.Tbl_Capital.Remove(tbl_Capital);
            db.SaveChanges();

            return Ok(tbl_Capital);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_CapitalExists(int id)
        {
            return db.Tbl_Capital.Count(e => e.Ca_Id == id) > 0;
        }
    }
}