using RealEstate.Data.Entities;
using RealEstate.Models.Agent;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Agent;
public interface IAgentService
{
    // CREATE
    Task<bool> RegisterAgentAsync(AgentRegister model);

    // READ
    Task<List<AgentDetail>> GetAllAgentsAsync();
    Task<AgentDetail?> GetAgentByIdAsync(int agentId);

    // UPDATE
    Task<TextResponse> UpdateAgentByIdAsync(int id, AgentUpdate updatedAgent);

    // DELETE
    Task<TextResponse> DeleteAgentByIdAsync(int id);
}