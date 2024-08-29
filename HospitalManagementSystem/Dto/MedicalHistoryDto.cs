using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Dto
{
    public class MedicalHistoryDto
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public List<string>? Conditions { get; set; }
        public List<string>? Medications { get; set; }
        public List<string>? Allergies { get; set; }
        public bool? HadSurgery { get; set; }
        public DateTime DateOfLastVisit { get; set; }
        public string? Notes { get; set; } = string.Empty;

       // public Patient Patient { get; set; }
    }




    public class AddMedicalHistory
    {
        public long PatientId { get; set; }
        public List<string>? Conditions { get; set; }
        public List<string>? Medications { get; set; }
        public List<string>? Allergies { get; set; }
        public bool? HadSurgery { get; set; }
        public DateTime DateOfLastVisit { get; set; }
        public string? Notes { get; set; } = string.Empty;
    }



    public class UpdateMedicalHistory
    {
        public long PatientId { get; set; }
        public List<string>? Conditions { get; set; }
        public List<string>? Medications { get; set; }
        public List<string>? Allergies { get; set; }
        public bool? HadSurgery { get; set; }
        public DateTime DateOfLastVisit { get; set; }
        public string? Notes { get; set; } = string.Empty;
    }
}
