using CodeFirst.models;
using CodeFist.models;

namespace APBD10_17c.dyp_s;

public class AddPatientDTO
{
    public PatientDTO Patient { get; set; } = null;
    public MedicamentsDTO MedicamentsDTO { get; set; } = null;
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    
    public ICollection<MedicamentsDTO> Medicaments = new List<MedicamentsDTO>();
}

public class PatientDTO
{
    public int IdPatient { get; set; }
    public string FiestName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public class PresiptionDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    
    public ICollection<DoctorDTO> Doctors = new List<DoctorDTO>();
    public ICollection<MedicamentsDTO> Medicaments = new List<MedicamentsDTO>();
}

public class DoctorDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; } = string.Empty;
}

public class MedicamentsDTO
{
    public int IdMedicament { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Dose { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}