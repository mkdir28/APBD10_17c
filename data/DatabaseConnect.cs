using CodeFirst.models;
using CodeFist.models;
using Microsoft.EntityFrameworkCore;

namespace APBD10_1_17c.data;

public class DatabaseConnect: DbContext
{
    protected DatabaseConnect()
    {
        
    }
    
    public DatabaseConnect(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient {
                IdPatient = 1,
                FiestName = "John",
                LastName = "Kowalski",
                Date = new DateTime(1997-7-4)
            },
            new Patient {
                IdPatient = 2,
                FiestName = "Nika",
                LastName = "Kowalska",
                Date = new DateTime(2000, 9, 1)
            }
        });

        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new Prescription
            {
                IdPrescription = 1,
                Date = new DateTime(2012-01-01),
                DueDate = new DateTime(2012-01-01)
            }
        });
        
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament
            {
                IdMedicament = 1,
                Name = "AAA",
                Description = "AAA"
            }
        });
        
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor
            {
                IdDoctor = 1,
                FiestName = "AAA"
            }
        });
        
        modelBuilder.Entity<Prescription_Medicament>().HasData(new List<Prescription_Medicament>()
        {
            new Prescription_Medicament
            {
                IdMedicament = 1,
                Dose = 3,
                Details = "Some description..."
            },
            
            new Prescription_Medicament
            {
            IdMedicament = 1,
            Dose = 10,
            Details = "AAA"
        }
        });
    }
}