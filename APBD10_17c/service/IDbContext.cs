namespace APBD10_1_17c.services;
using APBD10_17c.dto_s;
using CodeFist.models;
public interface DbContext
{
    Task<AddPrescriptionDTO?> GetPatientinformation(int id);
    Task<bool> DoesPatientExist(int id);
    Task AddPatient(Patient patient);
    Task<bool> DoesMedicamentsExist(int id);
}