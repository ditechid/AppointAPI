using AppointAPI.Models;

namespace AppointAPI.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByCodeAsync(string code);
        Task<bool> CreateAppointmentAsync(AppointmentDTO Appointment);
        Task<bool> UpdateAppointmentAsync(AppointmentDTO Appointment);
        Task<bool> DeleteAppointmentAsync(string code);
    }
}
