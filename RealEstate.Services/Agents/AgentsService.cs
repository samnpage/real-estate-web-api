using ElevenNote.Models.Agents;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Agents;
using RealEstate.Models.Responses;

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

        // Calls our AgentsEntity and applys each property value collected to its respective property.
        AgentsEntity entity = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
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

    // READ METHODS

    // READ All
    public async Task<List<AgentsEntity>> GetAllAgentsAsync()
    {
        var agents = await _context.Users.ToListAsync();
        return agents;
    }

    // READ by Id
    public async Task<AgentsDetail?> GetAgentByIdAsync(int agentId)
    {
        AgentsEntity? entity = await _context.Users.FindAsync(agentId);
        if (entity is null)
            return null;

        AgentsDetail detail = new()
        {
            Id = entity.Id,
            FirstName = entity.FirstName!,
            LastName = entity.LastName,
            Email = entity.Email!,
            UserName = entity.UserName!,
            DateCreated = entity.DateCreated
        };

        return detail;
    }

    // UPDATE METHOD
    public async Task<AgentsEntity?> UpdateAgentByIdAsync(int id, UpdateAgent updatedAgent)
    {
        var currentAgent = await _context.Users.FindAsync(id);

        if (currentAgent != null)
        {
            currentAgent.FirstName = updatedAgent.FirstName;
            currentAgent.LastName = updatedAgent.LastName;
            currentAgent.Email = updatedAgent.Email;
            currentAgent.UserName = updatedAgent.UserName;

            await _context.SaveChangesAsync();       
        }

        return currentAgent;
    }
    
    // DELETE METHOD
    public async Task<TextResponse> DeleteAgentByIdAsync(int id)
        {
            var agentToDelete = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);

            if (agentToDelete != null)
            {
                _context.Users.Remove(agentToDelete);
                await _context.SaveChangesAsync();
            }

            TextResponse response = new ("Agent successfully deleted");

            return response;
        }

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