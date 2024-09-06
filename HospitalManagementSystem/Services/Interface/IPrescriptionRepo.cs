using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Models.PharmacyManagement;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IPrescriptionRepo
    {
        Task<List<Prescriptions>> GetAllAsync();

        Task<Prescriptions?> GetPrescriptionIdAsync(long id);

        Task<Prescriptions> CreateAsync(Prescriptions prescriptions);

        Task<Prescriptions?> UpdatePrescriptionAsync(long id, Prescriptions prescriptions);

        Task<Prescriptions?> DeletePrescriptionAsync(long id);
    }
}
