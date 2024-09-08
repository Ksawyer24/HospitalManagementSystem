using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.PharmacyManagement
{
    public class Inventory
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfDelivery { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public string Supplier { get; set; } = string.Empty;

        [Phone]
        public string SupplierContact { get; set; } = string.Empty;


    }
}
