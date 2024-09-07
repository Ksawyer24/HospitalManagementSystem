using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IMedicalHistoryRepo
    {
        Task<List<MedicalHistory>> GetAllHistoriesAsync();

        Task<MedicalHistory?> GetHistoryIdAsync(long id);

        Task<MedicalHistory> CreateAsync(MedicalHistory medical);

        Task<MedicalHistory?> UpdateHistoryAsync(long id, MedicalHistory medical);

        Task<MedicalHistory?> DeleteHistoryAsync(long id);
    }
}
