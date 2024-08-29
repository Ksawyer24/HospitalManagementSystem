using AutoMapper;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.PatientManagement;

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

        }
    }
}
