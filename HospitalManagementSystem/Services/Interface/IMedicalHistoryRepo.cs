using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IMedicalHistoryRepo
    {
        Task<List<MedicalHistory>> GetAllPatientsAsync();

        Task<MedicalHistory?> GetPatientIdAsync(long id);

        Task<MedicalHistory> CreateAsync(MedicalHistory medical);

        Task<MedicalHistory?> UpdatePatientAsync(long id, MedicalHistory medical);

        Task<MedicalHistory?> DeletePatientAsync(long id);
    }
}
