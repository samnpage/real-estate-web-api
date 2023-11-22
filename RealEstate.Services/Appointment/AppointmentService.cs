using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Appointment;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Appointment;

    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        public AppointmentService(ApplicationDbContext context)

        {
            _context = context;
        }

    
      

        // CREATE METHOD.
        public async Task<AppointmentEntity> RegisterAppointmentAsync(AppointmentRegister model)
        {
            AppointmentEntity entity = new()
            {
                AgentId = model.AgentId,
                BuyerId = model.BuyerId,
                ListingId = model.ListingId,
                FeedBack = model.FeedBack,
                DateScheduled = DateTime.Now
            };
            _context.Add (entity);
            
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<AppointmentEntity>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        // GET METHOD.
        public async Task<AppointmentDetail?> GetAppointmentByIdAsync(int Id)
        {
            AppointmentEntity? entity = await _context.Appointments.FindAsync(Id);
            if (entity is null)
                return null;

            AppointmentDetail detail = new()
            {

                AgentId = entity.AgentId,
                BuyerId = entity.BuyerId,
                ListingId = entity.ListingId,
                FeedBack = entity.FeedBack,
                DateCreated = DateTime.Now

            };

            return detail;
        }

        //update method
        public async Task<TextResponse> UpdateAppointmentByIdAsync(int id, UpdateAppointment updateAppointment)
        {
            var existingAppointment = await _context.Appointments.FirstOrDefaultAsync(l => l.Id == id);

            if (existingAppointment != null)
            {  
                existingAppointment.AgentId = updateAppointment.AgentId;
                existingAppointment.BuyerId = updateAppointment.BuyerId;
                existingAppointment.ListingId = updateAppointment.ListingId;
                existingAppointment.FeedBack = updateAppointment.FeedBack;

                await _context.SaveChangesAsync();
                return new TextResponse("update was successful");
            }

            return new TextResponse("Update was unsuccessful");
        }

        //delete method
        public async Task<TextResponse> DeleteAppointmentAsync(int id)
        {
            var appointmentToDelete = await _context.Appointments.FirstOrDefaultAsync(l => l.Id == id);

            
            if (appointmentToDelete != null)
            {
                _context.Appointments.Remove(appointmentToDelete);
                await _context.SaveChangesAsync();
            }
            return new TextResponse("Appointment successfully deleted");
        }
    }
