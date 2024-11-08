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

        public ICollection<InvoiceItem> Items { get; set; }

        public decimal TotalAmount
        {
            get
            {
                return Items?.Sum(item => item.UnitPrice * item.Quantity) ?? 0;
            }
        }

    }


    public class AdddBillingInvoiceDto
    {

        public string InvoiceNumber { get; set; } = string.Empty;
        public string Patient { get; set; } = string.Empty;
        public string PatientAddress { get; set; } = string.Empty;

        [Phone]
        public string PatientContact { get; set; } = string.Empty;

        public ICollection<InvoiceItem> Items { get; set; }

        public decimal TotalAmount
        {
            get
            {
                return Items?.Sum(item => item.UnitPrice * item.Quantity) ?? 0;
            }
        }



    }

    public class InvoiceItemDto
    {
       // public long InvoiceItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

      
      //  public decimal TotalPrice => UnitPrice * Quantity;
    }
}
