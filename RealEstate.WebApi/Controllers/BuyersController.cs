using Microsoft.AspNetCore.Mvc;
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
}