using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Models.StaffManagement;
using HospitalManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services.Repos
{
    public class StaffRepo : IStaffRepo
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;

        public StaffRepo(HospitalSysDbContext hospitalSysDbContext)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
        }

        public async Task<Staff> CreateAsync(Staff staff)
        {
            await hospitalSysDbContext.AddAsync(staff);
            await hospitalSysDbContext.SaveChangesAsync();
            return staff;
        }

        public async Task<Staff?> DeleteStaffAsync(long id)
        {
            var existing = await hospitalSysDbContext.Staffs.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;

            }

            hospitalSysDbContext.Staffs.Remove(existing);
            await hospitalSysDbContext.SaveChangesAsync();
            return existing;

        }

        public async Task<List<Staff>> GetAllStaffAsync()
        {
            return await hospitalSysDbContext.Staffs.ToListAsync();
        }

        public async Task<Staff?> GetStaffIdAsync(long id)
        {
            return await hospitalSysDbContext.Staffs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Staff?> UpdateStaffAsync(long id, Staff staff)
        {
            var existing = await hospitalSysDbContext.Staffs.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;

            }

            existing.Name = staff.Name;
            existing.DateOfBirth = staff.DateOfBirth;
           existing.PhoneNumber = staff.PhoneNumber;
            existing.Position = staff.Position;
            existing.YearsOfEmployment = staff.YearsOfEmployment;
            existing.WorkingDays = staff.WorkingDays;
           
            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }
    }
}
