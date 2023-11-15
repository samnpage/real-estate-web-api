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

    // POST
    [HttpPost]
    public async Task<IActionResult> CreateBuyer([FromForm] CreateBuyer request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _buyerService.CreateBuyerContactAsync(request);
        if (response is not null)
            return Ok(response);

        return BadRequest(new TextResponse("Could not create new buyer"));
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAllBuyers()
    {
        var result = await _buyerService.GetAllBuyersAsync();
        return Ok(result);
    }

    // GET BY ID
    [HttpGet("{buyerId:int}")]
    public async Task<IActionResult> GetBuyerById([FromRoute] int buyerId)
    {
        BuyerEntity? entity = await _buyerService.GetBuyerByIdAsync(buyerId);

        return entity is not null
                ? Ok(entity)
                : NotFound();
    }

    // UPDATE
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBuyerById([FromRoute] int id, [FromForm] BuyerEntity request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _buyerService.UpdateBuyerByIdAsync(id, request);

        if (response is not null)
            return Ok(response);

        return BadRequest(new TextResponse("Could not update buyer"));
    }

    // DELETE
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBuyerById([FromRoute] int id)
    {
        TextResponse response = await _buyerService.DeleteBuyerByIdAsync(id);

        return response is not null
                ? Ok(response)
                : NotFound();
    }
}