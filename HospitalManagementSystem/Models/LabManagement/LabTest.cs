namespace HospitalManagementSystem.Models.LabManagement
{
    public class LabTest
    {
        public long Id { get; set; }
        public long PatientId { get; set; }  // Foreign key to Patient
        public long DoctorId { get; set; }   // Foreign key to Doctor
        public string TestName { get; set; } = string.Empty;
        public DateTime TestDate { get; set; }
        public string Results { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        
    }
}
