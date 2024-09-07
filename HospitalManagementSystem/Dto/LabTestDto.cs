using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Dto
{
    public class LabTestDto
    {
        public long Id { get; set; }
        public long PatientId { get; set; }  // Foreign key to Patient
        public string MLS { get; set; } = string.Empty;
        public string ReviewedBy { get; set; } = string.Empty;
        public string TestName { get; set; } = string.Empty;
        public DateTime TestDate { get; set; }
        public string Results { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;


       // public PatientDto Patient { get; set; }
    }

    public class AddLabTestDto
    {
       
        public long PatientId { get; set; }  // Foreign key to Patient
        public string MLS { get; set; } = string.Empty;
        public string ReviewedBy { get; set; } = string.Empty;
        public string TestName { get; set; } = string.Empty;
        public DateTime TestDate { get; set; }
        public string Results { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;


       // public PatientDto Patient { get; set; }
    }



    public class UpdateLabTestDto
    {
        
        public long PatientId { get; set; }  // Foreign key to Patient
        public string MLS { get; set; } = string.Empty;
        public string ReviewedBy { get; set; } = string.Empty;
        public string TestName { get; set; } = string.Empty;
        public DateTime TestDate { get; set; }
        public string Results { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;


        
    }
}
