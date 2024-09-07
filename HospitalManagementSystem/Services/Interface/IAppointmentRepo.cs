using HospitalManagementSystem.Models.AppointmentManagement;
using HospitalManagementSystem.Models.LabManagement;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IAppointmentRepo
    {
        Task<List<Appointment>> GetAllAppointmentsAsync();

        Task<Appointment?> GetAppointmentsIdAsync(long id);

        Task<Appointment> CreateAsync(Appointment labTest);

        Task<Appointment?> UpdateAppointmentsAsync(long id, Appointment labTest);

        Task<Appointment?> DeleteAppointmentsAsync(long id);
    }
}
