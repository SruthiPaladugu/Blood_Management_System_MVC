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
    public class TestDonorsController : ApiController
    {
        private IBloodAppContext db = new TestContext();
        public TestDonorsController() { }

        public TestDonorsController(IBloodAppContext context)
        {
            db = context;
        }

        // GET: api/Donors
        public IQueryable<Donor> GetDonors()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.Donors;
        }

        [HttpGet]
        public Donor Get([FromUri] int id, [FromUri] int phone)
        {
            using (CaseStudyContext db = new CaseStudyContext())
            {
                Donor don = null;
                db.Configuration.ProxyCreationEnabled = false;
                don = db.Donors.Where(e => e.DonorId == id && e.DonorPhone == phone).FirstOrDefault();
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

        // GET: api/Donors/5
        [ResponseType(typeof(Donor))]
        public IHttpActionResult GetDonor(int id)
        {
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return NotFound();
            }
            //db.Configuration.ProxyCreationEnabled = false;
            return Ok(donor);
        }

        // PUT: api/Donors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonor( Donor donor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != donor.DonorId)
            //{
            //    return BadRequest();
            //}

            //db.Entry(donor).State = EntityState.Modified;
            db.MarkAsModified(donor);

                db.SaveChanges();
            
            

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Donors
        [ResponseType(typeof(Donor))]
        public IHttpActionResult PostDonor(Donor donor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Donors.Add(donor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DonorExists(donor.DonorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = donor.DonorId }, donor);
        }

        // DELETE: api/Donors/5
        [ResponseType(typeof(Donor))]
        public IHttpActionResult DeleteDonor(int id)
        {
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return NotFound();
            }

            db.Donors.Remove(donor);
            db.SaveChanges();

            return Ok(donor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonorExists(int id)
        {
            return db.Donors.Count(e => e.DonorId == id) > 0;
        }
    }
}