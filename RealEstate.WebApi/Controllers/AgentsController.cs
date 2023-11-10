using RealEstate.Models.Agents;
using RealEstate.Models.Responses;
using RealEstate.Services.Agents;
using Microsoft.AspNetCore.Mvc;
using ElevenNote.Models.Agents;

namespace ElevenNote.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    // Fields that access our services
    private readonly IAgentsService _userService;

    // Constructor
    public UserController(IAgentsService userService)
    {
        _userService = userService;
    }

    [HttpPost("Register")]
    [ProducesResponseType(typeof(IEnumerable<AgentsRegister>), 200)]
    public async Task<IActionResult> RegisterUser([FromBody] AgentsRegister model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var registerResult = await _userService.RegisterAgentsAsync(model);
        if (registerResult)
        {
            TextResponse response = new("User was registered.");
            return Ok(response);
        }

        return BadRequest(new TextResponse("User could not be registered."));
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetById([FromRoute] int userId)
    {
        AgentsDetail? detail = await _userService.GetAgentByIdAsync(userId);

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
