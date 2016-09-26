using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ConsumerComplaints.API.Models;

namespace ConsumerComplaints.API.Controllers
{
    public class ComplaintsController : ApiController
    {
        private IComplaintContext db = new ComplaintContext();

        public ComplaintsController()
        {

        }
        public ComplaintsController(IComplaintContext context)
        {
            db = context;
        }

        // GET: api/Complaints
        public IQueryable<ConsumerComplaint> GetConsumerComplaints()
        {
            return db.ConsumerComplaints.Take(10);
        }

        // GET: api/Complaints/5
        [ResponseType(typeof(ConsumerComplaint))]
        public async Task<IHttpActionResult> GetConsumerComplaint(long id)
        {
            ConsumerComplaint consumerComplaint = await db.ConsumerComplaints.FindAsync(id);
            if (consumerComplaint == null)
            {
                return NotFound();
            }

            return Ok(consumerComplaint);
        }

        // PUT: api/Complaints/5
        [ResponseType(typeof(void))]
        [Authorize]
        public async Task<IHttpActionResult> PutConsumerComplaint(long id, ConsumerComplaint consumerComplaint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consumerComplaint.Id)
            {
                return BadRequest();
            }

            db.MarkAsModified(consumerComplaint);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumerComplaintExists(id))
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

        // POST: api/Complaints
        [ResponseType(typeof(ConsumerComplaint))]
        [Authorize]
        public async Task<IHttpActionResult> PostConsumerComplaint(ConsumerComplaint consumerComplaint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConsumerComplaints.Add(consumerComplaint);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConsumerComplaintExists(consumerComplaint.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = consumerComplaint.Id }, consumerComplaint);
        }

        // DELETE: api/Complaints/5
        [ResponseType(typeof(ConsumerComplaint))]
        [Authorize]
        public async Task<IHttpActionResult> DeleteConsumerComplaint(long id)
        {
            ConsumerComplaint consumerComplaint = await db.ConsumerComplaints.FindAsync(id);
            if (consumerComplaint == null)
            {
                return NotFound();
            }

            db.ConsumerComplaints.Remove(consumerComplaint);
            await db.SaveChangesAsync();

            return Ok(consumerComplaint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsumerComplaintExists(long id)
        {
            return db.ConsumerComplaints.Count(e => e.Id == id) > 0;
        }
    }
}