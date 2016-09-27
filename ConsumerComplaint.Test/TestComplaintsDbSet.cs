using ConsumerComplaints.API.Models;
using System.Linq;

namespace ConsumerComplaints.Test
{
    class TestComplaintsDbSet : TestDbSet<ConsumerComplaint>
    {
        public override ConsumerComplaint Find(params object[] keyValues)
        {
            return this.SingleOrDefault(c => c.Id == (int)keyValues.Single());
        }
    }
}
