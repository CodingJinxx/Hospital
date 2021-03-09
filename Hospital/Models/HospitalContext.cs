using Microsoft.EntityFrameworkCore;

namespace Hospital.Models
{
    public class HospitalContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CareTaker> CareTakers { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<HospitalFacility> HospitalFacilities { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<PhysicianWard> PhysicianStation { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.SVNR)
                .IsUnique();

            modelBuilder.Entity<CareTaker>()
                .HasOne(c=> c.Supervisor)
                .WithMany()
                .HasForeignKey(c => c.SupervisorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HospitalFacility>()
                .HasIndex(h => h.Name)
                .IsUnique();
            
            modelBuilder.Entity<HospitalFacility>()
                .HasIndex(h => h.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Ward>()
                .HasOne<HospitalFacility>(w => w.HospitalFacility)
                .WithMany();

            modelBuilder.Entity<Ward>()
                .HasOne(w => w.LeadPhysician)
                .WithOne()
                .HasForeignKey<Ward>(w => w.LeadPhysicianId);
            
            modelBuilder.Entity<PhysicianWard>()
                .HasKey(p => new {p.PhysicianId, p.WardId});

            modelBuilder.Entity<PhysicianWard>()
                .HasOne<Physician>(p => p.Physician)
                .WithMany()
                .HasForeignKey(p => p.PhysicianId);

            modelBuilder.Entity<PhysicianWard>()
                .HasOne<Ward>(p => p.Ward)
                .WithMany()
                .HasForeignKey(p => p.WardId);
        }

        public HospitalContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}