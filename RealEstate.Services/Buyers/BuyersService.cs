using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Buyers;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Buyers;
public class BuyersService : IBuyersService
{
    private readonly ApplicationDbContext _dbContext;

    public BuyersService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // CREATE Method that creates new buyer contact
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

    // Read Method that allows agent to view all buyers
    public async Task<List<BuyersEntity>> GetAllBuyersAsync()
    {
        var buyers = await _dbContext.Buyers.ToListAsync();
        return buyers;
    }

    // READ Method that allows agent to view buyer information by Id
    public async Task<BuyersEntity?> GetBuyerByIdAsync(int id)
        {
            return await _dbContext.Buyers.FirstOrDefaultAsync(l => l.Id == id);
        }

    // UPDATE Method. Updates the buyer information by Id.
    public async Task<BuyersEntity?> UpdateBuyerByIdAsync(int id, BuyersEntity updatedBuyer)
        {
            var existingBuyer = await _dbContext.Buyers.FirstOrDefaultAsync(e => e.Id == id);

            if (existingBuyer != null)
            {   
                existingBuyer.FirstName = updatedBuyer.FirstName;
                existingBuyer.LastName = updatedBuyer.LastName;
                existingBuyer.Email = updatedBuyer.Email;
                existingBuyer.Phone = updatedBuyer.Phone;
                existingBuyer.PrefSqFt = updatedBuyer.PrefSqFt;

                await _dbContext.SaveChangesAsync();
            }

            return existingBuyer;
        }
    // DELETE Method

    public async Task<TextResponse> DeleteBuyerByIdAsync(int id)
        {
            var buyerToDelete = await _dbContext.Buyers.FirstOrDefaultAsync(e => e.Id == id);

            if (buyerToDelete != null)
            {
                _dbContext.Buyers.Remove(buyerToDelete);
                await _dbContext.SaveChangesAsync();
            }

            TextResponse response = new ("Buyer deleted successfully.");

            return response;
        }
}