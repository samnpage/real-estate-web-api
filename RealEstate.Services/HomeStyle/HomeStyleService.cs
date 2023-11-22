using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models.Responses;
using RealEstate.Data.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using RealEstate.Models.HomeStyle;

namespace RealEstate.Services.HomeStyle;
public class HomeStyleService : IHomeStyleService
{
    private readonly ApplicationDbContext _dbContext;

    public HomeStyleService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // CREATE Method
    public async Task<bool> CreateHomeStyleAsync(CreateHomeStyle model)
    {
        HomeStyleEntity entity = new()
        {
            Name = model.Name,
        };

        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    // READ ALL Method
    public async Task<List<HomeStyleEntity>> GetAllHomeStylesAsync()
    {
        return await _dbContext.HomeStyles.ToListAsync();
    }

    // READ By Id Method
    public async Task<HomeStyleDetail?> GetHomeStyleByIdAsync(int id)
    {
        HomeStyleEntity? entity = await _dbContext.HomeStyles.FindAsync(id);
        if (entity is null)
            return null;

        HomeStyleDetail detail = new()
        {
            Id = entity.Id,
            Name = entity.Name,
        };

        return detail;
    }

    // UPDATE Method
    public async Task<TextResponse> UpdateHomeStyleByIdAsync(int id, CreateHomeStyle updatedHomeStyle)
    {
        var currentHomeStyle = await _dbContext.HomeStyles.FirstOrDefaultAsync(e => e.Id == id);

        if (currentHomeStyle != null)
        {
            bool hasChanges = false;

            if (currentHomeStyle.Name != updatedHomeStyle.Name)
            {
                currentHomeStyle.Name = updatedHomeStyle.Name;
                hasChanges = true;
            }

            if (hasChanges)
            {
                await _dbContext.SaveChangesAsync();
                return new TextResponse("Home Style was updated successfully");
            }
            else
            {
                return new TextResponse("Update was unsuccessful. No changes were made.");
            }
        }

        return new TextResponse("Update was unsuccessful. Home Style was not found.");
    }

    // DELETE Method
    public async Task<TextResponse> DeleteHomeStyleByIdAsync(int id)
    {
        var HomeStyleToDelete = await _dbContext.HomeStyles.FirstOrDefaultAsync(e => e.Id == id);

        if (HomeStyleToDelete != null)
        {
            _dbContext.HomeStyles.Remove(HomeStyleToDelete);
            await _dbContext.SaveChangesAsync();
        }

        TextResponse response = new("HomeStyle removed successfully.");

        return response;
    }
}