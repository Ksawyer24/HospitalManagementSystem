using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services.Repos
{
    public class MedicalHistoryRepo : IMedicalHistoryRepo
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;

        public MedicalHistoryRepo(HospitalSysDbContext hospitalSysDbContext)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
        }


        public async Task<MedicalHistory> CreateAsync(MedicalHistory medical)
        {
            await hospitalSysDbContext.AddAsync(medical);
            await hospitalSysDbContext.SaveChangesAsync();
            return medical;
        }

        public async Task<MedicalHistory?> DeleteHistoryAsync(long id)
        {
            var existing = await hospitalSysDbContext.MedicalHistories.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;

            }

            hospitalSysDbContext.MedicalHistories.Remove(existing);
            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }

       

        public async Task<List<MedicalHistory>> GetAllHistoriesAsync()
        {
            return await hospitalSysDbContext.MedicalHistories.ToListAsync();
        }

       

        public async Task<MedicalHistory?> GetHistoryIdAsync(long id)
        {
            return await hospitalSysDbContext.MedicalHistories.FirstOrDefaultAsync(x => x.Id == id);
        }

       

        public async Task<MedicalHistory?> UpdateHistoryAsync(long id, MedicalHistory medical)
        {
            var existing = await hospitalSysDbContext.MedicalHistories.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;

            }



            existing.Conditions = medical.Conditions;
            existing.Medications = medical.Medications;
            existing.Allergies = medical.Allergies;
            existing.HadSurgery = medical.HadSurgery;
            existing.Notes = medical.Notes;



            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }

       
    }
}
