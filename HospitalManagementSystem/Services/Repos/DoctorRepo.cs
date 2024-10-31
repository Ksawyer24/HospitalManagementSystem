using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.DoctorManagement;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services.Repos
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;

        public DoctorRepo(HospitalSysDbContext hospitalSysDbContext)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
        }



        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            doctor.DateOfBirth = DateTime.SpecifyKind(doctor.DateOfBirth, DateTimeKind.Utc);
            await hospitalSysDbContext.Doctors.AddAsync(doctor);
            await hospitalSysDbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor?> DeleteDoctorsAsync(long id)
        {
            var existing = await hospitalSysDbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;

            }

            hospitalSysDbContext.Doctors.Remove(existing);
            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await hospitalSysDbContext.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetDoctorsIdAsync(long id)
        {
            return await hospitalSysDbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }

        

        public async Task<Doctor?> UpdateDoctorAsync(long id, Doctor doctor)
        {
            var existing = await hospitalSysDbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;

            }


            existing.Name = doctor.Name;
            existing.DateOfBirth = DateTime.SpecifyKind(doctor.DateOfBirth, DateTimeKind.Utc);
            existing.Specialization = doctor.Specialization;
            existing.YearsOfExperience = doctor.YearsOfExperience;
            existing.ContactNumber = doctor.ContactNumber;
            existing.Email = doctor.Email;
            doctor.Address = doctor.Address;
            doctor.WorkingDays= doctor.WorkingDays;



            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }



    }
}
