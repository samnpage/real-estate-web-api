using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.ListingsModels;

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

        public async Task CreateListingAsync(ListingEntity listing)
        {
            _dbContext.Listings.Add(listing);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateListingAsync(int id, ListingEntity updatedListing)
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
                existingListing.FeedBack = updatedListing.FeedBack;
                existingListing.HomeStyle = updatedListing.HomeStyle;

                await _dbContext.SaveChangesAsync();
            }
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

        public Task CreateListingAsync(HomeListings listing)
        {
            throw new NotImplementedException();
        }
    }
}
