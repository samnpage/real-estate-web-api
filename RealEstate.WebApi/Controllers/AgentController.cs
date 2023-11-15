using RealEstate.Models.Agent;
using RealEstate.Models.Responses;
using RealEstate.Services.Agent;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Data.Entities;

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
            TextResponse response = new("Agent was registered.");
            return Ok(response);
        }

        return BadRequest(new TextResponse("Agent could not be registered."));
    }

    // GET Methods
    // GET all
    [HttpGet]
    public async Task<IActionResult> GetAllAgents()
    {
        var result = await _agentService.GetAllAgentsAsync();
        return Ok(result);
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

        return BadRequest(new TextResponse("Could not update Agent Information"));
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
    
//     [HttpPost("~/api/Token")]
//     [ProducesResponseType(typeof(IEnumerable<TokenRequest>), 200)]
//     public async Task<IActionResult> GetToken([FromBody] TokenRequest request)
//     {
//         if (!ModelState.IsValid)
//             return BadRequest(ModelState);
        
//         TokenResponse? response = await _tokenService.GetTokenAsync(request);

//         if (response is null)
//             return BadRequest(new TextResponse("Invalid username or password."));
        
//         return Ok(response);
//     }
}
