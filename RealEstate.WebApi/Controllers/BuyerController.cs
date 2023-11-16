using Microsoft.AspNetCore.Mvc;
using RealEstate.Data.Entities;
using RealEstate.Models.Buyer;
using RealEstate.Models.Responses;
using RealEstate.Services.Buyer;

namespace RealEstate.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BuyerController : ControllerBase
{
    private readonly IBuyerService _buyerService;

    public BuyerController(IBuyerService buyerService)
    {
        _buyerService = buyerService;
    }

    // POST Method
    [HttpPost]
    public async Task<IActionResult> CreateBuyer([FromBody] CreateBuyer request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var registerResult = await _buyerService.CreateBuyerContactAsync(request);
        if (registerResult)
        {
            TextResponse response = new("Buyer was added successfully.");
            return Ok(response);
        }

        return BadRequest(new TextResponse("Buyer already exists in the database."));
    }

    // GET ALL Method
    [HttpGet]
    public async Task<IActionResult> GetAllBuyers()
    {
        var result = await _buyerService.GetAllBuyersAsync();

        if (result != null && result.Any())
            return Ok(result);

        return BadRequest(new TextResponse("There are no buyers in the database."));
    }

    // GET BY Id Method
    [HttpGet("{buyerId:int}")]
    public async Task<IActionResult> GetBuyerById([FromRoute] int buyerId)
    {
        BuyerEntity? entity = await _buyerService.GetBuyerByIdAsync(buyerId);

        return entity is not null
                ? Ok(entity)
                : NotFound();
    }

    // UPDATE Method
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBuyerById([FromRoute] int id, [FromBody] UpdateBuyer request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _buyerService.UpdateBuyerByIdAsync(id, request);

        if (response is not null)
            return Ok(response);

        return BadRequest(response);
    }

    // DELETE Method
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBuyerById([FromRoute] int id)
    {
        TextResponse response = await _buyerService.DeleteBuyerByIdAsync(id);

        return response is not null
                ? Ok(response)
                : NotFound();
    }
}