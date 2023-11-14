using Microsoft.AspNetCore.Mvc;
using RealEstate.Data.Entities;
using RealEstate.Models.Buyers;
using RealEstate.Models.Responses;
using RealEstate.Services.Buyers;

namespace RealEstate.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BuyersController : ControllerBase
{
    private readonly IBuyersService _buyersService;

    public BuyersController(IBuyersService buyersService)
    {
        _buyersService = buyersService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBuyer([FromForm] CreateBuyers request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _buyersService.CreateBuyerContactAsync(request);
        if (response is not null)
            return Ok(response);

        return BadRequest(new TextResponse("Could not create new buyer"));
    }

    [HttpGet("{buyerId:int}")]
    public async Task<IActionResult> GetBuyerById([FromRoute] int buyerId)
    {
        BuyersEntity? entity = await _buyersService.GetBuyerByIdAsync(buyerId);

        return entity is not null
                ? Ok(entity)
                : NotFound();
    }
}