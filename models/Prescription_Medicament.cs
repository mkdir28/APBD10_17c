using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeFist.models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.models;

[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class Prescription_Medicament
{
    public int? Dose { get; set; }
    [MaxLength(100)]
    public string Details { get; set; }
    
    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; } = null!;
    [ForeignKey(nameof(IdPrescription))]
    public Prescription Prescription { get; set; } = null!;
   
}