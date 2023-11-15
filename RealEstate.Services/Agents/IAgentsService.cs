using ElevenNote.Models.Agents;
using RealEstate.Data.Entities;
using RealEstate.Models.Agents;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Agents;
public interface IAgentsService
{
    // CREATE
    Task<bool> RegisterAgentsAsync(AgentsRegister model);

    // READ
    Task<List<AgentsEntity>> GetAllAgentsAsync();
    Task<AgentsDetail?> GetAgentByIdAsync(int agentId);

    // UPDATE
    Task<AgentsEntity?> UpdateAgentByIdAsync(int id, UpdateAgent updatedAgent);

    // DELETE
    Task<TextResponse> DeleteAgentByIdAsync(int id);
}