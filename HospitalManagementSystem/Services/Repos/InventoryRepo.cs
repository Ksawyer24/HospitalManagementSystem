using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Models.PharmacyManagement;
using HospitalManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services.Repos
{
    public class InventoryRepo : IInventoryRepo
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;

        public InventoryRepo(HospitalSysDbContext hospitalSysDbContext)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
        }


        public async Task<Inventory> CreateAsync(Inventory inventory)
        {
            await hospitalSysDbContext.AddAsync(inventory);
            await hospitalSysDbContext.SaveChangesAsync();
            return inventory;
        }

        public async Task<Inventory?> DeleteInventoryAsync(long id)
        {
            var existing = await hospitalSysDbContext.Inventories.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;

            }

            hospitalSysDbContext.Inventories.Remove(existing);
            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<List<Inventory>> GetAllInventoriesAsync()
        {
            return await hospitalSysDbContext.Inventories.ToListAsync();
        }

        public async Task<Inventory?> GetInvIdAsync(long id)
        {
           return await hospitalSysDbContext.Inventories.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<Inventory?> UpdateInventoryAsync(long id, Inventory inventory)
        {
            var existing = await hospitalSysDbContext.Inventories.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;

            }


            existing.Name = inventory.Name;
            existing.ExpiryDate = inventory.ExpiryDate;
            existing.Supplier = inventory.Supplier;
            existing.SupplierContact = inventory.SupplierContact;
          



            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }
    }
}
