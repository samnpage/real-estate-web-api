using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Buyers;

namespace RealEstate.Services.Buyers;
public class BuyersService : IBuyersService
{
    private readonly ApplicationDbContext _context;

    public BuyersService(ApplicationDbContext context)
    {
        _context = context;
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