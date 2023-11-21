using Microsoft.AspNetCore.Mvc;
using RealEstate.Models.Transaction;
using RealEstate.Models.Responses;
using RealEstate.Services.Transaction; //! Why not this? 
using System.Transactions;
using RealEstate.Services.Buyer; //! What? lol

namespace RealEstate.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTranscation([FromBody] CreateTransaction request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var registerResult = await _transactionService.CreateTransactionAsync(request);
        if (registerResult)
        {
            TextResponse response = new("Transaction was added successfully.");
            return Ok(response);
        }

        return BadRequest(new TextResponse("Transaction already exists in the database."));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        var result = await _transactionService.GetAllTransactionsAsync();

        if (result != null && result.Any())
            return Ok(result);

        return BadRequest(new TextResponse("There are no transactions in the database."));
    }


    [HttpGet("{transactionId:int}")]
    public async Task<IActionResult> GetTransactionById([FromRoute] int transactionId)
    {
        TransactionDetail? detail = await _transactionService.GetTransactionByIdAsync(transactionId);

        return detail is not null
                ? Ok(detail)
                : NotFound();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTransactionById([FromRoute] int id, [FromBody] CreateTransaction request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _transactionService.UpdateTransactionByIdAsync(id, request);

        if (response is not null)
            return Ok(response);

        return BadRequest(response);
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTransactionById([FromRoute] int id)
    {
        TextResponse response = await _transactionService.DeleteTransactionByIdAsync(id);

        return response is not null
                ? Ok(response)
                : NotFound();
    }
}