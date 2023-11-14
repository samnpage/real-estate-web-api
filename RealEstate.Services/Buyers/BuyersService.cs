using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Buyers;

namespace RealEstate.Services.Buyers;
public class BuyersService : IBuyersService
{
    private readonly ApplicationDbContext _dbContext;

    public BuyersService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Method that creates new buyer contact
    public async Task<ListBuyers?> CreateBuyerContactAsync(CreateBuyers model)
    {
        BuyersEntity entity = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Phone = model.Phone,
            PrefSqFt = model.PrefSqFt,
            DateCreated = DateTime.Now
        };

        _dbContext.Add(entity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();

        if (numberOfChanges != 1)
        {
            return null;
        }

        ListBuyers response = new()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone,
            PrefSqFt = entity.PrefSqFt,
            DateCreated = DateTime.Now
        };

        return response;
    }

    // Method that allows agent to view buyer information by Id
    public async Task<BuyersEntity?> GetBuyerByIdAsync(int id)
        {
            return await _dbContext.Buyers.FirstOrDefaultAsync(l => l.Id == id);
        }

    // async Task<BuyerDetail> ViewBuyerByIdAsync(int Id)
    // {
    //     BuyersEntity entity = await _dbContext.Buyers.FirstOrDefaultAsync(e => e.Id == Id);
    //     return entity;
    // }
}