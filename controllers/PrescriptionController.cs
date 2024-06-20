using CodeFirst.models;
using CodeFist.models;
namespace APBD10_17c.data;

public class PrescriptionController
{
    public Patient Patient { set; get; } = null;
    public Prescription Prescription { set; get; }
    public Doctor Doctor { set; get; } = null;

    public ICollection<Medicament> Medicaments = new List<Medicament>();
}