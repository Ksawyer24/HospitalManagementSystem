using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IPatientRepo
    {
        Task<List<Patient>> GetAllPatientsAsync();

        Task<Patient?> GetPatientIdAsync(long id);

        Task<Patient> CreateAsync(Patient patient);

        Task<Patient?> UpdatePatientAsync(long id, Patient patient);

        Task<Patient?> DeletePatientAsync(long id);
    }
}
