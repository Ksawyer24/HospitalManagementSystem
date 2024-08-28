namespace HospitalManagementSystem.Models.StaffManagement
{
    public class Staff
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public string Position { get; set; } = string.Empty ;

        public string Shift { get; set; } = string.Empty;

       
    }
}
