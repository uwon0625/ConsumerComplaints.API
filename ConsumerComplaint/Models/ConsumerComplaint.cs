namespace ConsumerComplaints.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConsumerComplaint
    {
        public DateTime DateReceived { get; set; }

        [Required]
        [StringLength(50)]
        public string Product { get; set; }

        [Column("Sub-product")]
        [Required]
        [StringLength(100)]
        public string Sub_product { get; set; }

        [Required]
        [StringLength(200)]
        public string Issue { get; set; }

        [Column("Sub-issue")]
        [Required]
        [StringLength(200)]
        public string Sub_issue { get; set; }

        [Required]
        [StringLength(8000)]
        public string ConsumerComplaintNarrative { get; set; }

        [Required]
        [StringLength(200)]
        public string CompanyPublicResponse { get; set; }

        [Required]
        [StringLength(100)]
        public string Company { get; set; }

        [Required]
        [StringLength(8)]
        public string State { get; set; }

        [Required]
        [StringLength(10)]
        public string ZIP { get; set; }

        [Required]
        [StringLength(50)]
        public string Tags { get; set; }

        [Required]
        [StringLength(50)]
        public string ConsumerConsentProvided { get; set; }

        [Required]
        [StringLength(50)]
        public string SubmittedVia { get; set; }

        public DateTime DateSentToCompany { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyResponseToConsumer { get; set; }

        [Required]
        [StringLength(50)]
        public string TimelyResponse { get; set; }

        [Required]
        [StringLength(50)]
        public string ConsumerDisputed { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
    }
}
