using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Models.Agents;
using RealEstate.Data.Entities;
using RealEstate.Models.Appointments;

namespace RealEstate.Services.Appointments
{
    public interface IAppointmentsService
    {
        Task<bool> RegisterAppointmentsAsync(AppointmentsRegister model);
        Task<AppointmentsDetail?> GetAppointmentsByIdAsync(int Id);
    }
}