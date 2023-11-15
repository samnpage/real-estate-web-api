using RealEstate.Models.Agents;
using RealEstate.Models.Responses;
using RealEstate.Services.Agents;
using Microsoft.AspNetCore.Mvc;
using ElevenNote.Models.Agents;
using RealEstate.Data.Entities;

namespace ElevenNote.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgentsController : ControllerBase
{
    // Fields that access our services
    private readonly IAgentsService _agentsService;

    // Constructor
    public AgentsController(IAgentsService agentsService)
    {
        _agentsService = agentsService;
    }

    // POST Method
    [HttpPost("Register")]
    [ProducesResponseType(typeof(IEnumerable<AgentsRegister>), 200)]
    public async Task<IActionResult> RegisterAgent([FromBody] AgentsRegister model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var registerResult = await _agentsService.RegisterAgentsAsync(model);
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
    public async Task<IActionResult> GetAllTransactionsAsync()
    {
        var result = await _agentsService.GetAllAgentsAsync();
        return Ok(result);
    }
    
    // GET by Id
    [HttpGet("{agentId:int}")]
    public async Task<IActionResult> GetById([FromRoute] int agentId)
    {
        AgentsDetail? detail = await _agentsService.GetAgentByIdAsync(agentId);

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

        var response = await _agentsService.UpdateAgentByIdAsync(id, request);

        if (response is not null)
            return Ok(response);

        return BadRequest(new TextResponse("Could not update Agent Information"));
    }

    // DELETE Method
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBuyerById([FromRoute] int id)
    {
        TextResponse response = await _agentsService.DeleteAgentByIdAsync(id);

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
