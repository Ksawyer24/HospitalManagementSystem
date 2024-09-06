using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Models.StaffManagement;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IStaffRepo
    {
        Task<List<Staff>> GetAllStaffAsync();

        Task<Staff?> GetStaffIdAsync(long id);

        Task<Staff> CreateAsync(Staff staff);

        Task<Staff?> UpdateStaffAsync(long id, Staff staff);

        Task<Staff?> DeleteStaffAsync(long id);
    }
}
