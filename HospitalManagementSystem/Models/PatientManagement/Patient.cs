using HospitalManagementSystem.Models.AppointmentManagement;
using HospitalManagementSystem.Models.LabManagement;
using HospitalManagementSystem.Models.PharmacyManagement;

namespace HospitalManagementSystem.Models.PatientManagement
{
    public class Patient
    {
        public long Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }   
        public string NameOfEmergencyContact { get; set; } = string.Empty;

        public string PhoneNumberOfContact { get; set; } = string.Empty;

        public bool? InsurancIsActive { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public ICollection<Prescriptions> Prescriptions { get; set; } = new List<Prescriptions>();

        public ICollection<LabTest> Labs { get; set; } = new List<LabTest>();


        public MedicalHistory MedicalHistory { get; set; }





    }
}
