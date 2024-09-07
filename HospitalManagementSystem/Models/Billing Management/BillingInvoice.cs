using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Billing_Management
{
    public class BillingInvoice
    {
        public long Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string Patient { get; set; } = string.Empty;
        public string PatientAddress { get; set; } = string.Empty;

        [Phone]
        public string PatientContact { get; set; } = string.Empty;

        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();

        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);


    }
}
