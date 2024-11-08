using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.AppointmentManagement;
using HospitalManagementSystem.Models.Billing_Management;
using HospitalManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services.Repos
{
    public class BillingInvoiceRepo : IBillingInvoiceRepo
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;
      

        public BillingInvoiceRepo(HospitalSysDbContext hospitalSysDbContext)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
        }

        public async Task AddInvoiceAsync(BillingInvoice invoice)
        {
            await hospitalSysDbContext.BillingInvoices.AddAsync(invoice);
            await hospitalSysDbContext.SaveChangesAsync();
            
        }

        public async Task<BillingInvoice?> DeleteInvoiceAsync(long id)
        {
            var existing = await hospitalSysDbContext.BillingInvoices.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null; 
            }

            hospitalSysDbContext.BillingInvoices.Remove(existing);
            await hospitalSysDbContext.SaveChangesAsync();

            return existing; 
        }


        public async Task<List<BillingInvoice>> GetAllInvoicesAsync()
        {
            return await hospitalSysDbContext.BillingInvoices.Include(b => b.Items).ToListAsync();
        }

        public async Task<BillingInvoice> GetInvoiceByIdAsync(long id)
        {
            var invoice = await hospitalSysDbContext.BillingInvoices
              .Include(x => x.Items)
             .FirstOrDefaultAsync(x => x.Id == id);

            if (invoice == null)
            {
                throw new KeyNotFoundException($"No Billing invoice found with ID {id}.");
            }

            return invoice;
        }

        public async Task UpdateInvoiceAsync(BillingInvoice invoice)
        {
            hospitalSysDbContext.BillingInvoices.Update(invoice);
            await hospitalSysDbContext.SaveChangesAsync();
        }

    }
}
