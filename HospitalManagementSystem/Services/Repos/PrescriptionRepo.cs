using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Models.PharmacyManagement;
using HospitalManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services.Repos
{
    public class PrescriptionRepo : IPrescriptionRepo
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;

        public PrescriptionRepo(HospitalSysDbContext hospitalSysDbContext)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
        }

        public async Task<Prescriptions> CreateAsync(Prescriptions prescriptions)
        {
            await hospitalSysDbContext.AddAsync(prescriptions);
            await hospitalSysDbContext.SaveChangesAsync();
            return prescriptions;

        }

        public async Task<Prescriptions?> DeletePrescriptionAsync(long id)
        {
            var existing = await hospitalSysDbContext.Prescriptions.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;

            }

            hospitalSysDbContext.Prescriptions.Remove(existing);
            await hospitalSysDbContext.SaveChangesAsync();
            return existing;

        }

        public async  Task<List<Prescriptions>> GetAllAsync()
        {
            return await hospitalSysDbContext.Prescriptions.ToListAsync();
        }

        public async Task<Prescriptions?> GetPrescriptionIdAsync(long id)
        {
            return await hospitalSysDbContext.Prescriptions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Prescriptions?> UpdatePrescriptionAsync(long id, Prescriptions prescriptions)
        {
            var existing = await hospitalSysDbContext.Prescriptions.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;

            }


            existing.Name = prescriptions.Name;
            existing.Dosage = prescriptions.Dosage;
            existing.DateIssued = prescriptions.DateIssued;
            existing.PatientId = prescriptions.PatientId;



            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }
    }
}
