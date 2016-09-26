using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ConsumerComplaints.API.Models
{
    public interface IComplaintContext : IDisposable
    {
        DbSet<ConsumerComplaint> ConsumerComplaints { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void MarkAsModified(ConsumerComplaint item);
    }
}