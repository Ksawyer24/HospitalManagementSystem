namespace HospitalManagementSystem.Models.Billing_Management
{
    public class BiilingInvoice
    {
        public long Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string Patient { get; set; } = string.Empty;
        public string PatientAddress { get; set; } = string.Empty;
        public string PatientContact { get; set; } = string.Empty;

         public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
         
           private decimal CalculateTotalAmount()
           {

              decimal total = 0;
              foreach (var item in Items)
              {
                total += item.Quantity * item.UnitPrice;

              }
           
              return total;

           }

        public decimal Total => CalculateTotalAmount(); 
         


    }
}
