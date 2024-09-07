using HospitalManagementSystem.Models.Billing_Management;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dto
{
    public class BillingInvoiceDto
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


    public class AdddBillingInvoiceDto
    {
       
        public string InvoiceNumber { get; set; } = string.Empty;
        public string Patient { get; set; } = string.Empty;
        public string PatientAddress { get; set; } = string.Empty;

        [Phone]
        public string PatientContact { get; set; } = string.Empty;

        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();

        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);

    }

    public class InvoiceItemDto
    {
        public long Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

      
      //  public decimal TotalPrice => UnitPrice * Quantity;
    }
}
