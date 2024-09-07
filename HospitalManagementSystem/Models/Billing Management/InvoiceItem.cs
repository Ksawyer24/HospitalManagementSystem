namespace HospitalManagementSystem.Models.Billing_Management
{
    public class InvoiceItem
    {
       public long Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
