using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.LabManagement;
using HospitalManagementSystem.Models.PharmacyManagement;
using HospitalManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services.Repos
{
    public class LabTestRepo : ILabTestRepo
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;

        public LabTestRepo(HospitalSysDbContext hospitalSysDbContext)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
        }


        public async Task<LabTest> CreateAsync(LabTest labTest)
        {
            await hospitalSysDbContext.AddAsync(labTest);
            await hospitalSysDbContext.SaveChangesAsync();
            return labTest;

        }

        public async Task<LabTest?> DeleteInventoryAsync(long id)
        {
            var existing = await hospitalSysDbContext.LabTests.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;

            }

            hospitalSysDbContext.LabTests.Remove(existing);
            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<List<LabTest>> GetAllInentoriesAsync()
        {
            return await hospitalSysDbContext.LabTests.ToListAsync();
        }

        public Task<LabTest?> GetInvIdAsync(long id)
        {
            return hospitalSysDbContext.LabTests.FirstOrDefaultAsync(x=> x.Id == id);   
        }

        public async Task<LabTest?> UpdateInventoryAsync(long id, LabTest labTest)
        {
            var existing = await hospitalSysDbContext.LabTests.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;
            }


            existing.PatientId = labTest.PatientId;
            existing.MLS = labTest.MLS;
            existing.ReviewedBy = labTest.ReviewedBy;
            existing.TestName = labTest.TestName;
            existing.TestDate = labTest.TestDate;



            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }
    }
}
