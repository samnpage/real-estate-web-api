using Microsoft.AspNetCore.Mvc;
using RealEstate.Models.HomeStyle;
using RealEstate.Models.Responses;
using RealEstate.Services.HomeStyle;



namespace RealEstate.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class HomeStyleController : ControllerBase
{
    private readonly IHomeStyleService _HomeStyleService;

    public HomeStyleController(IHomeStyleService HomeStyleService)
    {
        _HomeStyleService = HomeStyleService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateHomeStyle([FromBody] CreateHomeStyle request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var registerResult = await _HomeStyleService.CreateHomeStyleAsync(request);
        if (registerResult)
        {
            TextResponse response = new("HomeStyle was added successfully.");
            return Ok(response);
        }

        return BadRequest(new TextResponse("HomeStyle already exists in the database."));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllHomeStyles()
    {
        var result = await _HomeStyleService.GetAllHomeStylesAsync();

        if (result != null && result.Any())
            return Ok(result);

        return BadRequest(new TextResponse("There are no HomeStyles in the database."));
    }


    [HttpGet("{HomeStyleId:int}")]
    public async Task<IActionResult> GetHomeStyleById([FromRoute] int HomeStyleId)
    {
        HomeStyleDetail? detail = await _HomeStyleService.GetHomeStyleByIdAsync(HomeStyleId);

        return detail is not null
                ? Ok(detail)
                : NotFound();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateHomeStyleById([FromRoute] int id, [FromBody] CreateHomeStyle request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _HomeStyleService.UpdateHomeStyleByIdAsync(id, request);

        if (response is not null)
            return Ok(response);

        return BadRequest(response);
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteHomeStyleById([FromRoute] int id)
    {
        TextResponse response = await _HomeStyleService.DeleteHomeStyleByIdAsync(id);

        return response is not null
                ? Ok(response)
                : NotFound();
    }
}