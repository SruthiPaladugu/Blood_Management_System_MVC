using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BloodManagementSystem_API_.Models
{
    public partial class CaseStudyContext : DbContext
    {
        public CaseStudyContext()
            : base("name=CaseStudyContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Seeker> Seekers { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminId)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Adminpassword)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.DonorName)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.DonorBloodGroup)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.DonorLocation)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .HasMany(e => e.Requests)
                .WithOptional(e => e.Donor)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Donor>()
                .HasOptional(e => e.Stock)
                .WithRequired(e => e.Donor)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Request>()
                .Property(e => e.BloodGroup)
                .IsUnicode(false);

            modelBuilder.Entity<Seeker>()
                .Property(e => e.SeekerName)
                .IsUnicode(false);

            modelBuilder.Entity<Seeker>()
                .Property(e => e.SeekerBloodGroup)
                .IsUnicode(false);

            modelBuilder.Entity<Seeker>()
                .Property(e => e.SeekerLocation)
                .IsUnicode(false);

            modelBuilder.Entity<Seeker>()
                .HasMany(e => e.Requests)
                .WithOptional(e => e.Seeker)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Stock>()
                .Property(e => e.BloodGroup)
                .IsUnicode(false);

            modelBuilder.Entity<Stock>()
                .Property(e => e.DonorName)
                .IsUnicode(false);
        }
    }
}
