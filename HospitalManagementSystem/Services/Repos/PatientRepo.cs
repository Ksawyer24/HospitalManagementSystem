using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services.Repos
{
    public class PatientRepo : IPatientRepo
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;

        public PatientRepo(HospitalSysDbContext hospitalSysDbContext)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {
            await hospitalSysDbContext.AddAsync(patient);
            await hospitalSysDbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient?> DeletePatientAsync(long patientId)
        {
            var existing = await hospitalSysDbContext.Patients.FirstOrDefaultAsync(x => x.Id == patientId);

            if (existing == null)
            {
                return null;

            }

            hospitalSysDbContext.Patients.Remove(existing);
            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<Patient?> GetPatientIdAsync(long patientId)
        {
            return await hospitalSysDbContext.Patients.FirstOrDefaultAsync(x => x.Id == patientId);

        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
           return await hospitalSysDbContext.Patients.ToListAsync();
        }

        public async Task<Patient?> UpdatePatientAsync(long patientId, Patient patient)
        {
            var existing = await hospitalSysDbContext.Patients.FirstOrDefaultAsync(x => x.Id == patientId);

            if (existing == null)
            {
                return null;

            }


            existing.PatientName = patient.PatientName;
            existing.PatientContact = patient.PatientContact;
            existing.DateOfBirth = patient.DateOfBirth;
            existing.NameOfEmergencyContact = patient.NameOfEmergencyContact;
            existing.PhoneNumberOfContact = patient.PhoneNumberOfContact;
            existing.InsuranceIsActive = patient.InsuranceIsActive;



            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }
    }
}
