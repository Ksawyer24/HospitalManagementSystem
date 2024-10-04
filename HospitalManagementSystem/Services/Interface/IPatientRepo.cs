using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IPatientRepo
    {
        Task<List<Patient>> GetAllPatientsAsync(string filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);

        Task<Patient?> GetPatientIdAsync(long id);

        Task<Patient> CreateAsync(Patient patient);

        Task<Patient?> UpdatePatientAsync(long id, Patient patient);

        Task<Patient?> DeletePatientAsync(long id);
    }
}
