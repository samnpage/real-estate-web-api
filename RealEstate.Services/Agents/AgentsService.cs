using ElevenNote.Models.Agents;
using Microsoft.AspNetCore.Identity;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Agents;

namespace RealEstate.Services.Agents;
public class AgentsService : IAgentsService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<AgentsEntity> _userManager;
    private readonly SignInManager<AgentsEntity> _signInManager;

    // Constructor that applies ApplicationDbContext's value to a readonly field above^.
    public AgentsService(ApplicationDbContext context,
                        UserManager<AgentsEntity> userManager,
                        SignInManager<AgentsEntity> signInManager)

    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }



    // public UserService(ApplicationDbContext context)
    // {
    //     _context = context;
    // }

    // CREATE METHOD
    public async Task<bool> RegisterAgentsAsync(AgentsRegister model)
    {
        //  checks the returned value from both methods. If either return anything but null, we'll know it's invalid data.
        if (await CheckEmailAvailability(model.Email) == false)
        {
            Console.WriteLine("Invalid email, already in use");
            return false;
        }
        if (await CheckUserNameAvailability(model.UserName) == false)
        {
            Console.WriteLine("Invalid username, already in use.");
            return false;
        }

        // Calls our UserEntity entity and applys each property value collected to its respective property.
        AgentsEntity entity = new()
        {
            Email = model.Email,
            UserName = model.UserName,
            DateCreated = DateTime.Now
        };

        IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);

        return registerResult.Succeeded;

        //Checks if username exists in the database or not.      
        // Adds our new entity object to _context.Users DbSet. This will add the entity to the Users table.
        // _context.Users.Add(entity);
        // Returns number of rows changed in the db and stores it into a variable.
        // int numberOfChanges = await _context.SaveChangesAsync();

        // returns a boolean value of true because we are expecting at least a single change.
        // return numberOfChanges == 1;

    }

    // READ METHOD
    public async Task<AgentsDetail?> GetAgentByIdAsync(int agentId)
    {
        AgentsEntity? entity = await _context.Users.FindAsync(agentId);
        if (entity is null)
            return null;

        AgentsDetail detail = new()
        {
            Id = entity.Id,
            Email = entity.Email!,
            UserName = entity.UserName!,
            FirstName = entity.FirstName!,
            LastName = entity.LastName,
            DateCreated = entity.DateCreated
        };

        return detail;
    }

    // UPDATE METHOD
    // DELETE METHOD

    // HELPER METHODS
    // Checks whether the user's email is unique
    private async Task<bool> CheckEmailAvailability(string email)
    {
        AgentsEntity? existingAgent = await _userManager.FindByEmailAsync(email);
        return existingAgent is null;
    }

    // Checks whether the user's username is unique
    private async Task<bool> CheckUserNameAvailability(string userName)
    {
        AgentsEntity? existingAgent = await _userManager.FindByNameAsync(userName);
        return existingAgent is null;
    }
}