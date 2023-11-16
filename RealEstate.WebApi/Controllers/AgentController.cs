using RealEstate.Models.Agent;
using RealEstate.Models.Responses;
using RealEstate.Services.Agent;
using Microsoft.AspNetCore.Mvc;

namespace ElevenNote.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgentController : ControllerBase
{
    // Fields that access our services
    private readonly IAgentService _agentService;

    // Constructor
    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }

    // POST Method
    [HttpPost("Register")]
    [ProducesResponseType(typeof(IEnumerable<AgentRegister>), 200)]
    public async Task<IActionResult> RegisterAgent([FromBody] AgentRegister model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var registerResult = await _agentService.RegisterAgentAsync(model);
        if (registerResult)
        {
            TextResponse response = new("Agent was successfully registered.");
            return Ok(response);
        }

        return BadRequest(new TextResponse("Agent registration unsuccessful. The agent you are trying to register already exists in the database."));
    }

    // GET Methods
    // GET all
    [HttpGet]
    public async Task<IActionResult> GetAllAgents()
    {
        var result = await _agentService.GetAllAgentsAsync();

        if (result != null && result.Any())
            return Ok(result);

        return BadRequest(new TextResponse("There are no agents in the database"));
    }
    
    // GET by Id
    [HttpGet("{agentId:int}")]
    public async Task<IActionResult> GetById([FromRoute] int agentId)
    {
        AgentDetail? detail = await _agentService.GetAgentByIdAsync(agentId);

        if (detail is null)
        {
            return NotFound();
        }

        return Ok(detail);
    }

    // PUT Method
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBuyerById([FromRoute] int id, [FromBody] UpdateAgent request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _agentService.UpdateAgentByIdAsync(id, request);

        if (response is not null)
            return Ok(response);

        return BadRequest(response);
    }

    // DELETE Method
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBuyerById([FromRoute] int id)
    {
        TextResponse response = await _agentService.DeleteAgentByIdAsync(id);

        return response is not null
                ? Ok(response)
                : NotFound();
    }
}