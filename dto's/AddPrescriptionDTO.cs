using CodeFirst.models;
using CodeFist.models;

namespace APBD10_17c.dyp_s;

public class AddPrescriptionDTO
{
    public Patient Patient { set; get; } = null;
    public Prescription Prescription { set; get; }
    public Doctor Doctor { set; get; } = null;

    public ICollection<Medicament> Medicaments = new List<Medicament>();
}