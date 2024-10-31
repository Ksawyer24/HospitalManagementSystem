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
        public bool HadSurgery { get; set; }
        public string? Notes { get; set; } = string.Empty;

      
    }




    public class AddMedicalHistory
    {
      
        public List<string>? Conditions { get; set; }
        public List<string>? Medications { get; set; }
        public List<string>? Allergies { get; set; }
        public bool HadSurgery { get; set; }
        public string? Notes { get; set; } = string.Empty;
    }



    public class UpdateMedicalHistory
    {
       
        public List<string>? Conditions { get; set; }
        public List<string>? Medications { get; set; }
        public List<string>? Allergies { get; set; }
        public bool HadSurgery { get; set; }
        public string? Notes { get; set; } = string.Empty;
    }
}
