using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Listing;
using RealEstate.Models.Responses;

namespace RealEstate.Services
{
    public class ListingService : IListingService
    {
        private readonly ApplicationDbContext _dbContext;

        public ListingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ListingEntity>> GetAllListingsAsync()
        {
            return await _dbContext.Listings.ToListAsync();
        }

        public async Task<ListingEntity> GetListingByIdAsync(int id)
        {
            return await _dbContext.Listings.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<TextResponse> CreateListingAsync(CreateListing createListing)
        {

            ListingEntity entity = new()
            {
                Address1 = createListing.Address1,
                Address2 = createListing.Address2,
                City = createListing.City,
                State = createListing.State,
                ZipCode = createListing.ZipCode,
                SquareFootage = createListing.SquareFootage,
                Price = createListing.Price,
                HomeStyleId = createListing.HomeStyleId,

            };

            _dbContext.Listings.Add(entity);
            await _dbContext.SaveChangesAsync();
            return new TextResponse("Listing Created");
        }

        public async Task<TextResponse> UpdateListingAsync(int id, UpdateListing updatedListing)
        {
            var existingListing = await _dbContext.Listings.FirstOrDefaultAsync(l => l.Id == id);

            if (existingListing != null)
            {
                existingListing.Address1 = updatedListing.Address1;
                existingListing.Address2 = updatedListing.Address2;
                existingListing.City = updatedListing.City;
                existingListing.State = updatedListing.State;
                existingListing.ZipCode = updatedListing.ZipCode;
                existingListing.SquareFootage = updatedListing.SquareFootage;
                existingListing.Price = updatedListing.Price;

                await _dbContext.SaveChangesAsync();
            }

            return new TextResponse("Update Successful");
        }

        public async Task DeleteListingAsync(int id)
        {
            var listingToDelete = await _dbContext.Listings.FirstOrDefaultAsync(l => l.Id == id);

            if (listingToDelete != null)
            {
                _dbContext.Listings.Remove(listingToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}