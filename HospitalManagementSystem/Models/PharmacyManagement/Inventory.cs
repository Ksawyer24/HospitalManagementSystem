﻿namespace HospitalManagementSystem.Models.PharmacyManagement
{
    public class Inventory
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public string Supplier { get; set; } = string.Empty;


    }
}
