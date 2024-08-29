using HospitalManagementSystem.Models.DoctorManagement;
using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IDoctorRepo
    {
        Task<List<Doctor>> GetAllPatientsAsync();

        Task<Doctor?> GetPatientIdAsync(long id);

        Task<Doctor> CreateAsync(Doctor doctor);

        Task<Doctor?> UpdatePatientAsync(long id, Doctor doctor);

        Task<Doctor?> DeletePatientAsync(long id);
    }
}
