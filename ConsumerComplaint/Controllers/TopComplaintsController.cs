using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using ConsumerComplaints.API.Models;

namespace ConsumerComplaints.API.Controllers
{
    public class TopComplaintsController : ApiController
    {
        private const int maxPageSize = 10;
        private readonly IComplaintContext db;

        public TopComplaintsController()
        {

        }
        public TopComplaintsController(IComplaintContext context)
        {
            db = context;
        }

        // GET: api/TopComplaints
        public IQueryable<TopComplaints> GetTopConsumerComplaints()
        {
            return db.ConsumerComplaints.GroupBy(c => c.Company)
                .Select(c => new TopComplaints { Name = c.Key, Count = c.Count() })
                .Take(maxPageSize)
                .OrderByDescending(c => c.Count);
        }

        // GET: api/TopComplaints/33071
        [ResponseType(typeof(TopComplaints))]
        [Route("api/TopComplaints/{zip}", Name = "TopComplaints")]
        public IHttpActionResult GetTopConsumerComplaints(string zip)
        {
            var query = from c in db.ConsumerComplaints
                        where c.ZIP.Equals(zip, System.StringComparison.InvariantCultureIgnoreCase)
                        group c by c.Company into g
                        select new TopComplaints { Name = g.Key, Count = g.Count() };
            var data = query.OrderByDescending(c => c.Count).ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
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