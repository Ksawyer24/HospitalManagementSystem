﻿using HospitalManagementSystem.Models.PatientManagement;

namespace HospitalManagementSystem.Models.AppointmentManagement
{
    public class Appointment
    {
        public long AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsActive { get; set; } 
        public string Reason { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public Patient Patient { get; set; }


    }
}
