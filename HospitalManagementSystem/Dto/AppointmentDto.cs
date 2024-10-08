﻿using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Dto
{
    public class AppointmentDto
    {
        public long AppointmentId { get; set; }
        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Time { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }


        // public PatientDto Patient { get; set; }

    }






    public class AddAppointmentDto
    {

        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Time { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

    }







    public class UpdateAppointmentDto
    {

        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Time { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }


    }
}





