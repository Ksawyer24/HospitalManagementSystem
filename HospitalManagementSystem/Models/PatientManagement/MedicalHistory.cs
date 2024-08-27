namespace HospitalManagementSystem.Models.PatientManagement
{
    public class MedicalHistory
    {
        public long HistoryId { get; set; }
        public long PatientId { get; set; }
        public List<string> Conditions { get; set; } = new List<string>();
        public List<string>? Medications { get; set; } = new List<string>();
        public List<string>? Allergies { get; set; } = new List<string>();
        public bool? HadSurgery { get; set; }
        public DateTime DateOfLastVisit { get; set; }
        public string? Notes { get; set; } = string.Empty;

        public Patient Patient { get; set; } 


    }
}
