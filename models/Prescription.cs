using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeFist.models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.models;

[Table("Prescription")]
[PrimaryKey(nameof(IdPatient), nameof(IdDoctor))]
public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    
    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; } = null!;
    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; } = null!;

}