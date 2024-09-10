using HospitalManagementSystem.Models.AppointmentManagement;
using HospitalManagementSystem.Models.LabManagement;
using HospitalManagementSystem.Models.PharmacyManagement;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HospitalManagementSystem.Models.PatientManagement
{
    public class Patient
    {
        public long Id { get; set; }
        public string PatientName { get; set; } = string.Empty;

        [Phone]
        public string PatientContact { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }   

        public string NameOfEmergencyContact { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumberOfContact { get; set; } = string.Empty;

        public bool? InsuranceIsActive { get; set; }

        public ICollection<Appointment>Appointments { get; set; } = new List<Appointment>();
 
        [JsonIgnore]
        public ICollection<Prescriptions> Prescriptions { get; set; } = new List<Prescriptions>();

        public ICollection<LabTest> Labs { get; set; } = new List<LabTest>();

        public MedicalHistory MedicalHistory { get; set; }





    }
}
