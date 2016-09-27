using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerComplaints.API.Models
{
    public interface IComplaintContext : IDisposable
    {
        IDbSet<ConsumerComplaint> ConsumerComplaints { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void MarkAsModified(ConsumerComplaint item);
    }
}