using HospitalManagementSystem.Models.LabManagement;
using HospitalManagementSystem.Models.PharmacyManagement;

namespace HospitalManagementSystem.Services.Interface
{
    public interface ILabTestRepo
    {
        Task<List<LabTest>> GetAllInentoriesAsync();

        Task<LabTest?> GetInvIdAsync(long id);

        Task<LabTest> CreateAsync(LabTest labTest);

        Task<LabTest?> UpdateInventoryAsync(long id, LabTest labTest);

        Task<LabTest?> DeleteInventoryAsync(long id);
    }
}
