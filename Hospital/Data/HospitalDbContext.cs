using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data;

public class HospitalDbContext : IdentityDbContext
{
    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
    :base(options)
    {
    }
    
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<BillingRecord> BillingRecords { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUser>(b =>
        {
            b.HasKey(u => u.Id);
        });
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany()
            .HasForeignKey(a => a.DoctorId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.AppointmentType)
            .WithMany()
            .HasForeignKey(a => a.AppointmentTypeId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.AppointmentStatus)
            .WithMany()
            .HasForeignKey(a => a.AppointmentStatusId);

        modelBuilder.Entity<BillingRecord>()
            .HasOne(b => b.Appointment)
            .WithMany()
            .HasForeignKey(b => b.AppointmentId);
            

        modelBuilder.Entity<BillingRecord>()
            .HasOne(b => b.Patient)
            .WithMany()
            .HasForeignKey(b => b.PatientId)
            .OnDelete(DeleteBehavior.NoAction);
        
        

        modelBuilder
            .Entity<Department>()
            .HasData(new Department()
                {
                    DepartmentId = 1,
                    Name = "Gastro",
                    Description = "stomasi opravqme burzo"
                },
                new Department()
                {
                    DepartmentId = 2,
                    Name = "GP",
                    Description = "ot vsichkoto nai dobroto"
                    
                } );
 
        base.OnModelCreating(modelBuilder);
    }

   
}