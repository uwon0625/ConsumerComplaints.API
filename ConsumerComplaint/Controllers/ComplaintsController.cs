using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ConsumerComplaints.API.Models;
using System.Collections.Generic;
using System;
using System.Web.Http.Routing;
using System.Web;
using System.Net.Http;

namespace ConsumerComplaints.API.Controllers
{
    public class ComplaintsController : ApiController
    {
        private const int maxPageSize = 10;
        private readonly IComplaintContext db;

        public ComplaintsController(IComplaintContext context)
        {
            db = context;
        }

        // GET: api/Complaints (all other parameteres are optional)
        // GET: api/Complaints/companyName/zip/pageSize/pageNumber/orderBy
        [Route("api/Complaints")]
        [Route("api/Complaints/{CompanyName}")]
        [Route("api/Complaints/{CompanyName}/{zip}")]
        [Route("api/Complaints/{CompanyName}/{zip}/{pageSize}")]
        [Route("api/Complaints/{CompanyName}/{zip}/{pageSize}/{pageNumber}")]
        [Route("api/Complaints/{CompanyName}/{zip}/{pageSize}/{pageNumber}/{orderBy}")]
        public IHttpActionResult GetConsumerComplaints(string companyName="", string zip="", int pageSize = maxPageSize, int pageNumber = 1, string orderBy = "Id")
        {
            try
            {
                var complaints = db.ConsumerComplaints.Where(c => (c.Company == companyName || companyName == "")  && (c.ZIP == zip || zip==""));

                if (complaints == null)
                {                   
                    return NotFound();
                }

                if (pageSize > maxPageSize)
                {
                    pageSize = maxPageSize;
                }

                // calculate data for metadata
                var totalCount = complaints.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var result = complaints
                    .ApplySort(orderBy)
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize)
                    .ToList();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // GET: api/Complaints/5
        [ResponseType(typeof(ConsumerComplaint))]
        public IHttpActionResult GetConsumerComplaint(long id)
        {
            ConsumerComplaint consumerComplaint =  db.ConsumerComplaints.FirstOrDefault(c => c.Id == id);
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
        //[Authorize]
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
        public IHttpActionResult DeleteConsumerComplaint(long id)
        {
            ConsumerComplaint consumerComplaint =  db.ConsumerComplaints.Find(id);
            if (consumerComplaint == null)
            {
                return NotFound();
            }

            db.ConsumerComplaints.Remove(consumerComplaint);
            db.SaveChanges();

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