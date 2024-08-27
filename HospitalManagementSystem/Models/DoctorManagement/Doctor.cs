namespace HospitalManagementSystem.Models.DoctorManagement
{
    public class Doctor
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Specialization { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public string ContactNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string WorkingDays { get; set; } = string.Empty;

    }
}
