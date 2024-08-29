using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.DoctorManagement;
using HospitalManagementSystem.Services.Interface;

namespace HospitalManagementSystem.Services.Repos
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;

        public DoctorRepo(HospitalSysDbContext hospitalSysDbContext)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
        }



        public Task<Doctor> CreateAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor?> DeletePatientAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Doctor>> GetAllPatientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Doctor?> GetPatientIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor?> UpdatePatientAsync(long id, Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
