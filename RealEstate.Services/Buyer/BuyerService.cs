using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Buyer;
using RealEstate.Models.Responses;

namespace RealEstate.Services.Buyer;

public class BuyerService : IBuyerService
{
    private readonly ApplicationDbContext _dbContext;

    public BuyerService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // CREATE Method
    public async Task<bool> CreateBuyerContactAsync(CreateBuyer model)
    {
        if (await CheckEmailAvailability(model.Email) == false)
        {
            Console.WriteLine("Invalid email, already in use");
            return false;
        }

        BuyerEntity entity = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Phone = model.Phone,
            PrefSqFt = model.PrefSqFt,
            DateCreated = DateTime.Now
        };

        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    // READ ALL Method
    public async Task<List<BuyerEntity>> GetAllBuyersAsync()
    {
        return await _dbContext.Buyers.ToListAsync();
    }

    // READ By Id Method
    public async Task<BuyerDetail?> GetBuyerByIdAsync(int id)
    {
        BuyerEntity? entity = await _dbContext.Buyers.FindAsync(id);
        if (entity is null)
            return null;

        BuyerDetail detail = new()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone,
            PrefSqFt = entity.PrefSqFt,
            DateCreated = entity.DateCreated
        };

        return detail;
    }

    // UPDATE Method
    public async Task<TextResponse> UpdateBuyerByIdAsync(int id, UpdateBuyer updatedBuyer)
    {
        var currentBuyer = await _dbContext.Buyers.FirstOrDefaultAsync(e => e.Id == id);

        if (currentBuyer != null)
        {
            bool hasChanges = false;

            if (currentBuyer.FirstName != updatedBuyer.FirstName)
            {
                currentBuyer.FirstName = updatedBuyer.FirstName;
                hasChanges = true;
            }

            if (currentBuyer.LastName != updatedBuyer.LastName)
            {
                currentBuyer.LastName = updatedBuyer.LastName;
                hasChanges = true;
            }

            if (currentBuyer.Email != updatedBuyer.Email)
            {
                currentBuyer.Email = updatedBuyer.Email;
                hasChanges = true;
            }

            if (currentBuyer.Phone != updatedBuyer.Phone)
            {
                currentBuyer.PrefSqFt = updatedBuyer.PrefSqFt;
                hasChanges = true;
            }

            if (hasChanges)
            {
                await _dbContext.SaveChangesAsync();
                return new TextResponse("Buyer updated successfully");
            }
            else
            {
                return new TextResponse("Update was unsuccessful. No changes were detected to the buyer information.");
            }
        }

        return new TextResponse("Update was unsuccessful. Buyer was not found in the database.");
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

        TextResponse response = new("Buyer deleted successfully.");

        return response;
    }

    // HELPER METHODS
    // Checks whether the user's email is unique
    private async Task<bool> CheckEmailAvailability(string email)
    {
        BuyerEntity? existingBuyer = await _dbContext.Buyers.FirstOrDefaultAsync(b => b.Email == email);
        return existingBuyer is null;
    }
}