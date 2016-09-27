using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using ConsumerComplaints.API.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace ConsumerComplaints.Test
{
    [TestClass]
    public class TestDataContext : IComplaintContext
    {
        public TestDataContext()
        {
            this.ConsumerComplaints = new TestComplaintsDbSet();
        }

        public IDbSet<ConsumerComplaint> ConsumerComplaints { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(ConsumerComplaint item) { }
        public void Dispose() { }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConsumerComplaint> GetComplaints()
        {
            throw new NotImplementedException();
        }
    }
}
