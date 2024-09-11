using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Models.LabManagement
{
    public class LabTest
    {
        public long Id { get; set; }
        public long PatientId { get; set; }  // Foreign key to Patient
        public string MLS { get; set; }  = string.Empty; //Medical Laboratory Scientist
        public string ReviewedBy { get; set; } = string.Empty;
        public string TestName { get; set; } = string.Empty;
        public DateTime TestDate { get; set; }
        public string Results { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;


        public Patient? Patient { get; set; }
        
    }
}
