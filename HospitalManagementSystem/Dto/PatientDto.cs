using HospitalManagementSystem.Models.AppointmentManagement;
using HospitalManagementSystem.Models.LabManagement;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Models.PharmacyManagement;

namespace HospitalManagementSystem.Dto
{
    public class PatientDto
    {
        public long Id { get; set; }
        public string PatientName { get; set; } = string.Empty;

        public string PatientContact { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string NameOfEmergencyContact { get; set; } = string.Empty;

        public string PhoneNumberOfContact { get; set; } = string.Empty;

        public bool? InsuranceIsActive { get; set; }

       // public MedicalHistory MedicalHistory { get; set; }

    }


    public class AddPatientDto
    {

        public string PatientName { get; set; } = string.Empty;

        public string PatientContact { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string NameOfEmergencyContact { get; set; } = string.Empty;

        public string PhoneNumberOfContact { get; set; } = string.Empty;

        public bool? InsuranceIsActive { get; set; }

       

        public AddMedicalHistory MedicalHistory { get; set; }

    }



    public class UpdatePatientDto
    {
        public string PatientName { get; set; } = string.Empty;

        public string PatientContact { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string NameOfEmergencyContact { get; set; } = string.Empty;

        public string PhoneNumberOfContact { get; set; } = string.Empty;

        public bool? InsuranceIsActive { get; set; }

    }

  


}
