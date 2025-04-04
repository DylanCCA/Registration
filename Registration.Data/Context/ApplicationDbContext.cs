using Microsoft.EntityFrameworkCore;
using Registration.Core.Models;

namespace Registration.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Subcontractor> Subcontractors { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Insurance> Insurance { get; set; }
        public DbSet<VerificationProgress> VerificationProgress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Subcontractor)
                .WithMany()
                .HasForeignKey(e => e.SubcontractorID);

            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Subcontractor)
                .WithMany()
                .HasForeignKey(d => d.SubcontractorID);

            modelBuilder.Entity<Insurance>()
                .HasOne(i => i.Subcontractor)
                .WithMany()
                .HasForeignKey(i => i.SubcontractorID);

            modelBuilder.Entity<Insurance>()
                .HasOne(i => i.Equipment)
                .WithMany()
                .HasForeignKey(i => i.EquipmentID);

            modelBuilder.Entity<VerificationProgress>()
                .HasOne(v => v.Subcontractor)
                .WithMany()
                .HasForeignKey(v => v.SubcontractorID);
        }
    }
}
