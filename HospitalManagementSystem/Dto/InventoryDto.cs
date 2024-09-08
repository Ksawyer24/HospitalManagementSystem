using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dto
{
    public class InventoryDto
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



    public class AddInventoryDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfDelivery { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public string Supplier { get; set; } = string.Empty;

        [Phone]
        public string SupplierContact { get; set; } = string.Empty;
    }



    public class UpdateInventoryDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfDelivery { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public string Supplier { get; set; } = string.Empty;

        [Phone]
        public string SupplierContact { get; set; } = string.Empty;
    }
}
