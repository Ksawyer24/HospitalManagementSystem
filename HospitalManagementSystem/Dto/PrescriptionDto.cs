using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Dto
{
    public class PrescriptionDto
    {

        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public DateTime DateIssued { get; set; }

        public long PatientId { get; set; }

        public PatientDto Patient { get; set; }
    }


    public class AddPrescriptionDto
    {
        public string Name { get; set; } = string.Empty;

        public string Dosage { get; set; } = string.Empty;

        public DateTime DateIssued { get; set; }

        public long PatientId { get; set; }

        public Patient Patient { get; set; }

    }


    public class UpdatePrescription
    {
        public string Name { get; set; } = string.Empty;

        public string Dosage { get; set; } = string.Empty;

        public DateTime DateIssued { get; set; }

        public long PatientId { get; set; }

        public Patient Patient { get; set; }

    }
}
