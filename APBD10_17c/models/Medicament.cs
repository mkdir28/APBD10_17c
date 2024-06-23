using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DefaultNamespace;


namespace CodeFist.models;

[Table("Medicament")]
public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Type { get; set; } = string.Empty;
    
    public ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; } = new HashSet<Prescription_Medicament>();
}