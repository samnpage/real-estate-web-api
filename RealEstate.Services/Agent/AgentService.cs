using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Agent;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Agent;
public class AgentService : IAgentService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<AgentEntity> _userManager;
    private readonly SignInManager<AgentEntity> _signInManager;

    public AgentService(ApplicationDbContext context,
                        UserManager<AgentEntity> userManager,
                        SignInManager<AgentEntity> signInManager)

    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // CREATE METHOD
    public async Task<bool> RegisterAgentAsync(AgentRegister model)
    {
        // Check email availability
        if (!await CheckEmailAvailability(model.Email))
        {
            Console.WriteLine("Invalid email, already in use");
            return false;
        }

        // Check username availability
        if (!await CheckUserNameAvailability(model.UserName))
        {
            Console.WriteLine("Invalid username, already in use.");
            return false;
        }

        AgentEntity entity = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserName = model.UserName,
            DateCreated = DateTime.Now
        };

        IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);

        return registerResult.Succeeded;
    }

    // READ METHODS

    // READ All
    public async Task<List<AgentDetail>> GetAllAgentsAsync()
    {
        var agents = await _context.Users.ToListAsync();
        var agentDetails = new List<AgentDetail>();

        foreach (var agent in agents)
        {
            var detail = new AgentDetail
            {
                Id = agent.Id,
                FirstName = agent.FirstName,
                LastName = agent.LastName,
                Email = agent.Email!,
                UserName = agent.UserName!,
                DateCreated = agent.DateCreated
            };

            agentDetails.Add(detail);
        }

        return agentDetails;
    }

    // READ by Id
    public async Task<AgentDetail?> GetAgentByIdAsync(int agentId)
    {
        AgentEntity? entity = await _context.Users.FindAsync(agentId);
        if (entity is null)
            return null;

        AgentDetail detail = new()
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
    public async Task<TextResponse> UpdateAgentByIdAsync(int id, AgentUpdate updatedAgent)
    {
        var currentAgent = await _context.Users.FindAsync(id);

        if (currentAgent != null)
        {
            bool hasChanges = false;

            if (currentAgent.FirstName != updatedAgent.FirstName)
            {
                currentAgent.FirstName = updatedAgent.FirstName;
                hasChanges = true;
            }

            if (currentAgent.LastName != updatedAgent.LastName)
            {
                currentAgent.LastName = updatedAgent.LastName;
                hasChanges = true;
            }

            if (currentAgent.Email != updatedAgent.Email)
            {
                currentAgent.Email = updatedAgent.Email;
                hasChanges = true;
            }

            if (currentAgent.UserName != updatedAgent.UserName)
            {
                currentAgent.UserName = updatedAgent.UserName;
                hasChanges = true;
            }

            if (hasChanges)
            {
                await _context.SaveChangesAsync();
                return new TextResponse("Agent updated successfully"); // Assuming you want to return the updated agent on success
            }
            else
            {
                return new TextResponse("Update Unsuccesful. No changes detected.");
            }
        }

        return new TextResponse("Update Unsuccessful. Agent not found.");
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

        TextResponse response = new("Agent successfully deleted");

        return response;
    }

    // HELPER METHODS
    // Checks whether the user's email is unique
    private async Task<bool> CheckEmailAvailability(string email)
    {
        AgentEntity? existingAgent = await _userManager.FindByEmailAsync(email);
        return existingAgent is null;
    }

    // Checks whether the user's username is unique
    private async Task<bool> CheckUserNameAvailability(string userName)
    {
        AgentEntity? existingAgent = await _userManager.FindByNameAsync(userName);
        return existingAgent is null;
    }
}