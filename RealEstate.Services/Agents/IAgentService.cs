using RealEstate.Data.Entities;
using RealEstate.Models.Agent;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Agent;
public interface IAgentService
{
    // CREATE
    Task<bool> RegisterAgentAsync(AgentRegister model);

    // READ
    Task<List<AgentEntity>> GetAllAgentsAsync();
    Task<AgentDetail?> GetAgentByIdAsync(int agentId);

    // UPDATE
    Task<AgentEntity?> UpdateAgentByIdAsync(int id, UpdateAgent updatedAgent);

    // DELETE
    Task<TextResponse> DeleteAgentByIdAsync(int id);
}