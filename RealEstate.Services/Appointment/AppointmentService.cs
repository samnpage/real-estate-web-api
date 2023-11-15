using Microsoft.AspNetCore.Identity;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Appointment;

namespace RealEstate.Services.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        // Fields
        private readonly ApplicationDbContext _context;

        // Constructor that applies ApplicationDbContext's value to a readonly field above^.
        public AppointmentService(ApplicationDbContext context)

        {
            _context = context;
        }



        // public UserService(ApplicationDbContext context)
        // {
        //     _context = context;
        // }
        // CREATE METHOD.
        public async Task<AppointmentEntity> RegisterAppointmentAsync(AppointmentRegister model)
        {
            //  checks the returned value from both methods. If either return anything but null, we'll know it's invalid data.
            // if (await CheckDateTimedAvailability(model.AppointmentId) == false)
            // {
            //     Console.WriteLine("Invalid Appointment, already in use");
            //     return false;
            // }

            // Calls our UserEntity entity and applys each property value collected to its respective property.
            AppointmentEntity entity = new()
            {
                AgentId = model.AgentId,
                BuyerId = model.BuyerId,
                ListingId = model.ListingId,
                DateScheduled = DateTime.Now
            };
            
            await _context.SaveChangesAsync();
            return entity;

            //Checks if username exists in the database or not.      
            // Adds our new entity object to _context.Users DbSet. This will add the entity to the Users table.
            // _context.Users.Add(entity);
            // Returns number of rows changed in the db and stores it into a variable.
            // int numberOfChanges = await _context.SaveChangesAsync();

            // returns a boolean value of true because we are expecting at least a single change.
            // return numberOfChanges == 1;

        }

        // GET METHOD. Gets user info by id. Returns null if it does not exist.
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
                DateCreated = DateTime.Now
            };

            return detail;
        }

        // Helper Methods
        // Checks whether the user's email is unique
        // private async Task<bool> CheckAppointmentIdAvailability(string appointmentId)
        // {
        //     AppointmentEntity? existingUser = await _userManager.FindByAppointmentIdAsync(appointmentId);
        //     return existingUser is null;
        // }

        // // Checks whether the user's username is unique
        // private async Task<bool> CheckUserNameAvailability(string userName)
        // {
        //     AppointmentEntity? existingUser = await _userManager.FindByNameAsync(userName);
        //     return existingUser is null;
        // }
    }
}
