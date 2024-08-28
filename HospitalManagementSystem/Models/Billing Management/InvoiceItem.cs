using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Billing_Management
{
    public class InvoiceItem
    {
        public long Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }
        public long InvoiceId { get; set; }
       public BiilingInvoice Invoice { get; set; }
    }
}
