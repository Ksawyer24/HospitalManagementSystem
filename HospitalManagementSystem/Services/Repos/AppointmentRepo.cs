using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.AppointmentManagement;
using HospitalManagementSystem.Models.LabManagement;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Services.Repos
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;

        public AppointmentRepo(HospitalSysDbContext hospitalSysDbContext)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
        }


        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            appointment.AppointmentDate = DateTime.SpecifyKind(appointment.AppointmentDate, DateTimeKind.Utc);
            appointment.CreatedDate = DateTime.SpecifyKind(appointment.CreatedDate, DateTimeKind.Utc);
            await hospitalSysDbContext.AddAsync(appointment);
            await hospitalSysDbContext.SaveChangesAsync();
            return appointment;
        }


        public async Task<Appointment?> DeleteAppointmentsAsync(long id)
        {
            var existing = await hospitalSysDbContext.Appointments.FirstOrDefaultAsync(x => x.AppointmentId == id);

            if (existing == null)
            {
                return null;

            }

            hospitalSysDbContext.Appointments.Remove(existing);
            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }


        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await hospitalSysDbContext.Appointments.ToListAsync();
        }

        public async Task<Appointment?> GetAppointmentsIdAsync(long id)
        {
           return await hospitalSysDbContext.Appointments.FirstOrDefaultAsync(x=> x.AppointmentId == id);
        }

        public async Task<Appointment?> UpdateAppointmentsAsync(long id, Appointment appointment)
        {
            var existing = await hospitalSysDbContext.Appointments.FirstOrDefaultAsync(x => x.AppointmentId == id);

            if (existing == null)
            {
                return null;
            }


            existing.PatientId = appointment.PatientId;
            existing.DoctorId = appointment.DoctorId;
            existing.AppointmentDate = DateTime.SpecifyKind(appointment.AppointmentDate, DateTimeKind.Utc);
            existing.Time = appointment.Time;
            existing.IsActive = appointment.IsActive;
            existing.Reason = appointment.Reason;
            existing.Notes = appointment.Notes;
            existing.CreatedDate = DateTime.SpecifyKind(appointment.CreatedDate, DateTimeKind.Utc);



            await hospitalSysDbContext.SaveChangesAsync();
            return existing;
        }
    }
}
