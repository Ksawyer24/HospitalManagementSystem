using HospitalManagementSystem.Models.DoctorManagement;
using HospitalManagementSystem.Models.PharmacyManagement;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IInventoryRepo
    {
        Task<List<Inventory>> GetAllInentoriesAsync();

        Task<Inventory?> GetInvIdAsync(long id);

        Task<Inventory> CreateAsync(Inventory inventory);

        Task<Inventory?> UpdateInventoryAsync(long id, Inventory inventory);

        Task<Inventory?> DeleteInventoryAsync(long id);
    }
}
