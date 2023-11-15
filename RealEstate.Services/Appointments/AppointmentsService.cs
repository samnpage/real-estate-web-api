using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Models.Agents;
using Microsoft.AspNetCore.Identity;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Appointments;
using RealEstate.Models.Buyer;
using RealEstate.Services.Appointments;

namespace inRealEstate.Services.Appointments
{
    public class AppointmentsService : IAppointmentsService
    {
        // Fields
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppointmentsEntity> _userManager;
        private readonly SignInManager<AppointmentsEntity> _signInManager;

        // Constructor that applies ApplicationDbContext's value to a readonly field above^.
        public AppointmentsService(ApplicationDbContext context,
                            UserManager<AppointmentsEntity> userManager,
                            SignInManager<AppointmentsEntity> signInManager)

        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }



        // public UserService(ApplicationDbContext context)
        // {
        //     _context = context;
        // }
        // CREATE METHOD.
        public async Task<bool> RegisterAppointmentsAsync(AppointmentsRegister model)
        {
            //  checks the returned value from both methods. If either return anything but null, we'll know it's invalid data.
            // if (await CheckDateTimedAvailability(model.AppointmentsId) == false)
            // {
            //     Console.WriteLine("Invalid Appointments, already in use");
            //     return false;
            // }
           

            // Calls our UserEntity entity and applys each property value collected to its respective property.
            AppointmentsEntity entity = new()
            {
                AgentId = model.AgentId,
                BuyerId = model.BuyerId,
                ListingId = model.ListingId,
                DateScheduled = DateTime.Now
            };

            IdentityResult registerResult = await _userManager.CreateAsync(entity);

            return registerResult.Succeeded;

            //Checks if username exists in the database or not.      
            // Adds our new entity object to _context.Users DbSet. This will add the entity to the Users table.
            // _context.Users.Add(entity);
            // Returns number of rows changed in the db and stores it into a variable.
            // int numberOfChanges = await _context.SaveChangesAsync();

            // returns a boolean value of true because we are expecting at least a single change.
            // return numberOfChanges == 1;

        }

        // GET METHOD. Gets user info by id. Returns null if it does not exist.
        public async Task<AppointmentsDetail?> GetAppointmentsByIdAsync(int Id)
        {
            AppointmentsEntity? entity = await _context.Appointments.FindAsync(Id);
            if (entity is null)
                return null;

            AppointmentsDetail detail = new()
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
        // private async Task<bool> CheckAppointmentsIdAvailability(string appointmentsId)
        // {
        //     AppointmentsEntity? existingUser = await _userManager.FindByAppointmentsIdAsync(appointmentsId);
        //     return existingUser is null;
        // }

        // // Checks whether the user's username is unique
        // private async Task<bool> CheckUserNameAvailability(string userName)
        // {
        //     AppointmentsEntity? existingUser = await _userManager.FindByNameAsync(userName);
        //     return existingUser is null;
        // }
    }
}
