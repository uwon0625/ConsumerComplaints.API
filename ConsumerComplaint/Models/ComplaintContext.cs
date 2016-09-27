namespace ConsumerComplaints.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class ComplaintContext : DbContext, IComplaintContext
    {
        public ComplaintContext()
            : base("name=ComplaintContext")
        {
        }
        Task<int> IComplaintContext.SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public virtual IDbSet<ConsumerComplaint> ConsumerComplaints { get; set; }

        public void MarkAsModified(ConsumerComplaint item)
        {
            Entry(item).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.Product)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.Sub_product)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.Issue)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.Sub_issue)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.ConsumerComplaintNarrative)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.CompanyPublicResponse)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.ZIP)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.Tags)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.ConsumerConsentProvided)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.SubmittedVia)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.CompanyResponseToConsumer)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.TimelyResponse)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumerComplaint>()
                .Property(e => e.ConsumerDisputed)
                .IsUnicode(false);
        }

    }
}
