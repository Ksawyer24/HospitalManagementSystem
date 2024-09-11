using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Models.PharmacyManagement
{
    public class Prescriptions
    {
        public long Id { get; set; }    
        public string Name { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public DateTime DateIssued { get; set; }   

        public long PatientId { get; set; }

        public Patient? Patient { get; set; }

    }
}
