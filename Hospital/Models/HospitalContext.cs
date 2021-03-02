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
        public DbSet<PhysicianStation> PhysicianStation { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.SVNR)
                .IsUnique();

            modelBuilder.Entity<CareTaker>()
                .HasOne<CareTaker>(c=> c.Supervisor)
                .WithMany()
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
                .HasOne<Physician>(w => w.LeadPhysician)
                .WithOne();
            
            modelBuilder.Entity<PhysicianStation>()
                .HasKey(p => new {p.PhysicianId, p.WardId});

            modelBuilder.Entity<PhysicianStation>()
                .HasOne<Physician>(p => p.Physician)
                .WithMany()
                .HasForeignKey(p => p.PhysicianId);

            modelBuilder.Entity<PhysicianStation>()
                .HasOne<Ward>(p => p.Ward)
                .WithMany()
                .HasForeignKey(p => p.WardId);
        }

        public HospitalContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}