using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.StaffManagement
{
    public class Staff
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int YearsOfEmployment { get; set; }
        public string WorkingDays { get; set; } = string.Empty;

       
    }
}
