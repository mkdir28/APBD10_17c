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
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .Where(p => p.IdPatient == id)
            .Select(p => new AddPrescriptionDTO
            {
                Patient = new PatientDTO
                {
                    IdPatient = p.IdPatient,
                    FiestName = p.FiestName,
                    LastName = p.LastName,
                    Date = p.Date
                },
                Medicaments = p.Prescriptions
                    .SelectMany(pr => pr.PrescriptionMedicaments)
                    .Select(pm => new MedicamentsDTO
                    {
                        IdMedicament = pm.Medicament.IdMedicament,
                        Name = pm.Medicament.Name,
                        Dose = pm.Dose.ToString(),
                        Description = pm.Description
                    }).ToList(),
                Date = p.Prescriptions.FirstOrDefault().Date,
                DueDate = p.Prescriptions.FirstOrDefault().DueDate
            })
            .FirstOrDefaultAsync();
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

    public async Task CheckDate(AddPatientDTO addPatientDto)
    {
        if (!await DoesPatientExist(addPatientDto.Patient.IdPatient))
        {
            await AddPatient(addPatientDto.Patient);
        }

        foreach (var med in addPatientDto.Medicaments)
        {
            if (!await DoesMedicamentsExist(med.IdMedicament))
            {
                throw new Exception($"Medicament with Id {med.IdMedicament} does not exist");
            }
        }

        var prescriptionEntity = new Prescription
        {
            IdPatient = addPatientDto.Patient.IdPatient,
            Date = addPatientDto.Date,
            DueDate = addPatientDto.DueDate ?? addPatientDto.Date
        };

        _context.Prescriptions.Add(prescriptionEntity);
        await _context.SaveChangesAsync();

        foreach (var med in addPatientDto.Medicaments)
        {
            var prescriptionMedicament = new Prescription_Medicament
            {
                IdPrescription = prescriptionEntity.IdPrescription,
                IdMedicament = med.IdMedicament,
                Dose = int.Parse(med.Dose),
                Details = med.Description
            };
            _context.Prescription_Medicaments.Add(prescriptionMedicament);
        }

        await _context.SaveChangesAsync();
    }
}