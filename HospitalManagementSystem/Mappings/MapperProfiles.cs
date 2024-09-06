using AutoMapper;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.DoctorManagement;
using HospitalManagementSystem.Models.LabManagement;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Models.PharmacyManagement;
using HospitalManagementSystem.Models.StaffManagement;

namespace HospitalManagementSystem.Mappings
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<AddPatientDto, Patient>().ReverseMap();
            CreateMap<UpdatePatientDto, Patient>().ReverseMap();

            CreateMap<MedicalHistory, MedicalHistoryDto>().ReverseMap();
            CreateMap<AddMedicalHistory, MedicalHistory>().ReverseMap();
            CreateMap<UpdateMedicalHistory, MedicalHistory>().ReverseMap();

            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<AddDoctorDto, Doctor>().ReverseMap();
            CreateMap<UpdateDoctorDto, Doctor>().ReverseMap();

            CreateMap<Staff, StaffDto>().ReverseMap();
            CreateMap<AddStaffDto, Staff>().ReverseMap();
            CreateMap<UpdateStaffDto, Staff>().ReverseMap();

            CreateMap<Prescriptions, PrescriptionDto>().ReverseMap();
            CreateMap<AddPrescriptionDto, Prescriptions>().ReverseMap();
            CreateMap<UpdatePrescription, Prescriptions>().ReverseMap();

            CreateMap<Inventory, PrescriptionDto>().ReverseMap();
            CreateMap<AddInventoryDto, Inventory>().ReverseMap();
            CreateMap<UpdateInventoryDto, Inventory>().ReverseMap();

            CreateMap<LabTest, PrescriptionDto>().ReverseMap();
            //CreateMap<AddPrescriptionDto, Prescriptions>().ReverseMap();
            //CreateMap<UpdatePrescription, Prescriptions>().ReverseMap();



        }
    }
}



















