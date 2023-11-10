using ElevenNote.Models.Agents;
using RealEstate.Models.Agents;

namespace RealEstate.Services.Agents;
public interface IAgentsService
{
    // CREATE
    Task<bool> RegisterAgentsAsync(AgentsRegister model);

    // READ
    Task<AgentsDetail?> GetAgentByIdAsync(int agentId);

    // UPDATE
    
    // DELETE
}