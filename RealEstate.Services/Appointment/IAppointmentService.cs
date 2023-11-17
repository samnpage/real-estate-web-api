using RealEstate.Data.Entities;
using RealEstate.Models.Appointment;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Appointment
{
    public interface IAppointmentService
    {
        // Create Method
        Task<AppointmentEntity> RegisterAppointmentAsync(AppointmentRegister model);

        // Read Method
        Task<AppointmentDetail?> GetAppointmentByIdAsync(int Id);

        Task<IEnumerable<AppointmentEntity>> GetAllAppointmentsAsync();
    
        // Update Method
        Task<TextResponse> UpdateAppointmentByIdAsync(int id, UpdateAppointment updateAppointment);
        
        // Delete Method
        Task<TextResponse> DeleteAppointmentAsync(int id);
    }
}