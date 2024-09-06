using HospitalManagementSystem.Models.DoctorManagement;
using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Services.Interface
{

    public interface IDoctorRepo
    {
        Task<List<Doctor>> GetAllDoctorsAsync();

        Task<Doctor?> GetDoctorsIdAsync(long id);

        Task<Doctor> CreateAsync(Doctor doctor);

        Task<Doctor?> UpdateDoctorAsync(long id, Doctor doctor);

        Task<Doctor?> DeleteDoctorsAsync(long id);
    }
}
