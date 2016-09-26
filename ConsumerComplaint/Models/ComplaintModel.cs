namespace ConsumerComplaints.API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ComplaintModel : DbContext
    {
        public ComplaintModel()
            : base("name=ComplaintModel")
        {
        }

        public virtual DbSet<ConsumerComplaint> ConsumerComplaints { get; set; }

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
