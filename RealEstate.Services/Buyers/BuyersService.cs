using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Buyers;

namespace RealEstate.Services.Buyers;
public class BuyersService : IBuyersService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly int _agentId;

    public BuyersService(UserManager<AgentsEntity> userManager, 
                        SignInManager<AgentsEntity> signInManager, 
                        ApplicationDbContext dbContext)
    {
        var currentAgent = signInManager.Context.User;
        var agentIdClaim = userManager.GetUserId(currentAgent);
        var hasValidId = int.TryParse(agentIdClaim, out _agentId);

        if (hasValidId == false)
            throw new Exception("Attempted to build BuyersService without Id claim.");
        _dbContext = dbContext;
    }

    // Creates new buyer contact
    public async Task<bool> CreateBuyerContactAsync(CreateBuyers model)
    {
        BuyersEntity entity = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Phone = model.Phone,
            PrefSqFt = model.PrefSqFt
        };
    }
}