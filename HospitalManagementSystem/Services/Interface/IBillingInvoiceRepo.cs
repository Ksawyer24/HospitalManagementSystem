using HospitalManagementSystem.Models.AppointmentManagement;
using HospitalManagementSystem.Models.Billing_Management;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IBillingInvoiceRepo
    {
        Task<List<BillingInvoice>> GetAllInvoicesAsync();
        Task<BillingInvoice> GetInvoiceByIdAsync(long id);
        Task AddInvoiceAsync(BillingInvoice invoice);
        Task UpdateInvoiceAsync(BillingInvoice invoice);
        Task DeleteInvoiceAsync(long id);
    }
}
