using RealEstate.Data.Entities;
using RealEstate.Models.Listing;
using RealEstate.Models.Responses;

namespace RealEstate.Services
{
    public interface IListingService
    {
        Task<IEnumerable<ListingEntity>> GetAllListingsAsync();
        Task<ListingEntity> GetListingByIdAsync(int id);
        Task<TextResponse> UpdateListingAsync(int id, UpdateListing updatedListing);
        Task DeleteListingAsync(int id);
        Task<TextResponse> CreateListingAsync(CreateListing createListing);

    }
}
