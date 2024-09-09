using AutoMapper;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.AppointmentManagement;
using HospitalManagementSystem.Models.Billing_Management;
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
            //CreateMap<Patient, PatientDto>().ReverseMap();
             CreateMap<Patient, PatientDto>()
            .ForMember(dest => dest.MedicalHistory, opt => opt.MapFrom(src => src.MedicalHistory));


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

            CreateMap<Inventory, InventoryDto>().ReverseMap();
            CreateMap<AddInventoryDto, Inventory>().ReverseMap();
            CreateMap<UpdateInventoryDto, Inventory>().ReverseMap();

            CreateMap<LabTest, LabTestDto>().ReverseMap();
            CreateMap<AddLabTestDto, LabTest>().ReverseMap();
            CreateMap<UpdateLabTestDto, LabTest>().ReverseMap();

            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<AddAppointmentDto, Appointment>().ReverseMap();
            CreateMap<UpdateAppointmentDto, Appointment>().ReverseMap();

            CreateMap<BillingInvoice, BillingInvoiceDto>().ReverseMap();
            CreateMap<AdddBillingInvoiceDto, BillingInvoice>().ReverseMap();


        }
    }
}



















