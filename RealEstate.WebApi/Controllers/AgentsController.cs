using RealEstate.Models.Agents;
using RealEstate.Models.Responses;
using RealEstate.Services.Agents;
using Microsoft.AspNetCore.Mvc;
using ElevenNote.Models.Agents;

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
