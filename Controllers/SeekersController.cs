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
using BloodManagementSystem_API_.Models;

namespace BloodManagementSystem_API_.Controllers
{
    public class SeekersController : ApiController
    {
        private CaseStudyContext db = new CaseStudyContext();

        // GET: api/Seekers
        public IQueryable<Seeker> GetSeekers()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Seekers;
        }

        [HttpGet]
        public Seeker Get([FromUri] int id, [FromUri] int phone)
        {
            using (CaseStudyContext db = new CaseStudyContext())
            {
                Seeker don = null;
                db.Configuration.ProxyCreationEnabled = false;
                don = db.Seekers.Where(e => e.SeekerId == id && e.SeekerPhone == phone).FirstOrDefault();
                if (don == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                else
                {
                    return don;
                }

            }
        }

        // GET: api/Seekers/5
        [ResponseType(typeof(Seeker))]
        public IHttpActionResult GetSeeker(int id)
        {
            Seeker seeker = db.Seekers.Find(id);
            if (seeker == null)
            {
                return NotFound();
            }
            db.Configuration.ProxyCreationEnabled = false;
            return Ok(seeker);
        }

        // PUT: api/Seekers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeeker(int id, Seeker seeker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seeker.SeekerId)
            {
                return BadRequest();
            }

            db.Entry(seeker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeekerExists(id))
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

        // POST: api/Seekers
        [ResponseType(typeof(Seeker))]
        public IHttpActionResult PostSeeker(Seeker seeker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Seekers.Add(seeker);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SeekerExists(seeker.SeekerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = seeker.SeekerId }, seeker);
        }

        // DELETE: api/Seekers/5
        [ResponseType(typeof(Seeker))]
        public IHttpActionResult DeleteSeeker(int id)
        {
            Seeker seeker = db.Seekers.Find(id);
            if (seeker == null)
            {
                return NotFound();
            }

            db.Seekers.Remove(seeker);
            db.SaveChanges();

            return Ok(seeker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeekerExists(int id)
        {
            return db.Seekers.Count(e => e.SeekerId == id) > 0;
        }
    }
}