using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data;

public class HospitalDbContext : IdentityDbContext
{
    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
    :base(options)
    {
    }
    public DbSet<Doctor>? Doctors { get; set; }
    public DbSet<Patient>? Patients { get; set; }
    public DbSet<DoctorPatient>? Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoctorPatient>()
            .HasKey(key => new { key.PatientId, key.DoctorId });

        modelBuilder.Entity<DoctorPatient>()
            .HasOne(a => a.Doctor)
            .WithMany(a => a.Patients)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);

        
    }

   
}