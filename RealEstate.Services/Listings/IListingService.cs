using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Data.Entities;
using RealEstate.Models.ListingsModels;


namespace RealEstate.Services
{
    public interface IListingService
    {
        Task<IEnumerable<ListingEntity>> GetAllListingsAsync();
        Task<ListingEntity> GetListingByIdAsync(int id);
        Task CreateListingAsync(ListingEntity listing);
        Task UpdateListingAsync(int id, ListingEntity updatedListing);
        Task DeleteListingAsync(int id);
        Task CreateListingAsync(HomeListings listing);
    }
}
