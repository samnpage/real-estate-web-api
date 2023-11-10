using ElevenNote.Models.Agents;
using RealEstate.Models.Agents;

namespace RealEstate.Services.Agents;
public interface IAgentsService
{
    Task<bool> RegisterAgentsAsync(AgentsRegister model);
    Task<AgentsDetail?> GetAgentByIdAsync(int agentId);
}