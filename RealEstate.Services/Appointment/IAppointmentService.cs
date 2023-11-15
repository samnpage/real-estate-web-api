using RealEstate.Data.Entities;
using RealEstate.Models.Appointment;

namespace RealEstate.Services.Appointment
{
    public interface IAppointmentService
    {
        Task<AppointmentEntity> RegisterAppointmentAsync(AppointmentRegister model);
        Task<AppointmentDetail?> GetAppointmentByIdAsync(int Id);
    }
}