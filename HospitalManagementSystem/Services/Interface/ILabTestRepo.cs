using HospitalManagementSystem.Models.LabManagement;
using HospitalManagementSystem.Models.PharmacyManagement;

namespace HospitalManagementSystem.Services.Interface
{
    public interface ILabTestRepo
    {
        Task<List<LabTest>> GetAllTestsAsync();

        Task<LabTest?> GetTestIdAsync(long id);

        Task<LabTest> CreateAsync(LabTest labTest);

        Task<LabTest?> UpdateTestAsync(long id, LabTest labTest);

        Task<LabTest?> DeleteTestAsync(long id);
    }
}
