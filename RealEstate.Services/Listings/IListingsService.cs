using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Data.Entities;


namespace RealEstate.Services
{
    public interface IListingsService
    {
        Task<IEnumerable<Listings>> GetAllListingsAsync();
        Task<Listings> GetListingByIdAsync(int id);
        Task CreateListingAsync(Listings listing);
        Task UpdateListingAsync(int id, Listings updatedListing);
        Task DeleteListingAsync(int id);
    }
}
