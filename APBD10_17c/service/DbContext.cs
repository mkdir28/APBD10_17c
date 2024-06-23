namespace APBD10_1_17c.services;


public class DbContext: IDbContext
{
    private readonly DatabaseConnect _context;
    public DbContext(DatabaseConnect context)
    {
        _context = context;
    }
    
    public async Task<AddPrescriptionDTO?> GetPatientinformation(int id)
    {
        return await _context.Patients
            .Include(e => e.IdPatient)
            .ThenInclude(e => e.Prescription_Medicaments)
            .Select()
            .ToListAsync();
    }

    public async Task<bool> DoesPatientExist(int id)
    {
        return await _context.Patients.AnyAsync(e => e.IdPatient == id);
    }

    public async Task AddPatient(PatientDTO patient)
    {
        var patientEntity = new Patient
        {
            IdPatient = patient.IdPatient,
            FiestName = patient.FiestName,
        };
        await _context.AddAsync(patientEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesMedicamentsExist(int id)
    {
        return await _context.Medicaments.AnyAsync(e => e.IdMedicament == id);
    }
